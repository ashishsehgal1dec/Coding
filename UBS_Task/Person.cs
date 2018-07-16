using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace UBS.Code
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public double GrossSalary { get; set; }
        
        public Person()
        {

        }

        public Person(int age, string country, string gender, double grsal)
        {
            Country = country;
            Age = age;
            Gender = gender;
            GrossSalary = grsal;
        }
    }
}
