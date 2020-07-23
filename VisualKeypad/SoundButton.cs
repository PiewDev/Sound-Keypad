using ClassKeypad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace VisualKeypad
{
    public class SoundButton : Button
    {
        public Button btncerrar { get; set; }
        public Sound Sound { get; set; }
        public bool IsPlayList { get; set; }
        public SoundButton(Sound sound)
        {
            this.IsPlayList = false;
            this.btncerrar = new Button();
            this.Sound = sound;           
        }
       

              
    }
}
