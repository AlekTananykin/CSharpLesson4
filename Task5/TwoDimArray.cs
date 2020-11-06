using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class TwoDimArray
    {
        private int[,] _array;
        private readonly int _rows;
        private readonly int _columns;

        public TwoDimArray(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;

            _array = new int[_rows, _columns];
        }

        public TwoDimArray(string path)
        {
            try
            {
                using (StreamReader sw = new StreamReader(path))
                {
                    _rows = int.Parse(sw.ReadLine());
                    _columns = int.Parse(sw.ReadLine());
                    _array = new int[_rows, _columns];

                    for (int i = 0; i < _rows; ++i)
                        for (int j = 0; j < _columns; ++j)
                            _array[i, j] = int.Parse(sw.ReadLine());
                }
            }
            catch (Exception ex)
            {
                throw new TwoDimArrayException(
                    "Ошибка считывания массива из файла", ex);
            }
        }

        public TwoDimArray(int rows, int columns,
            int minValue, int maxValue)
        {
            _rows = rows;
            _columns = columns;

            _array = new int[_rows, _columns];

            Random rnd = new Random();
            for (int i = 0; i < _rows; ++i)
                for (int j = 0; j < _columns; ++j)
                    _array[i, j] = rnd.Next(minValue, maxValue);
        }



        public int Rows
        {
            get { return _rows; }
        }

        public int Columns
        {
            get { return _columns; }
        }

        public int this[int rowPos, int columnPos]
        {
            get
            {
                return _array[rowPos, columnPos];
            }
            set
            {
                _array[rowPos, columnPos] = value;
            }
        }

        public int Sum()
        {
            int sum = 0;
            foreach (int item in _array)
                sum += item;

            return sum;
        }

        public int Sum(int threshold)
        {
            int sum = 0;
            foreach (int item in _array)
            {
                if (item > threshold)
                    sum += item;
            }
            return sum;
        }

        public int Min
        {
            get
            {
                int min = _array[0, 0];
                foreach (int item in _array)
                {
                    if (item < min)
                        min = item;
                }

                return min;
            }
        }

        public int Max
        {
            get
            {
                int max = _array[0, 0];
                foreach (int item in _array)
                {
                    if (item > max)
                        max = item;
                }

                return max;
            }
        }

        public void GetMaxItemPos(ref int maxRow, ref int maxColumn)
        {
            int max = _array[0, 0];
            for (int i = 0; i < _rows; ++i)
                for (int j = 0; j < _columns; ++j)
                {
                    int item = _array[i, j];
                    if (max < item)
                    {
                        max = item;
                        maxRow = i;
                        maxColumn = j;
                    }
                }
        }

        public static TwoDimArray ReadArrayFromFile(string path)
        {
            try
            {
                using (StreamReader sw = new StreamReader(path))
                {
                    int numRows = int.Parse(sw.ReadLine());
                    int numColumns = int.Parse(sw.ReadLine());

                    TwoDimArray array = new TwoDimArray(numRows, numColumns);

                    for (int i = 0; i < numRows; ++i)
                        for (int j = 0; j < numColumns; ++j)
                            array[i, j] = int.Parse(sw.ReadLine());

                    return array;
                }
            }
            catch (Exception ex)
            {
                throw new TwoDimArrayException(
                    "Ошибка считывания массива из файла", ex);
            }
        }

        public static void WriteArrayToFile(TwoDimArray array, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(array.Rows);
                    sw.WriteLine(array.Columns);
                    for (int i = 0; i < array.Rows; ++i)
                        for (int j = 0; j < array.Columns; ++j)
                            sw.WriteLine(array[i, j]);
                }
            }
            catch (Exception ex)
            {
                throw new TwoDimArrayException(
                   "Ошибка зсписи массива в файл", ex);
            }
        }
    }
}
