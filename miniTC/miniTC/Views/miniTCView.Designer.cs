namespace miniTC
{
    partial class miniTCView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(miniTCView));
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonMove = new System.Windows.Forms.Button();
            this.labelDirection = new System.Windows.Forms.Label();
            this.panelMiniTCRight = new miniTC.Views.PanelMiniTC();
            this.panelMiniTCLeft = new miniTC.Views.PanelMiniTC();
            this.SuspendLayout();
            // 
            // buttonCopy
            // 
            this.buttonCopy.Enabled = false;
            this.buttonCopy.Location = new System.Drawing.Point(398, 78);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(77, 23);
            this.buttonCopy.TabIndex = 2;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(398, 136);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(77, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonMove
            // 
            this.buttonMove.Enabled = false;
            this.buttonMove.Location = new System.Drawing.Point(398, 107);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(77, 23);
            this.buttonMove.TabIndex = 4;
            this.buttonMove.Text = "Move";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // labelDirection
            // 
            this.labelDirection.AutoSize = true;
            this.labelDirection.Location = new System.Drawing.Point(415, 199);
            this.labelDirection.Name = "labelDirection";
            this.labelDirection.Size = new System.Drawing.Size(37, 13);
            this.labelDirection.TabIndex = 5;
            this.labelDirection.Text = "-------->";
            // 
            // panelMiniTCRight
            // 
            this.panelMiniTCRight.CurrentPath = "";
            this.panelMiniTCRight.Drives = ((System.Collections.Generic.List<string>)(resources.GetObject("panelMiniTCRight.Drives")));
            this.panelMiniTCRight.Items = ((System.Collections.Generic.List<string>)(resources.GetObject("panelMiniTCRight.Items")));
            this.panelMiniTCRight.Location = new System.Drawing.Point(477, 12);
            this.panelMiniTCRight.Name = "panelMiniTCRight";
            this.panelMiniTCRight.Size = new System.Drawing.Size(383, 493);
            this.panelMiniTCRight.TabIndex = 1;
            this.panelMiniTCRight.Click += new System.EventHandler(this.panelMiniTCRight_Click);
            this.panelMiniTCRight.Enter += new System.EventHandler(this.panelMiniTCRight_Click);
            // 
            // panelMiniTCLeft
            // 
            this.panelMiniTCLeft.BackColor = System.Drawing.SystemColors.Control;
            this.panelMiniTCLeft.CurrentPath = "";
            this.panelMiniTCLeft.Drives = ((System.Collections.Generic.List<string>)(resources.GetObject("panelMiniTCLeft.Drives")));
            this.panelMiniTCLeft.Items = ((System.Collections.Generic.List<string>)(resources.GetObject("panelMiniTCLeft.Items")));
            this.panelMiniTCLeft.Location = new System.Drawing.Point(12, 12);
            this.panelMiniTCLeft.Name = "panelMiniTCLeft";
            this.panelMiniTCLeft.Size = new System.Drawing.Size(383, 493);
            this.panelMiniTCLeft.TabIndex = 0;
            this.panelMiniTCLeft.Click += new System.EventHandler(this.panelMiniTCLeft_Click);
            this.panelMiniTCLeft.Enter += new System.EventHandler(this.panelMiniTCLeft_Click);
            // 
            // miniTCView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(874, 513);
            this.Controls.Add(this.labelDirection);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.panelMiniTCRight);
            this.Controls.Add(this.panelMiniTCLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "miniTCView";
            this.Text = "miniTC";
            this.Load += new System.EventHandler(this.miniTCView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Views.PanelMiniTC panelMiniTCLeft;
        private Views.PanelMiniTC panelMiniTCRight;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Label labelDirection;
    }
}

