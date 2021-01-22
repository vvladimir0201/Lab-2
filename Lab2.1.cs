using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Lab2.1
{
    class Program
    {

        [DllImport(dllName: "Lib2.1.dll", CallingConvention = CallingConvention.Cdecl)]             
        public static extern double TheFunc(string surname, double x);

        private static double CallTheFunc(string surname, double x)
        {
            return TheFunc(surname, x);                    
        }
        private static double MyFunc(double x, double a, double b, double c)
        {
            return a * Math.Pow(x, 2) - b * x + c;

        }

        static void Main(string[] args)
        {

            double x, a, b, c, f1, f2;
            string surname = "Выдыш";

            var xxx = new List<double>();    
            var yyy = new List<double>();

            c = TheFunc(s, x);            /// Коэффициент c ф-ии
            x = 1;                        
            f1 = TheFunc(s, x);
            x = 2;
            f2 = TheFunc(s, x);
            b = 2 * f1 - 2 * c - f2 / 2;
            b = Math.Round(b, 2);        ///Коэффициенты b ф-ии
            a = f1 - b - c;
            a = Math.Round(a, 2);        ///Коэффициенты a ф-ии


            for (var x = 1; x < 11; x++)      
            {
                double call = CallTheFunc(surname, x);

                xxx.Add(x);
                yyy.Add(call);
                Console.WriteLine($"{ x}  { call}");           
            }

            var xxx2 = new List<double>();
            var yyy2 = new List<double>();

            for (var x = 0; x < 11; x ++)        
            {
                double call1 = MyFunc(x, a, b, c);

                xxx2.Add(x);
                yyy2.Add(call1);
            }

            var graphic = new ScottPlot.Plot(300, 300);                   
            graphic.PlotScatter(xxx.ToArray(), yyy.ToArray());
            graphic.SaveFig("TheFunc.png");

            var graphic2 = new ScottPlot.Plot(300, 300);                   
            graphic.PlotScatter(xxx2.ToArray(), yyy2.ToArray());
            graphic.SaveFig("TheFunc2.png");

            Console.ReadLine();
        }
    }
}
