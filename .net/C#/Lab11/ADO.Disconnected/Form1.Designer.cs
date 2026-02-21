namespace ADO.Disconnected
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
            griddata = new DataGridView();
            lblId = new Label();
            txtDegree = new TextBox();
            lblName = new Label();
            lblDegree = new Label();
            lblSalary = new Label();
            txtId = new TextBox();
            txtName = new TextBox();
            txtSalary = new TextBox();
            btnAdd = new Button();
            btnSync = new Button();
            ((System.ComponentModel.ISupportInitialize)griddata).BeginInit();
            SuspendLayout();
            // 
            // griddata
            // 
            griddata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            griddata.Location = new Point(12, 12);
            griddata.Name = "griddata";
            griddata.RowHeadersWidth = 51;
            griddata.Size = new Size(762, 187);
            griddata.TabIndex = 0;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(61, 226);
            lblId.Name = "lblId";
            lblId.Size = new Size(22, 20);
            lblId.TabIndex = 1;
            lblId.Text = "Id";
            // 
            // txtDegree
            // 
            txtDegree.Location = new Point(125, 306);
            txtDegree.Name = "txtDegree";
            txtDegree.Size = new Size(125, 27);
            txtDegree.TabIndex = 2;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(61, 269);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 3;
            lblName.Text = "Name";
            // 
            // lblDegree
            // 
            lblDegree.AutoSize = true;
            lblDegree.Location = new Point(61, 306);
            lblDegree.Name = "lblDegree";
            lblDegree.Size = new Size(58, 20);
            lblDegree.TabIndex = 4;
            lblDegree.Text = "Degree";
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Location = new Point(61, 350);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(49, 20);
            lblSalary.TabIndex = 5;
            lblSalary.Text = "Salary";
            // 
            // txtId
            // 
            txtId.Location = new Point(125, 223);
            txtId.Name = "txtId";
            txtId.Size = new Size(125, 27);
            txtId.TabIndex = 6;
            // 
            // txtName
            // 
            txtName.Location = new Point(125, 266);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 7;
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(125, 350);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(125, 27);
            txtSalary.TabIndex = 8;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(137, 399);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSync
            // 
            btnSync.Location = new Point(367, 399);
            btnSync.Name = "btnSync";
            btnSync.Size = new Size(94, 29);
            btnSync.TabIndex = 10;
            btnSync.Text = "Sync";
            btnSync.UseVisualStyleBackColor = true;
            btnSync.Click += btnSync_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSync);
            Controls.Add(btnAdd);
            Controls.Add(txtSalary);
            Controls.Add(txtName);
            Controls.Add(txtId);
            Controls.Add(lblSalary);
            Controls.Add(lblDegree);
            Controls.Add(lblName);
            Controls.Add(txtDegree);
            Controls.Add(lblId);
            Controls.Add(griddata);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)griddata).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView griddata;
        private Label lblId;
        private TextBox txtDegree;
        private Label lblName;
        private Label lblDegree;
        private Label lblSalary;
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtSalary;
        private Button btnAdd;
        private Button btnSync;
    }
}
