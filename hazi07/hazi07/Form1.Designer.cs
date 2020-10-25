namespace hazi07
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
            this.btn_browse = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_nepesseg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numYears = new System.Windows.Forms.NumericUpDown();
            this.richTextbox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numYears)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(704, 12);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(127, 30);
            this.btn_browse.TabIndex = 0;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Start.Location = new System.Drawing.Point(855, 12);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(127, 30);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(399, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(274, 26);
            this.textBox1.TabIndex = 2;
            // 
            // lbl_nepesseg
            // 
            this.lbl_nepesseg.AutoSize = true;
            this.lbl_nepesseg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_nepesseg.Location = new System.Drawing.Point(262, 17);
            this.lbl_nepesseg.Name = "lbl_nepesseg";
            this.lbl_nepesseg.Size = new System.Drawing.Size(137, 25);
            this.lbl_nepesseg.TabIndex = 3;
            this.lbl_nepesseg.Text = "Néppeség fájl:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Záróév:";
            // 
            // numYears
            // 
            this.numYears.Location = new System.Drawing.Point(95, 17);
            this.numYears.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numYears.Name = "numYears";
            this.numYears.Size = new System.Drawing.Size(120, 26);
            this.numYears.TabIndex = 5;
            this.numYears.Value = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            // 
            // richTextbox
            // 
            this.richTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextbox.Location = new System.Drawing.Point(17, 63);
            this.richTextbox.Name = "richTextbox";
            this.richTextbox.Size = new System.Drawing.Size(965, 438);
            this.richTextbox.TabIndex = 6;
            this.richTextbox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 513);
            this.Controls.Add(this.richTextbox);
            this.Controls.Add(this.numYears);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_nepesseg);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.btn_browse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numYears)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_nepesseg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numYears;
        private System.Windows.Forms.RichTextBox richTextbox;
    }
}

