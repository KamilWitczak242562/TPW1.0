using Dane;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Logika
{
    public class BallLogic : INotifyPropertyChanged
    {
        private Ball ball;

        public BallLogic(Ball ball)
        {
            this.ball = ball;
            ball.PropertyChanged += Update;
        }

        private void Update(object source, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "X")
            {
                OnPropertyChanged("X");
            }
            else if (e.PropertyName == "Y")
            {
                OnPropertyChanged("Y");
            }
            else if (e.PropertyName == "Radius")
            {
                OnPropertyChanged("Radius");
            }

        }
        public double X
        {
            get { return ball.X; }
            set
            {
                ball.X = value;
                OnPropertyChanged("X");
            }
        }
        public double Y
        {
            get { return ball.Y; }
            set
            {
                ball.Y = value;
                OnPropertyChanged("Y");
            }
        }
        public double Radius
        {
            get { return ball.Radius; }
            set
            {
                ball.Radius = value;
                OnPropertyChanged("Radius");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
