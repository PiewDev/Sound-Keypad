using ClassKeypad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using WMPLib;


namespace VisualKeypad
{
    public partial class MenuPrincipal : Form, IForm
    {
        public int xClick = 0, yClick = 0;
        public IKeypad keypad { get; set; }
        private List<String> TagsOn = new List<string>();
        private WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
        private PlayList playList = new PlayList("");
        private Size minSize;
        private Size defaultSize;        
        private int playListLeft;
        private int defaultLeft;
        Cursor BitMapCursor;
        Point mousepos;
        
        public MenuPrincipal()
        {            
            this.keypad = new Keypad();
            this.keypad.SoundsChange += Keypad_SoundsChange;
            this.keypad.TagsChange += Keypad_TagsChange;
            this.keypad.PlayListChange += Keypad_PlayListChange;
            InitializeComponent();
            this.playListLeft = this.panelPlayList.Left;
            this.defaultSize = this.Size;
            this.minSize = new Size(1122, this.Size.Height);            
            this.comboBoxPlayList.ValueMember = "Name";
            this.comboBoxPlayList.DisplayMember = "Name";
            //this.checkedListBoxTags.Items.AddRange(this.GetTagList().ToArray());          
            
        }

        private void Keypad_PlayListChange()
        {
            this.LoadPlaylistSounds();
            this.RefreshList();
        }

        private void Keypad_TagsChange()
        {
            this.LoadTags();
           
        }

        private void Keypad_SoundsChange()
        {
            this.LoadButtons();
        }


        // LOAD 
        #region LOAD
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            List<PlayList> playLists = this.ReturnPlayLists();
            this.playList = playLists.FirstOrDefault();
            this.LoadButtons();
            this.LoadTags();
            this.RefreshList();
            this.LoadPlaylistSounds();
        }
        private void LoadPlaylistSounds()
        {
            this.flowPlayList.Controls.Clear();
            foreach (var sound in this.playList.ReturnSounds())
            {                
                SoundButton btn = this.CreateButtonInFlowPlayList(sound);                
                btn.IsPlayList = true;
            }
            this.RefreshList();

        }
        private void LoadButtons()
        {
            this.FlowButtonSounds.Controls.Clear();
            if (this.TagsOn.Count == 0)
            {
                foreach (var sound in this.ReturnSounds())
                {
                    this.CreateButtonInFlowButtonSounds(sound);
                }
            }
            else
            {
                foreach (var sound in this.FilterSounds(this.TagsOn))
                {
                    this.CreateButtonInFlowButtonSounds(sound);
                }
            }



        }


        private void LoadTags()
        {
            this.flowChekTag.Controls.Clear();

            foreach (var tag in this.ReturnTags())
            {
                CheckBox chk = new CheckBox()
                {
                    Name = tag,
                    Text = tag,
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(32, 33, 36),

                };
                chk.Size = new Size(150, chk.Size.Height);
                chk.Font = new Font(chk.Font.FontFamily, 12.5f);
                chk.CheckedChanged += new EventHandler(ItemChecked);
                flowChekTag.Controls.Add(chk);
            }
            //var sounds = ReturnSounds();
            //foreach (var sound in sounds)
            //{
            //    this.CreateCheck(sound);
            //}

        }
        #endregion

        // ButtonsHandling        
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            CreateButton createbtn = new CreateButton();
            createbtn.Owner = this;
            createbtn.Show();
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //dinamic
        public void CreateButtonInFlowButtonSounds(Sound sound)
        {
            FlowButtonSounds.Controls.Add(CreateButtons(sound));
        }
        //public void CreateButtonInFlowButtonSounds(string name, string id, object owner)
        //{
        //    FlowButtonSounds.Controls.Add(CreateButtons(name,id));
        //    if (owner != this)
        //    {
        //         this.LoadTags();
        //    }            
        //}
        public SoundButton CreateButtonInFlowPlayList(Sound sound)
        {
            SoundButton btn = CreateButtons(sound);
            btn.Width = this.flowPlayList.Width -7;
            btn.Height = 40;
            flowPlayList.Controls.Add(btn);
            return btn;
        }
        private SoundButton CreateButtons(Sound sound)
        {
            SoundButton btn = new SoundButton(sound)
            {
                Name = sound.Name,
                Text = sound.Name,
                Height = 80,
                Width = 80,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(32, 33, 36)
            };
            btn.QueryContinueDrag += new QueryContinueDragEventHandler(ClickButton);
            btn.MouseDown += new MouseEventHandler(btn_MouseDown);
            btn.GiveFeedback += new GiveFeedbackEventHandler(btn_GiveFeedback);
            return btn;

        }
       
        private void btn_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            //Deactivate the default cursor
            e.UseDefaultCursors = false;
            //Use the cursor created from the bitmap
            Cursor.Current = this.BitMapCursor;


        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            //Cast the sender to control type youre using
            this.mousepos = Cursor.Position;
            SoundButton send = (SoundButton)sender;
            if (e.Button == MouseButtons.Left)
            {

                Bitmap bmp = new Bitmap(send.Width, send.Height);
                send.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
                //In a variable save the cursor with the image of your controler
                this.BitMapCursor = new Cursor(bmp.GetHicon());
                send.DoDragDrop(send, DragDropEffects.Move);


            }
            //Copy the control in a bitmap


        }

        private void ClickButton(object sender, QueryContinueDragEventArgs e)
        {
            SoundButton btn = (SoundButton)sender;           
            if (e.Action != DragAction.Continue && this.mousepos == Cursor.Position)
            {
                
                    string url = this.SearchPath(btn.Sound);
                    this.wplayer.controls.stop();
                    if (this.wplayer.URL != url)
                    {
                        this.wplayer.URL = url;
                        this.wplayer.controls.play();
                    }
                    else
                    {
                        this.wplayer.URL = "";
                    }
                
            }
           

        }

        private void MouseeUp(object sender, MouseEventArgs e)
        {
           
        }


        //TagHandling
        private void ItemChecked(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)
            {
                this.TagsOn.Add(chk.Name);
            }
            else
            {
                this.TagsOn.Remove(chk.Name);
            }
            this.LoadButtons();

            //RefreshButtons();

        }

        // DragHandling
        private void MenuPrincipal_DragDrop(object sender, DragEventArgs e)
        {
            CreateButton btn = new CreateButton(sender, e);
            btn.Owner = this;
            btn.Show();
        }
        private void MenuPrincipal_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        private void labelDelete_DragDrop(object sender, DragEventArgs e)
        {
            var send = (Label)sender;           
            SoundButton btn = (SoundButton)e.Data.GetData(typeof(SoundButton));
            if (btn.IsPlayList == false)
            {
                this.DeleteSound(btn.Sound);
            }
            else
            {
                this.DeleteSoundInPlayList(btn.Sound);
            }
            //this.LoadButtons();
            send.Size = new Size(send.Size.Width - 10, send.Size.Height - 10);

        }
        private void labelDelete_DragEnter(object sender, DragEventArgs e)
        {
            var send = (Label)sender;
            SoundButton IsButton = (SoundButton)e.Data.GetData(typeof(SoundButton));
            if (IsButton != null)
            {
                send.Size = new Size(send.Size.Width + 10, send.Size.Height + 10);
                e.Effect = DragDropEffects.Move;
                send.DragLeave += new EventHandler(labelDelete_DragLeave);

            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }
        private void labelDelete_DragLeave(object sender, EventArgs e)
        {
            var send = (Label)sender;
            send.Size = new Size(send.Size.Width - 10, send.Size.Height - 10);
            send.DragLeave -= new EventHandler(labelDelete_DragLeave);
        }
        private void flowPlayList_DragEnter(object sender, DragEventArgs e)
        {
            SoundButton IsButton = (SoundButton)e.Data.GetData(typeof(SoundButton));
            if (IsButton != null && IsButton.IsPlayList == false)
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void flowPlayList_DragDrop(object sender, DragEventArgs e)
        {

            SoundButton btn = (SoundButton)e.Data.GetData(typeof(SoundButton));
            if (this.playList.Name == "")
            {
                this.playList = new PlayList();
            }            
            this.playList.AddSound(btn.Sound);           
            //this.CreateButtonInFlowPlayList(btn.Text, btn.Name);
            //this.flowPlayList.Controls.Add(btn);
            this.SavePlayList(this.playList);
            this.LoadPlaylistSounds();
        }

        //LabelDelete

        private void labelDelete_Click(object sender, EventArgs e)
        {

        }

        //IKeypad
        #region Ikeypad
        public string SearchPath(Sound sound)
        {
            return keypad.SearchPath(sound);
        }
        public void SaveSound(Sound sound)
        {
            keypad.SaveSound(sound);
        }
        public List<string> ReturnTags()
        {
            return this.keypad.ReturnTags();
        }
        public List<Sound> FilterSounds(List<string> tags)
        {
            return this.keypad.FilterSounds(tags);
        }
        public List<Sound> ReturnSounds()
        {
            return this.keypad.ReturnSounds();
        }
        public void DeleteSound(Sound sound)
        {
            this.keypad.DeleteSound(sound);           
        }
        public List<PlayList> ReturnPlayLists()
        {
            return this.keypad.ReturnPlayLists();
        }
        public PlayList ReturnPlayList(string name)
        {
            return this.keypad.ReturnPlayList(name);
        }
        public bool ExistPlayList(string name)
        {
            return this.keypad.ExistPlayList(name);
        }
        public void SavePlayList(PlayList playList)
        {
            if (!String.IsNullOrEmpty(playList.Name) && !String.IsNullOrWhiteSpace(playList.Name))
                this.keypad.SavePlayList(playList);
        }
        #endregion

        //PlayList
        private void RefreshList()
        {            
            this.comboBoxPlayList.Items.Clear();           
            this.comboBoxPlayList.Items.AddRange(this.ReturnPlayLists().ToArray());          
            if (this.playList == null)
            {
                this.playList = new PlayList("");
            }           
            if (this.comboBoxPlayList.Text != this.playList.Name)            
                this.comboBoxPlayList.Text = this.playList.Name;                       
            this.comboBoxPlayList.Refresh();
        }
        private void comboBoxPlayList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string name = this.comboBoxPlayList.Text.ToString();
                if (ExistPlayList(name))
                {
                    this.playList = this.ReturnPlayList(name);
                }
                else if (!String.IsNullOrWhiteSpace(this.comboBoxPlayList.Text) || !String.IsNullOrEmpty(this.comboBoxPlayList.Text))
                {
                    this.playList = new PlayList(name);
                    this.SavePlayList(playList);
                }
            }
        }
        public void DeleteSoundInPlayList(Sound sound)
        {
            this.keypad.DeleteSoundInPlayList(sound, this.playList);
        }

        //Legacy
        private void CreateCheck(Sound sound)
        {
            foreach (var tag in sound.Tags)
            {
                CheckBox chk = new CheckBox()
                {
                    Name = tag,
                    Text = tag,
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(32, 33, 36)
                };
                chk.CheckedChanged += new EventHandler(ItemChecked);
                flowChekTag.Controls.Add(chk);
            }
        }       
        private void comboBoxPlayList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void FlowButtonSounds_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxPlayList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ExistPlayList(this.comboBoxPlayList.Text))
            {
                this.playList = this.ReturnPlayList(this.comboBoxPlayList.Text);
                this.LoadPlaylistSounds();
                
            }
            else if (String.IsNullOrWhiteSpace(this.comboBoxPlayList.Text) && String.IsNullOrEmpty(this.comboBoxPlayList.Text))
            {
                this.playList = new PlayList()
                {
                    Name = this.comboBoxPlayList.Text
                };
                this.SavePlayList(playList);
                this.RefreshList();
            }

        }

        private void ReduceButton_Click(object sender, EventArgs e)
        {
            if (this.Size == this.defaultSize)
                this.Size = this.minSize;
            else if (this.Size == this.panelPlayList.Size)
            {
                this.Size = this.defaultSize;
                this.panelPlayList.Left = this.playListLeft;
                this.Left = defaultLeft;
                
            }

        }

        private void MenuPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { 
                xClick = e.X; yClick = e.Y; 
            }
            else
            {
                this.defaultLeft = this.Left;
                this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick);                
            }
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            if (this.TopMost)
            {
                this.TopMost = false;
                this.buttonLock.ForeColor = Color.Red;
            }
            else
            {
                this.TopMost = true;
                this.buttonLock.ForeColor = Color.Green;
            }
            
        }

        private void FlowButtonSounds_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void ExpandButton_Click(object sender, EventArgs e)
        {
            if (this.Size == this.defaultSize)
            {
                
                this.defaultLeft = this.Left;                
                this.Size = this.panelPlayList.Size;
                this.Left = this.panelPlayList.Left;
                this.panelPlayList.Left = 0;                
                

            }                
            else if (this.Size == this.minSize)
            {
                this.Size = this.defaultSize;
            }
        }
    }
}
