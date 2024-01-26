using System;


namespace AppliedMathsProject
{
    internal class Program
    {
        public static double g = -9.81;//ms^-2
        public static int m = 300;//kg
        public static double mu = 0.09;
        public static double alpha = 100;
        public static double theta = (53.13) * Math.PI/180;
        public static double rho = 1.225;
        public static double dragCoef = 0.2;
        public static double A = 1.68;
        static void Main(string[] args)
        {
            Console.WriteLine("Iteration 1:");
            ITERATION1();
            Console.WriteLine("Iteration 2:");
            ITERATION2();
            Console.WriteLine("Iteration 3:");
            ITERATION3();
        }
        #region left
        public static void ITERATION1() {
            double v = 28.01;
            Console.WriteLine(v.ToString());
            for (int n = 1; n < alpha; n++)
            {
                
                v = Math.Sqrt((v * v) +
                    2 * (g * Math.Sin(
                        Math.Atan((15 * Math.Cos(T(n)) - 15 * Math.Cos(T(n + 1))) / (15 * Math.Sin(T(n)) - 15 * Math.Sin(T(n + 1)))))) * Math.Sqrt(((-15 * Math.Cos(T(n + 1)) + 15 * Math.Cos(T(n))) * (-15 * Math.Cos(T(n + 1)) + 15 * Math.Cos(T(n))))
                    + ((-15 * Math.Sin(T(n + 1)) + 15 * Math.Sin(T(n))) * (-15 * Math.Sin(T(n + 1)) + 15 * Math.Sin(T(n)))))
                    );
                Console.WriteLine(v.ToString());
            }
        }
        public static void ITERATION2()
        {
            double v = 26.94; 
            Console.WriteLine(v.ToString());
            for (int n = 1; n < alpha; n++)
            {
                
                v = Math.Sqrt((v * v) +
                    2 * (
                    g * Math.Sin(
                        Math.Atan((15 * Math.Cos(T(n)) - 15 * Math.Cos(T(n + 1))) / (15 * Math.Sin(T(n)) - 15 * Math.Sin(T(n + 1))))
                        )
                    - mu * (g * Math.Cos(Math.Atan((15 * Math.Cos(T(n)) - 15 * Math.Cos(T(n + 1))) / (15 * Math.Sin(T(n)) - 15 * Math.Sin(T(n + 1))))
                    ) + (v * v) / 15))
                    *
                    Math.Sqrt(((-15 * Math.Cos(T(n + 1)) + 15 * Math.Cos(T(n))) * (-15 * Math.Cos(T(n + 1)) + 15 * Math.Cos(T(n))))
                    + ((-15 * Math.Sin(T(n + 1)) + 15 * Math.Sin(T(n))) * (-15 * Math.Sin(T(n + 1)) + 15 * Math.Sin(T(n)))))
                    );
                Console.WriteLine(v.ToString());
            }
        }
        public static void ITERATION3()
        {
            double v = 26.06;
            for (int n = 1; n < alpha; n++)
            {
                Console.WriteLine(v.ToString());
                v = Math.Sqrt((v * v) +
                    2 * (
                    g * Math.Sin(
                        Math.Atan((15 * Math.Cos(T(n)) - 15 * Math.Cos(T(n + 1))) / (15 * Math.Sin(T(n)) - 15 * Math.Sin(T(n + 1))))
                        )
                    - mu * (g * Math.Cos(Math.Atan((15 * Math.Cos(T(n)) - 15 * Math.Cos(T(n + 1))) / (15 * Math.Sin(T(n)) - 15 * Math.Sin(T(n + 1))))
                    ) + (v * v) / 15) - DragAcc(v))
                    *
                    Math.Sqrt(((-15 * Math.Cos(T(n + 1)) + 15 * Math.Cos(T(n))) * (-15 * Math.Cos(T(n + 1)) + 15 * Math.Cos(T(n))))
                    + ((-15 * Math.Sin(T(n + 1)) + 15 * Math.Sin(T(n))) * (-15 * Math.Sin(T(n + 1)) + 15 * Math.Sin(T(n)))))
                    );
            }
        }
        static double T(int n)
        {
            return ((theta*(alpha+1))/alpha)-(theta*n)/alpha;
        }
        static double T1(int n)
        {
            return ((90 * (alpha + 1)) / alpha) - (90 * n) / alpha;
        }

        static double DragAcc(double v)
        {
            return (rho*dragCoef*A*v*v) / (2 * m);
        }
        #endregion
    }
}