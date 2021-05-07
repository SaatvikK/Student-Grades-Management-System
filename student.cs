using System;
using System.IO;

namespace Student_Grades_Management_System {
  class student {
    private addMarks() { 
      Console.WriteLine("-> Amount of Subjects: ");
      int SubjAmount = Console.ReadLine();
      Console.WriteLine("-> Subjects (input format: `[subject] [mark (FLOAT)]`, eg: `physics 50`:");
      
      string[SubjAmount] subjects;
      float[SubjAmount] marks;
      for(int i = 0; i < SubjAmount; i++) {
        Console.WriteLine("|| -> Subject #" + i + ": ");
        string input = Console.ReadLine();
        string[2] inputs = input.Split(" ");
        subjects[i] = inputs[0];
        marks[i] = float.Parse(inputs[1]);
      }
    }
  }
}