using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace lab_book
{
    /// <summary>
    /// Interaction logic for LabBook_window.xaml
    /// </summary>
    public partial class LabBook_window : Window
    {
        bool isNew = true;
        LabBook tmp;
        public LabBook_window()
        {
            InitializeComponent();
            if (isNew)
            {
                this.DataContext = new LabBook();
            }
        }
        public LabBook_window(LabBook lab) : this()
        {
            isNew = false;
            tmp = lab.Clone();
            this.DataContext = lab;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Save
            this.DialogResult = true;

            ((LabBook)DataContext).experiment = experiment.Text;
            ((LabBook)DataContext).author = author.Text;
            ((LabBook)DataContext).date = date.DisplayDate;
            ((LabBook)DataContext).description = description.Text;
            ((LabBook)DataContext).comment = comment.Text;

            this.Close();
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
    }
}
