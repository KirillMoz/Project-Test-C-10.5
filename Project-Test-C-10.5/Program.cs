using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Test_C_10._5
{
    public class Program
    {
        public interface ISummary { 
            int Summ(int x, int y);
        }

        public interface ILoger {
            void Event(string Message);
            void Error (string Message);
        }

        public class Loger: ILoger {
            public void Event(string Message)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(Message);
                Console.ResetColor();
            }
            public void Error(string Message)
            { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Message);
                Console.ResetColor();
            }
        }

        public class Summary: ISummary 
        {
            private int X, Y;
            ILoger loger { get; }

            public Summary(ILoger loger)
            {
                this.loger = loger;
            }

            public void StartedSummary()
            {
                try
                {
                    Console.WriteLine("Введие первое слагаемое: ");
                    X = Convert.ToInt32(Console.ReadLine());
                    loger.Event("X = " + X.ToString());

                    Console.WriteLine("Введие второе слагаемое: ");
                    Y = Convert.ToInt32(Console.ReadLine());
                    loger.Event("Y = " + X.ToString());

                    loger.Event("Сумма чисел равна " + Summ(X, Y).ToString());
                }
                catch (Exception ex) 
                { 
                    loger.Error(ex.Message); 
                }
            }

            public int Summ(int x, int y) => x + y;
        }
        
        static public void Main(string[] args)
        {
            ILoger loger = new Loger();
            Summary summary = new Summary(loger);
            summary.StartedSummary();
            Console.ReadKey();
        }
    }
}
