namespace What_are_WinForms
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
            this.btnClickMe = new System.Windows.Forms.Button();
            this.lblHelloWorld = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClickMe
            // 
            this.btnClickMe.Location = new System.Drawing.Point(46, 46);
            this.btnClickMe.Name = "btnClickMe";
            this.btnClickMe.Size = new System.Drawing.Size(87, 32);
            this.btnClickMe.TabIndex = 0;
            this.btnClickMe.Text = "Click me!";
            this.btnClickMe.UseVisualStyleBackColor = true;
            this.btnClickMe.Click += new System.EventHandler(this.btnClickMe_Click);
            // 
            // lblHelloWorld
            // 
            this.lblHelloWorld.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHelloWorld.AutoSize = true;
            this.lblHelloWorld.BackColor = System.Drawing.SystemColors.Info;
            this.lblHelloWorld.Font = new System.Drawing.Font("MV Boli", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelloWorld.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHelloWorld.Location = new System.Drawing.Point(109, 155);
            this.lblHelloWorld.Name = "lblHelloWorld";
            this.lblHelloWorld.Size = new System.Drawing.Size(81, 16);
            this.lblHelloWorld.TabIndex = 1;
            this.lblHelloWorld.Text = "Hello world!";
            this.lblHelloWorld.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 257);
            this.Controls.Add(this.lblHelloWorld);
            this.Controls.Add(this.btnClickMe);
            this.Name = "Form1";
            this.Text = "Hi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClickMe;
        private System.Windows.Forms.Label lblHelloWorld;
    }
}

