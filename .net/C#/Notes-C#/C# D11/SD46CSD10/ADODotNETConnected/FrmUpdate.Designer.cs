namespace ADODotNETConnected
{
    partial class FrmUpdate
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
            lblResult = new Label();
            btnUpdate = new Button();
            txtAddress = new TextBox();
            txtLName = new TextBox();
            txtFName = new TextBox();
            txtId = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            comboAuthors = new ComboBox();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(586, 369);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(27, 15);
            lblResult.TabIndex = 19;
            lblResult.Text = "____";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(454, 306);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(275, 219);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(147, 23);
            txtAddress.TabIndex = 17;
            // 
            // txtLName
            // 
            txtLName.Location = new Point(275, 159);
            txtLName.Name = "txtLName";
            txtLName.Size = new Size(147, 23);
            txtLName.TabIndex = 16;
            // 
            // txtFName
            // 
            txtFName.Location = new Point(275, 111);
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(147, 23);
            txtFName.TabIndex = 15;
            // 
            // txtId
            // 
            txtId.Location = new Point(275, 66);
            txtId.Name = "txtId";
            txtId.Size = new Size(147, 23);
            txtId.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(188, 223);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 13;
            label4.Text = "Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(188, 162);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 12;
            label3.Text = "Last Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(188, 114);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 11;
            label2.Text = "First Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(188, 69);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 10;
            label1.Text = "Id";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 22);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 21;
            label5.Text = "Author";
            // 
            // comboAuthors
            // 
            comboAuthors.FormattingEnabled = true;
            comboAuthors.Location = new Point(135, 19);
            comboAuthors.Name = "comboAuthors";
            comboAuthors.Size = new Size(121, 23);
            comboAuthors.TabIndex = 20;
            comboAuthors.SelectedIndexChanged += comboAuthors_SelectedIndexChanged;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(512, 22);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 22;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // FrmUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(label5);
            Controls.Add(comboAuthors);
            Controls.Add(lblResult);
            Controls.Add(btnUpdate);
            Controls.Add(txtAddress);
            Controls.Add(txtLName);
            Controls.Add(txtFName);
            Controls.Add(txtId);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmUpdate";
            Text = "FrmUpdate";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblResult;
        private Button btnUpdate;
        private TextBox txtAddress;
        private TextBox txtLName;
        private TextBox txtFName;
        private TextBox txtId;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private ComboBox comboAuthors;
        private Button btnDelete;
    }
}