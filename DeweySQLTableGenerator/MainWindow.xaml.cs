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

        private void btnReadData_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();

            string[] input = File.ReadAllLines("dewey.txt");

            foreach (var line in input)
            {
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

            foreach (DataRow dr in dt.Rows)
            {
                txtBox.AppendText(dr.ItemArray[0].ToString());
                
            }
        }

        private void btnWriteData_Click(object sender, RoutedEventArgs e)
        {
            addDelimiterToFile dataFile = new addDelimiterToFile();

            dataFile.addDelimiter("dewey.txt", "delimiter.txt", ":", 3);
        }

        private void btnOpenFileDialog_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            var result = fileDialog.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    var file = fileDialog.FileName;
                    txtBlock.Text = file;
                    txtBlock.ToolTip = file;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    txtBlock.Text = null;
                    txtBlock.ToolTip = null;
                    break;
            }
        }

    }

}
