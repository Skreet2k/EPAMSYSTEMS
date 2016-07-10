using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    /// <summary>
    ///     Динамический массив с запасом.
    /// </summary>
    internal class DynamicArray<T> : IEnumerable<T>
    {
        protected T[] Items;

        /// <summary>
        ///     Конструктор по умолчанию. Создает пустой массив с емкостью по умолчанию.
        /// </summary>
        public DynamicArray()
        {
            int defaultCapacity;
            if (CustomSection.IntDefaultCapacity.DefaultValue != null)
                defaultCapacity = (int) CustomSection.IntDefaultCapacity.DefaultValue;
            else
                defaultCapacity = 8;
            Items = new T[defaultCapacity];
        }

        /// <summary>
        ///     Конструктор инициализирует массив с заданной емкостью.
        /// </summary>
        /// <param name="capacity">Эмкость массива.</param>
        public DynamicArray(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException();
            Items = new T[capacity];
        }

        /// <summary>
        ///     Создает массив из элементов коллекции collection.
        /// </summary>
        /// <param name="collection">Коллекция.</param>
        public DynamicArray(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();
            var c = collection as T[] ?? collection.ToArray();
            Items = c;
            Length = c.Count();
        }

        /// <summary>
        ///     Индексатор, позволяющий работать с элементом с указанным номером.
        /// </summary>
        /// <param name="index">Индекс элемента.</param>
        public T this[int index]
        {
            get
            {
                if (index >= Length || index < 0)
                    throw new ArgumentOutOfRangeException();
                return Items[index];
            }
            set
            {
                if (index >= Length || index < 0)
                    throw new ArgumentOutOfRangeException();
                Items[index] = value;
            }
        }

        /// <summary>
        ///     Емкость массива.
        /// </summary>
        public int Capacity
        {
            get { return Items.Length; }
            set
            {
                if (value < Length || value <= 0)
                    throw new ArgumentException();
                if (value == Length)
                    return;
                var array = new T[value];
                if (Length > 0)
                {
                    Array.Copy(Items, 0, array, 0, Length);
                    Items = array;
                }
                else
                {
                    Items = array;
                }
            }
        }

        /// <summary>
        ///     Количество элементов в массиве.
        /// </summary>
        public int Length { get; private set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <summary>
        ///     Возвращает перечислитель, осуществляющий перебор элементов списка.
        /// </summary>
        /// <returns>Новый объект Enumerator для DynamicArray.</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <summary>
        ///     Возвращает Enumerator.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <summary>
        ///     Добавляет итем в конец коллекции.
        /// </summary>
        public void Add(T item)
        {
            if (Capacity == Items.Length)
                IncreaseCapacity(Length + 1);
            Items[Length] = item;
            Length++;
        }

        /// <summary>
        ///     Добавляет в конец массива элементы коллекции.
        /// </summary>
        /// <returns>Возвращает true, если операция прошла успешно.</returns>
        public bool AddRange(IEnumerable<T> collection)
        {
            bool isSuccessfully;
            try
            {
                var c = collection as T[] ?? collection.ToArray();
                if (Length + c.Length > Items.Length)
                    IncreaseCapacity(Length + c.Length);
                Array.Copy(c, 0, Items, Length, c.Length);
                Length += c.Length;
                isSuccessfully = true;
            }
            catch (Exception)
            {
                isSuccessfully = false;
            }
            return isSuccessfully;
        }

        private void IncreaseCapacity(int newCapacity)
        {
            var factorCapacity = newCapacity%Items.Length == 0
                ? newCapacity/Items.Length
                : newCapacity/Items.Length + 1;
            Capacity = Items.Length*factorCapacity;
        }

        /// <summary>
        ///     Добавляет итем на указанную позицию.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index">Индекс ячейки массива.</param>
        public void Insert(T item, int index)
        {
            if (index < 0 || index >= Length)
                throw new ArgumentOutOfRangeException();
            if (Capacity == Items.Length)
                IncreaseCapacity(Length + 1);
            Array.Copy(Items, index, Items, index + 1, Length - index);
            Items[index] = item;
            Length++;
        }

        /// <summary>
        ///     Удаляет итем с указанным индексом.
        /// </summary>
        /// <param name="index">Индекс ячейки массива.</param>
        /// <returns>Возвращает true, если операция прошла успешно.</returns>
        public bool Remove(int index)
        {
            bool isSuccessfully;
            try
            {
                Array.Copy(Items, index + 1, Items, index, Length - index);
                Length--;
                isSuccessfully = true;
            }
            catch (Exception)
            {
                isSuccessfully = false;
            }
            return isSuccessfully;
        }

        /// <summary>
        ///     Реализация интерфейса IEnumerator<T />.
        /// </summary>
        public struct Enumerator : IEnumerator<T>
        {
            private readonly DynamicArray<T> _array;
            private int _index;

            public T Current { get; private set; }

            object IEnumerator.Current
            {
                get
                {
                    if (_index == 0 || _index == _array.Length + 1)
                        throw new ArgumentOutOfRangeException();
                    return Current;
                }
            }

            internal Enumerator(DynamicArray<T> array)
            {
                _array = array;
                _index = 0;
                Current = default(T);
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                var objArray = _array;
                if (_index >= objArray.Length)
                    return MoveNextRare();
                Current = objArray.Items[_index];
                _index = _index + 1;
                return true;
            }

            private bool MoveNextRare()
            {
                _index = _array.Length + 1;
                Current = default(T);
                return false;
            }

            void IEnumerator.Reset()
            {
                _index = 0;
                Current = default(T);
            }
        }
    }
}