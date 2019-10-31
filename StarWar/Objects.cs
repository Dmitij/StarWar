using System;
using System.Collections.Generic;
using System.Drawing;


namespace Asteroids
{
    class BaseFigure
    {
        protected Point pos;
        protected Point dir;
        protected Size size;

        public BaseFigure(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }

        public virtual void Draw()
        {
            Game.buffer.Graphics.DrawEllipse(Pens.White, pos.X, pos.Y, size.Width, size.Height);
        }

        public virtual void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;
            if (pos.X < 0) dir.X = -dir.X;
            if (pos.X > Game.Width) dir.X = -dir.X;
            if (pos.Y < 0) dir.Y = -dir.Y;
            if (pos.Y > Game.Height) dir.Y = -dir.Y;
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

    class Stars
    {
        protected Point pos;
        protected Point dir;
        
        public static Image Image { get; set; }
              
        public Stars(Point pos, Point dir) 
        {
            this.pos = pos;
            this.dir = dir;            
        }

        public virtual void Update()
        {
            var rand = new Random();
            pos.X = pos.X - dir.X;
            if (pos.X < -100)
            {
                pos.X = Game.Width;
                pos.Y = rand.Next(Game.Height);
            }
        }

        public virtual void Draw()
        {
            Game.buffer.Graphics.DrawImage(Image, pos);
        }

    }

    class Stars100 : Stars
    {
        public static Image Image { get; set; }
        public Stars100(Point pos, Point dir) : base(pos, dir)
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

    class Stars50 : Stars
    {
        public static Image Image { get; set; }
        public Stars50(Point pos, Point dir) : base(pos, dir)
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

    class Stars25 : Stars
    {
        public static Image Image { get; set; }
        public Stars25(Point pos, Point dir) : base(pos, dir)
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
    class Stars10 : Stars
    {
        public static Image Image { get; set; }
        public Stars10(Point pos, Point dir) : base(pos, dir)
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
}
