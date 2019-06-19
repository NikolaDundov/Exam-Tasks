using System;

namespace Repository
{
    public class StartUp
    {
        public static void Main()
        {
            Person firstPerson = new Person("George", 10, new DateTime(2009, 05, 04));
            Person secondPerson = new Person("Peter", 5, new DateTime(2014, 05, 24));
            Person thirdPerson = new Person("Pesho", 23, new DateTime(2012, 05, 22));

            Repository myRepository = new Repository();
            myRepository.Add(firstPerson);
            myRepository.Add(secondPerson);

           

            Console.WriteLine(myRepository.Update(0, thirdPerson));
            Console.WriteLine(myRepository.Count);
            Console.WriteLine(myRepository.Update(0, secondPerson));
            Console.WriteLine(myRepository.Delete(0));
        }
    }
}
