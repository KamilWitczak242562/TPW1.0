using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Text.Json;
using System.IO;
using System.Timers;
using static Dane.AbstractDataApi;

namespace Dane
{
    internal class Logger
    {
        private static List<Ball> balls;
        private System.Timers.Timer timer;

        public Logger(List<Ball> ballL)
        {
            balls = ballL;
            timer = new System.Timers.Timer(1000); 
            timer.Elapsed += TimerElapsed;
            timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            using (StreamWriter streamWriter = new StreamWriter("C:\\Studia\\TPW1.0\\Dane\\ballLog.txt", true))
            {
                streamWriter.WriteLine("\n");
                string stamp = ($"Ball data: {DateTime.Now:R}");
                foreach (Ball ball in balls)
                {
                    streamWriter.WriteLine(stamp + JsonSerializer.Serialize(ball));
                }
            }
        }

        public void Stop()
        {
            timer.Stop();
            timer.Dispose();
        }
    }
}
