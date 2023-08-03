using System;
using System.Reflection;
namespace Assignment_22
{
    public class Program
    {
        public static void MapProperties(Source source, Destination destination)
        {
            Type sourceType = typeof(Source);
            Type destinationType = typeof(Destination);

            PropertyInfo[] sourceProperties = sourceType.GetProperties();
            PropertyInfo[] destinationProperties = destinationType.GetProperties();

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                PropertyInfo destinationProperty = Array.Find(destinationProperties,
                    p => p.Name == sourceProperty.Name && p.PropertyType == sourceProperty.PropertyType);

                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    object value = sourceProperty.GetValue(source);
                    destinationProperty.SetValue(destination, value);
                }
            }
        }

        static void Main(string[] args)
        {
            Source source = new Source
            {
                Name = "Vin Diesel",
                Age = 56,
               
            };

            Destination destination = new Destination
            {
                Occupation = "Actor",
                Email = "vin.diesel@example.com"
            };

            MapProperties(source, destination);

            Console.WriteLine("  Mapping Successful!!!");
            Console.WriteLine("=========================");
            Console.WriteLine("Name: " + destination.Name);
            Console.WriteLine("Age: " + destination.Age);
            Console.WriteLine("Occupation: " + destination.Occupation);
            Console.WriteLine("Email: " + destination.Email);

            Console.ReadKey();
        }



    }
}
