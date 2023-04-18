namespace PYS.Application.Security.TestForm
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.TxtCleanText = new System.Windows.Forms.TextBox();
            this.TxtEncryptext = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.TxtDecrypText = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtCleanText
            // 
            this.TxtCleanText.Location = new System.Drawing.Point(33, 45);
            this.TxtCleanText.Name = "TxtCleanText";
            this.TxtCleanText.Size = new System.Drawing.Size(267, 20);
            this.TxtCleanText.TabIndex = 1;
            // 
            // TxtEncryptext
            // 
            this.TxtEncryptext.Location = new System.Drawing.Point(409, 45);
            this.TxtEncryptext.Name = "TxtEncryptext";
            this.TxtEncryptext.Size = new System.Drawing.Size(295, 20);
            this.TxtEncryptext.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(318, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TxtDecrypText
            // 
            this.TxtDecrypText.Location = new System.Drawing.Point(409, 84);
            this.TxtDecrypText.Name = "TxtDecrypText";
            this.TxtDecrypText.Size = new System.Drawing.Size(295, 20);
            this.TxtDecrypText.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(435, 158);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.TxtDecrypText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TxtEncryptext);
            this.Controls.Add(this.TxtCleanText);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtCleanText;
        private System.Windows.Forms.TextBox TxtEncryptext;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TxtDecrypText;
        private System.Windows.Forms.Button button3;
    }
}

