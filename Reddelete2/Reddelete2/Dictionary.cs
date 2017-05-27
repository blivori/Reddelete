using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reddelete2
{
    public partial class Dictionary : Form
    {
        string filePath = Directory.GetCurrentDirectory() + @"\dictionary.rtf";
        OpenFileDialog opentext = new OpenFileDialog();

        public Dictionary()
        {
            InitializeComponent();
        }

        private void Dictionary_Load(object sender, EventArgs e)
        {
            opentext.FileName = filePath;

            if (File.Exists(filePath))
            {
                rTxtDictionary.Text = File.ReadAllText(opentext.FileName);
            }

        }

        private void tsBtnOpen_Click(object sender, EventArgs e)
        {
            opentext.InitialDirectory = Directory.GetCurrentDirectory();
            opentext.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf|All files (*.*)|*.*";

            if (opentext.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(opentext.FileName);
                rTxtDictionary.Text = File.ReadAllText(opentext.FileName);
                sr.Close();
            }
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog savetext = new SaveFileDialog();
            savetext.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf|All files (*.*)|*.*";


            if (savetext.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                savetext.FileName.Length > 0)
            {
                rTxtDictionary.SaveFile(savetext.FileName, RichTextBoxStreamType.PlainText);

                
            }

        }
    }
}
