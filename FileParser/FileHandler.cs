using System.Collections.Generic;
using System.IO;
//Comments = XML doc tags

namespace FileParser
{
    public class FileHandler {
       
        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filePath) {
            List<string> lines = new List<string>();
            StreamReader reader = new StreamReader(filePath);     //streamreader to read the csv file

            while (!reader.EndOfStream)
            {
                lines.Add(reader.ReadLine());
            }

            return lines; //-- return result here
        }

        
        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows) {
            //always analyse the parameters, and the comments
            //look at the tests to see what the parameters will return, ie. delimeter = "*"

            //1. Opening a stream to write
            StreamWriter writer = new StreamWriter(filePath);

            //2. Compiling a string
            string str = "";
            foreach (List<string> rowJoin in rows) //advanced for loop since no need to keep a counter
            {
                //Joining List of 'rowJoin' in the List of 'rows'
                str += string.Join(delimeter.ToString(), rowJoin) + "\n";
            }

            //3. Writing string to file
            writer.WriteLine(str);
            //4. Closing the stream
            writer.Close();

        }

        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimiter) {      //same concept to ParseCsv
            List<List<string>> result = new List<List<string>>();                     // ^difference is that the deliminator
                                                                                      // ^is already declared in the method
            List<string> split;                                                       

            for (int i = 0; i < data.Count; i++)
            {
                split = new List<string>(data[i].Split(delimiter));

                result.Add(split);
            }
            return result; //-- return result here
        }
        
        /// <summary>
        /// Takes a list of strings and separates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data) {
            List<List<string>> parsedList = new List<List<string>>();    //establishing the list of list of strings
            char delimiter = ',';      //declaring a delimiter (comma)
            List<string> split;        //calling a list of strings to be split

            for(int i =0; i < data.Count; i++)      //for loop, starting at first value until max value at increments of 1
            {
                split = new List<string>(data[i].Split(delimiter));      //splitting the list of list of strings with the delimiter

                parsedList.Add(split);       // Adding/Concatinating the 'split' lists into the parsedList.
            }

            return parsedList;  //-- return result here
        }
    }
}