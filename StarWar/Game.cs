using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
//Рязанцев Дмитрий

//1.звуки 2. размер формы меньше чем размер игры 3. как удалить улетевшие за экран пули 4. MessageDie?.Invoke(); 5. нажатие двух клавишь сразу  6. foreach (Objects aster in asters)

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
        static public Objects[] stars;
        static public System.Windows.Forms.Timer timer;
        static Image background;
        static List<Bullets> bulls;        
        static Asteroids[] asters;
        static Lives[] lives;
        static Ship ship;
        static int counter;
        


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

            form.KeyDown += Form_KeyDown;
            Ship.ShipDie += Finish;
            Asteroids.AsterDie += AsterMessage;
        }

        private static void AsterMessage()
        {
            Console.WriteLine("Астероид сбит " + counter);
            counter++;
        }

        public static void Finish()
        {
            buffer.Graphics.DrawString("Energy:" + ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            timer.Stop();
            buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            buffer.Render();
            Console.WriteLine("Карабль уничтожен ");
           
        }
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                bulls.Add(new Bullets(new Point(ship.Rect.X + Ship.Image.Width, ship.Rect.Y + Ship.Image.Height / 2), new Point(10, 0), new Size(4, 1)));
                Console.WriteLine(bulls.Count);
            }
            if (e.KeyCode == Keys.Up) 
                ship.Up();
            if (e.KeyCode == Keys.Down) 
                ship.Down();

        }

        static public void Load()
        {            
            var rand = new Random();
           
            Game.background = Image.FromFile("Images\\back900.jpg");

            stars = new Objects[200];                                 
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

            asters = new Asteroids[5];
            Asteroids.Image = Image.FromFile("Images\\aster100.png");
            for (int i = 0; i < asters.Length; i++)
                asters[i] = new Asteroids(new Point(Game.Width+100, rand.Next(Game.Height-100)), new Point(1+i, 0), new Size(Asteroids.Image.Width, Asteroids.Image.Height));

            lives = new Lives[2];
            Lives.Image = Image.FromFile("Images\\2_72-64x64.png");
            for (int i = 0; i < lives.Length; i++)
                lives[i] = new Lives(new Point(Game.Width + 100, rand.Next(Game.Height - 100)), new Point(10 + i, 0), new Size(Lives.Image.Width, Lives.Image.Height));

            Ship.Image = Image.FromFile("Images\\StarShip.png");
            ship = new Ship(new Point(0, Game.Height / 2), new Point(0, 10), new Size(Ship.Image.Width, Ship.Image.Height));
            bulls = new List<Bullets>() { new Bullets(new Point(-500, 0), new Point(0, 0), new Size(0, 0)) };
            
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }  

        static public void Draw()
        {            
            buffer.Graphics.DrawImage(background, new Point(0,0));
                    
            foreach (Objects star in stars)
                star.Draw();
            foreach (Objects bull in bulls)
                bull.Draw(); 
            foreach (Objects aster in asters)
                aster.Draw();
            foreach (Objects live in lives)
                live.Draw();
            ship.Draw();

            buffer.Graphics.DrawString("Energy:" + ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            buffer.Graphics.DrawString("Count:" + counter, SystemFonts.DefaultFont, Brushes.White, 100, 0);

            buffer.Render();

        }

        static public void Update()
        {
            
            var rand = new Random();            
            foreach (Objects star in stars) 
                star.Update();                        
            foreach (Objects aster in asters)
                aster.Update();
            foreach (Objects bull in bulls)
                bull.Update();
            foreach (Objects live in lives)
                live.Update();

            for (int i = 0; i < lives.Length; i++)
                if (lives[i].Collision(ship))
                {
                    //Console.WriteLine("Столкновение с астеройдом");
                    System.Media.SystemSounds.Asterisk.Play();

                    
                    ship.Energy += lives[i].Energy;
                    lives[i] = new Lives(new Point(Game.Width + 100, rand.Next(Game.Height - 100)), new Point(i + 10, 0), new Size(Lives.Image.Width, Lives.Image.Height));

                   
                }




            for (int i = 0; i < asters.Length; i++)
            {
                for (int j = 0; j < bulls.Count; j++)
                {
                    if (asters[i].Collision(bulls[j]))
                    {
                        //Console.WriteLine("Попадание в астеройд");
                        System.Media.SystemSounds.Beep.Play();

                        //if (asters[i].Speed >= bulls[j].Speed)
                        //    throw new ArgumentOutOfRangeException("Скорость астеройда больше чем скорость пули");
                        int e = asters[i].Energy;
                        asters[i].Energy -= bulls[j].Energy;
                        bulls[j].Energy -= e;

                        if (asters[i].Energy <= 0)
                        {
                            asters[i] = new Asteroids(new Point(Game.Width + 100, rand.Next(Game.Height - 100)), new Point(i + 1, 0), new Size(Asteroids.Image.Width, Asteroids.Image.Height));
                            asters[i].Die();
                        }
                        if (bulls[j].Energy <= 0)
                            bulls.Remove(bulls[j]);
                    }
                }

                if (asters[i].Collision(ship))
                {
                    //Console.WriteLine("Столкновение с астеройдом");
                    System.Media.SystemSounds.Asterisk.Play();

                    int e = asters[i].Energy;
                    asters[i].Energy -= ship.Energy;
                    ship.Energy -= e;

                    if (asters[i].Energy <= 0)
                    {
                        asters[i] = new Asteroids(new Point(Game.Width + 100, rand.Next(Game.Height - 100)), new Point(i + 1, 0), new Size(Asteroids.Image.Width, Asteroids.Image.Height));
                        asters[i].Die();
                    }
                    if (ship.Energy <= 0)
                        ship.Die();
                }


            }

        }
    }

}
