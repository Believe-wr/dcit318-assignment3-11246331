using System;
using System.Collections.Generic;
using System.IO;

namespace StudentGradingSystem
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            var students = new List<Student>();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string? line; // Nullable to avoid warning
                int lineNumber = 1;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length != 3)
                        throw new MissingFieldException($"Line {lineNumber}: Missing required fields.");

                    string idStr = parts[0].Trim();
                    string fullName = parts[1].Trim();
                    string scoreStr = parts[2].Trim();

                    if (!int.TryParse(scoreStr, out int score))
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Score is not a valid integer.");

                    if (!int.TryParse(idStr, out int id))
                        throw new InvalidScoreFormatException($"Line {lineNumber}: ID is not a valid integer.");

                    students.Add(new Student(id, fullName, score));
                    lineNumber++;
                }
            }

            return students;
        }

        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}");
                }
            }
        }
    }
}

