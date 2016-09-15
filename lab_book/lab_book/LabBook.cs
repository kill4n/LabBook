using System;

namespace lab_book
{
    [Serializable]
    public class LabBook : NotifyBase
    {
        #region Atributos
        private DateTime _date = DateTime.Today;
        private string _experiment = "Experiment name.";
        private string _author = "Author name";
        private string _description = "Describe the experiment.";
        private string _comment = "Comment...";
        #endregion
        #region Propiedades
        public DateTime date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged("date"); }
        }

        public string experiment
        {
            get { return _experiment; }
            set { _experiment = value; OnPropertyChanged("experiment"); }
        }

        public string author
        {
            get { return _author; }
            set { _author = value; OnPropertyChanged("author"); }
        }

        public string description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged("description"); }
        }
        public string comment
        {
            get { return _comment; }
            set { _comment = value; OnPropertyChanged("comment"); }
        }
        #endregion

        #region Metodos
        public LabBook Clone()
        {
            return (LabBook)MemberwiseClone();
        }
        #endregion
    }
}