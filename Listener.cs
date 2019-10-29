using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyApp
{
    class Listener
    {
        //Idee, herausfinden wann sich File geändert hat und dann aktualisierung der Table
        //https://docs.microsoft.com/de-de/dotnet/api/system.io.filesystemwatcher.changed?view=netframework-4.8

        //    public void FileHasChanged(string path)
        //    {
        //        FileInfo info = new FileInfo(path);
        //        var writeTime = info.LastWriteTime;


        //        FileSystemWatcher watcher = new FileSystemWatcher();
        //        watcher.Path = Path.GetDirectoryName(path);
        //        watcher.Filter = Path.GetFileName(path);
        //        watcher.Changed += Watcher_Changed;
        //    }

        //    private void Watcher_Changed(object sender, FileSystemEventArgs e)
        //    {
        //        StreamWriter writer = new StreamWriter("test.txt");
        //        writer.Write("Triggerd");
        //        writer.Close();
        //    }

        //    public void OnChanged()
        //    {

        //    }
    }
}
