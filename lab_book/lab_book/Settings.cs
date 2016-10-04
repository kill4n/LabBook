using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_book
{
    [Serializable]
    public class Settings
    {
        public Settings()
        {
        }
        private String _dataPath = "./LabBook/";
        public String DataPath
        {
            get { return _dataPath; }
            set { _dataPath = value; }
        }

        private String def_author = "Crhistian Segura";

        public String DefaultAuthor
        {
            get { return def_author; }
            set { def_author = value; }
        }


    }
}
