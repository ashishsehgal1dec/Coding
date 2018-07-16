using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace UBS.Code
{
    public class Library
    {
        private List<Person> objDataset ;

        public Library (List<Person> dataset)
        {
            objDataset = dataset;
        }

        public double GetAverageGrossSalary(string country, int age)
        {
            double avgGrossSalary;
            List<Person> persons;
            try
            {

                persons = new List<Person>();

                persons = (from person in objDataset
                           where person.Country == country && person.Age == age
                           select person).ToList();

                avgGrossSalary = persons.Average(s => s.GrossSalary);

                return avgGrossSalary;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public dynamic getAvgGrossSalPairs()
        {
            try
            {
                List<Person> lstPerson = new List<Person>();

                var result = objDataset.GroupBy(x => new { x.Country, x.Age })
                                        .Select(x => new
                                        {
                                            Country = x.Key.Country,
                                            Age = x.Key.Age,
                                            Average = x.Average(z => z.GrossSalary)
                                        }).ToList();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SetAverageGrossSalary(string Country, int Age, double grSal)
        {
            try
            {
                var items2 = objDataset.GroupBy(x => new { x.Country, x.Age })
                                        .Select(x => new
                                        {
                                            Country = x.Key.Country,
                                            Age = x.Key.Age,
                                            Average = (x.Key.Country == Country) && (x.Key.Age == Age) ? grSal : x.Average(z => z.GrossSalary)
                                        }).ToList();
                          
            }
            catch (Exception e)
            {
               
                throw;
            }
        }

        public void PrintResult( dynamic result)
        {
            List<int> allAges = new List<int>();
            List<string> allCountries = new List<string>();

            allAges = objDataset.Select(s => s.Age).Distinct().ToList();
            allCountries = objDataset.Select(s => s.Country).Distinct().ToList();

            allAges.Sort();
            allCountries.Sort();

            WriteInConsole("Average");

            foreach (int item in allAges)
            {
                WriteInConsole(item.ToString());
            }

            AddNewLineInConsole();

            foreach (String sCountry in allCountries)
            {
                WriteInConsole(sCountry);
                foreach (var item in result)
                {
                   if(item.Country == sCountry)
                    {                        
                        WriteInConsole(item.Average.ToString());
                    }
                }
                AddNewLineInConsole();              
            }
            
        }

        public void WriteInConsole (string input)
        {
            Console.Write(input + "\t");            
        }

        public void AddNewLineInConsole()
        {
            Console.WriteLine("");
        }

        public dynamic dynamicGrouping(string prop1, string prop2, string aggFunc)
        {
            try
            {
                List<Person> lstPerson = new List<Person>();
                
                if ((prop1 == "Country" && prop2 == "Age") || (prop2 == "Country" && prop1 == "Age"))
                {
                    switch (aggFunc.ToLower())
                    {
                       
                        case "average":
                             var result1 = objDataset.GroupBy(x => new { x.Country, x.Age })
                                        .Select(x => new
                                        {
                                            Country = x.Key.Country,
                                            Age = x.Key.Age,
                                            Average = x.Average(z => z.GrossSalary)
                                        }).ToList();
                            return result1;
                            
                        case "sum" :
                            var result2 = objDataset.GroupBy(x => new { x.Country, x.Age })
                                        .Select(x => new
                                        {
                                            Country = x.Key.Country,
                                            Age = x.Key.Age,
                                            Sum = x.Sum(z => z.GrossSalary)
                                        }).ToList();
                            return result2;

                        case "max":
                            var result3 = objDataset.GroupBy(x => new { x.Country, x.Age })
                                        .Select(x => new
                                        {
                                            Country = x.Key.Country,
                                            Age = x.Key.Age,
                                            Max = x.Max(z => z.GrossSalary)
                                        }).ToList();
                            return result3;

                        case "min":
                            var result4 = objDataset.GroupBy(x => new { x.Country, x.Age })
                                        .Select(x => new
                                        {
                                            Country = x.Key.Country,
                                            Age = x.Key.Age,
                                            Min = x.Min(z => z.GrossSalary)
                                        }).ToList();
                            return result4;

                        case "count":
                            var result5 = objDataset.GroupBy(x => new { x.Country, x.Age })
                                        .Select(x => new
                                        {
                                            Country = x.Key.Country,
                                            Age = x.Key.Age,
                                            Count = x.Count(z => z.GrossSalary > 0)
                                        }).ToList();
                            return result5;

                         default :
                            return null;
                    }

                }
                else if ((prop1 == "Country" && prop2 == "Gender") || (prop1 == "Gender" && prop2 == "Country"))
                {
                    switch (aggFunc.ToLower())
                    {

                        case "average":
                            var result1 = objDataset.GroupBy(x => new { x.Country, x.Gender })
                                       .Select(x => new
                                       {
                                           Country = x.Key.Country,
                                           Gender = x.Key.Gender,
                                           Average = x.Average(z => z.GrossSalary)
                                       }).ToList();
                            return result1;

                        case "sum":
                            var result2 = objDataset.GroupBy(x => new { x.Country, x.Gender })
                                        .Select(x => new
                                        {
                                            Country = x.Key.Country,
                                            Gender = x.Key.Gender,
                                            Sum = x.Sum(z => z.GrossSalary)
                                        }).ToList();
                            return result2;

                        case "max":
                            var result3 = objDataset.GroupBy(x => new { x.Country, x.Gender })
                                        .Select(x => new
                                        {
                                            Country = x.Key.Country,
                                            Gender = x.Key.Gender,
                                            Max = x.Max(z => z.GrossSalary)
                                        }).ToList();
                            return result3;

                        case "min":
                            var result4 = objDataset.GroupBy(x => new { x.Country, x.Gender })
                                        .Select(x => new
                                        {
                                            Country = x.Key.Country,
                                            Gender = x.Key.Gender,
                                            Min = x.Min(z => z.GrossSalary)
                                        }).ToList();
                            return result4;

                        case "count":
                            var result5 = objDataset.GroupBy(x => new { x.Country, x.Gender })
                                        .Select(x => new
                                        {
                                            Country = x.Key.Country,
                                            Gender = x.Key.Gender,
                                            Count = x.Count(z => z.GrossSalary > 0)
                                        }).ToList();
                            return result5;


                        default:
                            return null;
                    }
                }
                else if ((prop1 == "Age" && prop2 == "Gender") || (prop1 == "Gender" && prop2 == "Age"))
                {
                    var result = objDataset.GroupBy(x => new { x.Age, x.Gender })
                                       .Select(x => new
                                       {
                                           Age = x.Key.Age,
                                           Gender = x.Key.Gender,
                                           Average = x.Average(z => z.GrossSalary)
                                       }).ToList();

                    switch (aggFunc.ToLower())
                    {

                        case "average":
                            var result1 = objDataset.GroupBy(x => new { x.Age, x.Gender })
                                       .Select(x => new
                                       {
                                           Age = x.Key.Age,
                                           Gender = x.Key.Gender,
                                           Average = x.Average(z => z.GrossSalary)
                                       }).ToList();
                            return result1;

                        case "sum":
                            var result2 = objDataset.GroupBy(x => new { x.Age, x.Gender })
                                        .Select(x => new
                                        {
                                            Age = x.Key.Age,
                                            Gender = x.Key.Gender,
                                            Sum = x.Sum(z => z.GrossSalary)
                                        }).ToList();
                            return result2;

                        case "max":
                            var result3 = objDataset.GroupBy(x => new { x.Age, x.Gender })
                                        .Select(x => new
                                        {
                                            Age = x.Key.Age,
                                            Gender = x.Key.Gender,
                                            Max = x.Max(z => z.GrossSalary)
                                        }).ToList();
                            return result3;

                        case "min":
                            var result4 = objDataset.GroupBy(x => new { x.Age, x.Gender })
                                        .Select(x => new
                                        {
                                            Age = x.Key.Age,
                                            Gender = x.Key.Gender,
                                            Min = x.Min(z => z.GrossSalary)
                                        }).ToList();
                            return result4;

                        case "count":
                            var result5 = objDataset.GroupBy(x => new { x.Age, x.Gender })
                                        .Select(x => new
                                        {
                                            Age = x.Key.Age,
                                            Gender = x.Key.Gender,
                                            Count = x.Count(z => z.GrossSalary > 0)
                                        }).ToList();
                            return result5;


                        default:
                            return null;

                    }
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public  Person ReadToObject(string json)
        {
            Person deserializedPerson = new Person();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(deserializedPerson.GetType());
            deserializedPerson = serializer.ReadObject(ms) as Person;
            ms.Close();

            return deserializedPerson;
        }

        public string ConverttoJson(Person per)
        {
            MemoryStream ms = new MemoryStream();  
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));
            ser.WriteObject(ms, per);
            byte[] objjson = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(objjson, 0, objjson.Length);
        }
    }
}

