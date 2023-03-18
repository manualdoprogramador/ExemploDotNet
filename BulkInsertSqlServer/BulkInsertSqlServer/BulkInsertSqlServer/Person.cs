using System;
using Newtonsoft.Json;

namespace BulkInsertSqlServer
{
    public class Person
    {
        private Person() { }
        public Person(string document, string name)
        {
            Document = document;
            Name = name;
        }

        [JsonProperty(PropertyName = "cpf")]
        public string Document
        {
            get;
            private set;
        }

        [JsonProperty(PropertyName = "nome")]
        public string Name
        {
            get;
            private set;
        }
    }
}

