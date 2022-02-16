using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Final.Models
{
    public class PlaylistLoader
    {
        public ObservableCollection<SongFileModel> Load(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                var songs = new ObservableCollection<SongFileModel>();

                var line = sr.ReadLine();
                do
                {
                    songs.Add(new SongFileModel(line));
                    line = sr.ReadLine();
                } while (line != null);

                return songs;
            }
        }
    }
}