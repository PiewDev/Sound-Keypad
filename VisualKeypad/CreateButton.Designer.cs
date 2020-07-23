namespace VisualKeypad
{
    partial class CreateButton
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.labelSound = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonFile = new System.Windows.Forms.Button();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelTags = new System.Windows.Forms.Label();
            this.richTextBoxTags = new System.Windows.Forms.RichTextBox();
            this.flowLabelTags = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(37, 53);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(53, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // labelSound
            // 
            this.labelSound.AutoSize = true;
            this.labelSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSound.ForeColor = System.Drawing.Color.White;
            this.labelSound.Location = new System.Drawing.Point(34, 126);
            this.labelSound.Name = "labelSound";
            this.labelSound.Size = new System.Drawing.Size(56, 20);
            this.labelSound.TabIndex = 2;
            this.labelSound.Text = "Sound";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Media Files|*.wav;*.mp3;*.mp2;*.wma";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk_1);
            // 
            // buttonFile
            // 
            this.buttonFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonFile.ForeColor = System.Drawing.Color.Black;
            this.buttonFile.Location = new System.Drawing.Point(236, 154);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(76, 22);
            this.buttonFile.TabIndex = 4;
            this.buttonFile.Text = "Open File";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelFile
            // 
            this.labelFile.AllowDrop = true;
            this.labelFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.labelFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelFile.ForeColor = System.Drawing.Color.White;
            this.labelFile.Location = new System.Drawing.Point(37, 155);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(202, 20);
            this.labelFile.TabIndex = 5;
            this.labelFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.label1_DragDrop);
            this.labelFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.label1_DragEnter);
            // 
            // labelTags
            // 
            this.labelTags.AutoSize = true;
            this.labelTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTags.ForeColor = System.Drawing.Color.White;
            this.labelTags.Location = new System.Drawing.Point(34, 195);
            this.labelTags.Name = "labelTags";
            this.labelTags.Size = new System.Drawing.Size(46, 20);
            this.labelTags.TabIndex = 6;
            this.labelTags.Text = "Tags";
            // 
            // richTextBoxTags
            // 
            this.richTextBoxTags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.richTextBoxTags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.richTextBoxTags.ForeColor = System.Drawing.Color.White;
            this.richTextBoxTags.Location = new System.Drawing.Point(38, 219);
            this.richTextBoxTags.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxTags.MaxLength = 12;
            this.richTextBoxTags.Name = "richTextBoxTags";
            this.richTextBoxTags.Size = new System.Drawing.Size(274, 20);
            this.richTextBoxTags.TabIndex = 8;
            this.richTextBoxTags.Text = "";
            this.richTextBoxTags.TextChanged += new System.EventHandler(this.richTextBoxTags_TextChanged_1);
            this.richTextBoxTags.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxTags_KeyDown);
            this.richTextBoxTags.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxTags_KeyPress);
            // 
            // flowLabelTags
            // 
            this.flowLabelTags.Location = new System.Drawing.Point(38, 258);
            this.flowLabelTags.Name = "flowLabelTags";
            this.flowLabelTags.Size = new System.Drawing.Size(274, 101);
            this.flowLabelTags.TabIndex = 9;
            this.flowLabelTags.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(117, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "New Sound";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.ForeColor = System.Drawing.Color.Black;
            this.buttonSave.Location = new System.Drawing.Point(237, 379);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click_1);
            this.buttonSave.DragOver += new System.Windows.Forms.DragEventHandler(this.buttonSave_DragOver);
            // 
            // buttonCancel
            // 
            this.buttonCancel.ForeColor = System.Drawing.Color.Black;
            this.buttonCancel.Location = new System.Drawing.Point(38, 379);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.textBoxName.ForeColor = System.Drawing.Color.White;
            this.textBoxName.Location = new System.Drawing.Point(41, 85);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(271, 19);
            this.textBoxName.TabIndex = 13;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged_1);
            // 
            // CreateButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(348, 414);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxTags);
            this.Controls.Add(this.flowLabelTags);
            this.Controls.Add(this.labelTags);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.labelSound);
            this.Controls.Add(this.labelName);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateButton";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create";
            this.Load += new System.EventHandler(this.CreateButton_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelSound;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelTags;
        private System.Windows.Forms.RichTextBox richTextBoxTags;
        private System.Windows.Forms.FlowLayoutPanel flowLabelTags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxName;
    }
}