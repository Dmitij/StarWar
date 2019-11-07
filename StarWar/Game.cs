using System;
using System.Windows.Forms;
using System.Drawing;

namespace Asteroids
{
    static class Game
    {
        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;
        // Свойства
        // Ширина и высота игрового поля
        static public int Width { get; set; }
        static public int Height { get; set; }
        static public BaseFigure[] fig;
        static public Stars[] stars;
        static public System.Windows.Forms.Timer timer;

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
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        static public void Load()
        {
            //fig = new BaseFigure[1];
            ////for (int i = 0; i < objs.Length; i++)
            //    fig[0] = new BaseFigure(new Point(Width/2, Height/2), new Point(15, 0 ), new Size(100, 100));
            var rand = new Random();

            //int wi = -100, Game.Width + 100;

            stars = new Stars[200];
            Stars100.Image = Image.FromFile("Images\\star100.png");
            for (int i = 0; i < 1; i++)
                stars[i] = new Stars100(new Point(rand.Next(-100, Game.Width + 100), rand.Next(Game.Height)), new Point(15, 0));

            Stars50.Image = Image.FromFile("Images\\star50.png");
            for (int i = 1; i < 10; i++)
            stars[i] = new Stars50(new Point(rand.Next(-100, Game.Width + 100), rand.Next(Game.Height)), new Point(4, 0));

            Stars25.Image = Image.FromFile("Images\\star25.png");
            for (int i = 10; i < 30; i++)
            stars[i] = new Stars25(new Point(rand.Next(-100, Game.Width + 100), rand.Next(Game.Height)), new Point(2, 0));

            Stars10.Image = Image.FromFile("Images\\star10.png");
            for (int i = 30; i < stars.Length; i++)
            stars[i] = new Stars10(new Point(rand.Next(-100, Game.Width + 100), rand.Next(Game.Height)), new Point(1, 0));


            //Star2.Image = Image.FromFile("Images\\star3100100.png");
            ////for (int i = 0 ; i < objs.Length; i++)
            //objs[2] = new Star2(new Point(Width / 2, Height / 2), new Point(15, 0), new Size(10, 10));

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
            buffer.Graphics.Clear(Color.Empty);            
            //foreach (BaseFigure obj in fig)
            //    obj.Draw();
            foreach (Stars obj in stars)
                obj.Draw();
            buffer.Render();
        }

        static public void Update()
        {
            //foreach (BaseFigure obj in fig) obj.Update();
            foreach (Stars obj in stars) obj.Update();
        }
    }

}
