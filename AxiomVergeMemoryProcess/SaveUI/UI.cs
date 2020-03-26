using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SaveUI
{
    public partial class UI : Form
    {
        DirectoryInfo currentDir;
        readonly string appLocation = Application.StartupPath;
        readonly string backupFolder = "\\Backup\\";
        public UI()
        {    
            InitializeComponent();
            if (Properties.Settings.Default.SaveFolder == "")
            {
                string input = Interaction.InputBox("Please enter your save folder path:", "Error Missing Save Folder", "C:\\Program Files (x86)\\Steam\\userdata\\USERIDgoesHERE\\332200\\remote\\", -1, -1);
                Properties.Settings.Default.SaveFolder = input;
                Properties.Settings.Default.Save();
            }
            currentDir = new DirectoryInfo($"{appLocation}{backupFolder}{comboBox2.Text}\\");
            FileCount.Value = currentDir.GetFiles().Length;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentDir = new DirectoryInfo($"{appLocation}{backupFolder}{comboBox2.Text}\\");
            FileCount.Value = currentDir.GetFiles().Length;
            FileCount.Value++;
            string saveCount = (FileCount.Value < 10) ? $"00{FileCount.Value}" : (FileCount.Value > 9 && FileCount.Value < 99) ? $"0{FileCount.Value}" : $"{ FileCount.Value}";

            string fileLocation = Properties.Settings.Default.SaveFolder;
            string fileName = "Save3.sav";
            string file = fileLocation + fileName;
            
            string newFileName = $"{comboBox1.Text}_{comboBox2.Text}_{saveCount}{textBox1.Text}.sav";
            string destination = $"{appLocation}{backupFolder}{comboBox2.Text}\\{newFileName}";
            
            if (Properties.Settings.Default.SaveFolder == "") { return; }
            File.Copy(file, destination);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentDir = new DirectoryInfo($"{appLocation}{backupFolder}{comboBox2.Text}\\");
            FileCount.Value = currentDir.GetFiles().Length;
        }
    }
}
