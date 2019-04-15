using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("НАЖМИТЕ [1] для сложения   НАЖМИТЕ [2] для вычитания"+ "\r\n"+ "НАЖМИТЕ [3] для умножения");
            Sum S = new Sum();
            Raznost R = new Raznost();
            Umnozh U = new Umnozh();



            while (true)
            {
                ConsoleKeyInfo CRK;
                CRK = Console.ReadKey();
                if (CRK.Key == ConsoleKey.NumPad1)
                {
                    try
                    {
                        Console.WriteLine("Введите первое число");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите второе число");
                        int b = Convert.ToInt32(Console.ReadLine());
                        S.sum(a, b);
                        Console.WriteLine("НАЖМИТЕ [1] для сложения   НАЖМИТЕ [2] для вычитания" + "\r\n" + "НАЖМИТЕ [3] для умножения");
                    }
                    catch (FormatException)
                    { Console.WriteLine("Введите число, а не буквы!"); }
                }
                else if (CRK.Key == ConsoleKey.NumPad2)
                {
                    try
                    {
                        Console.WriteLine("Введите первое число");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите второе число");
                        int b = Convert.ToInt32(Console.ReadLine());
                        R.raz(a, b);
                        Console.WriteLine("НАЖМИТЕ [1] для сложения   НАЖМИТЕ [2] для вычитания" + "\r\n" + "НАЖМИТЕ [3] для умножения");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Введите число в 16й системе счисления!");
                    }
                }
                else if (CRK.Key == ConsoleKey.NumPad3)
                {
                    try
                    {
                        Console.WriteLine("Введите первое число");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите второе число");
                        int b = Convert.ToInt32(Console.ReadLine());
                        U.proizv(a, b);                        
                        Console.WriteLine("НАЖМИТЕ [1] для сложения   НАЖМИТЕ [2] для вычитания");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Введите число в 16й системе счисления!");
                    }
                }
                else if (CRK.Key == ConsoleKey.Escape) { break; }
            }


        }
       

        public class Rasschet
        {
            public int raznica = 0;
            public string s;
            public string s2;
            public int rezult;
            
            public string rasschet(int a, int b)
            {
                int raznica = 0;
                s = a.ToString();
                s2 = b.ToString();
                if (a.ToString().Length > b.ToString().Length)
                { 
                    raznica = a.ToString().Length - b.ToString().Length;
                    s2 = new string(' ', raznica) + s2;
                    return s2;
                }
                else
                {
                    raznica = b.ToString().Length - a.ToString().Length;
                    s = new string(' ', raznica) + s;
                    return s;
                }
               
            }

        }

        public class Sum : Rasschet
        {            
            public void sum(int a, int b)
            {
                rezult = a + b;
                if (a.ToString().Length > b.ToString().Length)
                {
                    s2 = rasschet(a, b);
                        }
                else { s = rasschet(a, b); }
                Console.WriteLine(" " + s + "\r\n+\r\n" + " " + s2 + "\r\n" + "__________\r\n" + " " + rezult);
            }
        }
        public class Raznost : Rasschet
        {
            public void raz(int a, int b)
            {
                rezult = a - b;
                if (a.ToString().Length > b.ToString().Length)
                {
                    s2 = rasschet(a, b);
                }
                else { s = rasschet(a, b); }
                Console.WriteLine(" " + s + "\r\n-\r\n" + " " + s2 + "\r\n" + "__________\r\n" + " " + rezult);
            }
        }
        public class Umnozh:Rasschet
        {
            
            string mnozhitel;
            double proizvedenie;
            string probel_konec = "";
            string probel_nachalo;
            string result;
            int length;
            public string umnozhenie(int a, int b)
            {
                s = a.ToString();
                s2 = b.ToString();
                proizvedenie = a * b;
                length = (proizvedenie.ToString()).Length;

                for (int i = s2.Length - 1; i >= 0; i--)
                {
                    mnozhitel = (a * char.GetNumericValue(s2[i])).ToString() + probel_konec;
                    probel_nachalo = new string(' ', length - mnozhitel.Length);
                    result += probel_nachalo + mnozhitel + "\r\n+\r\n";
                    probel_konec += " ";
                }
                result = result.Substring(0, result.Length - 1);
                return result;


            }
            public void proizv(int a, int b)
            {
                raznica= (a * b).ToString().Length;

                int proizv = a * b;
                string rez = umnozhenie(a, b);                
                s2 = new string(' ', raznica - s2.Length)+ s2;
                s = new string(' ', raznica - s.Length) + s;
                Console.WriteLine(s + "\r\n" + "*" + "\r\n" + s2 + "\r\n__________\r\n" + rez + "__________\r\n"+ proizv);

            }
}




    }


}
