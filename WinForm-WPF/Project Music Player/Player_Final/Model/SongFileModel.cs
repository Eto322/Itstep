using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using TagLib;

namespace Player_Final.Models
{
    [Serializable]
    public class SongFileModel
    {
        public string Path { get; set; }
        public uint Track { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public uint Year { get; set; }
        public TimeSpan Duration { get; set; }
        public byte[] Picture { get; set; }

        public SongFileModel()
        {

        }
        public SongFileModel(string Path)
        {
            var tag = TagLib.File.Create(Path).Tag;

            this.Path = Path;
            Track = tag.Track;
            Title = tag.Title;
            Artist = tag.AlbumArtists.FirstOrDefault();
            Album = tag.Album;
            Year = tag.Year;

            Duration = new AudioFileReader(Path).TotalTime;
            Picture = tag.Pictures.FirstOrDefault()?.Data.Data;
        }

    }
}