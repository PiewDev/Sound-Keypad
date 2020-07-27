using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using JsonManagement;
using Newtonsoft.Json;

namespace ClassKeypad
{
    public class Keypad : IKeypad
    {
        private ObservableCollection<Sound> Sounds;        
        private ObservableCollection<String> Tags;
        private ObservableCollection<PlayList> PlayLists;
        public delegate void ListEventHandler();
        public event ListEventHandler SoundsChange;
        public event ListEventHandler TagsChange;
        public event ListEventHandler PlayListChange;        
       

        public Keypad()        
        {
            this.Sounds = new ObservableCollection<Sound>();
            this.Tags = new ObservableCollection<string>();
            this.PlayLists = new ObservableCollection<PlayList>();            
            Deserialized();
        }

       private void SoundCollectionChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.SoundsChange();
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                List<Sound> sounds = new List<Sound>();
                foreach (Object item in e.OldItems)
                {
                    Sound sound = (Sound)item;                    
                    sounds.Add(sound);
                    foreach (var tag in sound.Tags)
                    {
                        var existSounds = FilterSounds(tag);
                        if (existSounds.Count == 0)
                        {
                            this.Tags.Remove(tag);
                        }
                    }
                  
                }
                foreach (var playlist in this.PlayLists)
                {
                    playlist.DeleteSounds(sounds);
                    this.PlayListChange();
                }
                
               


            }
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Sound sound in e.OldItems)
                {                                       
                    foreach (var tag in sound.Tags)
                    {
                        var existSounds = FilterSounds(tag);
                        if (existSounds.Count == 0)
                        {
                            this.Tags.Remove(tag);
                        }
                    }

                }

            }
            

        }        


        #region FilesSystem
        private void Deserialized()
        {
            this.Sounds = this.Sounds.Deserialize("Sounds");
            this.Sounds.CollectionChanged += this.SoundCollectionChange;
            this.Tags = this.Tags.Deserialize("Tags");
            this.Tags.CollectionChanged += this.TagCollectionChange;
            this.PlayLists = this.PlayLists.Deserialize("PlayLists");
            this.PlayLists.CollectionChanged += PlayLists_CollectionChanged;
        }

        private void PlayLists_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.Serialized();
            this.PlayListChange();
        }

        private void TagCollectionChange(object sender, NotifyCollectionChangedEventArgs e)
        {            
            this.TagsChange();
        }

        private string CopyFile(string path)
        {
            var finalpath = Directory.GetCurrentDirectory() + "\\Sounds\\" + Path.GetFileName(path);
            bool work = this.CopyBool(path, finalpath);
            if (!work)
            {
                for (int i = 1; i < 100; i++)
                {
                    finalpath = Directory.GetCurrentDirectory() + "\\Sounds\\" + Path.GetFileNameWithoutExtension(path) + $"({i})" + Path.GetExtension(path);
                    if (this.CopyBool(path, finalpath))
                        return finalpath;
                }

            }
            return finalpath;

        }
        private bool CopyBool(string path, string finalpath)
        {
            try
            {
                File.Copy(path, finalpath);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        private void Serialized()
        {
           this.Sounds.Serialize("Sounds");
           this.Tags.Serialize("Tags");
            this.PlayLists.Serialize("PlayLists");

           
        }
        #endregion


        private void AddTags(List<string> tags)
        {
            foreach (var tag in tags)
            {
               if (!this.Tags.ToList().Exists(x=> x == tag))
                {
                    this.Tags.Add(tag);
                }
            }
            this.Serialized();
        }
       
        public List<Sound> FilterSounds(string tag)
        {
            List<Sound> sounds = new List<Sound>();
            foreach (var sound in this.Sounds)
            {
                if (sound.Existag(tag))
                {
                    sounds.Add(sound);
                }

            }
            return sounds;
        }


        //Ikeypad
        #region Ikeypad
        public string SearchPath(Sound sound)
        {
            return Sounds.Where(x => x == sound).FirstOrDefault().SoundPath;
        }
        public void SaveSound(Sound sound)
        {
            try
            {
                var searchSound = this.Sounds.Where(x => x == sound).FirstOrDefault();
                if (searchSound != null)
                {
                    searchSound.Modify(sound);
                    this.SoundCollectionChange(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,this.Sounds));
                }
                else
                {
                    sound.SoundPath = this.CopyFile(sound.SoundPath);
                    this.Sounds.Add(sound);
                    this.AddTags(sound.Tags);
                }              
                this.Serialized();
               
                
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<string> ReturnTags()
        {
            return this.Tags.ToList();
        }
        public List<Sound> FilterSounds(List<string> tags)
        {
            List<Sound> sounds = new List<Sound>();
            foreach (var sound in this.Sounds)
            {
                if (sound.Existag(tags))
                {
                    sounds.Add(sound);
                }

            }
            return sounds;
        }
        public List<Sound> ReturnSounds()
        {
            return this.Sounds.ToList(); ;
        }
        public Sound ReturnSound(Sound sound)
        {
            return this.Sounds.Where(x => x == sound).FirstOrDefault();
        }
        public void DeleteSound(Sound sound)
        {
            sound = this.Sounds.Where(x => x == sound).FirstOrDefault();
            this.Sounds.Remove(sound);
            File.Delete(sound.SoundPath);
            this.Serialized();
        }
        public List<PlayList> ReturnPlayLists()
        {
            return this.PlayLists.ToList();
        }
        public PlayList ReturnPlayList(string name)
        {
            return this.PlayLists.Where(x => x.Name == name).FirstOrDefault();
        }
        public bool ExistPlayList(string name)
        {
            try
            {
                return this.PlayLists.ToList().Exists(x => x.Name == name);
            }
            catch (Exception)
            {

                return false;
            }
            
        }
        public void SavePlayList(PlayList playList)
        {
            var index = this.PlayLists.IndexOf(playList);            
            if (index != -1 )
            {
                this.PlayLists[index] = playList;
            }
            else
            {
                var newname = playList.Name;
                for (int i = 1; i < 100; i++)
                {
                    if (this.PlayLists.ToList()
                                      .Exists(x => x.Name == newname))

                    {
                        newname = playList.Name + $" ({(i).ToString()})";
                    }
                    else
                        break;
                }
                playList.Name = newname;
                this.PlayLists.Add(playList);
                this.Serialized();
            }
           
        }
        public void DeleteSoundInPlayList(Sound sound, PlayList playList)
        {
            PlayList plist = this.PlayLists.Where(x => x == playList).FirstOrDefault();
            plist.DeleteSound(sound);
            this.PlayListChange();
            this.Serialized();

        }
        
        
       
       
        
        
        
        
        
        
        #endregion
    }
}
