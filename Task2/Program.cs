using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Тананыкин
 * 
 * Реализуйте задачу 1 в виде статического класса StaticClass;
 * а) Класс должен содержать статический метод, который принимает 
 * на вход массив и решает задачу 1;
 * б) *Добавьте статический метод для считывания массива из текстового файла. 
 * Метод должен возвращать массив целых чисел;
 * в)**Добавьте обработку ситуации отсутствия файла на диске.
 */
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Программа вывода количества смежных пар. ****\n");

            const int minValue = -10000;
            const int maxValue = 10000;
            const int arraySize = 20;
            int[] array = ArrayTools.GenerateArray(
                minValue, maxValue, arraySize);

            Console.WriteLine("Сохранение массива на диск. ");
            string arrayPath = Directory.GetCurrentDirectory() + "/array.txt";

            try
            {
                ArrayTools.WriteArrayToFile(array, arrayPath);

                Console.WriteLine("Чтение массива с диска. ");
                int[] fileArray = ArrayTools.GetArrayFromFile(arrayPath);

                Console.WriteLine("Считанный массив. ");
                ArrayTools.PrintArray(fileArray);

                Console.WriteLine("Количество пар {0}", 
                    ArrayTools.GetPairsCount(fileArray));

            }
            catch (ArrayToolsException ex)
            {
                Console.WriteLine(ex.Message);
                if (null != ex.InnerException)
                    Console.WriteLine(ex.InnerException.Message);
            }
            finally
            {
                if (File.Exists(arrayPath))
                    File.Delete(arrayPath);
            }

            CheckFileNotFoundException();

            Console.ReadKey();

        }

        static void CheckFileNotFoundException()
        {
            Console.WriteLine("\nДемонстрация обработки ситуации отсутствия " +
                "файла на диске.");

            string wrongPath = 
                Directory.GetCurrentDirectory() + "/FileNotFound.txt";

            try {
                int[] array = ArrayTools.GetArrayFromFile(wrongPath);
            }
            catch (ArrayToolsException ex)
            {
                Console.WriteLine(ex.Message);
                if (null != ex.InnerException)
                    Console.WriteLine(ex.InnerException.Message);
            }
        }
    }
}
