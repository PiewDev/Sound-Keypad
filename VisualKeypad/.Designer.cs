namespace VisualKeypad
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.FlowButtonSounds = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.flowChekTag = new System.Windows.Forms.FlowLayoutPanel();
            this.flowPlayList = new System.Windows.Forms.FlowLayoutPanel();
            this.labelDelete = new System.Windows.Forms.Label();
            this.comboBoxPlayList = new System.Windows.Forms.ComboBox();
            this.ExpandButton = new System.Windows.Forms.Button();
            this.ReduceButton = new System.Windows.Forms.Button();
            this.panelPlayList = new System.Windows.Forms.Panel();
            this.buttonLock = new System.Windows.Forms.Button();
            this.panelPlayList.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlowButtonSounds
            // 
            this.FlowButtonSounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            resources.ApplyResources(this.FlowButtonSounds, "FlowButtonSounds");
            this.FlowButtonSounds.Name = "FlowButtonSounds";
            this.FlowButtonSounds.DragEnter += new System.Windows.Forms.DragEventHandler(this.FlowButtonSounds_DragEnter);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonExit
            // 
            resources.ApplyResources(this.buttonExit, "buttonExit");
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // flowChekTag
            // 
            this.flowChekTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            resources.ApplyResources(this.flowChekTag, "flowChekTag");
            this.flowChekTag.Name = "flowChekTag";
            // 
            // flowPlayList
            // 
            this.flowPlayList.AllowDrop = true;
            this.flowPlayList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            resources.ApplyResources(this.flowPlayList, "flowPlayList");
            this.flowPlayList.Name = "flowPlayList";
            this.flowPlayList.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowPlayList_DragDrop);
            this.flowPlayList.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowPlayList_DragEnter);
            // 
            // labelDelete
            // 
            this.labelDelete.AllowDrop = true;
            this.labelDelete.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.labelDelete, "labelDelete");
            this.labelDelete.Name = "labelDelete";
            this.labelDelete.Click += new System.EventHandler(this.labelDelete_Click);
            this.labelDelete.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelDelete_DragDrop);
            this.labelDelete.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelDelete_DragEnter);
            // 
            // comboBoxPlayList
            // 
            this.comboBoxPlayList.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxPlayList, "comboBoxPlayList");
            this.comboBoxPlayList.Name = "comboBoxPlayList";
            this.comboBoxPlayList.SelectedValueChanged += new System.EventHandler(this.comboBoxPlayList_SelectedValueChanged);
            this.comboBoxPlayList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxPlayList_KeyPress);
            // 
            // ExpandButton
            // 
            resources.ApplyResources(this.ExpandButton, "ExpandButton");
            this.ExpandButton.Name = "ExpandButton";
            this.ExpandButton.UseVisualStyleBackColor = true;
            this.ExpandButton.Click += new System.EventHandler(this.ExpandButton_Click);
            // 
            // ReduceButton
            // 
            resources.ApplyResources(this.ReduceButton, "ReduceButton");
            this.ReduceButton.Name = "ReduceButton";
            this.ReduceButton.UseVisualStyleBackColor = true;
            this.ReduceButton.Click += new System.EventHandler(this.ReduceButton_Click);
            // 
            // panelPlayList
            // 
            this.panelPlayList.Controls.Add(this.buttonLock);
            this.panelPlayList.Controls.Add(this.buttonExit);
            this.panelPlayList.Controls.Add(this.comboBoxPlayList);
            this.panelPlayList.Controls.Add(this.ReduceButton);
            this.panelPlayList.Controls.Add(this.flowPlayList);
            this.panelPlayList.Controls.Add(this.ExpandButton);
            resources.ApplyResources(this.panelPlayList, "panelPlayList");
            this.panelPlayList.Name = "panelPlayList";
            this.panelPlayList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuPrincipal_MouseMove);
            // 
            // buttonLock
            // 
            this.buttonLock.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.buttonLock, "buttonLock");
            this.buttonLock.Name = "buttonLock";
            this.buttonLock.UseVisualStyleBackColor = true;
            this.buttonLock.Click += new System.EventHandler(this.buttonLock_Click);
            // 
            // MenuPrincipal
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Controls.Add(this.panelPlayList);
            this.Controls.Add(this.labelDelete);
            this.Controls.Add(this.flowChekTag);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FlowButtonSounds);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuPrincipal";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MenuPrincipal_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MenuPrincipal_DragEnter);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuPrincipal_MouseMove);
            this.panelPlayList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlowButtonSounds;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.FlowLayoutPanel flowChekTag;
        private System.Windows.Forms.FlowLayoutPanel flowPlayList;
        private System.Windows.Forms.Label labelDelete;
        private System.Windows.Forms.ComboBox comboBoxPlayList;
        private System.Windows.Forms.Button ExpandButton;
        private System.Windows.Forms.Button ReduceButton;
        private System.Windows.Forms.Panel panelPlayList;
        private System.Windows.Forms.Button buttonLock;
    }
}

