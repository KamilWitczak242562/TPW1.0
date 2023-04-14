using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public class Scene
    {
        private readonly int width;
            public int Width
            {
                get { return width; }
            }

        private readonly int height;
            public int Height
            {
                get { return height; }
            }

        private bool enabled = false;
            public bool Enabled
            {
                get { return enabled; }
                set { enabled = value; }
            }

        private readonly List<Ball> balls = new List<Ball>();
            public List<Ball> Balls
            {
                get { return balls; }
            }

        public Scene(int width, int height, int ballsQuantity, int ballRadius)
        {
            this.width = width;
            this.height = height;
            GenerateBallsList(ballsQuantity, ballRadius);
        }

        public Ball GenerateBall(int radius)
        {
            Random random = new Random();
            bool valid = true;
            int x = radius, y = radius;
            do
            {
                valid = true;
                x = random.Next(radius, this.width - radius);
                y = random.Next(radius, this.height - radius);
                foreach (Ball b in this.Balls)
                {
                    double distance = Math.Sqrt(((b.X - x) * (b.X - x)) + ((b.Y - y) * (b.Y - y)));
                    if (distance <= b.Radius + radius)
                    {
                        valid = false;
                        break;
                    };
                }
                if (!valid)
                {
                    continue;
                };
                valid = true;

            } while (!valid);
            return new Ball(x, y, radius);
        }

        public void GenerateBallsList(int ballsQuantity, int ballRadius)
        {
            balls.Clear();
            for (int i = 0; i < ballsQuantity; i++)
            {
                Ball ball = GenerateBall(ballRadius);
                this.balls.Add(ball);
            }
        }
    }
}
