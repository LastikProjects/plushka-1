﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plushka_1
{
    class Program
    {
        static void izmenenie(ref double[] mas,int kol)
            {
            double zamena,zamena1,zamena2;
            int i,j,pozic;

            for (i = 0; i < kol; i = i + 2)
            {
                if (mas[i] > mas[i + 1])
                {
                    zamena = mas[i];
                    mas[i] = mas[i + 1];
                    mas[i + 1] = zamena;
                };
            }

            for(i=0;i+1<kol;i=i+2)
            {
                pozic = i;
                zamena1 = mas[i];
                zamena2 = mas[i + 1];
                for (j = i + 2; j + 1 < kol;j=j+2)
                {
                    if(mas[j]<zamena1)
                    {
                        pozic = j;
                        zamena1 = mas[j];
                        zamena2 = mas[j + 1];
                    }
                }
                mas[pozic] = mas[i];
                mas[pozic + 1] = mas[i + 1];
                mas[i] = zamena1;
                mas[i + 1] = zamena2;
            }
            }

        static void vIbvod(double[] mas,int kol)
        {
            int i;
            for(i=0;i<kol;i=i+2)
            {
                Console.WriteLine("({0};{1}) ",mas[i],mas[i+1]);
            }
        }

        static void Main(string[] args)
        {
            vvod: Console.Write("Введите четное количество точек\n");//метка для ввода
            int kol = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (kol <= 0 || kol % 2 != 0)
            {
                Console.Write("Неправильное количетсво точек!!!\n");
                goto vvod; //переход в метку
            }
            double[] mas = new double[kol];
            int i;
            for(i=0;i<kol ;i++)
            {
                mas[i]=Convert.ToDouble(Console.ReadLine());
            }

            double max = mas[0], min = mas[0];//максимальный и минимальный символ во всем интервале
            int nummin=0;//номер минимального элемента

            for (i = 0; i < kol; i++)//поиск max и min числа
            {
                if (max < mas[i])
                {
                    max = mas[i];
                }
                if(min>mas[i])
                {
                    min = mas[i];
                }
            }

            izmenenie(ref mas,kol);//замена чисел в массиве если конец больше начала и его сортировка
            vIbvod(mas,kol);
            Boolean proverka = false;
            for (i=2;i<kol;i=i+2)
            {
                if (mas[i] <= mas[nummin+1] && mas[i]>=mas[nummin] && mas[i+1]>mas[nummin+1])
                {
                    nummin = i;
                }
                    if (mas[nummin+1]==max)
                {
                    proverka = true;
                }
            }
            if (proverka==false)
            {
                Console.Write("интервалы не объединяются");
            }
            else
            {
                Console.WriteLine("интервалы объединяются в интервал ({0};{1})",min,max);
            }
            Console.ReadKey();
        }
    }
}
