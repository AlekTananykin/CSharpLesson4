using System;
using System.Collections.Generic;
using System.IO;



namespace Task2
{
    static class ArrayTools
    {
        public static int GetPairsCount(int[] array)
        {
            if (null == array || array.Length < 2)
                return 0;

            int pairsCount = 0;
            bool isPrevMod3 = IsAppropriateValue(array[0]);
            for (int i = 1; i < array.Length; ++i)
            {
                bool isCurrMod3 = IsAppropriateValue(array[i]);
                if (isPrevMod3 && !isCurrMod3 || !isPrevMod3 && isCurrMod3)
                    ++pairsCount;

                isPrevMod3 = isCurrMod3;
            }

            return pairsCount;
        }

        private static bool IsAppropriateValue(int a)
        {
            return 0 == a % 3 && 0 != a;
        }

        public static int[] GetArrayFromFile(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);
                if (0 == lines.Length)
                    return null;

                int[] array = new int[lines.Length];
                for (int i = 0; i < lines.Length; ++i)
                    array[i] = int.Parse(lines[i]);

                return array;
            }
            catch (FileNotFoundException fnfex)
            {
                throw new ArrayToolsException(
                    "Ошибка считывания массива из файла. " + 
                    "Файл не был найден. ",  fnfex);
            }
            catch (Exception ex)
            {
                throw new ArrayToolsException(
                    "Ошибка считывания массива из файла. ",  ex);
            }
        }

        public static void WriteArrayToFile(int[] array, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < array.Length; ++i)
                    sw.WriteLine(array[i]);
            }
        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
                Console.WriteLine("{0}", array[i]);
        }

        public static int[] GenerateArray(
            int minValue, int maxValue, int arraySize)
        {
            Random rnd = new Random();
            int[] array = new int[arraySize];

            for (int i = 0; i < array.Length; ++i)
                array[i] = rnd.Next(minValue, maxValue);

            return array;
        }
    }
}
