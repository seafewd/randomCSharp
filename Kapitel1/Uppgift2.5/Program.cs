using System;
using System.Collections.Generic;

namespace Uppgift2._5
{
    public class Program
    {
        static void Main(string[] args)
        {
            // create school
            School gu = new School();

            // create students
            Student student4 = new Student(new DateTime(2020, 12, 25), "MustardKing", 25, gu);
            Student student3 = new Student(new DateTime(2021, 02, 02), "AyKay", 29, gu);
            Student student1 = new Student(new DateTime(2021, 03, 02), "Alex", 30, gu);
            Student student8 = new Student(new DateTime(2021, 03, 02), "Alex", 33, gu);
            Student student2 = new Student(new DateTime(2021, 01, 30), "Robin", 33, gu);
            Student student5 = new Student(new DateTime(2019, 06, 19), "Kaninchen", 31, gu);
            Student student6 = new Student(new DateTime(2009, 11, 11), "SaladSnack", 18, gu);

            // list students
            Console.WriteLine("Students i order of creation:");

            // sort after date created
            gu.Students.Sort();
            foreach (Student s in gu.Students)
                Console.WriteLine(s.Name + ", Age: " + s.Age + ", Date created: " + s.DateCreated);

            Console.WriteLine("\n-----------\n");

            // list in alphabetical order
            Console.WriteLine("Students in descending alphabetical order:");
            gu.Students.Sort(new DescendingNameComparer());
            foreach (Student s in gu.Students)
                Console.WriteLine(s.Name + ", Age: " + s.Age + ", Date created: " + s.DateCreated);
        }
    }

    /// <summary>
    /// School to hold Students
    /// </summary>
    public class School
    {
        private List<Student> students = new List<Student>();

        public List<Student> Students
        {
            get { return students; }
            set { }

        }
    }

    /// <summary>
    /// Student
    /// </summary>
    public class Student : IComparable<Student>
    {
        private string name;
        private int age;
        private DateTime dateCreated;

        public Student(DateTime dateCreated, string name, int age, School school)
        {
            this.name = name;
            this.age = age;
            this.dateCreated = dateCreated;
            school.Students.Add(this);
        }

        // CompareTo - sort after date created
        int IComparable<Student>.CompareTo(Student other)
        {
            return this.DateCreated.CompareTo(other.DateCreated);
        }

        public string Name
        {
            get { return name; } 
            set { }
        }
        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { }
        }

        public int Age
        { 
            get { return age; } 
            set { }
        }
    }

    /// <summary>
    /// Comparer, compares Names alphabetically
    /// </summary>
    public class DescendingNameComparer : IComparer<Student>
    {
        public int Compare(Student a, Student b)
        {
            // sort after age if names are identical
            if (a.Name == b.Name)
                return a.Age.CompareTo(b.Age);

            // prepare char arrays for both names
            char[] first = a.Name.ToString().ToCharArray();
            char[] second = b.Name.ToString().ToCharArray();
            int index = 0;

            // loop through each element in 1st char array and compare with each element in 2nd
            foreach (char c in first) {
                if (c > second[index++])
                    return 1;
                else if (c < second[index++])
                    return -1;
            }
            return 0;
        }
    }
}
