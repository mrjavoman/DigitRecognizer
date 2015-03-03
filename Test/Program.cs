using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitRecognizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var trainingPath = @"C:\Users\xavi\Dropbox\Dev work\Machine Learning for .NET Developers\trainingsample.csv";
            var training = DataReader.ReadObservations(trainingPath);
            
            Console.ReadLine();
        }
    }
}
