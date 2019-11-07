using System;
using System.Collections.Generic;
using System.Drawing;
//Рязанцев Дмитрий

namespace StarWar
{
    abstract class Pictures : ICollision
    {
        protected Point pos;
        protected Point dir;
        protected Size size;

        public Pictures(Point pos, Point dir, Size size)
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

    }

    class Bullet : Pictures
    {
        int speed;
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            speed = dir.X;
        }

        public override void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;
            if (pos.X < 0) dir.X = -dir.X;
            if (pos.X > Game.Width) dir.X = -dir.X;
            if (pos.Y < 0) dir.Y = -dir.Y;
            if (pos.Y > Game.Height) dir.Y = -dir.Y;
        }
        //{            

        //    pos.X = pos.X + dir.X;
        //    if (pos.X < Game.Width)
        //    {
        //        pos.X = pos.X + speed;
        //        //pos.Y = rand.Next(Game.Height);
        //    }

        //}
        public override void Draw()
        {
            Game.buffer.Graphics.DrawEllipse(Pens.White, pos.X, pos.Y, size.Width, size.Height);
        }
    }

    //class Star: BaseObject
    //{

    //    public static Image Image { get; set; }

    //    //public Star():base(new Point(0,0),new Point(0,0),new Size(0,0))
    //    //{

    //    //}

    //    public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
    //    {

    //    }

    //    public override void Update()
    //    {
    //        var rand = new Random();
    //        pos.X = pos.X - dir.X;
    //        if (pos.X < 0)
    //        {
    //            pos.X = Game.Width;
    //            pos.Y = rand.Next(Game.Height);
    //        }
    //    }

    //    public override void Draw()
    //    {           
    //        Game.buffer.Graphics.DrawImage(Image, pos);
    //    }

    //}

    //abstract class Pictures: ICollision
    //{
    //    protected Point pos;
    //    protected Point dir;        
    //    public static Image Image { get; set; }
         
    //    public Pictures(Point pos, Point dir) 
    //    {
    //        this.pos = pos;
    //        this.dir = dir;            
    //    }
    //    public abstract void Update();

    //    public abstract void Draw();


    //    public Rectangle Rect =>  new Rectangle(pos, new Size(100,100));
    //    public bool Collision(ICollision collision)
    //    {
    //        return (collision.Rect.IntersectsWith(this.Rect));
    //    }
    //}

    class Stars100 : Pictures
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

    class Stars50 : Pictures
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

    class Stars25 : Pictures
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
    class Stars10 : Pictures
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

    class Asteroid : Pictures
    {
        public static Image Image { get; set; }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
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
            //Asteroid.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);            
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

}
