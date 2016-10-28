using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; 

namespace ConvertToCodingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Specify File Output Name");
                return; 
            }

            HashSet<String> uses = new HashSet<string>(); 
            var files = Directory.GetFiles(".", "*.cs");
            LinkedList <String> toWrite = new LinkedList<string>();  
            foreach (var file in files)
            {
                var lines = File.ReadAllLines (file);
                foreach (var line in lines)
                {
                    if (line.Contains("using "))
                    {
                        uses.Add(line.ToString());
                    }
                    else
                    {
                        toWrite.AddLast(line); 
                    }
                }
            }
            foreach (var use in uses)
            {
                toWrite.AddFirst(use); 
            }

            File.WriteAllLines((String)args[0] , toWrite.ToArray<String>()); 
        }
    }
}
