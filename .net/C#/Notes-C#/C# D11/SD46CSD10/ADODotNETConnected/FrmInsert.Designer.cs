namespace ADODotNETConnected
{
    partial class FrmInsert
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtId = new TextBox();
            txtFName = new TextBox();
            txtLName = new TextBox();
            txtAddress = new TextBox();
            btnInsert = new Button();
            lblResult = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 64);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 0;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 109);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 1;
            label2.Text = "First Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 157);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 2;
            label3.Text = "Last Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 218);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 3;
            label4.Text = "Address";
            // 
            // txtId
            // 
            txtId.Location = new Point(127, 61);
            txtId.Name = "txtId";
            txtId.Size = new Size(147, 23);
            txtId.TabIndex = 4;
            // 
            // txtFName
            // 
            txtFName.Location = new Point(127, 106);
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(147, 23);
            txtFName.TabIndex = 5;
            // 
            // txtLName
            // 
            txtLName.Location = new Point(127, 154);
            txtLName.Name = "txtLName";
            txtLName.Size = new Size(147, 23);
            txtLName.TabIndex = 6;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(127, 214);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(147, 23);
            txtAddress.TabIndex = 7;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(306, 301);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(75, 23);
            btnInsert.TabIndex = 8;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(438, 364);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(27, 15);
            lblResult.TabIndex = 9;
            lblResult.Text = "____";
            // 
            // FrmInsert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResult);
            Controls.Add(btnInsert);
            Controls.Add(txtAddress);
            Controls.Add(txtLName);
            Controls.Add(txtFName);
            Controls.Add(txtId);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmInsert";
            Text = "FrmInsert";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtId;
        private TextBox txtFName;
        private TextBox txtLName;
        private TextBox txtAddress;
        private Button btnInsert;
        private Label lblResult;
    }
}