﻿namespace hazi8
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btn_car = new System.Windows.Forms.Button();
            this.btn_ball = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_color = new System.Windows.Forms.Button();
            this.btn_present = new System.Windows.Forms.Button();
            this.color_ribbon = new System.Windows.Forms.Button();
            this.color_box = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(69, 125);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(200, 100);
            this.mainPanel.TabIndex = 0;
            // 
            // btn_car
            // 
            this.btn_car.Location = new System.Drawing.Point(52, 34);
            this.btn_car.Name = "btn_car";
            this.btn_car.Size = new System.Drawing.Size(75, 23);
            this.btn_car.TabIndex = 1;
            this.btn_car.Text = "Car";
            this.btn_car.UseVisualStyleBackColor = true;
            this.btn_car.Click += new System.EventHandler(this.btn_car_Click);
            // 
            // btn_ball
            // 
            this.btn_ball.Location = new System.Drawing.Point(133, 34);
            this.btn_ball.Name = "btn_ball";
            this.btn_ball.Size = new System.Drawing.Size(75, 23);
            this.btn_ball.TabIndex = 2;
            this.btn_ball.Text = "Ball";
            this.btn_ball.UseVisualStyleBackColor = true;
            this.btn_ball.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(515, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Coming next:";
            // 
            // btn_color
            // 
            this.btn_color.BackColor = System.Drawing.Color.Aqua;
            this.btn_color.Location = new System.Drawing.Point(52, 63);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(87, 34);
            this.btn_color.TabIndex = 4;
            this.btn_color.UseVisualStyleBackColor = false;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // btn_present
            // 
            this.btn_present.Location = new System.Drawing.Point(327, 29);
            this.btn_present.Name = "btn_present";
            this.btn_present.Size = new System.Drawing.Size(75, 23);
            this.btn_present.TabIndex = 5;
            this.btn_present.Text = "Present";
            this.btn_present.UseVisualStyleBackColor = true;
            this.btn_present.Click += new System.EventHandler(this.btn_present_Click);
            // 
            // color_ribbon
            // 
            this.color_ribbon.BackColor = System.Drawing.Color.Aqua;
            this.color_ribbon.Location = new System.Drawing.Point(269, 63);
            this.color_ribbon.Name = "color_ribbon";
            this.color_ribbon.Size = new System.Drawing.Size(87, 34);
            this.color_ribbon.TabIndex = 6;
            this.color_ribbon.UseVisualStyleBackColor = false;
            this.color_ribbon.Click += new System.EventHandler(this.color_ribbon_Click);
            // 
            // color_box
            // 
            this.color_box.BackColor = System.Drawing.Color.Aqua;
            this.color_box.Location = new System.Drawing.Point(362, 63);
            this.color_box.Name = "color_box";
            this.color_box.Size = new System.Drawing.Size(87, 34);
            this.color_box.TabIndex = 7;
            this.color_box.UseVisualStyleBackColor = false;
            this.color_box.Click += new System.EventHandler(this.color_box_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.color_box);
            this.Controls.Add(this.color_ribbon);
            this.Controls.Add(this.btn_present);
            this.Controls.Add(this.btn_color);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ball);
            this.Controls.Add(this.btn_car);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btn_car;
        private System.Windows.Forms.Button btn_ball;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_color;
        private System.Windows.Forms.Button btn_present;
        private System.Windows.Forms.Button color_ribbon;
        private System.Windows.Forms.Button color_box;
    }
}

