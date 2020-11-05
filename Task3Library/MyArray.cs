using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace Task3Library
{
    public class MyArray
    {
        int[] _array;

        public MyArray(int size)
        {
            _array = new int[size];
        }

        public MyArray(int size, int el)
        {
            _array = new int[size];
            for (int i = 0; i < size; ++i)
                _array[i] = el;
        }

        public MyArray(int size, int first, int step)
        {
            _array = new int[size];
            for (int i = 0, val = first; i < size; ++i, val += step)
                _array[i] = val;
        }

        public int Get(int pos)
        {
            return _array[pos];
        }

        public void Set(int pos, int value)
        {
            _array[pos] = value;
        }

        public int this[int pos]
        {
            get 
            {
                return _array[pos];
            }
            set 
            {
                _array[pos] = value;
            }
        }

        public int Length
        {
            get
            {
                return _array.Length;
            }
        }

        public int Max
        {
            get 
            {
                int max = _array[0];
                for (int i = 1; i < _array.Length; ++i)
                    if (_array[i] > max)
                        max = _array[i];

                return max;
            }
        }

        public int Min
        {
            get {
                int min = _array[0];
                for (int i = 1; i < _array.Length; ++i)
                    if (_array[i] < min)
                        min = _array[i];

                return min;
            }
        }

        public int MaxCount
        {
            get
            {
                int max = this.Max;
                int maxCount = 0;

                foreach (int el in _array)
                    if (max == el) ++ maxCount;

                return maxCount;
            }
        }

        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < _array.Length; ++i)
                    sum += _array[i];

                return sum;
            }
        }

        public MyArray Inverse()
        {
            MyArray inverseArray = new MyArray(_array.Length);
            for (int i = 0; i < inverseArray.Length; ++i)
                inverseArray[i] = -_array[i];

            return inverseArray;
        }

        public void Multi(int factor)
        {
            for (int i = 0; i < _array.Length; ++i)
                _array[i] *= factor;
        }

    }
}
