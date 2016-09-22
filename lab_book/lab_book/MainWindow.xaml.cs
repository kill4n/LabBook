using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;

namespace lab_book
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Settings ajustes = new Settings();
        string pathFile = "myfile.lbb";

        public ObservableCollection<LabBook> labs { get; set; }

        public MainWindow()
        {
            this.labs = new ObservableCollection<LabBook>();
            this.initStructure();
            InitializeComponent();
            labb.DataContext = labs.FirstOrDefault();
        }

        public void initStructure()
        {
            string pathSet = ajustes.DataPath + "data/setings.xml";
            if (File.Exists(pathSet))
            {
                var serializer = new XmlSerializer(typeof(Settings));
                using (var reader = XmlReader.Create(pathSet))
                {
                    ajustes = (Settings)serializer.Deserialize(reader);
                }
            }
            else
            {
                if (!Directory.Exists(ajustes.DataPath + "data"))
                    Directory.CreateDirectory(ajustes.DataPath + "data");
                if (!Directory.Exists(ajustes.DataPath + "labbooks"))
                    Directory.CreateDirectory(ajustes.DataPath + "labbooks");
                var serializer = new XmlSerializer(ajustes.GetType());
                using (var writer = XmlWriter.Create(pathSet))
                {
                    serializer.Serialize(writer, ajustes);
                }
            }
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
        //save
        //IFormatter formatter = new BinaryFormatter();
        //Stream stream = new FileStream(pathFile, FileMode.Create,
        //                         FileAccess.Write, FileShare.None);
        //formatter.Serialize(stream, labs);
        //stream.Close();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Open

        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            //New
            LabBook_window lbv = new LabBook_window(ajustes);
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
