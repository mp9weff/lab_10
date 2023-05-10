using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace lab_10
{
    class Program
    {
        static void Main(string[] args)
        {
            // Створення екземпляра класу Person
            Person person = new Person("John", new DateTime(1990, 1, 1));

            // Створення екземпляра BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();

            // Серіалізуємо об'єкт у файл
            using (FileStream stream = new FileStream("person.bin", FileMode.Create))
            {
                formatter.Serialize(stream, person);
            }

            // Десеріалізація об'єкта з файлу
            using (FileStream stream1 = new FileStream("person.bin", FileMode.Open))
            {
                Person deserializedPerson = (Person)formatter.Deserialize(stream1);
                Console.WriteLine(deserializedPerson.ToString());
            }
        }
    }
}
