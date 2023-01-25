using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Student_Grades_Management_System {
  public class jsonSchool {
    public string SchoolName { get; set; }
    public string city { get; set; }
    public string county { get; set; }    
    public double NumStudents { get; set; }
  }

  public class school {
    public bool create() {
      // Getting school details via CLI user input
      Console.WriteLine("-> Name of school: ");
      string SchoolName = Console.ReadLine();
      Console.WriteLine("-> Name of city: ");
      string city = Console.ReadLine();
      Console.WriteLine("-> Name of county: ");
      string county = Console.ReadLine();
      int NumStudents;
      try { NumStudents = int.Parse(Console.ReadLine()); } catch(Exception) { 
        Console.WriteLine("Error! The amount of students MUST be an integer value!"); 
        return false; 
      }

      try {
        createDB(SchoolName);
      } catch { return false; }

      jsonSchool school = createObj(SchoolName, city, county, NumStudents);
      bool written = writeToFile(school, SchoolName);
      if(written) return true;
      else return false;
    }

    private static void createDB(string SchoolName) {
      if(Directory.Exists($"database/{SchoolName}")) {
        throw new InvalidOperationException("School already exists");
      } else {
        Directory.CreateDirectory($"database/{SchoolName}");
        using(FileStream fs = File.Create($"database/{SchoolName}/info.json")) {}
        using(FileStream fs = File.Create($"database/{SchoolName}/students.json")) {}
      }
    }
    public static bool writeToFile(jsonSchool schoolobj, string SchoolName) {

      File.WriteAllText(@$"database/{SchoolName}/info.json", JsonConvert.SerializeObject(schoolobj));

      // serialize JSON directly to a file
      using(StreamWriter file = File.CreateText(@$"database/{SchoolName}/info.json")) {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, schoolobj);
      }
      return true;
    }

    private static jsonSchool createObj(string school, string City, string County, double NoStudents) {
      Random rand = new Random();
      jsonSchool json = new jsonSchool {
        SchoolName = school,
        city = City,
        county = County,
        NumStudents = NoStudents
      };
      return json;
    }
  }
}