using System;
using System.Collections.Generic;
using System.Diagnostics;
using FileParser;

namespace FileParser
{
    public delegate List<List<string>> Parser(List<List<string>> data);

    public class CsvHandler
    {

        /// <summary>
        /// Reads a csv file (readfile) and applies datahandling via dataHandler delegate and writes result as csv to writeFile.
        /// </summary>
        /// <param name="readFile"></param>
        /// <param name="writeFile"></param>
        /// <param name="dataHandler"></param>
        public void ProcessCsv(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> dataHandler)
        {

            //1. ReadList & Passed List
            //List of string
            List<string> readList = new List<string>();
            //List of List of string
            List<List<string>> passedList = new List<List<string>>();

            //2. FileHandle & DataParser objects to access appropriate methods
            FileHandler filehandle = new FileHandler();
            DataParser dataParse = new DataParser();

            //3. Read list
            readList = filehandle.ReadFile(readFile);

            //4. Pass list
            passedList = filehandle.ParseCsv(readList);

            //5. Format Data

            dataHandler += dataParse.StripQuotes;

            dataHandler += dataParse.StripWhiteSpace;

            //6. Write formatted list to file
            filehandle.WriteFile(writeFile, ',', dataHandler(passedList));

            dataHandler(passedList);




        }

    }
}