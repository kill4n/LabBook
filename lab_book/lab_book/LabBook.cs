using System;

namespace lab_book
{
    [Serializable]
    public class LabBook : NotifyBase
    {
        #region Atributos
        private DateTime _date;
        private string _experiment = "Experiment name.";
        private string _author = "Author nName";
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

        public LabBook Clone()
        {
            return (LabBook)MemberwiseClone();
        }

        public void Load(LabBook lb)
        {
            this.experiment = lb.experiment;
            this.date = lb.date;
            this.description = lb.description;
            this.author = lb.author;
            this.comment = lb.comment;
        }
    }
}