using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace lab_book
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pathFile = "myfile.lbb";

        public ObservableCollection<LabBook> labs { get; set; }

        public MainWindow()
        {
            this.labs = new ObservableCollection<LabBook>();
            if (File.Exists(pathFile))
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(pathFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    labs = (ObservableCollection<LabBook>)formatter.Deserialize(stream);
                    stream.Close();
                }
            }
            InitializeComponent();
            labb.DataContext = labs.FirstOrDefault();
        }

        private void listView_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                LabBook_window lbv = new LabBook_window((LabBook)item);
                lbv.ShowTupleDialog();
            }
        }

        private void listView_Click(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
                labb.DataContext = (LabBook)item;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //save
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(pathFile, FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, labs);
            stream.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Open

        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            //New
            LabBook_window lbv = new LabBook_window();
            LabBook lbNew = lbv.ShowTupleDialog();
            if (lbNew != null)
            {
                labs.Add(lbNew);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
