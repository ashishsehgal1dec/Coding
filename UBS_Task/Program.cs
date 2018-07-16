using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBS.Code;


namespace UBS_Task
{
    class Program
    {
        static void Main(string[] args)
        {
           
            List<Person> lstPersons = new List<Person>();

            lstPersons.Add(new Person(10, "PL", "M", 2000));
            lstPersons.Add(new Person(10, "UK", "F", 5000));

            lstPersons.Add(new Person(20, "UK", "F", 3000));
            lstPersons.Add(new Person(20, "PL", "M", 7000));

            lstPersons.Add(new Person(30, "PL", "M", 6000));
            lstPersons.Add(new Person(30, "UK", "F", 3000));

            lstPersons.Add(new Person(40, "PL", "M", 4000));
            lstPersons.Add(new Person(40, "UK", "F", 6000));

    
            Library objLib = new Library(lstPersons);

            var items1 = objLib.getAvgGrossSalPairs();

            objLib.PrintResult(items1);

            var items2 = objLib.dynamicGrouping("Country", "Age", "Average");
            
            double test = objLib.GetAverageGrossSalary("UK", 20);

            
        }
    }
}
