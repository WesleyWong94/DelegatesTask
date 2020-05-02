using System;
using System.Collections.Generic;
using FileParser;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise
{
    class Delegate_Exercise
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C:\\Users\\wesle\\Desktop\\Delegate_Task\\Dip_Delegates_Task\\DataFiles\\data.csv");
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
