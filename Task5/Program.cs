using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Тананыкин
 * 
 * *а) Реализовать библиотеку с классом для работы с двумерным массивом. 
 * Реализовать конструктор, заполняющий массив случайными числами. 
 * Создать методы, которые 
 * возвращают сумму всех элементов массива, 
 * сумму всех элементов массива больше заданного, 
 * свойство, возвращающее минимальный элемент массива, 
 * свойство, возвращающее максимальный элемент массива, 
 * метод, возвращающий номер максимального элемента массива 
 * (через параметры, используя модификатор ref или out).
**б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
**в) Обработать возможные исключительные ситуации при работе с файлами.
 */
namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            const int rows = 3;
            const int columns = 3;
            const int minValue = -9;
            const int maxValue = 9;

            TwoDimArray array = new TwoDimArray(
                rows, columns, minValue, maxValue);

            Console.WriteLine("Двумерный массив: ");
            PrintArray(array);
            Console.WriteLine();
            Console.WriteLine("Сумма элементов массива : {0}", array.Sum());
            
            int threshold = 2;
            Console.WriteLine("Сумма элементов больше {0}: {1}", 
                threshold, array.Sum(threshold));

            Console.WriteLine("Минимальный элемент массива: {0}", array.Min);
            Console.WriteLine("Максимальный элемент массива: {0}", array.Max);

            int row = 0, column = 0;
            array.GetMaxItemPos(ref row, ref column);

            Console.WriteLine("Максимальный элемент находится " +
                "(строка: {0}; колонка: {1})", row, column);


            Console.WriteLine("\n\nЗапись двумерного массива на диск " +
                "исчитвание этого массива");


            string arrayPath = Directory.GetCurrentDirectory() +
               "/TwoDimArray.txt";

            Console.WriteLine("Путь сохранения массива{0}", arrayPath);

            try
            {

                TwoDimArray.WriteArrayToFile(array, arrayPath);
                TwoDimArray fileArray = TwoDimArray.ReadArrayFromFile(arrayPath);
                File.Delete(arrayPath);

                Console.WriteLine("Считанный массив");
                PrintArray(fileArray);

            }
            catch (TwoDimArrayException tdex)
            {
                Console.WriteLine(tdex.Message);
                if (null != tdex.InnerException)
                Console.WriteLine(tdex.InnerException.Message);
            }
            Console.ReadKey();
        }

        private static void PrintArray(TwoDimArray array)
        {
            for (int i = 0; i < array.Rows; ++i)
            {
                for (int j = 0; j < array.Columns; ++j)
                    Console.Write("{0}\t", array[i, j]);
                Console.WriteLine();
            }

        }
    }

   
}
