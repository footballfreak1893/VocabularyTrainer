using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace VocabularyApp
{
    class Listener : MainForm
    {
        //Idee, herausfinden wann sich File geändert hat und dann aktualisierung der Table
        //https://docs.microsoft.com/de-de/dotnet/api/system.io.filesystemwatcher.changed?view=netframework-4.8

        public void FileHasChanged(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(path);

            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
            watcher.Filter = Data.pathAllWords; //Gibt an welche dateien abgehört werden sollen



            //Events
            watcher.Changed += FileChanged;

            
        }

        private static void FileChanged(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show("Changed !" + DateTime.Now);
        }
    }
}
