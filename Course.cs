using System;
public class Course
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
    public static List<Course> availableCourses = new List<Course>();

    public static void InitializeAvailableCourses()
    {
        availableCourses.Add(new Course { Id = 1, CourseName = "Bio" });
        availableCourses.Add(new Course { Id = 2, CourseName = "Che" });
        availableCourses.Add(new Course { Id = 3, CourseName = "Mts" });
    }

    static Course()
    {
        InitializeAvailableCourses();
    }



    public static void EnrollStudentInACourse()
    {


        Console.WriteLine("Enter student ID: ");
        string studentId = Console.ReadLine();
        var student = Student.students.FirstOrDefault(s => s.StudentID == studentId);
        if (student != null)
        {
            Console.WriteLine("Available courses:");
            int courseIndex = 1;
            foreach (var course in availableCourses)
            {
                Console.WriteLine($"{courseIndex}. {course.CourseName}");
                courseIndex++;
            }
            var selectedCourses = new List<Course>();

            Console.WriteLine("Enter course numbers separated by comma: ");
            string courseNumbers = Console.ReadLine();
            foreach (var courseNumber in courseNumbers.Split(','))
            {
                int courseId = Convert.ToInt32(courseNumber.Trim());
                if (courseId >= 1 && courseId <= availableCourses.Count)
                {
                    selectedCourses.Add(availableCourses[courseId - 1]);
                }
                else
                {
                    Console.WriteLine($"Invalid course number: {courseNumber}");
                }
            }
            // var selectedCourse = availableCourses.Where(c => courseIds.Contains(c.Id)).ToList();
            foreach (var item in selectedCourses)
            {
                student.Courses.Add(item);
                item.Students.Add(student);
                Console.WriteLine($"Student {student.StudentName} was enrolled in course : {item.CourseName} succesfully");
            }
        }
    }
    public void ViewAllCourse()
    {

        foreach (var item in availableCourses)
        {
            Console.WriteLine($"Course Id : {item.Id} Course Name : {item.CourseName}");

        }
    }
}
