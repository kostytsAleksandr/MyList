namespace MyListConsoleApp
{
    using System;

    /// <summary>
    /// Class for starting program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Point inputs to program.
        /// </summary>
        /// <param name="args">params.</param>
        private static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            list.Add(7);
            list.Add(77);
            list.Add(75);
            list.Add(72);
            list.Add(17);
            list.Add(77777);
            list.Sort();
            int[] arr = new int[4] { 23, 456, 765, 2 };

            list.AddRange(arr);
            list.Remove(23);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].ToString());
            }
        }
    }
}