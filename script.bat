@echo off
setlocal EnableDelayedExpansion

:: Define C# code
set "code=using System;^
namespace AppliedMathsProject {^
    internal class Program {^
        public static double g = 9.81;//ms^-2^
        public static int m = 300;//kg^
        public static double mu = 0.1;^
        public static double alpha = 10000;^
        public static double theta = 53.13 * Math.PI/180;^
        static void Main(string[] args) {^
            double v=23.44;^
            for(int n=1; n<alpha; n++) {^
                v = Math.Sqrt((v * v) + ^ 
                    2*(^
                        g*Math.Sin(^
                            Math.Atan((15*Math.Cos(T(n))-15*Math.Cos(T(n+1)))/ (15 * Math.Sin(T(n)) - 15 * Math.Sin(T(n + 1))))^
                        )^
                    -mu*(g*Math.Cos(Math.Atan((15 * Math.Cos(T(n)) - 15 * Math.Cos(T(n + 1))) / (15 * Math.Sin(T(n)) - 15 * Math.Sin(T(n + 1))))^
                    ) + (v*v)/15))^
                    *^
                    Math.Sqrt(((-15*Math.Cos(T(n+1))+ 15 * Math.Cos(T(n))) * (-15 * Math.Cos(T(n + 1)) + 15 * Math.Cos(T(n))))^
                    + ((-15 * Math.Sin(T(n + 1)) + 15 * Math.Sin(T(n))) * (-15 * Math.Sin(T(n + 1)) + 15 * Math.Sin(T(n)))))^
                );^
                Console.WriteLine(v.ToString());^
            }^
            Console.ReadKey();^
        }^
        static double T(int n) {^
            return ((theta*(alpha+1))/alpha)-(theta*n)/alpha;^
        }^
    }^
}"

:: Create a temporary C# file
echo %code% > AppliedMathsProject.cs

:: Compile and run the C# code using csc (C# compiler)
csc /out:AppliedMathsProject.exe AppliedMathsProject.cs
AppliedMathsProject.exe

:: Clean up temporary files
del AppliedMathsProject.cs
del AppliedMathsProject.exe

endlocal
