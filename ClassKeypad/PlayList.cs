using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassKeypad
{
    public class PlayList : Identity
    {      

        public List<Sound> Sounds;
        public string Name { get; set; }

        
        public PlayList(string name = "PlayList")        
        {          
            this.Sounds = new List<Sound>();
            this.Name = name;
        }

        public void AddSound(Sound sound)
        {
            this.Sounds.Add(sound);
        }
        public void DeleteSound(Sound sound)
        {
            this.Sounds.Remove(sound);
        }
        public void DeleteSounds(List<Sound> sounds)
        {
            foreach (var sound in sounds)
            {
                this.Sounds.RemoveAll(x => x == sound);
            }
            
        }
        public void ModifySounds(List<Sound> oldsounds, List<Sound> newsounds)
        {
            foreach (var oldsound in oldsounds)
            {
                var index = this.Sounds.FindIndex(x => x == oldsound);
                this.Sounds[index] = newsounds.Where(x => x == oldsound).FirstOrDefault();
            }
        }
        public List<Sound> ReturnSounds()
        {
            return this.Sounds;
        }
    }
}
