using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using ServiceStack;

namespace AspCorePluSight.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

    }

    public enum Gender
    {
        Male,Female
    }
}

