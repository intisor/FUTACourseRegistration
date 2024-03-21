using System;
using System.Collections.Generic;
public  class Student 
{
   public string StudentName {get; set;}
   public string StudentID {get; set;} 
   private static int nextID = 1;
   public string Program {get; set;}
   public static List<Student> students = new List<Student>();
   public List<Course> Courses {get;set;} = new List<Course>();

   public Student()
   {
     
   }
   public static void AddStudent()
   {
      var student = new Student();
      Console.WriteLine("Input Student Name");
      student.StudentName = Console.ReadLine(); 
      Console.WriteLine("Input your Program in the School");
      student.Program = Console.ReadLine();
      student.StudentID = nextID++.ToString();
      students.Add(student);
      Console.WriteLine("Student Successfully Created");
   }
   public static void ViewAllStudent()
   {
        if (students == null)
        {
            Console.WriteLine("No students available.");
            return;
        }
      foreach (var item in students)
      {
         Console.WriteLine($"Student ID: {item.StudentID}, Student Name : {item.StudentName}");
      }  
   }
}