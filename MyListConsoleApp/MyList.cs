namespace MyListConsoleApp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// My List.
    /// </summary>
    /// <typeparam name="T">Template.</typeparam>
    public class MyList<T> : IList<T>
    {
        private T[] myList;

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

        private void ArrayExpansion()
        {
            T[] tmpList = new T[this.Count * 2];
            for (int i = 0; i < this.Count; i++)
            {
                tmpList[i] = this.myList[i];
            }

            this.myList = tmpList;
        }

        /// <summary>
        /// Gets or Sets by index.
        /// </summary>
        /// /// <param name="index">number of index.</param>
        public T this[int index] { get => this.myList[index]; set => this.myList[index] = value; }

        /// <summary>
        /// Gets Count of elements.
        /// </summary>
        public int Count
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
        /// Add new element in collection.
        /// </summary>
        /// <param name="item">adding element.</param>
        public void Add(T item)
        {
            if (this.Count >= this.myList.Length)
            {
                this.ArrayExpansion();
            }

            this.myList[this.Count] = item;
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
            throw new NotImplementedException();
        }

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

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
