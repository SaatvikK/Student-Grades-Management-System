using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Student_Grades_Management_System {
  public class jsonSchool {
    public string ID  { get; set; }
    public string SchoolName { get; set; }
    public string city { get; set; }
    public string county { get; set; }    
    public double NumStudents { get; set; }
  }

  public class school {
    public static bool createSchool() {
      Console.WriteLine("-> Name of School: ");
      string SchoolName = Console.ReadLine();
      Console.WriteLine("-> Name of City: ");
      string city = Console.ReadLine();
      
      return true;
    }
    public static void writeToFile(string ID, string SchoolName, string city, string county, string NumStudents) {
      if( new FileInfo("database/info.json").Length == 0) {
        createJSON(subjects, marks, fname, sname); // Nothing in json, do not try to read file.
      } else {
        appendJSON(subjects, marks, fname, sname); // Something in it, read file and append new data.
      }
      Console.WriteLine("Added user to database! Run `see [ID]` to see that student's information!");
    }

    private static void appendJSON(string[] subjects, double[] marks, string fname, string sname) {
      var jsonString = File.ReadAllText("database/students.json");
      dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
      List<jsonStudent> students = result.ToObject(typeof(List<jsonStudent>));
      List<jsonStudent> newList = addToList(students, subjects, marks, fname, sname);
      File.WriteAllText(@"database/students.json", JsonConvert.SerializeObject(newList));

      // serialize JSON directly to a file
      using(StreamWriter file = File.CreateText(@"database/students.json")) {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, newList);
      }      
    }

    private static void createJSON(string[] subjects, double[] marks, string fname, string sname) {
      //List<jsonStudent> students = new List<jsonStudent>();
      List<jsonStudent> newList = addToList(new List<jsonStudent>(), subjects, marks, fname, sname);
      File.WriteAllText(@"database/students.json", JsonConvert.SerializeObject(newList));

      // serialize JSON directly to a file
      using(StreamWriter file = File.CreateText(@"database/students.json")) {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, newList);
      }
    }

    private static jsonSchool addToList(string ID, string school, string City, string County, double NoStudents) {
      Random rand = new Random();
      jsonSchool json = new jsonSchool {
        ID = rand.Next(0, 1000000000).ToString(),
        SchoolName = school,
        city = City,
        county = County,
        NumStudents = NoStudents
      };
      return json;
    }
  }
}