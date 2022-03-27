using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSdemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            double k, l, m, n, z1, z2;
            Console.WriteLine("Enter a number to select a method: \n" +
                "1. Sum Twelve\n" +
                "2. Box-Muller\n" +
                "3. Polar Rejecetion\n" +
                "4. Joint Normal Distribution");
            l = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("What is the size of the sample do you want?");
            m = Convert.ToDouble(Console.ReadLine());
            Random r = new Random();
            List<double> list1 = new List<double>();
            List<double> list2 = new List<double>();
            if (l == 1)
            {
                for (int i = 0; i < m; i++) 
                {
                    k = SumTwelve();
                    list1.Add(k);
                }
                list1.Sort();
                Console.WriteLine(string.Join(',', list1));
            }
            else if (l == 2)
            {
                for (int i = 0; i < m; i++) 
                {
                    (k, n) = BoxMuller();
                    list1.Add(k);
                    list2.Add(n);
                }
                list1.Sort();
                list2.Sort();
                Console.WriteLine(string.Join(',', list1));
                Console.WriteLine(string.Join(',', list2));
            }
            else if (l == 3)
            {
                for (int i = 0; i < m; i++) 
                {
                    (k,n) = PolarRejection();
                    list1.Add(k);
                    list2.Add(n);
                }
                list1.Sort();
                list2.Sort();
                Console.WriteLine(string.Join(',', list1));
                Console.WriteLine(string.Join(',', list2));
            }
            else if (l == 4)
            {
                double rho;
                Console.WriteLine("Please enter the Correlation Coefficient , note that the coefficient can only from -1 to 1");
                rho = Convert.ToDouble(Console.ReadLine());
                if (Math.Abs(rho) > 1)
                    Console.WriteLine("Please enter a valid number!");
                else
                    for (int i = 0; i < m; i++)
                    {
                        (z1, z2) = BoxMuller();
                        (k, n) = JointNormal(z1, z2, rho);
                        list1.Add(k);
                        list2.Add(n);
                    }
                list1.Sort();
                list2.Sort();
                Console.WriteLine(string.Join(',', list1));
                Console.WriteLine(string.Join(',', list2));
            }
            else
            {
                Console.WriteLine("Please enter a valid number!");
            }
            Console.ReadLine();
        }   

        static double SumTwelve()
        {
            Random r = new Random();
            double k = 0;
            for (int i = 0; i < 12; i++)
            {
                double j = r.NextDouble();
                k = k + j;
            }
            return k-6;
        }

        static (double k1, double k2) BoxMuller()
        {
            Random r = new Random();
            double i = r.NextDouble();
            double j = r.NextDouble();
            double k1 = Math.Sqrt(-2 * Math.Log(i)) * Math.Cos(-2 * Math.PI * j);
            double k2 = Math.Sqrt(-2 * Math.Log(i)) * Math.Sin(-2 * Math.PI * j);
            return (k1, k2);
            
        }

        static (double k1, double k2) PolarRejection()
        {
            Random r = new Random();
            double r1 = (r.NextDouble() * 2 - 1);
            double r2 = (r.NextDouble() * 2 - 1);
            double w = Math.Pow(r1, 2) + Math.Pow(r2, 2);
            while (true)
            {
                if (w <= 1)
                    break;
                else
                    r1 = (r.NextDouble() * 2 - 1);
                    r2 = (r.NextDouble() * 2 - 1);
                    w = Math.Pow(r1, 2) + Math.Pow(r2, 2);
            }
            double c = Math.Sqrt(-2*Math.Log(w)/w);
            double k1 = c * r1;
            double k2 = c * r2;
            return (k1, k2);   
        }

        static (double k1, double k2) JointNormal(double z1, double z2, double rho)
        {
            double k1 = z1;
            double k2 = rho * z1 + Math.Sqrt(1 - Math.Pow(rho, 2)) * z2;
            return (k1,k2);
        }

    }
}