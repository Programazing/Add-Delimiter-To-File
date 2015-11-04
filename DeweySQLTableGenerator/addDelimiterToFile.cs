using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweySQLTableGenerator
{
    class addDelimiterToFile
    {
        public void addDelimiter(string fileLocationRead, string fileLocationWrite, string delimiter, int numberOfSpaces)
        {
            /*
              This class reads files one line at a time and allows you to
              insert a delimiter within that line. The purpose is so that
              you will be able to use the file in your code and divide data
              however you want. This method works best if there is a set number
              of charcters that seperates your data. For example...
             
              001 This is some test data
              002 blah blah blah
              003 Oh, look, commas, all, up, in, the, data,,,,,,
              
              becomes
              
              001: This is some test data
              002: blah blah blah
              003: Oh, look, commas, all, up, in, the, data,,,,,,
             */

            //The location of your file.
            string[] input = File.ReadAllLines(fileLocationRead);

            string[] output = new string[input.Length];

            int i = 0;
            foreach (string entry in input)
            {
                /*
                Takes a line of text from your file that is stored
                in a position of the input array and adds it to the
                output array in the same position after adding your
                delimiter N charcters into the string.
                 */
                output[i] = input[i].Insert(numberOfSpaces, delimiter);
                i++; 
            }

            //Writes each position of the output array to your file
            //as a new line. Remember to add a file extention like .txt
            File.WriteAllLines(fileLocationWrite, output);

        }

    }
}