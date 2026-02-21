namespace WindowsForms
{
    partial class MyForm
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
        ///  the contents of this method wiph the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRegister = new Button();
            txtFName = new TextBox();
            txtLName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(465, 164);
            btnRegister.Margin = new Padding(3, 4, 3, 4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(203, 143);
            btnRegister.TabIndex = 0;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.UseWaitCursor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtFName
            // 
            txtFName.Location = new Point(178, 70);
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(262, 24);
            txtFName.TabIndex = 1;
            txtFName.UseWaitCursor = true;
            // 
            // txtLName
            // 
            txtLName.Location = new Point(178, 124);
            txtLName.Name = "txtLName";
            txtLName.Size = new Size(262, 24);
            txtLName.TabIndex = 2;
            txtLName.UseWaitCursor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(90, 70);
            label1.Name = "label1";
            label1.Size = new Size(74, 18);
            label1.TabIndex = 3;
            label1.Text = "First Name";
            label1.UseWaitCursor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(90, 130);
            label2.Name = "label2";
            label2.Size = new Size(72, 18);
            label2.TabIndex = 4;
            label2.Text = "Last Name";
            label2.UseWaitCursor = true;
            // 
            // MyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSeaGreen;
            ClientSize = new Size(765, 499);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtLName);
            Controls.Add(txtFName);
            Controls.Add(btnRegister);
            Font = new Font("Comic Sans MS", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            ForeColor = Color.Firebrick;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MyForm";
            Text = "Form One HELLO Properties";
            UseWaitCursor = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegister;
        private TextBox txtFName;
        private TextBox txtLName;
        private Label label1;
        private Label label2;
    }
}
