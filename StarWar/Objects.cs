using System;
using System.Collections.Generic;
using System.Drawing;
//Рязанцев Дмитрий

namespace StarWar
{
    abstract class Objects : ICollision
    {
        protected Point pos;
        protected Point dir;
        protected Size size;
        
        public Objects(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }

        public abstract void Draw();    
        public abstract void Update();        

        public Rectangle Rect => new Rectangle(pos, size);
        public bool Collision(ICollision collision)
        {
            return (collision.Rect.IntersectsWith(this.Rect));
        }
        public delegate void Message();
        public delegate void Log();
    }       

    class Stars100 : Objects
    {          
        public static Image Image { get; set; }
        public Stars100(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
           
        }
        public override void Update()
        {
            var rand = new Random();
            pos.X = pos.X - dir.X;
            if (pos.X < -100)
            {
                pos.X = Game.Width;
                pos.Y = rand.Next(Game.Height);
            }
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(Image, pos);
        }
    }
    class Stars50 : Objects
    {        
        public static Image Image { get; set; }
        public Stars50(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        public override void Update()
        {
            var rand = new Random();
            pos.X = pos.X - dir.X;
            if (pos.X < -100)
            {
                pos.X = Game.Width;
                pos.Y = rand.Next(Game.Height);
            }
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(Image, pos);
        }
    }
    class Stars25 : Objects
    {        
        public static Image Image { get; set; }
        public Stars25(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        public override void Update()
        {
            var rand = new Random();
            pos.X = pos.X - dir.X;
            if (pos.X < -100)
            {
                pos.X = Game.Width;
                pos.Y = rand.Next(Game.Height);
            }
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(Image, pos);
        }
    }
    class Stars10 : Objects
    {
        public static Image Image { get; set; }
        public Stars10(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        public override void Update()
        {
            var rand = new Random();
            pos.X = pos.X - dir.X;
            if (pos.X < -100)
            {
                pos.X = Game.Width;
                pos.Y = rand.Next(Game.Height);
            }
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(Image, pos);
        }
    }

    
    interface ICollision
    {
        bool Collision(ICollision collision);
        Rectangle Rect { get; }
    }

    class Bullets : Objects
    {
        public int Energy { get; set; }
        public int Speed { get; set; }
        public Bullets(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Energy = 49;
            Speed = dir.X;
            this.pos = pos;
        }
                

        public override void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;
            if ((pos.X > Game.Width) && (pos.X < 0) && (pos.Y < 0) && (pos.Y > Game.Height))
            {
                pos.X = -500;
                pos.Y = -500;
            }
        }
        
        public override void Draw()
        {
            Game.buffer.Graphics.DrawEllipse(Pens.White, pos.X, pos.Y, size.Width, size.Height);
        }
        public void Die()
        {
        }
    }
       
    
    class Asteroids : Objects
    {
        public int Energy { get; set; }
        public int Speed { get; set; }

        public static Image Image { get; set; }
        public Asteroids(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Energy = 100;
            Speed = -dir.X;
        }
        public override void Update()
        {
            var rand = new Random();
            pos.X = pos.X - dir.X;
            if (pos.X < -100)
            {
                pos.X = Game.Width;
                pos.Y = rand.Next(Game.Height);

            }
            //Asteroid.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);            
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(Image, pos);
        }
        public void Die()
        {
            AsterDie?.Invoke();
        }
        public static event Message AsterDie;
    }

    class Lives : Objects
    {
        public int Energy { get; set; }
        public int Speed { get; set; }

        public static Image Image { get; set; }
        public Lives(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Energy = 100;
            Speed = -dir.X;
        }
        public override void Update()
        {
            var rand = new Random();
            pos.X = pos.X - dir.X;
            if (pos.X < -100)
            {
                pos.X = Game.Width;
                pos.Y = rand.Next(Game.Height);

            }
            //Asteroid.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);            
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(Image, pos);
        }
        public void Die()
        {
            AsterDie?.Invoke();
        }
        public static event Message AsterDie;
    }

    class Ship : Objects
    {
        public static Image Image { get; set; }
        public int Energy { get; set; }
        public int Speed { get; set; }

        //public void EnergyLow(int n)
        //{
        //    Energy -= n;            
        //    Speed = dir.Y;
        //}
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Energy = 100;
            Speed = dir.Y;
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(Image, pos);
        }
        public override void Update()
        {
          
        }
        public void Up()
        {
            if (pos.Y > 0) 
                pos.Y = pos.Y - dir.Y;
        }
        public void Down()
        {
            if (pos.Y < Game.Height-50) 
                pos.Y = pos.Y + dir.Y;
        }
        public void Die()
        {
            ShipDie.Invoke();
        }
        public static event Message ShipDie;
    }
}
