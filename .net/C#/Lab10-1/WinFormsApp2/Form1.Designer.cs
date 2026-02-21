namespace WinFormsApp2
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
            txtScreen = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            Clear = new Button();
            Equal = new Button();
            button16 = new Button();
            SuspendLayout();
            // 
            // txtScreen
            // 
            txtScreen.Dock = DockStyle.Top;
            txtScreen.Location = new Point(0, 0);
            txtScreen.Name = "txtScreen";
            txtScreen.Size = new Size(800, 27);
            txtScreen.TabIndex = 0;
            txtScreen.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(195, 144);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnNumbers_Click;
            // 
            // button2
            // 
            button2.Location = new Point(295, 144);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnNumbers_Click;
            // 
            // button3
            // 
            button3.Location = new Point(395, 144);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 3;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnNumbers_Click;
            // 
            // button4
            // 
            button4.Location = new Point(495, 144);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 4;
            button4.Text = "+";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnNumbers_Click;
            // 
            // button5
            // 
            button5.Location = new Point(195, 179);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 5;
            button5.Text = "4";
            button5.UseVisualStyleBackColor = true;
            button5.Click += btnNumbers_Click;
            // 
            // button6
            // 
            button6.Location = new Point(295, 179);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 6;
            button6.Text = "5";
            button6.UseVisualStyleBackColor = true;
            button6.Click += btnNumbers_Click;
            // 
            // button7
            // 
            button7.Location = new Point(395, 179);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 7;
            button7.Text = "6";
            button7.UseVisualStyleBackColor = true;
            button7.Click += btnNumbers_Click;
            // 
            // button8
            // 
            button8.Location = new Point(495, 179);
            button8.Name = "button8";
            button8.Size = new Size(94, 29);
            button8.TabIndex = 8;
            button8.Text = "-";
            button8.UseVisualStyleBackColor = true;
            button8.Click += btnNumbers_Click;
            // 
            // button9
            // 
            button9.Location = new Point(195, 214);
            button9.Name = "button9";
            button9.Size = new Size(94, 29);
            button9.TabIndex = 9;
            button9.Text = "7";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(295, 214);
            button10.Name = "button10";
            button10.Size = new Size(94, 29);
            button10.TabIndex = 10;
            button10.Text = "8";
            button10.UseVisualStyleBackColor = true;
            button10.Click += btnNumbers_Click;
            // 
            // button11
            // 
            button11.Location = new Point(395, 214);
            button11.Name = "button11";
            button11.Size = new Size(94, 29);
            button11.TabIndex = 11;
            button11.Text = "9";
            button11.UseVisualStyleBackColor = true;
            button11.Click += btnNumbers_Click;
            // 
            // button12
            // 
            button12.Location = new Point(495, 214);
            button12.Name = "button12";
            button12.Size = new Size(94, 29);
            button12.TabIndex = 12;
            button12.Text = "*";
            button12.UseVisualStyleBackColor = true;
            button12.Click += btnNumbers_Click;
            // 
            // button13
            // 
            button13.Location = new Point(195, 249);
            button13.Name = "button13";
            button13.Size = new Size(94, 29);
            button13.TabIndex = 13;
            button13.Text = "0";
            button13.UseVisualStyleBackColor = true;
            button13.Click += btnNumbers_Click;
            // 
            // Clear
            // 
            Clear.Location = new Point(295, 249);
            Clear.Name = "Clear";
            Clear.Size = new Size(94, 29);
            Clear.TabIndex = 14;
            Clear.Text = "C";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += Clear_Click;
            // 
            // Equal
            // 
            Equal.Location = new Point(395, 249);
            Equal.Name = "Equal";
            Equal.Size = new Size(94, 29);
            Equal.TabIndex = 15;
            Equal.Text = "=";
            Equal.UseVisualStyleBackColor = true;
            Equal.Click += Equal_Click;
            // 
            // button16
            // 
            button16.Location = new Point(495, 249);
            button16.Name = "button16";
            button16.Size = new Size(94, 29);
            button16.TabIndex = 16;
            button16.Text = "/";
            button16.UseVisualStyleBackColor = true;
            button16.Click += btnNumbers_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button16);
            Controls.Add(Equal);
            Controls.Add(Clear);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtScreen);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtScreen;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button Clear;
        private Button Equal;
        private Button button16;
    }
}
