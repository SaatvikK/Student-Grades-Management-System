/*using System;
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
    public static void writeToFile(string ID, string SchoolName, string city, string county, double NoStudents) {
      var jsonString = File.ReadAllText("info.json");
      dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
      if(result == null) {
        //List<jsonStudent> students = new List<jsonStudent>();
        jsonSchool InfoJson = addToList( ID, SchoolName, city, county, NoStudents);
        File.WriteAllText(@"students.json", JsonConvert.SerializeObject(InfoJson));

        // serialize JSON directly to a file
        using(StreamWriter file = File.CreateText(@"students.json")) {
          JsonSerializer serializer = new JsonSerializer();
          serializer.Serialize(file, InfoList);
        }
      } else {
        List<jsonStudent> schools = result.ToObject(typeof(List<school>));
        List<jsonStudent> InfoList = addToList(students, subjects, marks, fname, sname);
        File.WriteAllText(@"students.json", JsonConvert.SerializeObject(InfoList));

        // serialize JSON directly to a file
        using(StreamWriter file = File.CreateText(@"students.json")) {
          JsonSerializer serializer = new JsonSerializer();
          serializer.Serialize(file, InfoList);
        }
      }

      Console.WriteLine("Added user to database! Run `see [ID]` to see that student's information!");
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
}*/