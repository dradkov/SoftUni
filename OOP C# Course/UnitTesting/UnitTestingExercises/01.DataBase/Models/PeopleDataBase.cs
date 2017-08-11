namespace _01.DataBase.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class PeopleDataBase : IEnumerable<Person>
    {
        private const int Capacity = 16;

        private Person[] peopleStorage;
        private int count;

        public PeopleDataBase(params Person[] items)
        {
            this.peopleStorage = new Person[Capacity];
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public int Count { get { return this.count; } }



        public void Add(Person person)
        {
            if (this.count == Capacity)
            {
                throw new InvalidOperationException("The Storage is Full");
            }
            if (PersonExist(person))
            {
                throw new InvalidOperationException("The Person Already Exist");
            }
            this.peopleStorage[this.count] = person;
            this.count++;


        }

        public Person Remove()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The Storage is Empty");
            }

            Person item = this.peopleStorage[this.count - 1];

            this.peopleStorage[this.count - 1] = default(Person);
            this.count--;
            return item;

        }

        public Person[] Fetch()
        {
            Person[] result = new Person[this.count];
            Array.Copy(this.peopleStorage, result, this.count);

            return result;

        }

        public Person FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(string.Empty, "Username cannot be empty!");
            }
            if (!PersonExist(username))
            {
                throw new InvalidOperationException("The Person doesn't exist");
            }
            return this.peopleStorage.First(p => p.UserName == username);
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(string.Empty, "Username cannot be negative!");
            }

            if (!PersonExist(id))
            {
                throw new InvalidOperationException("The Person doesn't exist");
            }
          

            return this.peopleStorage.First(p => p.Id == id);
        }

        private bool PersonExist(Person person)
        {
            if (this.count == 0)
            {
                return false;
            }
            return this.peopleStorage.Where(x => x != null).Any(p => p.Id == person.Id || p.UserName == person.UserName);
        }

        private bool PersonExist(string userName)
        {
            if (this.count == 0)
            {
                return false;
            }
            return this.peopleStorage.Where(x => x != null).Any(p => p.UserName == userName);
        }
        private bool PersonExist(long id)
        {
            if (this.count == 0)
            {
                return false;
            }
            return this.peopleStorage.Where(x => x != null).Any(p => p.Id == id);
        }

        public IEnumerator<Person> GetEnumerator()
        {
            for (int i = 0; i < this.count; i++)
            {
                yield return peopleStorage[i];

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


}
