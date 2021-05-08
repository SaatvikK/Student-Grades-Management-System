using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Student_Grades_Management_System {
  public class jsonStudent {
      public string ID  { get; set; }
      
      public string FirstName { get; set; }

      public string SurName { get; set; }
      public string[] subjects { get; set; }

      public double[] marks { get; set; }

      public double ave { get; set; }
  }


  class student {
    public void addMarks() { 
      Console.Write("-> First Name: ");
      string fname = Console.ReadLine();
      Console.Write("-> Surname: ");
      string sname = Console.ReadLine();
      Console.Write("-> Amount of Subjects: ");
      int SubjAmount = int.Parse(Console.ReadLine());
      Console.WriteLine("-> Subjects (input format: `[subject] [mark (FLOAT)]`, eg: `physics 50`:");

      //string[SubjAmount] subjects;
      string[] subjects = new string[SubjAmount];
      double[] marks = new double[SubjAmount];
      for(int i = 0; i < subjects.Length; i++) {
        Console.Write("|| -> Subject #" + i + ": ");
        string input = Console.ReadLine();
        string[] inputs = input.Split(" ");
        subjects[i] = inputs[0];
        marks[i] = Double.Parse(inputs[1]);
      }

      writeToFile(subjects, marks, fname, sname);
    }

    public static void writeToFile(string[] subjects, double[] marks, string fname, string sname) {
      var jsonString = File.ReadAllText("students.json");
      dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
      if(result == null) {
        //List<jsonStudent> students = new List<jsonStudent>();
        List<jsonStudent> newList = addToList(new List<jsonStudent>(), subjects, marks, fname, sname);
        File.WriteAllText(@"students.json", JsonConvert.SerializeObject(newList));

        // serialize JSON directly to a file
        using(StreamWriter file = File.CreateText(@"students.json")) {
          JsonSerializer serializer = new JsonSerializer();
          serializer.Serialize(file, newList);
        }
      } else {
        List<jsonStudent> students = result.ToObject(typeof(List<jsonStudent>));
        List<jsonStudent> newList = addToList(students, subjects, marks, fname, sname);
        File.WriteAllText(@"students.json", JsonConvert.SerializeObject(newList));

        // serialize JSON directly to a file
        using(StreamWriter file = File.CreateText(@"students.json")) {
          JsonSerializer serializer = new JsonSerializer();
          serializer.Serialize(file, newList);
        }
      }
    }

    public static List<jsonStudent> addToList(List<jsonStudent> students, string[] subjects, double[] marks, string fname, string sname) {
      double sum = 0;
      for(int i = 0; i < marks.Length; i++) { sum += marks[i]; }
      Random rand = new Random();
      jsonStudent json = new jsonStudent {
        ID = rand.Next(0, 1000000000).ToString(),
        FirstName = fname,
        SurName = sname,
        subjects = subjects,
        marks = marks,
        ave = sum/marks.Length
      };
      students.Add(json);
      return students;
    }
  }
}