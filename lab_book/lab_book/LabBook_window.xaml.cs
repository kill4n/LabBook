using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Serialization;

namespace lab_book
{
    /// <summary>
    /// Interaction logic for LabBook_window.xaml
    /// </summary>
    public partial class LabBook_window : Window
    {
        bool isNew = true;
        LabBook tmp;
        private Settings ajustes;

        public LabBook_window()
        {
            InitializeComponent();
            //if (isNew)
            //{
            //    var labs = Directory.EnumerateDirectories(ajustes.DataPath + "labbooks").Count();
            //    DataContext = new LabBook() { author = ajustes.DefaultAuthor, folder = "Lab_" + (labs + 1) };
            //    Directory.CreateDirectory(ajustes.DataPath + "labbooks/" + ((LabBook)DataContext).folder);
            //}
        }
        public LabBook_window(LabBook lab, Settings ajustes)
        {
            this.ajustes = ajustes;

            InitializeComponent();
            isNew = false;
            tmp = lab.Clone();
            DataContext = lab;
        }

        public LabBook_window(Settings ajustes)
        {
            this.ajustes = ajustes;
            InitializeComponent();
            if (isNew)
            {
                var labs = Directory.EnumerateDirectories(ajustes.DataPath + "labbooks").Count();
                DataContext = new LabBook() { author = ajustes.DefaultAuthor, folder = "Lab_" + (labs + 1) };
                Directory.CreateDirectory(ajustes.DataPath + "labbooks/" + ((LabBook)DataContext).folder);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Save
            DialogResult = true;

            ((LabBook)DataContext).experiment = experiment.Text;
            ((LabBook)DataContext).author = author.Text;
            ((LabBook)DataContext).date = date.DisplayDate;
            ((LabBook)DataContext).description = description.Text;
            ((LabBook)DataContext).comment = comment.Text;

            var serializer = new XmlSerializer(((LabBook)DataContext).GetType());
            using (var writer = XmlWriter.Create(ajustes.DataPath + "labbooks/" + ((LabBook)DataContext).folder + "/lab.xml"))
            {
                serializer.Serialize(writer, (LabBook)DataContext);
            }

            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Cancel
            this.DialogResult = false;
            this.Close();
        }

        public LabBook ShowTupleDialog()
        {
            if (ShowDialog() == true)
            {
                if (!isNew)
                {
                    return null;
                }
                else
                {
                    return (LabBook)this.DataContext;
                }
            }
            else
            {
                return null;
            }
        }

        private void imagenes_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void imagenes_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string fileImg = ((string[])e.Data.GetData(DataFormats.FileDrop)).FirstOrDefault();
                string ex = fileImg.Split('.').Last();
                string newPath = ajustes.DataPath + "labbooks/" + ((LabBook)DataContext).folder + "/" + DateTime.Now.Millisecond + "." + ex;
                //   File.Copy(fileImg, newPath);

                Image img = new Image() { Margin = new Thickness(10) };
                var uri = new Uri(fileImg);
                var bitmap = new BitmapImage(uri);
                img.Source = bitmap;
                imagenes.Children.Add(img);
            }
        }
    }
}
