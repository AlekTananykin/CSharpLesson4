using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/* Тананыкин
 * 
 * Дан  целочисленный  массив  из 20 элементов.  Элементы  массива  могут 
 * принимать  целые  значения  от –10 000 до 10 000 включительно. Заполнить 
 * случайными числами.  Написать программу, позволяющую найти и вывести 
 * количество пар элементов массива, в которых только одно число делится на 3. 
 * В данной задаче под парой подразумевается два подряд идущих элемента 
 * массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 
 */

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа вывода количества смежных пар");

            Random rnd = new Random();
            const int minValue = -10000;
            const int maxValue = 10000;

            const int arraySize = 20;
            int[] array = new int[arraySize];

            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = rnd.Next(minValue, maxValue);
                Console.WriteLine("{0}", array[i]);
            }
            Console.WriteLine("\nКоличество пар: {0}", GetPairsCount(array));
            Console.ReadKey();
        }

        private static int GetPairsCount(int[] array)
        {
            if (null == array || array.Length < 2)
                return 0;

            int pairsCount = 0;
            bool isPrevMod3 = IsAppropriateValue(array[0]);
            for (int i = 1; i < array.Length; ++ i)
            {
                bool isCurrMod3 = IsAppropriateValue(array[i]);
                if (isPrevMod3 && !isCurrMod3 || !isPrevMod3 && isCurrMod3)
                    ++ pairsCount;

                isPrevMod3 = isCurrMod3;
            }

            return pairsCount;
        }

        private static bool IsAppropriateValue(int a)
        {
            return 0 == a % 3 && 0 != a;
        }
    }
}
