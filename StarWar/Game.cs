using System;
using System.Windows.Forms;
using System.Drawing;
//Рязанцев Дмитрий
namespace StarWar
{

    static class Game
    {
        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;
        // Свойства

            
        // Ширина и высота игрового поля
        static public int Width { get; set; }
        static public int Height { get; set; }


        //static public Figure[] figures;
        static public Pictures[] stars;
        static public System.Windows.Forms.Timer timer;
        static Image background;
        static public Bullet bull;
        static public Asteroid[] asters;

        static Game()
        {
        }

        
        static public void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // предоставляет доступ к главному буферу графического контекста для текущего приложения
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();// Создаём объект - поверхность рисования и связываем его с формой
                                      // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            // Связываем буфер в памяти с графическим объектом.
            // для того, чтобы рисовать в буфере
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            timer.Start();

           



          
        }



        static public void Load()
        {
            //fig = new BaseFigure[1];
            ////for (int i = 0; i < objs.Length; i++)
            //    fig[0] = new BaseFigure(new Point(Width/2, Height/2), new Point(15, 0 ), new Size(100, 100));
            var rand = new Random();
           
            Game.background = Image.FromFile("Images\\back900.jpg");

            stars = new Pictures[200];                                 //массив типа картинка
            Stars10.Image = Image.FromFile("Images\\star10.png");
            for (int i = 0; i < 169; i++)
                stars[i] = new Stars10(new Point(rand.Next(-100, Game.Width), rand.Next(Game.Height)), new Point(1, 0), new Size(Stars10.Image.Width, Stars10.Image.Height));

            Stars25.Image = Image.FromFile("Images\\star25.png");
            for (int i = 169; i < 189; i++)
                stars[i] = new Stars25(new Point(rand.Next(-100, Game.Width), rand.Next(Game.Height)), new Point(2, 0), new Size(Stars25.Image.Width, Stars25.Image.Height));

            Stars50.Image = Image.FromFile("Images\\star50.png");
            for (int i = 189; i < 199; i++)
                stars[i] = new Stars50(new Point(rand.Next(-100, Game.Width), rand.Next(Game.Height)), new Point(4, 0), new Size(Stars50.Image.Width, Stars50.Image.Height));

            Stars100.Image = Image.FromFile("Images\\star100.png");
            for (int i = 199; i < stars.Length; i++)
                stars[i] = new Stars100(new Point(rand.Next(-100, Game.Width), rand.Next(Game.Height)), new Point(8, 0), new Size(Stars100.Image.Width, Stars100.Image.Height));

           

            bull = new Bullet(new Point(0, Game.Height / 2),new Point(10, 0), new Size(100, 100));

            asters = new Asteroid[5];
            Asteroid.Image = Image.FromFile("Images\\aster100.png");
            for (int i = 0; i < asters.Length; i++)
                asters[i] = new Asteroid(new Point(Game.Width, Game.Height / 2), new Point(1+i, 0), new Size(Asteroid.Image.Width, Asteroid.Image.Height));

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }  

        static public void Draw()
        {
            // Проверяем вывод графики     

            //buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //buffer.Graphics.Clear(Color.Empty);
            buffer.Graphics.DrawImage(background, new Point(0,0));
            //foreach (BaseFigure obj in fig)
            //    obj.Draw();
            foreach (Pictures star in stars)
                star.Draw();
            bull.Draw();
            foreach (Asteroid aster in asters)
                aster.Draw();
            buffer.Render();
        }

        static public void Update()
        {
            var rand = new Random();
            //foreach (BaseFigure obj in fig) obj.Update();
            foreach (Pictures star in stars) 
                star.Update();
            bull.Update();
            foreach (Asteroid aster in asters)
                aster.Update();

            int asperspeed, bullspeed=10;
            for (int i = 0; i < asters.Length; i++)
            {
                if (asters[i].Collision(bull))
                {
                    Console.WriteLine("aaaa");
                    //WMP.URL = @"Sounds/Power Blade – Уровень 5_ Музыка из игры Dendy скачать.mp3";
                    //WMP.controls.play();

                    asperspeed = 1 + i;
                    if (asperspeed >= bullspeed)
                        throw new ArgumentOutOfRangeException("Скорость астеройда больше чем скорость пули");

                    asters[i] = new Asteroid(new Point(Game.Width, rand.Next(Game.Height-100)), new Point(asperspeed, 0), new Size(Asteroid.Image.Width, Asteroid.Image.Height));
                    bull = new Bullet(new Point(0, rand.Next(Game.Height-100)), new Point(bullspeed, 0), new Size(100, 100));
                }
            }
        }
    }

}
