using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Class_form_11_13;
using System.Windows.Forms;

namespace Library
{
    public class SaveAndReadFile
    {
        public bool check = false;
        public StreamWriter fileWriter;
        public StreamReader fileReader;
        public void Save (string fileName)
        {
            if (fileName == string.Empty)
            {
                MessageBox.Show("Invalid File Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                check = false;
            }
            else
            {
                try
                {
                 //   MessageBox.Show("Success");
                    FileStream output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                    fileWriter = new StreamWriter(output);
                    check = true;
                }
                catch (IOException)
                {
                    MessageBox.Show("Error opening file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
        }
        public void Read(string fileName)
        {
            if (fileName == string.Empty)
                MessageBox.Show("Invalid File Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    MessageBox.Show("Success");
                    FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    fileReader = new StreamReader(input);
                }
                catch (IOException)
                {
                    MessageBox.Show("Invalid File Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
        }
    }
}
