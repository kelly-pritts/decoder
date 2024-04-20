using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.IO;

namespace decoder
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var message1 = decode("C:\\Development\\decoder\\decoder\\messageToDecode.txt");
            Console.WriteLine(message1);
            Console.ReadLine();

            string message2 = decode("C:\\Development\\decoder\\decoder\\coding_qual_input.txt");
            Console.WriteLine(message2);
            Console.ReadLine();

        }

        static string decode(string message_file)
        {
            Dictionary<int, string> messageKey = new Dictionary<int, string>();
            var logFile = File.ReadAllLines(message_file);
            foreach (var line in logFile)
            {
                string[] splitLine = line.Split(' ');
                messageKey.Add(Convert.ToInt32(splitLine[0]), splitLine[1]);
            }

            //make sure the list is in ascending order
            List<int> orderedNums = messageKey.Keys.ToList().OrderBy(i => i).ToList();
            List<List<int>> pyramid = new List<List<int>>();

            int step = 1;
            int index = 0;

            //create pyramid
            while (index < orderedNums.Count)
            {
                List<int> temp = orderedNums.GetRange(index, count: step);
                pyramid.Add(temp);
                index += step;
                step++;

            }

            //decode message using the last number in each level of the pyramid
            string message = string.Empty;
            foreach (var level in pyramid)
            {
                int key = level[level.Count - 1]; 
                message += messageKey[key] + ' ';
            }

            return message.Trim();
        }


    }
}
