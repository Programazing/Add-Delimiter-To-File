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


namespace AddDelimiterToFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        addDelimiterToFile dataFile = new addDelimiterToFile();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnReadData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string[] input = File.ReadAllLines(txtFileLocation.Text);

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
                    txtBox.AppendText(dr.ItemArray[0].ToString() + System.Environment.NewLine);


                }
            }

            catch (ArgumentException error)
            {

                MessageBox.Show("File Location cannot be Empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnWriteData_Click(object sender, RoutedEventArgs e)
        {
            if (txtDelimiter.Text != "" && txtNumberOfCharcters.Text != "" && txtFileLocation.Text != "")
            {
                try
                {
                    Microsoft.Win32.SaveFileDialog saveDialog = new Microsoft.Win32.SaveFileDialog();

                    saveDialog.FileName = "Document";
                    saveDialog.DefaultExt = ".text";
                    saveDialog.Filter = "Text documents (.txt)|*.txt";

                    Nullable<bool> result = saveDialog.ShowDialog();

                    if (result == true)
                    {
                        dataFile.addDelimiter(dataFile.originalFileLocation, saveDialog.FileName, txtDelimiter.Text, Convert.ToInt16(txtNumberOfCharcters.Text));

                        MessageBox.Show("File Saved!", "Complete", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else { MessageBox.Show("The Information above can not be Blank", "Warning", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void btnOpenFileDialog_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            var result = fileDialog.ShowDialog();

            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    var file = fileDialog.FileName; //.SafeFileName only shows the File Name
                    txtFileLocation.Text = file;
                    txtFileLocation.ToolTip = file;
                    dataFile.originalFileLocation = file;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    txtFileLocation.Text = null;
                    txtFileLocation.ToolTip = null;
                    break;
            }
        }

        private void txtNumberOfCharcters_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {

                e.Handled = true;

            } 
        }




    }

}
