﻿using System;
namespace MP.ApiRedis
{
    public class Person
    {
        public Person(string name, string document)
        {
            Name = name;
            Document = document;
        }

        public string Name { get; private set; }
        public string Document { get; private set; }
    }
}

