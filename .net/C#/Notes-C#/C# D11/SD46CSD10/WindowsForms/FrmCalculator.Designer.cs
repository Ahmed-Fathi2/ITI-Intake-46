namespace WindowsForms
{
    partial class FrmCalculator
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
            txtScreen = new TextBox();
            btnOne = new Button();
            btnTwo = new Button();
            btnPlus = new Button();
            btnMinus = new Button();
            btnEquals = new Button();
            SuspendLayout();
            // 
            // txtScreen
            // 
            txtScreen.Dock = DockStyle.Top;
            txtScreen.Enabled = false;
            txtScreen.Location = new Point(0, 0);
            txtScreen.Name = "txtScreen";
            txtScreen.Size = new Size(374, 23);
            txtScreen.TabIndex = 0;
            // 
            // btnOne
            // 
            btnOne.Location = new Point(62, 81);
            btnOne.Name = "btnOne";
            btnOne.Size = new Size(75, 23);
            btnOne.TabIndex = 1;
            btnOne.Text = "1";
            btnOne.UseVisualStyleBackColor = true;
            btnOne.Click += btnNumbers_Click;
            // 
            // btnTwo
            // 
            btnTwo.Location = new Point(248, 81);
            btnTwo.Name = "btnTwo";
            btnTwo.Size = new Size(75, 23);
            btnTwo.TabIndex = 2;
            btnTwo.Text = "2";
            btnTwo.UseVisualStyleBackColor = true;
            btnTwo.Click += btnNumbers_Click;
            // 
            // btnPlus
            // 
            btnPlus.Location = new Point(62, 200);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(75, 23);
            btnPlus.TabIndex = 3;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = true;
            btnPlus.Click += btnOperators_Click;
            // 
            // btnMinus
            // 
            btnMinus.Location = new Point(248, 200);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(75, 23);
            btnMinus.TabIndex = 4;
            btnMinus.Text = "-";
            btnMinus.UseVisualStyleBackColor = true;
            btnMinus.Click += btnOperators_Click;
            // 
            // btnEquals
            // 
            btnEquals.Location = new Point(150, 346);
            btnEquals.Name = "btnEquals";
            btnEquals.Size = new Size(75, 23);
            btnEquals.TabIndex = 5;
            btnEquals.Text = "=";
            btnEquals.UseVisualStyleBackColor = true;
            btnEquals.Click += btnEquals_Click;
            // 
            // FrmCalculator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 450);
            Controls.Add(btnEquals);
            Controls.Add(btnMinus);
            Controls.Add(btnPlus);
            Controls.Add(btnTwo);
            Controls.Add(btnOne);
            Controls.Add(txtScreen);
            Name = "FrmCalculator";
            Text = "FrmCalculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtScreen;
        private Button btnOne;
        private Button btnTwo;
        private Button btnPlus;
        private Button btnMinus;
        private Button btnEquals;
    }
}