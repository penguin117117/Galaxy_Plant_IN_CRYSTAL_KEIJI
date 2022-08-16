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
        internal static void Open() 
        {
            FolderBrowserDialog fbd = new()
            {
                Description = "フォルダを選んでください",
                InitialDirectory = GetUserSelectFolder()
            };

            var result = fbd.ShowDialog();
            
            if (result != DialogResult.Cancel)
            {
                if (IsGalaxyProjectFolder(Directory.GetDirectories(fbd.SelectedPath))) 
                {
                    PathSave(fbd.SelectedPath);
                    Debug.WriteLine("IsGalaxyFolder");
                }
            }
        }

        private static bool IsGalaxyProjectFolder(string[] directories) 
        {
            foreach (string directory in directories) 
            {
                if (Path.GetFileName(directory) == "StageData") 
                {
                    return true;
                }
            }
            return false;
        }

        private static void PathSave(string selectedDirPath) 
        {
            Properties.Settings.Default.GalaxyProjectPath = selectedDirPath;
            Properties.Settings.Default.Save();
        }

        private static string GetUserSelectFolder() 
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
