namespace MyListConsoleApp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// My List.
    /// </summary>
    /// <typeparam name="T">Template.</typeparam>
    public class MyList<T> : IList<T>, IEnumerator
    {
        private T[] myList;
        private int index;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyList{T}"/> class.
        /// </summary>
        public MyList()
        {
            this.myList = new T[2];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyList{T}"/> class.
        /// </summary>
        /// <param name="item">Template item.</param>
        public MyList(T item)
        {
            this.myList = new T[2];
            this.myList[0] = item;
        }

        private T[] ArrayExpansion()
        {
            T[] tmpList = new T[this.Count * 2];
            for (int i = 0; i < this.Count; i++)
            {
                tmpList[i] = this.myList[i];
            }

            this.myList = tmpList;
            return this.myList;
        }

        /// <summary>
        /// Gets or Sets by index.
        /// </summary>
        /// /// <param name="index">number of index.</param>
#pragma warning disable SA1201 // Elements should appear in the correct order
        public T this[int index] { get => this.myList[index]; set => this.myList[index] = value; }
#pragma warning restore SA1201 // Elements should appear in the correct order

        /// <summary>
        /// Gets Count of elements.
        /// </summary>
#pragma warning disable SA1201 // Elements should appear in the correct order
        public int Count
#pragma warning restore SA1201 // Elements should appear in the correct order
        {
            get
            {
                int count = 0;
                for (int i = 0; i < this.myList.Length; i++)
                {
                    if (this.myList[i] != null)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }

                return count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether gets info about Readonly collection.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets Current item.
        /// </summary>
        public object Current
        {
            get
            {
                return this.myList[this.index];
            }
        }

        /// <summary>
        /// Add new element in collection.
        /// </summary>
        /// <param name="item">adding element.</param>
        public void Add(T item)
        {
            this.index = this.Count;
            if (this.Count >= this.myList.Length)
            {
                this.ArrayExpansion();
            }

            this.myList[this.index] = item;
        }

        /// <summary>
        /// Add new element in collection.
        /// </summary>
        /// <param name="array">adding collection.</param>
        public void AddRange(T[] array)
        {
            if (this.Count + array.Length < this.myList.Length)
            {
                for (int i = this.Count; i < this.Count + array.Length; i++)
                {
                    for (int j = 0; j < array.Length; j++)
                    {
                        this.myList[i] = array[j];
                    }
                }
            }
            else
            {
                T[] tmpList = new T[this.Count + array.Length];
                for (int i = 0; i < this.Count; i++)
                {
                    tmpList[i] = this.myList[i];
                }

                for (int i = this.Count; i < tmpList.Length; i++)
                {
                    for (int j = 0; j < array.Length; j++)
                    {
                        tmpList[i] = array[j];
                    }
                }

                this.myList = tmpList;
            }
        }

        /// <summary>
        /// Clear collection.
        /// </summary>
        public void Clear()
        {
            this.myList = new T[2];
        }

        /// <summary>
        /// Gets info Conains item in collection or no.
        /// </summary>
        /// <param name="item">Template item.</param>
        /// <returns>true or false.</returns>
        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.myList[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Copy items to array after index.
        /// </summary>
        /// <param name="array">name of array.</param>
        /// <param name="arrayIndex">index.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = arrayIndex; i < arrayIndex + this.Count; i++)
            {
                array[i] = this.myList[i - arrayIndex];
            }
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return IEnumerator<T>;
        }v

        /// <summary>
        /// Returns index of first found element.
        /// </summary>
        /// <param name="item">Template item.</param>
        /// <returns>index of first found element.</returns>
        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.myList[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Inserting item on index.
        /// </summary>
        /// <param name="index">index for inserting.</param>
        /// <param name="item">item for inserting.</param>
        public void Insert(int index, T item)
        {
            if (this.Count >= this.myList.Length)
            {
                this.ArrayExpansion();
            }

            for (int i = this.Count; i > index;)
            {
                this.myList[i] = this.myList[--i];
            }

            this.myList[index] = item;
        }

        /// <summary>
        /// If this element was found in collection and deleted.
        /// </summary>
        /// <param name="item">Template item.</param>
        /// <returns>true or false.</returns>
        public bool Remove(T item)
        {
            int index = 0;
            bool isFound = false;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.myList[i].Equals(item))
                {
                    index = i;
                    isFound = true;
                }
            }

            for (int i = index; i < this.Count - 1;)
            {
                this.myList[i] = this.myList[++i];
            }

            return isFound;
        }

        /// <summary>
        /// Remove element by index.
        /// </summary>
        /// <param name="index">index of item.</param>
        public void RemoveAt(int index)
        {
            for (int i = index; i < this.Count - 1;)
            {
                this.myList[i] = this.myList[++i];
            }
        }

        /// <summary>
        /// Sorting.
        /// </summary>
        public void Sort()
        {
            Array.Sort(this.myList);
        }

        /// <summary>
        /// If Move Next.
        /// </summary>
        /// <returns>bool Move Next.</returns>
        public bool MoveNext()
        {
            if (this.index < this.myList.Length - 1)
            {
                this.index++;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Resset index.
        /// </summary>
        public void Reset()
        {
            this.index = -1;
        }
    }
}
