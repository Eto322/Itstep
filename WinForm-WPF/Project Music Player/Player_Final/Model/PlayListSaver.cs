using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Final.Models
{
    public class PlaylistSaver
    {
        public void Save(ObservableCollection<SongFileModel> playlist, string destinationFilename)
        {
            using (var sw = new StreamWriter(destinationFilename))
            {
                foreach (var song in playlist)
                {
                    sw.WriteLine(song.Path);
                }
            }
        }
    }
}