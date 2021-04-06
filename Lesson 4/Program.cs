using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArray array1 = new MyArray(20);
            array1.Print();
            Console.WriteLine("\n Количество пар, делящихся на 3 = " + array1.Pair_to_N(3));

            MyArray array2 = new MyArray(7, 10, 10);
            array2.Print();

            Console.WriteLine("\n Сумма: " + array2.Sum);

            array2.Inverse();
            Console.Write("\n Меняем знак числа: ");
            array2.Print();

            array2.Multi(3);
            Console.Write("\n Умножаем на 3: ");
            array2.Print();

            Console.WriteLine("\n Количество максимальных элементов в массиве array1: " + array1.MaxCount);
            Console.WriteLine("\n Количество максимальных элементов в массиве array2: " + array2.MaxCount);

            MyArray array3 = new MyArray(100000);
            Console.WriteLine("\n Количество максимальных элементов в массиве array3: " + array3.MaxCount);

            MyArray array4 = new MyArray(@"B:\Geekbrains\Lesson 4\Lesson 4\Test.txt");
            Console.WriteLine("\n Чтение из файла");
            array4.Print();
            Console.WriteLine("\n Запись в файл  и чтение новых данных");
            array1.Rec(@"B:\Geekbrains\Lesson 4\Lesson 4\Test.txt");
            Read(@"B:\Geekbrains\Lesson 4\Lesson 4\Test.txt");

            Console.ReadKey();
        }


        static void Read(string filename)
        {
            if (File.Exists(filename))
            {

                string[] ss = File.ReadAllLines(filename);
                for (int i = 0; i < ss.Length; i++)
                {
                    Console.Write(ss[i] + " ");
                }
                Console.WriteLine();
            }
            else Console.WriteLine("Файл не найден");
        }
    }

    class MyArray
    {
        int[] a;
        Random rnd = new Random();


        public MyArray(int n)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(-10000, 10000);
        }


        public MyArray(int n, int start, int step)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = start + step * i;
            }
        }


        public MyArray(string filename)
        {

            if (File.Exists(filename))
            {

                string[] ss = File.ReadAllLines(filename);
                a = new int[ss.Length];

                for (int i = 0; i < ss.Length; i++)
                    a[i] = int.Parse(ss[i]);
            }
            else Console.WriteLine("Файл не найден");
        }

        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    sum += a[i];
                }
                return sum;
            }
        }


        public void Inverse()
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] *= -1;
            }
        }


        public void Multi(int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] *= x;
            }
        }


        public int MaxCount
        {
            get
            {
                int max = a[0];
                int count = 1;
                for (int i = 1; i < a.Length; i++)
                {
                    if (a[i] > max)
                    {
                        max = a[i];
                        count = 1;
                    }
                    else if (a[i] == max)
                    {
                        count++;
                    }
                }
                return count;
            }
        }


        public void Print()
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();
        }


        public int Pair_to_N(int n)
        {
            int count = 0;
            for (int i = 0; i < (a.Length - 1); i++)
            {
                if ((a[i] % n == 0) || (a[i + 1] % n == 0))
                {
                    count++;
                }
            }
            return count;
        }


        public void Rec(string filename)
        {

            string[] a_string = new string[a.Length];
            for (int i = 0; i < a_string.Length; i++)
                a_string[i] = Convert.ToString(a[i]);


            System.IO.File.WriteAllLines(filename, a_string);
        }
    }
}