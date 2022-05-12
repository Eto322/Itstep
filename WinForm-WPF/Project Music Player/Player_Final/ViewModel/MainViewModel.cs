using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Infralution.Localization.Wpf;
using Microsoft.Win32;

using NAudio.Wave;
using Player_Final.Models;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using Timer = System.Timers.Timer;


namespace Player_Final.ViewModel
{

    class MainModelView : ViewModelBase
    {   private String[] args = App.mArgs;
        public MainModelView()
        {
            Playlist = new ObservableCollection<SongFileModel>();
            waveOut = new WaveOutEvent();

            

            _timer = new Timer();
            _timer.Interval = 500;
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }

        
        private ObservableCollection<SongFileModel> _playlist;
        public ObservableCollection<SongFileModel> Playlist
        {
            get { return _playlist; }
            set
            {
                if (Equals(value, _playlist)) return;
                _playlist = value;
                RaisePropertyChanged(nameof(Playlist));
            }
        }
        private TimeSpan _currentTime;
        private Timer _timer;
        private long _currentPosition;
        private AudioFileReader _songReader;
        private bool _langState = false;
        private SongFileModel _currentSong;
        private WaveOutEvent waveOut;
        private int _volume;

        public AudioFileReader SongReader { get => _songReader; set { _songReader = value; RaisePropertyChanged(); } }

        public long CurrentPosition
        {
            get => _currentPosition;
            set
            {
                if (CurrentSong != null)
                {
                    _currentPosition = value;
                    if (SongReader != default)
                    {
                        SongReader.Position = value;
                    }
                }

            }
        }



        public SongFileModel CurrentSong
        {
            get => _currentSong;
            set
            {
                if (_currentSong != value)
                {
                    _currentSong = value;

                    if (CurrentSong != default)
                    {
                        waveOut.Stop();
                        SongReader = new AudioFileReader(CurrentSong.Path);
                        waveOut.Init(SongReader);
                        waveOut.Play();
                        if (SongReader != null)
                        {
                            CurrentTime = SongReader.CurrentTime;
                        }

                    }
                    RaisePropertyChanged();

                }
            }
        }

        public TimeSpan CurrentTime
        {
            get => _currentTime;
            set
            {
                if (SongReader != default)
                {
                    _currentTime = value;
                    if (CurrentSong != default)
                    {
                        SongReader.CurrentTime = value;
                    }
                }

            }
        }

        public int Volume
        {
            get => _volume;
            set
            {
                if (_volume != value)
                {
                    _volume = value;
                    waveOut.Volume = Volume / 100f;

                }
                RaisePropertyChanged();
            }
        }


        private void nextSong()
        {
            var index = Playlist.IndexOf(CurrentSong);
            if (index < Playlist.Count - 1)
            {
                CurrentSong = Playlist[index + 1];
            }
            else
            {
                CurrentSong = Playlist.FirstOrDefault();
            }
        }

        private void previousSong()
        {
            var index = Playlist.IndexOf(CurrentSong);
            if (index > 0)
            {
                CurrentSong = Playlist[index - 1];
            }
            else
            {
                CurrentSong = Playlist.LastOrDefault();
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (SongReader != null)
            {
                CurrentTime = SongReader.CurrentTime;
                RaisePropertyChanged("CurrentTime");
                _currentPosition = SongReader.Position;
                RaisePropertyChanged("CurrentPosition");

                if (SongReader.Position == SongReader.Length)
                {
                    SongReader = null;
                    nextSong();

                }
            }
        }

        public RelayCommand AddCommand
        {
            get => new RelayCommand(() =>
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = true;
                fileDialog.Filter = "Audio files (*.mp3,) | *.mp3;";
                var list = new List<SongFileModel>();
                if (fileDialog.ShowDialog() == true)
                {
                    foreach (var item in fileDialog.FileNames)
                    {
                        list.Add(new SongFileModel(item));
                    }

                }
                foreach (var item in list)
                {
                    Playlist.Add(item);
                }
            });
        }

        public RelayCommand AddOnStartCommand
        {
            get => new RelayCommand(() =>
            {
                var list = new List<SongFileModel>();
                foreach (var item in args)
                {
                    list.Add(new SongFileModel(item));
                }
                foreach (var item in list)
                {
                    Playlist.Add(item);
                }
                
            });
        }

        public RelayCommand PlayPauseCommand
        {
            get => new RelayCommand(() =>
            {
                if (CurrentSong != default)
                {
                    switch (waveOut.PlaybackState)
                    {
                        case PlaybackState.Playing:
                            waveOut.Pause();
                            break;
                        case PlaybackState.Paused:
                            waveOut.Play();
                            break;
                        case PlaybackState.Stopped:
                            SongReader = new AudioFileReader(CurrentSong.Path);
                            waveOut.Init(SongReader);
                            waveOut.Play();
                            break;


                    }
                }

            });
        }



        public RelayCommand NextSongCommand => new RelayCommand(() => nextSong());
        public RelayCommand PreviousSongCommand => new RelayCommand(() => previousSong());

        public RelayCommand ShuffleCommand
        {
            get => new RelayCommand(() =>
            {
                var list = Playlist.ToList();
                var i = 0;
                while (i < Playlist.Count)
                {
                    Playlist.Move(0, new Random().Next(0, Playlist.Count - 1));
                    i++;
                }
            });
        }

        public RelayCommand TranslateCommand
        {
            get => new RelayCommand(() =>
            {

                if (_langState == false)
                {
                    CultureManager.UICulture = new CultureInfo("ru-RU");
                    _langState = true;
                }
                else
                {
                    CultureManager.UICulture = new CultureInfo("en-US");
                    _langState = false;
                }
            });
        }

        public RelayCommand RemoveCommand
        {

            get => new RelayCommand(() =>
            {
                Playlist.Remove(_currentSong);
                waveOut.Stop();

            });
        }


        public void Serealize()
        {

            var sfd = new Microsoft.Win32.SaveFileDialog();
            sfd.CreatePrompt = false;
            sfd.OverwritePrompt = true;
            sfd.Filter = "playlist files (*.playlist) | *.playlist";
            if (sfd.ShowDialog() == true)
            {
                var ps = new PlaylistSaver();
                ps.Save(Playlist, sfd.FileName);
            }

        }

        public void Deserealize()
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "playlist files (*.playlist) | *.playlist";
            if (ofd.ShowDialog() == true)
            {
                Playlist = new PlaylistLoader().Load(ofd.FileName);
            }
            waveOut.Stop();
        }

        public RelayCommand SaveCommand
        {

            get => new RelayCommand(() => Serealize());
        }

        public RelayCommand LoadCommand
        {
            get => new RelayCommand(() => Deserealize());
        }
    }





}

