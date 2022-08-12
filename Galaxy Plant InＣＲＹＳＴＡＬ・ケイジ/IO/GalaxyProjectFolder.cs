using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Galaxy_Plant_InＣＲＹＳＴＡＬ_ケイジ.IO
{
    internal class GalaxyProjectFolder
    {
        internal GalaxyProjectFolder() 
        {
            Open();
        }

        private void Open() 
        {
            FolderBrowserDialog fbd = new()
            {
                Description = "フォルダを選んでください",
                InitialDirectory = GetUserSelectFolder()
            };

            var result = fbd.ShowDialog();
            
            if (result != DialogResult.Cancel)
            {
                Debug.WriteLine(fbd.SelectedPath);
                PathSave(fbd.SelectedPath);
            }
        }

        private void PathSave(string selectedDirPath) 
        {
            Properties.Settings.Default.GalaxyProjectPath = selectedDirPath;
            Properties.Settings.Default.Save();
        }

        private string GetUserSelectFolder() 
        {
            bool foundDirectory = Directory.Exists(Properties.Settings.Default.GalaxyProjectPath);

            if (foundDirectory) 
            {
                return Properties.Settings.Default.GalaxyProjectPath;
            }

            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
        
    }
}
