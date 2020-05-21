using System;
using System.Collections.Generic;
using FileParser;

namespace Delegate_Exercise
{
    class Delegate_Exercise
    {
        static void Main(string[] args)
        {
            // Read and Write file paths
            string readFilePath = "C:\\Users\\wesle\\Desktop\\Delegate_Task\\DelegatesTask\\DataFiles\\data.csv";
            string writeFilePath = "C:\\Users\\wesle\\Desktop\\Delegate_Task\\DelegatesTask\\DataFiles\\processed_data.csv";

            //1. Instantiate ReadList & Passed List
            //List of string
            List<string> readList = new List<string>();
            //List of List of string
            List<List<string>> passedList = new List<List<string>>();

            //2. FileHandle & DataParser objects to access appropriate methods
            FileHandler filehandle = new FileHandler();
            DataParser dataParse = new DataParser();

            //3. Read list
            readList = filehandle.ReadFile(readFilePath);
            //4. Pass list
            passedList = filehandle.ParseCsv(readList);

            //5. Format data in list -- All this to be handled inside delegate
            // Add dataparse methods to Func<List<List<string>>, List<List<string>>> dataHandler
            dataParse.StripQuotes(passedList);
            dataParse.StripWhiteSpace(passedList);
            RemoveHashes(passedList);

            //6. Write list to file
            filehandle.WriteFile(writeFilePath, ',', passedList);

            //Display formatted list -- Only for my reference || Print a list of list
            for(int i = 0; i < passedList.Count; i++)
            {
                Console.WriteLine("-----------------");

                foreach (string str in passedList[i])
                {
                    Console.WriteLine(str);
                }
            }


        }

        public static List<List<string>> RemoveHashes(List<List<string>> data) {
            foreach(var row in data) {
                for (var index = 0; index < row.Count; index++) {
                    if(row[index][0] == '#')
                        row[index] = row[index].Remove(0,1);
 
                }
            }
            return data;
            
        }
    }
}
