using System;
using System.Collections.Generic;

namespace TestCSharp.Question3
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }

        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - BirthDate.Year;
                if (BirthDate.Date > DateTime.Now.AddYears(-age)) age--;
                return age;
            }
        }

        public Person(int id, string name, DateTime birthDate)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
        }
    }

    public static class PersonManager
    {
        private static Dictionary<int, Person> DB { get; set; }
        private static int nextPersonId = 1;

        static PersonManager()
        {
            DB = new Dictionary<int, Person>();
        }

        public static Person AddPerson(string name, DateTime birthDate)
        {
            try
            {               
                if (String.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Invalid name.");
                }

                if (birthDate > DateTime.Now)
                {
                    throw new ArgumentException("Invalid birth date.");
                }

                Person p = new Person(nextPersonId, name, birthDate);
                DB.Add(nextPersonId++, p);
                return p;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool DeletePerson(int id)
        {
            try
            {
                return DB.Remove(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int GetPersonCount()
        {
            return DB.Count;
        }
    }
}
