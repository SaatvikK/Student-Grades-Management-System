using System;
using System.IO;

namespace Student_Grades_Management_System {
  class main {
    static void Main(string[] args){
      Console.WriteLine("Starting...");
      Console.WriteLine("Welcome to SGMS, or the Student Grades Management System...");
      Console.WriteLine("Run `help` to see different commands that can be ran!");
      Console.Write("SGMS $");
      string input = Console.ReadLine();
      string[] ArgsArr = input.Split(" "); //command = args[0]

      //Command Handler
      switch(args[0]) {
        case "addstudent":
          student newStudent = new student();
          newStudent.addMarks();
      }
    }
  }
}
