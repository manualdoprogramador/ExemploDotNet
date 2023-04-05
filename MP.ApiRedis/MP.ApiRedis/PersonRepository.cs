using System;
namespace MP.ApiRedis
{
    public class PersonRepository
    {
        public PersonRepository()
        {
        }

        public List<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person("Maria","88759602163"),
                new Person("Gustavo","53662184893"),
                new Person("Pedro","12938562900"),
                new Person("Joao","16882219214"),
                new Person("Alex","17271653147"),
                new Person("Ana Paula","52226367632"),
                new Person("Lilian","71618340662"),
                new Person("Ricardo","51709436875"),
                new Person("Rafaela","33781361381"),
                new Person("Fernanda","84726998978"),
                new Person("Otavio","85454813222")
            };
        }
    }
}

