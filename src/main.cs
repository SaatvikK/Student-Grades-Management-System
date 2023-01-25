using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Student_Grades_Management_System {
  class globals { 
    public string[] ArgsArr;
  }

  class main {
    static void Main(string[] args) {
      globals globs = new globals();
      Console.WriteLine("Starting...");
      Console.WriteLine("Welcome to SGMS, or the Student Grades Management System...");
      Console.WriteLine("Run `help` to see different commands that can be ran!");
      
      while(true) {
        Console.Write("SGMS $");
        string input = Console.ReadLine();
        globs.ArgsArr = input.Split(" "); //command = args[0]

        //Command Handler
        switch(globs.ArgsArr[0]) {
          case "addstudent":
            student newStudent = new student();
            newStudent.addMarks();
          break;
          
          case "see":
            if( new FileInfo("database/students.json").Length > 0) {
              var jsonString = File.ReadAllText("../database/students.json");
              dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
              Console.WriteLine(result[0]);
              for(int i = 0; i < result.Count; i++) {
                if(result[i]["ID"] == globs.ArgsArr[1]) {
                  Console.WriteLine("====== " + result[i]["FirstName"].ToObject(typeof(string)).ToUpper() + " " + result[i]["SurName"].ToObject(typeof(string)).ToUpper() + " ======");
                  Console.WriteLine("Student ID: " + result[i]["ID"]);
                  Console.WriteLine("SUBJECTS:");
                  for(int j = 0; j < result[i]["subjects"].Count; j++) {
                    Console.WriteLine("|| " + result[i]["subjects"][j] + ": " + result[i]["marks"][j].ToString() + " marks.");
                  }
                  Console.WriteLine("==============");
                  return;
                }
              }
              Console.WriteLine("No student with that ID was found.");
            } else {
              Console.WriteLine("SGMS database empty! To add a student, run `addstudent`.");
            }
          break;
          
          case "seeids":
            if( new FileInfo("database/students.json").Length > 0) {
              var jsonString2 = File.ReadAllText("database/students.json");
              dynamic results = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString2);
                for(int i = 0; i < results.Count; i++) {
                  Console.WriteLine(results[i]["FirstName"].ToObject(typeof(string)).ToUpper() + " " + results[i]["SurName"].ToObject(typeof(string)).ToUpper() + ": " + results[i]["ID"]);
                }
              Console.WriteLine("===========================");
            } else {
              Console.WriteLine("SGMS database empty! To add a student, run `addstudent`.");
            }
          break;
          
          case "help":
            Console.WriteLine("=== COMMANDS ===");
            Console.WriteLine("`addstudent` - Adds a student to the database.");
            Console.WriteLine("`seeids` - Outputs all student IDs.");
            Console.WriteLine("`see [id]` - Outputs information of a specific student given their ID.");
          break;
          
          case "exit":
            Console.WriteLine("CRTL + C to close.");

          break;

          default:
            Console.WriteLine("That is not a valid command! Run `help` to see a list of commands.");
            break;
        }
      }
    }
  }
}
