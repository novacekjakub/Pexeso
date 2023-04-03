namespace Pexeso
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TStart = new System.Windows.Forms.Button();
            this.LFinal = new System.Windows.Forms.Label();
            this.LSkore = new System.Windows.Forms.Label();
            this.LNavod = new System.Windows.Forms.Label();
            this.TRestart = new System.Windows.Forms.Button();
            this.LPokusy = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TStart
            // 
            this.TStart.Location = new System.Drawing.Point(313, 289);
            this.TStart.Name = "TStart";
            this.TStart.Size = new System.Drawing.Size(167, 83);
            this.TStart.TabIndex = 0;
            this.TStart.Text = "START";
            this.TStart.UseVisualStyleBackColor = true;
            this.TStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // LFinal
            // 
            this.LFinal.AutoSize = true;
            this.LFinal.Location = new System.Drawing.Point(216, 146);
            this.LFinal.Name = "LFinal";
            this.LFinal.Size = new System.Drawing.Size(47, 20);
            this.LFinal.TabIndex = 1;
            this.LFinal.Text = "LFinal";
            this.LFinal.Click += new System.EventHandler(this.label1_Click);
            // 
            // LSkore
            // 
            this.LSkore.AutoSize = true;
            this.LSkore.Location = new System.Drawing.Point(362, 412);
            this.LSkore.Name = "LSkore";
            this.LSkore.Size = new System.Drawing.Size(53, 20);
            this.LSkore.TabIndex = 2;
            this.LSkore.Text = "LSkore";
            this.LSkore.Click += new System.EventHandler(this.label2_Click);
            // 
            // LNavod
            // 
            this.LNavod.AutoSize = true;
            this.LNavod.Location = new System.Drawing.Point(362, 211);
            this.LNavod.Name = "LNavod";
            this.LNavod.Size = new System.Drawing.Size(60, 20);
            this.LNavod.TabIndex = 3;
            this.LNavod.Tag = "Návod";
            this.LNavod.Text = "LNavod";
            this.LNavod.Click += new System.EventHandler(this.LNavod_Click);
            // 
            // TRestart
            // 
            this.TRestart.Location = new System.Drawing.Point(313, 289);
            this.TRestart.Name = "TRestart";
            this.TRestart.Size = new System.Drawing.Size(167, 83);
            this.TRestart.TabIndex = 5;
            this.TRestart.Text = "RESTART";
            this.TRestart.UseVisualStyleBackColor = true;
            this.TRestart.Click += new System.EventHandler(this.TRestart_Click);
            // 
            // LPokusy
            // 
            this.LPokusy.AutoSize = true;
            this.LPokusy.Location = new System.Drawing.Point(636, 413);
            this.LPokusy.Name = "LPokusy";
            this.LPokusy.Size = new System.Drawing.Size(50, 20);
            this.LPokusy.TabIndex = 6;
            this.LPokusy.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LPokusy);
            this.Controls.Add(this.TRestart);
            this.Controls.Add(this.LNavod);
            this.Controls.Add(this.LSkore);
            this.Controls.Add(this.LFinal);
            this.Controls.Add(this.TStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button TStart;
        private Label LFinal;
        private Label LSkore;
        private Label LNavod;
        private Button TRestart;
        private Label LPokusy;
    }
}