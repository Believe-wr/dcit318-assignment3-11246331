using System;
using System.Collections.Generic;
using System.IO;

namespace StudentGradingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new StudentResultProcessor();
            string inputFile = "students.txt"; // Input file name
            string outputFile = "report.txt";  // Output file name

            try
            {
                List<Student> students = processor.ReadStudentsFromFile(inputFile);
                processor.WriteReportToFile(students, outputFile);

                Console.WriteLine("✅ Report generated successfully: " + outputFile);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("❌ Error: The input file was not found.");
            }
            catch (InvalidScoreFormatException ex)
            {
                Console.WriteLine("❌ Score Format Error: " + ex.Message);
            }
            catch (MissingFieldException ex)
            {
                Console.WriteLine("❌ Missing Data Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Unexpected Error: " + ex.Message);
            }
        }
    }
}
