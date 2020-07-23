using System;
using System.Collections.Generic;
using static ClassKeypad.Keypad;

namespace ClassKeypad
{
   
    public interface IKeypad   
    {
        event ListEventHandler PlayListChange;

        event ListEventHandler TagsChange;

        event ListEventHandler SoundsChange;
        string SearchPath(Sound sound);
        void SaveSound(Sound sound);
        List<string> ReturnTags();
        List<Sound> FilterSounds(List<string> tags);
        List<Sound> ReturnSounds();       
        void DeleteSound(Sound sound);
        List<PlayList> ReturnPlayLists();
        PlayList ReturnPlayList(string name);
        bool ExistPlayList(string name);
        void SavePlayList(PlayList playList);
        void DeleteSoundInPlayList(Sound sound, PlayList playList);


    }
}