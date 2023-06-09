﻿using Dane;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace Logika
{
    public abstract class AbstractLogicApi
    {
        public static AbstractLogicApi CreateApi(AbstractDataApi abstractDataApi = null)
        {
            return new LogicApi(abstractDataApi);
        }

        public abstract List<BallLogic> GetBalls();

        public abstract void Enable(int width, int height, int ballsQuantity, int ballRadius);

        public abstract void Disable();

        public abstract bool IsEnabled();

        internal sealed class LogicApi : AbstractLogicApi
        {
            private AbstractDataApi DataApi;

            private List<BallLogic> balls = new List<BallLogic>();

            bool enabled = false;

            public bool Enabled
            {
                get { return enabled; }
                set { enabled = value; }
            }

            internal LogicApi(AbstractDataApi abstractDataApi = null)
            {
                if (abstractDataApi == null)
                {
                    this.DataApi = AbstractDataApi.CreateApi();
                }
                else
                {
                    this.DataApi = abstractDataApi;
                }
            }

            public override List<BallLogic> GetBalls()
            {
                return this.balls;
            }

            public override void Enable(int width, int height, int ballsQuantity, int ballRadius)
            {
                DataApi.CreateScene(width, height, ballsQuantity, ballRadius);
                foreach (Ball orb in DataApi.GetBalls())
                {
                    this.balls.Add(new BallLogic(orb));
                    orb.PropertyChanged += Update;
                }
            }

            public override void Disable()
            {
                DataApi.Disable();
                this.balls.Clear();
            }

            public override bool IsEnabled()
            {
                return enabled;
            }

            private void Update(object sender, PropertyChangedEventArgs ev)
            {
                Ball orb = (Ball)sender;
                if (ev.PropertyName == "Position")
                {
                    CheckCollision(orb);
                }

            }

            private void CheckCollision(Ball orb)
            {
                AreaCollision(orb);
                BallCollision(orb);
            }

            private void AreaCollision(Ball orb)
            {
                if ((orb.X + orb.Radius) >= DataApi.Scene.Width)
                {
                    orb.XSpeed = -orb.XSpeed;
                    orb.X = DataApi.Scene.Width - orb.Radius;
                }
                if ((orb.X - orb.Radius) <= 0)
                {
                    orb.XSpeed = -orb.XSpeed;
                    orb.X = orb.Radius;
                }
                if ((orb.Y + orb.Radius) >= DataApi.Scene.Height)
                {
                    orb.YSpeed = -orb.YSpeed;
                    orb.Y = DataApi.Scene.Height - orb.Radius;
                }
                if ((orb.Y - orb.Radius) <= 0)
                {
                    orb.YSpeed = -orb.YSpeed;
                    orb.Y = orb.Radius;
                }
            }

            private void BallCollision(Ball orb)
            {
                foreach (Ball o in DataApi.GetBalls())
                {
                    if (o == orb)
                    {
                        continue;
                    }
                    double xDiff = o.X - orb.X;
                    double yDiff = o.Y - orb.Y;
                    double distance = Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff));
                    if (distance <= (orb.Radius))
                    {
                        double newSpeed = ((o.XSpeed * (o.Weight - orb.Weight) + (orb.Weight * orb.XSpeed * 2)) / (o.Weight + orb.Weight));
                        orb.XSpeed = ((orb.XSpeed * (orb.Weight - o.Weight) + (o.Weight * o.XSpeed * 2)) / (o.Weight + orb.Weight));
                        o.XSpeed = newSpeed;

                        newSpeed = ((o.YSpeed * (o.Weight - orb.Weight)) + (orb.Weight * orb.YSpeed * 2) / (o.Weight + orb.Weight));
                        orb.YSpeed = ((orb.YSpeed * (orb.Weight - o.Weight)) + (o.Weight * o.YSpeed * 2) / (o.Weight + orb.Weight));
                        o.YSpeed = newSpeed;
                    }
                }
            }
        }
    }
}
