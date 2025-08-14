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
                // Auto-create the students.txt file if it doesn't exist
                if (!File.Exists(inputFile))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("⚠ File not found. Creating sample students.txt...");
                    Console.ResetColor();

                    File.WriteAllLines(inputFile, new string[]
                    {
                        "101,Alice Smith,84",
                        "102,John Doe,76",
                        "103,Mary Johnson,62",
                        "104,Bob Brown,45"
                    });
                }

                List<Student> students = processor.ReadStudentsFromFile(inputFile);
                processor.WriteReportToFile(students, outputFile);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Report generated successfully: " + outputFile);
                Console.ResetColor();
            }
            catch (FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Error: The input file was not found.");
                Console.ResetColor();
            }
            catch (InvalidScoreFormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Score Format Error: " + ex.Message);
                Console.ResetColor();
            }
            catch (MissingFieldException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Missing Data Error: " + ex.Message);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Unexpected Error: " + ex.Message);
                Console.ResetColor();
            }
        }
    }
}
