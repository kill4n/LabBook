using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_book
{
    public class Settings
    {
        private String _dataPath = "./LabBook/";

        public String DataPath
        {
            get { return _dataPath; }
            set { _dataPath = value; }
        }

        public Settings()
        {

        }
        public void initStructure()
        {
            if (!Directory.Exists(_dataPath + "data"))
                Directory.CreateDirectory(_dataPath + "data");
            if (!Directory.Exists(_dataPath + "labbooks"))
                Directory.CreateDirectory(_dataPath + "labbooks");
        }
    }
}
