using System;
using System.Threading;
using System.Collections.Generic;

namespace Dane
{
    public abstract class AbstractDataApi
    {
        public abstract void CreateScene(int width, int height, int ballsQuantity, int ballRadius);
        public abstract List<Ball> GetBalls();

        public abstract void Disable();

        public abstract Scene Scene { get; }
        public static AbstractDataApi CreateApi()
        {
            return new DataApi();
        }

        internal sealed class DataApi : AbstractDataApi
        {
            private readonly object locked = new object();

            private bool enabled = false;

            private Scene scene;

            public bool Enabled 
            {
                get { return enabled; }
                set { enabled = value; }
            }

            public override Scene Scene { 
                get { return scene; } 
            }

            public override void CreateScene(int width, int height, int orbQuantity, int orbRadius)
            {
                this.scene = new Scene(width, height, orbQuantity, orbRadius);
                this.Enabled = true;
                List<Ball> balls = GetBalls();

                foreach (Ball ball in balls)
                {
                    Thread t = new Thread(() => {
                        while (this.Enabled)
                        {
                            lock (locked)
                            {
                                ball.move();
                            }

                            Thread.Sleep(5);
                        }
                    });
                    t.Start();
                }
            }

            public override List<Ball> GetBalls()
            {
                return Scene.Balls;
            }

            public override void Disable()
            {
                this.Enabled = false;
            }
        }
    }
}

