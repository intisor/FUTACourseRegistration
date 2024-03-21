using System;
using System.Runtime.Intrinsics.Arm;

public class Program
{
    private static void Main(string[] args)
    {
       
        var course = new Course();
        bool stop = false;
        while (!stop)
        {
            Console.WriteLine("FUTA Course Registration System");
            Console.WriteLine("1. Register as a new Member");
            Console.WriteLine("2. View all Students");
            Console.WriteLine("3. View Available Courses");
            Console.WriteLine("4. Exit");
            Console.WriteLine("5. Enroll Student in a Course");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Enter your Choice");
            string choice = Console.ReadLine();

           switch (choice)
           {
             case "1":
                Student.AddStudent();
                break;
            case "2":
                Student.ViewAllStudent();
                break;
            case "3":
                course.ViewAllCourse();
                break;
            case "4":
                stop = true;
                break;
            case "5":
                 Course.EnrollStudentInACourse();
                break;
           }
        }
    }
}