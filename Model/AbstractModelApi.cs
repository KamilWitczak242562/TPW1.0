using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Logika;

namespace Model
{
    public abstract class AbstractModelApi
    {
        public static AbstractModelApi CreateApi(AbstractLogicApi abstractLogicApi = null)
        {
            return new ModelApi();
        }

        public abstract ObservableCollection<BallUI> GetAllBalls();

        public abstract void Enable(int quantity);

        public abstract void Disable();

        public abstract bool IsEnabled();

        public sealed class ModelApi : AbstractModelApi
        {
            private AbstractLogicApi logicApi = AbstractLogicApi.CreateApi(null);

            private ObservableCollection<BallUI> ballsUI = new ObservableCollection<BallUI>();

            public ObservableCollection<BallUI> BallsUI
            {
                get 
                { 
                    return ballsUI; 
                }
                set 
                { 
                    ballsUI = value; 
                }
            }

            internal ModelApi(AbstractLogicApi abstractLogicApi = null)
            {
                if (abstractLogicApi == null)
                {
                    this.logicApi = AbstractLogicApi.CreateApi();
                }
                else
                {
                    this.logicApi = abstractLogicApi;
                }
            }

            public override void Enable(int quantity)
            {
                logicApi.Enable(785, 630, quantity, 40);
            }

            public override ObservableCollection<BallUI> GetAllBalls()
            {
                List<BallLogic> ballsUI = logicApi.GetBalls();
                BallsUI.Clear();
                foreach (BallLogic ball in ballsUI)
                {
                    BallsUI.Add(new BallUI(ball));
                }
                return BallsUI;
            }

            public override void Disable()
            {
                logicApi.Disable();
            }

            public override bool IsEnabled()
            {
                return logicApi.IsEnabled();
            }
        }
    }
}
