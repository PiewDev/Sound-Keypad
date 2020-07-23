using ClassKeypad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VisualKeypad
{
    public partial class CreateButton : Form
    {
        private List<String> Tags = new List<string>();
        private string path;
        public CreateButton()
        {
            InitializeComponent();        
        }
        public CreateButton(object sender, DragEventArgs e)
           
        {
            InitializeComponent();
            this.label1_DragDrop(sender, e);            
        }



        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.path = openFileDialog1.FileName;
                labelFile.Text = Path.GetFileName(this.path);
            }
        }

        private void label1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                this.path = s[i];
                labelFile.Text = Path.GetFileName(path);
            if (String.IsNullOrEmpty(this.textBoxName.Text) || String.IsNullOrWhiteSpace(this.textBoxName.Text))
            {
                this.textBoxName.Text = Path.GetFileNameWithoutExtension(path);
            }
        }

        private void label1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void richTextBoxTags_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == ',')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }

       }

        private void DeleteLabel(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            this.Tags.Remove(lbl.Text);
            lbl.Visible = false;
        }
        private void richTextBoxTags_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            var owned = this.Owner as IForm;
            if (owned != null)
            {
                try
                {
                    Sound sound = new Sound(this.textBoxName.Text, this.Tags, this.path);                   
                    owned.SaveSound(sound);                    
                    //owned.CreateButtonInFlowButtonSounds(this.textBoxName.Text,id, this);
                    DialogResult saved = MessageBox.Show("Do you want to create another sound?", "Saved successfully", MessageBoxButtons.YesNo);
                    if (saved == DialogResult.No)
                        this.Close();
                    else
                    {
                        this.Clean();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                       
              
              
            }

        }

        private void CreateButton_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
        private void textBoxName_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }
        private void Clean()
        {
            this.textBoxName.Text = "";
            this.labelFile.Text = "";
            this.richTextBoxTags.Text = "";
            this.flowLabelTags.Controls.Clear();
            this.Tags.Clear();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBoxTags_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == 188)
            {                
                if (!string.IsNullOrEmpty(richTextBoxTags.Text) && !string.IsNullOrWhiteSpace(richTextBoxTags.Text))
                {
                    foreach (Control item in flowLabelTags.Controls.OfType<Control>())
                    {
                        if (item.Name == richTextBoxTags.Text)
                            flowLabelTags.Controls.Remove(item);
                    }
                    Label lbl = new Label()
                    {
                        Name = richTextBoxTags.Text,
                        Text = richTextBoxTags.Text,
                        ForeColor = Color.White
                    };
                    lbl.Click += new EventHandler(DeleteLabel);
                    flowLabelTags.Controls.Add(lbl);
                    this.Tags.Add(this.richTextBoxTags.Text);
                    this.richTextBoxTags.Text = "";
                }                
                e.Handled = true;
            }
            

        }

        private void richTextBoxTags_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void buttonSave_DragOver(object sender, DragEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
