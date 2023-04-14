using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Dane
{
    public class Ball : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double radius;
        private double[] speed = new double[2];

        public Ball(double x, double y, double radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            Random random = new Random();
            double xSpeed = 0;
            do
            {
                xSpeed = random.NextDouble() * 0.99;
            } while (xSpeed == 0);
            double ySpeed = Math.Sqrt(4 - (xSpeed * xSpeed));
            ySpeed = (random.Next(-1, 1) < 0) ? ySpeed : -ySpeed;
            this.speed[0] = xSpeed;
            this.speed[1] = ySpeed;
        }

        public double X 
        { 
            get { return x; } 
            set 
            { 
                x = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get { return y; }
            set 
            { 
                y = value; 
                OnPropertyChanged("Y");
            }
        }
        [JsonIgnore]
        public double Radius
        {
            get { return radius; }
            set 
            { 
                radius = value;
                OnPropertyChanged("Radius");
            }
        }

        public double XSpeed 
        { 
            get { return speed[0]; }
            set { speed[0] = value; }
        }

        public double YSpeed 
        {
            get { return speed[1]; }
            set { speed[1] = value; }
        }

        public void move()
        {
            this.X += this.XSpeed;
            this.Y += this.YSpeed;
            OnPropertyChanged("Position");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
