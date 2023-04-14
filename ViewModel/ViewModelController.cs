using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewModelController : INotifyPropertyChanged
    {
        public ViewModelController (AbstractModelApi ModelApi = null)
        {
            SignalEnable = new Signal(Enable);
            SignalDisable = new Signal(Disable);
            if (ModelApi == null)
            {
                this.modelApi = AbstractModelApi.CreateApi();
            }
            else
            {
                this.modelApi = ModelApi;
            }
        }
        public ViewModelController() : this(null) {}

        public ICommand SignalEnable
        {
            get;
            set;
        }
        public ICommand SignalDisable
        {
            get;
            set;
        }

        private AbstractModelApi modelApi;
        
        private int ballsQuantity = 0;

        public string BallsQuantity
        {
            get
            {
                return Convert.ToString(ballsQuantity);
            }
            set
            {
                ballsQuantity = Convert.ToInt32(value);
                OnPropertyChanged("BallsQuantity");
            }
        }

        private ObservableCollection<BallUI> ballList;
        public ObservableCollection<BallUI> BallList
        {
            get { return ballList; }
            set
            {
                if (value.Equals(this.ballList)) return;
                ballList = value;
                OnPropertyChanged("BallList");
            }
        }

        private bool isEnabled = true;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set 
            { 
                isEnabled = value;
                OnPropertyChanged("IsEnabled");
                OnPropertyChanged("IsDisabled");
            }
        }
        public bool IsDisabled 
        { 
            get
            {
                return !isEnabled;
            }
        }

        private void Enable()
        {
            modelApi.Enable(ballsQuantity);
            BallList = modelApi.GetAllBalls();
        }

        private void Disable()
        {
            modelApi.Disable();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
