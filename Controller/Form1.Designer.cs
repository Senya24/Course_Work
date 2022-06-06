using Kursova.View;

namespace Kursova.Controller
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textFields = new System.Windows.Forms.TextBox[]
            {
                new System.Windows.Forms.TextBox(),
                new System.Windows.Forms.TextBox(),
                new System.Windows.Forms.TextBox(),
                new System.Windows.Forms.TextBox()
            };
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = Style.TitleLabelFont;
            this.label1.Location = new System.Drawing.Point(162, 80);
            this.label1.Name = "label1";
            this.label1.Size = Style.TitleLabelSize;
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter your inequalities:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxes
            // 
            for (int i = 0; i < 4; i++)
            {
                this.textFields[i].Font = Style.TextFieldFont;
                this.textFields[i].Location = new System.Drawing.Point(148, 150+40*i);
                this.textFields[i].Name = $"textBox{i+1}";
                this.textFields[i].Size = Style.TextFieldSize;
                this.textFields[i].TabIndex = 1+i;
            }
            // 
            // button1
            // 
            this.button1.BackColor = Style.NextButtonColor;
            this.button1.ForeColor = Style.NextButtonForeColor;
            this.button1.Location = new System.Drawing.Point(400, 320);
            this.button1.Name = "button1";
            this.button1.Size = Style.ButtonSize;
            this.button1.TabIndex = 5;
            this.button1.Text = "Continue";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Continue);
            // 
            // button2
            // 
            this.button2.BackColor = Style.ResetButtonColor;
            this.button2.ForeColor = Style.ResetButtonForeColor;
            this.button2.Location = new System.Drawing.Point(314, 320);
            this.button2.Name = "button2";
            this.button2.Size = Style.ButtonSize;
            this.button2.TabIndex = 6;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.ResetFields);
            // 
            // label2
            // 
            this.label2.Font = Style.NumerationLabelFont;
            this.label2.Location = new System.Drawing.Point(115, 150);
            this.label2.Name = "label2";
            this.label2.Size = Style.NumerationLabelSize;
            this.label2.TabIndex = 7;
            this.label2.Text = "1:";
            // 
            // label3
            // 
            this.label3.Font = Style.NumerationLabelFont;
            this.label3.Location = new System.Drawing.Point(115, 190);
            this.label3.Name = "label3";
            this.label3.Size = Style.NumerationLabelSize;
            this.label3.TabIndex = 8;
            this.label3.Text = "2:";
            // 
            // label4
            // 
            this.label4.Font = Style.NumerationLabelFont;
            this.label4.Location = new System.Drawing.Point(115, 230);
            this.label4.Name = "label4";
            this.label4.Size = Style.NumerationLabelSize;
            this.label4.TabIndex = 9;
            this.label4.Text = "3:";
            // 
            // label5
            // 
            this.label5.Font = Style.NumerationLabelFont;
            this.label5.Location = new System.Drawing.Point(115, 270);
            this.label5.Name = "label5";
            this.label5.Size = Style.NumerationLabelSize;
            this.label5.TabIndex = 10;
            this.label5.Text = "4:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(598, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            foreach (var field in textFields)
                this.Controls.Add(field);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.Text = "Inequalities Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox[] textFields;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}