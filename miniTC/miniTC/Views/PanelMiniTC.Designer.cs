namespace miniTC.Views
{
    partial class PanelMiniTC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBack = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.comboBoxDrives = new System.Windows.Forms.ComboBox();
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.Beige;
            this.buttonBack.Location = new System.Drawing.Point(3, 17);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(29, 20);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "<-";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.BackColor = System.Drawing.Color.Beige;
            this.textBoxPath.Location = new System.Drawing.Point(38, 18);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(291, 20);
            this.textBoxPath.TabIndex = 1;
            // 
            // comboBoxDrives
            // 
            this.comboBoxDrives.BackColor = System.Drawing.Color.Beige;
            this.comboBoxDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDrives.FormattingEnabled = true;
            this.comboBoxDrives.Location = new System.Drawing.Point(335, 18);
            this.comboBoxDrives.Name = "comboBoxDrives";
            this.comboBoxDrives.Size = new System.Drawing.Size(45, 21);
            this.comboBoxDrives.TabIndex = 2;
            this.comboBoxDrives.SelectedIndexChanged += new System.EventHandler(this.comboBoxDrives_SelectedIndexChanged);
            this.comboBoxDrives.Click += new System.EventHandler(this.comboBoxDrives_Click);
            // 
            // listBoxItems
            // 
            this.listBoxItems.BackColor = System.Drawing.Color.Beige;
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.Location = new System.Drawing.Point(3, 44);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(377, 446);
            this.listBoxItems.TabIndex = 3;
            this.listBoxItems.DoubleClick += new System.EventHandler(this.listBoxItems_DoubleClick);
            // 
            // PanelMiniTC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxItems);
            this.Controls.Add(this.comboBoxDrives);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.buttonBack);
            this.Name = "PanelMiniTC";
            this.Size = new System.Drawing.Size(383, 498);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.ComboBox comboBoxDrives;
        private System.Windows.Forms.ListBox listBoxItems;
    }
}
