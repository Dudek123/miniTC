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
            this.panelMiniTCRight = new miniTC.Views.PanelMiniTC();
            this.panelMiniTCLeft = new miniTC.Views.PanelMiniTC();
            this.SuspendLayout();
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
            // 
            // panelMiniTCLeft
            // 
            this.panelMiniTCLeft.CurrentPath = "";
            this.panelMiniTCLeft.Drives = ((System.Collections.Generic.List<string>)(resources.GetObject("panelMiniTCLeft.Drives")));
            this.panelMiniTCLeft.Items = ((System.Collections.Generic.List<string>)(resources.GetObject("panelMiniTCLeft.Items")));
            this.panelMiniTCLeft.Location = new System.Drawing.Point(12, 12);
            this.panelMiniTCLeft.Name = "panelMiniTCLeft";
            this.panelMiniTCLeft.Size = new System.Drawing.Size(383, 493);
            this.panelMiniTCLeft.TabIndex = 0;
            // 
            // miniTCView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 513);
            this.Controls.Add(this.panelMiniTCRight);
            this.Controls.Add(this.panelMiniTCLeft);
            this.Name = "miniTCView";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.miniTCView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Views.PanelMiniTC panelMiniTCLeft;
        private Views.PanelMiniTC panelMiniTCRight;
    }
}

