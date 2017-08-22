namespace VehicleLicense
{
    partial class AddPicture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPicture));
            this.bntCapture = new System.Windows.Forms.Button();
            this.bntContinue = new System.Windows.Forms.Button();
            this.bntStop = new System.Windows.Forms.Button();
            this.bntStart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.imgCapture = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bntCapture
            // 
            this.bntCapture.BackColor = System.Drawing.Color.Goldenrod;
            this.bntCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntCapture.Location = new System.Drawing.Point(501, 349);
            this.bntCapture.Margin = new System.Windows.Forms.Padding(4);
            this.bntCapture.Name = "bntCapture";
            this.bntCapture.Size = new System.Drawing.Size(113, 28);
            this.bntCapture.TabIndex = 26;
            this.bntCapture.Text = "Capture Image";
            this.bntCapture.UseVisualStyleBackColor = false;
            this.bntCapture.Click += new System.EventHandler(this.bntCapture_Click);
            // 
            // bntContinue
            // 
            this.bntContinue.BackColor = System.Drawing.Color.Goldenrod;
            this.bntContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntContinue.Location = new System.Drawing.Point(216, 349);
            this.bntContinue.Margin = new System.Windows.Forms.Padding(4);
            this.bntContinue.Name = "bntContinue";
            this.bntContinue.Size = new System.Drawing.Size(76, 28);
            this.bntContinue.TabIndex = 25;
            this.bntContinue.Text = "Continue";
            this.bntContinue.UseVisualStyleBackColor = false;
            this.bntContinue.Click += new System.EventHandler(this.bntContinue_Click);
            // 
            // bntStop
            // 
            this.bntStop.BackColor = System.Drawing.Color.Goldenrod;
            this.bntStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntStop.Location = new System.Drawing.Point(136, 349);
            this.bntStop.Margin = new System.Windows.Forms.Padding(4);
            this.bntStop.Name = "bntStop";
            this.bntStop.Size = new System.Drawing.Size(72, 28);
            this.bntStop.TabIndex = 24;
            this.bntStop.Text = "Stop";
            this.bntStop.UseVisualStyleBackColor = false;
            this.bntStop.Click += new System.EventHandler(this.bntStop_Click);
            // 
            // bntStart
            // 
            this.bntStart.BackColor = System.Drawing.Color.Goldenrod;
            this.bntStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntStart.Location = new System.Drawing.Point(55, 349);
            this.bntStart.Margin = new System.Windows.Forms.Padding(4);
            this.bntStart.Name = "bntStart";
            this.bntStart.Size = new System.Drawing.Size(73, 28);
            this.bntStart.TabIndex = 23;
            this.bntStart.Text = "Start";
            this.bntStart.UseVisualStyleBackColor = false;
            this.bntStart.Click += new System.EventHandler(this.bntStart_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Goldenrod;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(400, 349);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 28);
            this.button1.TabIndex = 28;
            this.button1.Text = "Previous";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imgCapture
            // 
            this.imgCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgCapture.Location = new System.Drawing.Point(174, 30);
            this.imgCapture.Margin = new System.Windows.Forms.Padding(4);
            this.imgCapture.Name = "imgCapture";
            this.imgCapture.Size = new System.Drawing.Size(217, 197);
            this.imgCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCapture.TabIndex = 22;
            this.imgCapture.TabStop = false;
            this.imgCapture.Click += new System.EventHandler(this.imgCapture_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.imgCapture);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Goldenrod;
            this.groupBox1.Location = new System.Drawing.Point(33, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 251);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Picture";
            // 
            // AddPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(657, 409);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bntCapture);
            this.Controls.Add(this.bntContinue);
            this.Controls.Add(this.bntStop);
            this.Controls.Add(this.bntStart);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPicture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddPicture";
            this.Load += new System.EventHandler(this.AddPicture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bntCapture;
        private System.Windows.Forms.Button bntContinue;
        private System.Windows.Forms.Button bntStop;
        private System.Windows.Forms.Button bntStart;
        private System.Windows.Forms.PictureBox imgCapture;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}