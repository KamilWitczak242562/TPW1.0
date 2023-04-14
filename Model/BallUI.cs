using Logika;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class BallUI : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double radius;
        private double weight;

        public BallUI(BallLogic ball)
        {
            this.x = ball.X;
            this.y = ball.Y;
            this.radius = ball.Radius;
            ball.PropertyChanged += Update;
        }

        private void Update(object source, PropertyChangedEventArgs key)
        {
            BallLogic sourceBall = (BallLogic)source;
            if(key.PropertyName == "X")
            {
                this.X = sourceBall.X - sourceBall.Radius ;
            }

            if(key.PropertyName == "Y")
            {
                this.Y = sourceBall.Y - sourceBall.Radius ;
            }

            if(key.PropertyName == "Radius")
            {
                this.Radius = sourceBall.Radius ;
            }

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

        public double Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                OnPropertyChanged("Radius");
            }
        }

        public double Weight
        {
            get { return weight; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
