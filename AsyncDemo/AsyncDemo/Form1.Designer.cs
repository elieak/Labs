namespace AsyncDemo
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
            this.firstNumberTB = new System.Windows.Forms.TextBox();
            this.secondNumberTB = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.calculateBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstNumberTB
            // 
            this.firstNumberTB.Location = new System.Drawing.Point(12, 29);
            this.firstNumberTB.Name = "firstNumberTB";
            this.firstNumberTB.Size = new System.Drawing.Size(100, 20);
            this.firstNumberTB.TabIndex = 0;
            // 
            // secondNumberTB
            // 
            this.secondNumberTB.Location = new System.Drawing.Point(12, 77);
            this.secondNumberTB.Name = "secondNumberTB";
            this.secondNumberTB.Size = new System.Drawing.Size(100, 20);
            this.secondNumberTB.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(119, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 186);
            this.listBox1.TabIndex = 2;
            // 
            // calculateBtn
            // 
            this.calculateBtn.Location = new System.Drawing.Point(21, 176);
            this.calculateBtn.Name = "calculateBtn";
            this.calculateBtn.Size = new System.Drawing.Size(75, 23);
            this.calculateBtn.TabIndex = 3;
            this.calculateBtn.Text = "Calculate...";
            this.calculateBtn.UseVisualStyleBackColor = true;
            this.calculateBtn.Click += new System.EventHandler(this.calculateBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter first int";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enter Second Int";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 206);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calculateBtn);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.secondNumberTB);
            this.Controls.Add(this.firstNumberTB);
            this.Name = "Form1";
            this.Text = "AsyncPrime Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstNumberTB;
        private System.Windows.Forms.TextBox secondNumberTB;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button calculateBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

