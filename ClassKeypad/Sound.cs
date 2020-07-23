using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ClassKeypad
{
    public class Sound : Identity
    {      
        public string Name { get; set; }        
        public List<string> Tags { get; private set; }
        
        public string SoundPath;               
 

        public Sound(string name, List<string> tags, string soundpath)
        {           
            this.Tags = new List<string>(); 
            tags = tags.Distinct().ToList();
            this.Tags.AddRange(tags);
            this.Name = name;
            this.SoundPath = soundpath;
        }
       
        public bool Existag(List<string> tags)
        {
            foreach (var tag in tags)
            {
                string findtag = this.Tags.Where(x => x == tag).FirstOrDefault();
                if (findtag == null)
                {
                    return false;
                                       
                }               
            }
            return true;
        }
        public bool Existag(string tag)
        {
                string findtag = this.Tags.Where(x => x == tag).FirstOrDefault();
                if (findtag != null)
                {
                    return true;
                }

         
            return false;
        }
    }
}
