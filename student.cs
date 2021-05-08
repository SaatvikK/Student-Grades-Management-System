using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Student_Grades_Management_System {
  public class jsonStudent {
      public string ID  { get; set; }
      public string[] subjects { get; set; }

      public double[] marks { get; set; }

      public double ave { get; set; }
  }


  class student {
    public bool addMarks() { 
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

      //string[][] ReturnVals = new[] {subjects, marks};
      writeToFile(subjects, marks);
      return true;
    }

    public static void writeToFile(string[] subjects, double[] marks) {
      double sum = 0;
      for(int i = 0; i < marks.Length; i++) { sum += marks[i]; }

      jsonStudent json = new jsonStudent {
        ID = "3",
        subjects = subjects,
        marks = marks,
        ave = sum/marks.Length
      };

      List<jsonStudent> students = new List<jsonStudent>();
      students.Add(json);
      File.WriteAllText(@"students.json", JsonConvert.SerializeObject(students));

      // serialize JSON directly to a file
      using (StreamWriter file = File.CreateText(@"students.json")) {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, students);
      }
    }
  }
}