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
            book.NameChanged += new NameChangedDelegate(OnNameChanged2);

            book.Name = "Kumar's Grade Book";
            book.Name = "Kumar's Grade Book";
            book.Name = "Kumar' Grade Book";

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            ////book.LowestGrade();

            WriteResult("Average",stats.AverageGrade);
            WriteResult("Highest Grade",(int)stats.HighestGrade);
            WriteResult("Lowest Grade",stats.LowestGrade);
            Console.ReadLine();

        }

        static void OnNameChanged(string existingName, string newName)
        {
            Console.WriteLine($"Grade book changing from {existingName} to {newName}");
        }

        static void OnNameChanged2(string existingName, string newName)
        {
            Console.WriteLine($"****");
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine(description+": "+result);
        }


    }
}
