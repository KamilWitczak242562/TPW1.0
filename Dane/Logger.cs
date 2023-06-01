using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Text.Json;
using System.IO;
using static Dane.AbstractDataApi;

namespace Dane
{
    internal class Logger
    {
        private static List<Ball> balls;
        private Stopwatch stopWatch = new Stopwatch();

        public Logger(List<Ball> ballL)
        {
            balls = ballL;
            Thread t = new Thread(() =>
            {
                ClearLogFile();
                stopWatch.Start();
                while (true)
                {
                    if (stopWatch.ElapsedMilliseconds >= 1000)
                    {
                        stopWatch.Restart();
                        using (StreamWriter streamWriter = new StreamWriter("G:\\Sem IV\\TPW2.0\\Dane\\orbLog.txt", true))
                        {
                            string stamp = ($"Ball data: {DateTime.Now:R}");
                            foreach (Ball ball in balls)
                            {
                                streamWriter.WriteLine(stamp + JsonSerializer.Serialize(ball));
                            }

                        }
                    }
                }
            })
            {
                IsBackground = true
            };
            t.Start();
        }

        private void ClearLogFile()
        {
            try
            {
                File.WriteAllText("G:\\Sem IV\\TPW2.0\\Dane\\orbLog.txt", string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while clearing the log file: " + ex.Message);
            }
        }

        public void stop()
        {
            stopWatch.Reset();
            stopWatch.Stop();
        }
    }
}
