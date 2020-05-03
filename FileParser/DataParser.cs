using System.Collections.Generic;

namespace FileParser {
    public class DataParser {
        

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data) {

            foreach(List<string> trimString in data)
            {
                //stripped whitespace from first index, need to iterate and do the remainder of list
                for(int i = 0; i < trimString.Count; i++)
                {
                    trimString[i] = trimString[i].Trim();
                }
                
            }

           

            return data; //-- return result here
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {

            //solution? replace quotes with empty char and then trim like before

            foreach (List<string> trimReplace in data)
            {
                for (int i = 0; i < trimReplace.Count; i++)
                {
                    trimReplace[i] = trimReplace[i].Replace('"', ' ');
                    trimReplace[i] = trimReplace[i].Trim();
                }

            }

                return data; //-- return result here
        }

    }
}