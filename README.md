# FUTA Course Registration System

A console-based course registration system designed for the Federal University of Technology, Akure (FUTA). This application provides a simple yet effective interface for managing student registrations and course enrollments.

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Architecture](#architecture)
- [Menu Options](#menu-options)
- [Data Model](#data-model)
- [Contributing](#contributing)
- [Future Enhancements](#future-enhancements)
- [License](#license)

## Overview

The FUTA Course Registration System is a command-line application that streamlines the student registration and course enrollment process. Built with C# and .NET 8.0, it demonstrates fundamental object-oriented programming concepts including classes, inheritance, collections, and user interaction through a console interface.

This system is particularly useful for educational institutions that need a lightweight, easy-to-deploy solution for managing basic student information and course assignments without the overhead of a full-featured web application or database system.

## Features

### Core Functionality
- **Student Registration**: Add new students to the system with unique identification
- **Student Management**: View all registered students with their details
- **Course Catalog**: Browse available courses in the system
- **Course Enrollment**: Enroll students in multiple courses simultaneously
- **Interactive Menu**: User-friendly console interface for all operations
- **In-Memory Storage**: Fast data access using in-memory collections

### Technical Features
- Auto-incrementing student IDs for unique identification
- Many-to-many relationship between students and courses
- Input validation and error handling
- Real-time feedback for all operations
- Supports multiple course enrollments in a single transaction

## Technology Stack

- **Language**: C# 10.0+
- **Framework**: .NET 8.0
- **Runtime**: .NET Core
- **IDE Compatibility**: Visual Studio 2022, Visual Studio Code, Rider
- **Platform**: Cross-platform (Windows, macOS, Linux)

## Prerequisites

Before running this application, ensure you have the following installed:

- **.NET 8.0 SDK** or later
  - Download from: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
  - Verify installation: `dotnet --version`

## Installation

### Clone the Repository

```bash
git clone https://github.com/intisor/FUTACourseRegistration.git
cd FUTACourseRegistration
```

### Build the Project

```bash
dotnet build
```

This will:
- Restore NuGet packages
- Compile the source code
- Generate executable files in `bin/Debug/net8.0/`

### Run the Application

```bash
dotnet run
```

Alternatively, you can run the compiled executable directly:

**Windows:**
```bash
.\bin\Debug\net8.0\FUTACR.exe
```

**Linux/macOS:**
```bash
./bin/Debug/net8.0/FUTACR
```

## Usage

### Starting the Application

When you run the application, you'll see the main menu:

```
FUTA Course Registration System
1. Register as a new Member
2. View all Students
3. View Available Courses
4. Exit
5. Enroll Student in a Course
-------------------------------------
Enter your Choice
```

### Example Workflow

#### 1. Register a New Student

```
Enter your Choice: 1
Input Student Name: John Doe
Input your Program in the School: Computer Science
Student Successfully Created
```

The system automatically assigns a unique ID (starting from 1) to each new student.

#### 2. View All Students

```
Enter your Choice: 2
Student ID: 1, Student Name: John Doe
Student ID: 2, Student Name: Jane Smith
```

#### 3. View Available Courses

```
Enter your Choice: 3
Course Id: 1 Course Name: Bio
Course Id: 2 Course Name: Che
Course Id: 3 Course Name: Mts
```

The system comes pre-configured with three courses:
- **Bio** - Biology
- **Che** - Chemistry
- **Mts** - Mathematics

#### 4. Enroll a Student in Courses

```
Enter your Choice: 5
Enter student ID: 1
Available courses:
1. Bio
2. Che
3. Mts
Enter course numbers separated by comma: 1,3
Student John Doe was enrolled in course: Bio successfully
Student John Doe was enrolled in course: Mts successfully
```

#### 5. Exit the Application

```
Enter your Choice: 4
```

## Project Structure

```
FUTACourseRegistration/
├── Program.cs           # Main entry point and menu system
├── Student.cs           # Student class and student management logic
├── Course.cs            # Course class and enrollment logic
├── Registration.cs      # Registration class (placeholder for future use)
├── FUTACR.csproj        # Project configuration file
├── FUTACR.sln           # Solution file
├── .editorconfig        # Editor configuration
├── .gitignore           # Git ignore rules
└── README.md            # This file
```

### File Descriptions

#### Program.cs
The main entry point of the application. Contains:
- Main method that initializes the application
- Menu system with a while loop for continuous operation
- Switch-case statement for routing user choices
- Integration of Student and Course operations

#### Student.cs
Manages student-related functionality:
- **Properties**: `StudentName`, `StudentID`, `Program`, `Courses`
- **Static Members**: `students` list, `nextID` counter
- **Methods**: 
  - `AddStudent()`: Registers new students
  - `ViewAllStudent()`: Displays all registered students

#### Course.cs
Handles course management and enrollment:
- **Properties**: `Id`, `CourseName`, `Students`
- **Static Members**: `availableCourses` list
- **Methods**:
  - `InitializeAvailableCourses()`: Pre-loads system courses
  - `EnrollStudentInACourse()`: Handles student enrollment
  - `ViewAllCourse()`: Lists all available courses

#### Registration.cs
Currently a placeholder class for future registration-specific logic.

## Architecture

### Design Patterns

The application follows several design principles:

1. **Object-Oriented Design**: Proper encapsulation with classes representing real-world entities
2. **Static Factory Pattern**: Course initialization using static constructor
3. **Repository Pattern**: Static collections acting as in-memory repositories
4. **Separation of Concerns**: Each class handles its own domain logic

### Data Flow

```
User Input → Program.Main (Router) → Domain Classes (Student/Course) → In-Memory Storage → Console Output
```

### Class Relationships

```
Student ←→ Course (Many-to-Many)
  ↓          ↓
Courses    Students
(List)     (List)
```

Each student can enroll in multiple courses, and each course can have multiple students enrolled.

## Menu Options

| Option | Description | Implementation |
|--------|-------------|----------------|
| 1 | Register as a new Member | Creates a new student with auto-generated ID |
| 2 | View all Students | Displays all registered students |
| 3 | View Available Courses | Shows the course catalog |
| 4 | Exit | Terminates the application |
| 5 | Enroll Student in a Course | Links students to courses |

## Data Model

### Student Entity

```csharp
public class Student 
{
    public string StudentName { get; set; }
    public string StudentID { get; set; }
    public string Program { get; set; }
    public List<Course> Courses { get; set; }
    public static List<Student> students { get; set; }
}
```

**Fields:**
- `StudentName`: Full name of the student
- `StudentID`: Unique identifier (auto-incremented)
- `Program`: Academic program/major
- `Courses`: List of enrolled courses
- `students`: Global collection of all students

### Course Entity

```csharp
public class Course
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public List<Student> Students { get; set; }
    public static List<Course> availableCourses { get; set; }
}
```

**Fields:**
- `Id`: Unique course identifier
- `CourseName`: Name of the course
- `Students`: List of enrolled students
- `availableCourses`: Global collection of all courses

## Contributing

Contributions are welcome! Here's how you can help:

### Getting Started
1. Fork the repository
2. Create a feature branch: `git checkout -b feature/YourFeature`
3. Make your changes
4. Commit with clear messages: `git commit -m 'Add: YourFeature'`
5. Push to your fork: `git push origin feature/YourFeature`
6. Open a Pull Request

### Coding Standards
- Follow C# naming conventions (PascalCase for public members)
- Add XML documentation comments for public APIs
- Maintain consistent indentation (4 spaces)
- Write self-documenting code with meaningful variable names
- Handle edge cases and validate user input

### Areas for Contribution
- Add unit tests for core functionality
- Implement data persistence (file/database storage)
- Add course prerequisites and capacity limits
- Implement student grade management
- Create a web API interface
- Add authentication and authorization
- Improve error handling and validation
- Internationalization support

## Future Enhancements

### Short-term Goals
- [ ] Add data persistence using JSON/XML files
- [ ] Implement course capacity limits
- [ ] Add student search functionality
- [ ] Enhanced input validation
- [ ] Course prerequisites system
- [ ] Generate enrollment reports

### Long-term Goals
- [ ] Database integration (SQL Server/PostgreSQL)
- [ ] Web-based interface using ASP.NET Core
- [ ] RESTful API development
- [ ] Student grade management
- [ ] Academic calendar integration
- [ ] Email notifications for enrollments
- [ ] Multi-semester support
- [ ] Faculty assignment to courses
- [ ] Course scheduling with time slots
- [ ] Student transcript generation
- [ ] Payment integration for course fees

### Technical Improvements
- [ ] Unit testing with xUnit/NUnit
- [ ] Logging framework integration
- [ ] Dependency injection
- [ ] Configuration management
- [ ] Docker containerization
- [ ] CI/CD pipeline setup
- [ ] API documentation with Swagger

## License

This project is available for educational purposes. Feel free to use, modify, and distribute as needed for learning and development.

---

**Developed for**: Federal University of Technology, Akure (FUTA)  
**Repository**: [https://github.com/intisor/FUTACourseRegistration](https://github.com/intisor/FUTACourseRegistration)  
**Version**: 1.0.0  
**.NET Version**: 8.0

For questions, issues, or suggestions, please open an issue on the GitHub repository.