using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace DeweySQLTableGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string[] scores = File.ReadAllLines("scorefile.txt");
            //var orderedScores = scores.OrderByDescending(x => int.Parse(x.Split(' ')[1]));

            //foreach (var score in orderedScores)
            //{
            //    Console.WriteLine(score);
            //}

            DataTable dt = new DataTable();

            string[] input = File.ReadAllLines("dewey.txt");

            foreach (var line in input)
            {
                //char[] space = { ' ' };
                //string[] entry = line.Split(space, StringSplitOptions.RemoveEmptyEntries);
                string[] entry = line.Split(':');

                if (dt.Columns.Count == 0)
                {

                    // Create the data columns for the data table based on the number of items
                    // on the first line of the file
                    for (int i = 0; i < entry.Length; i++)
                        dt.Columns.Add(new DataColumn("Column" + i, typeof(string)));
                    
                }
                dt.Rows.Add(entry);

            }



        }
        public void addDelimiter()
        {
            string[] input = File.ReadAllLines("dewey.txt");
            string[] output = new string[input.Length];
            int i = 0;

            foreach (string entry in input)
            {
                output[i] = input[i].Insert(3, ":");
                i++;
            }

            i = 0;
            foreach (string entry in output)
            {
                Console.WriteLine(output[i]);
                i++;
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            addDelimiter();
        }

    }

}
