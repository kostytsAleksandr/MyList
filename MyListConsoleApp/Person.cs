namespace MyListConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// class Person.
    /// </summary>
    public class Person : IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="lastName">Last Name.</param>
        /// <param name="age">Age.</param>
        public Person(string name, string lastName, int age)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Age = age;
        }

        /// <summary>
        /// Gets or Sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets Age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Comparing people.
        /// </summary>
        /// <param name="obj">Person for comparing.</param>
        /// <returns>1,-1,0.</returns>
        public int CompareTo(object obj)
        {
            Person p = obj as Person;
            if (this.Age > p.Age)
            {
                return 1;
            }
            else if (this.Age < p.Age)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
