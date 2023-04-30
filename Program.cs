using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(@"D:\Users\Maxim\Descktop\Новая папка\Students.dat", FileMode.Open)) // Открываем бинарный файл Student.dat
                {
                    Student[] students = (Student[])formatter.Deserialize(fs);
                    WriteStudents(students);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение: {ex.Message}");
            }
        }

        public static void WriteStudents(Student[] students) // Принимаем параметр - Student
        {
            var path = @"D:\Users\Maxim\Descktop\Новая папка";

            foreach (var student in students)
            {
                if (!Directory.Exists(path + @$"\{student.Group}"))
                {
                    Directory.CreateDirectory(path + @$"\{student.Group}");
                }

                using (StreamWriter writer = new StreamWriter(path + @$"\{student.Group}\Students.txt", true))
                {
                    writer.WriteLineAsync($"Student - {student.Name}, Birthday - {student.DateOfBirth}");
                }
            }
        }
    }

    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
