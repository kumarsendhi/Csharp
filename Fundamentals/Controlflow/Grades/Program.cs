using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();

            synth.Speak("Hello!, this is the grade book program");

            GradeBook book = new GradeBook();

           // book.NameChanged = new NameChangedDelegate(OnNameChanged);
            //book.NameChanged = new NameChangedDelegate(OnNameChanged2);
            book.NameChanged += new NameChangedDelegate(OnNameChanged);
            // book.NameChanged += new NameChangedDelegate(OnNameChanged2);
            //book.NameChanged = null;

            
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
            //book.Name = "Kumar's Grade Book";
            //book.Name = "Kumar' Grade Book";

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            book.WriteGrades(Console.Out);

            GradeStatistics stats = book.ComputeStatistics();
            ////book.LowestGrade();

            WriteResult("Average",stats.AverageGrade);
            WriteResult("Highest Grade",(int)stats.HighestGrade);
            WriteResult("Lowest Grade",stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
            Console.ReadLine();

        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing from {args.existingName} to {args.newName}");
        }

        //static void OnNameChanged2(string existingName, string newName)
        //{
        //    Console.WriteLine($"****");
        //}

        static void WriteResult(string description, string result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine(description+": "+result);
        }


    }
}
