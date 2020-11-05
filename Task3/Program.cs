using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3Library;

/*Тананыкин 
 * а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, 
 * создающий массив определенного размера и заполняющий массив числами от 
 * начального значения с заданным шагом. Создать свойство Sum, которое возвращает 
 * сумму элементов массива, метод Inverse, возвращающий новый массив с 
 * измененными знаками у всех элементов массива (старый массив, остается 
 * без изменений),  метод Multi, умножающий каждый элемент массива на определённое
 * число, свойство MaxCount, возвращающее количество максимальных элементов. 
 * б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
 * е) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
 */
namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа, демонстрирующая работу с классом " +
                "массива MyArray, который объявлен в библиотеке классов " +
                "Task3Library. ");
            Console.WriteLine();

            const int arraySize = 23;
            const int firstElement = 2;
            const int step = 3;
            MyArray array = new MyArray(arraySize, firstElement, step);

            Console.WriteLine("\nМассив чисел");
            PrintMyArray(array);

            Console.WriteLine("\nРазмер массива: {0}", array.Length);
            Console.WriteLine("Максимальный элемент массива: {0}", array.Max);
            Console.WriteLine("Минимальный элемент массива: {0}", array.Min);
            Console.WriteLine("Количество максимальных элеметов: {0}", array.MaxCount);
            Console.WriteLine("Сумма элементов массива: {0}", array.Sum);

            Console.WriteLine("\nСоздан инвертированный массив:");
            MyArray inverseArray = array.Inverse();
            PrintMyArray(inverseArray);

            const int factor = 3;
            Console.WriteLine(
                "\nУмножение исходного массива на число \"{0}\"", factor);

            array.Multi(factor);
            PrintMyArray(array);

            Console.ReadKey();
        }

        private static void PrintMyArray(MyArray array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write("{0}\t", array[i]);
                if (0 == (i + 1) % 8)
                    Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
