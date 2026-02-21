namespace ADO.Connected;

partial class Form3
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
        comboBox = new ComboBox();
        button1 = new Button();
        textSalaryValue = new TextBox();
        textDegreeValue = new TextBox();
        textNameValue = new TextBox();
        textIDValue = new TextBox();
        txtSalary = new Label();
        txtDegree = new Label();
        txtName = new Label();
        txtId = new Label();
        button2 = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(245, 33);
        label1.Name = "label1";
        label1.Size = new Size(123, 20);
        label1.TabIndex = 4;
        label1.Text = "InstractorsNames";
        // 
        // comboBox
        // 
        comboBox.FormattingEnabled = true;
        comboBox.Location = new Point(382, 33);
        comboBox.Name = "comboBox";
        comboBox.Size = new Size(151, 28);
        comboBox.TabIndex = 3;
        comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
        // 
        // button1
        // 
        button1.Location = new Point(332, 368);
        button1.Name = "button1";
        button1.Size = new Size(152, 29);
        button1.TabIndex = 17;
        button1.Text = "Update";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // textSalaryValue
        // 
        textSalaryValue.Location = new Point(382, 294);
        textSalaryValue.Name = "textSalaryValue";
        textSalaryValue.Size = new Size(151, 27);
        textSalaryValue.TabIndex = 16;
        // 
        // textDegreeValue
        // 
        textDegreeValue.Location = new Point(382, 239);
        textDegreeValue.Name = "textDegreeValue";
        textDegreeValue.Size = new Size(151, 27);
        textDegreeValue.TabIndex = 15;
        // 
        // textNameValue
        // 
        textNameValue.Location = new Point(382, 183);
        textNameValue.Name = "textNameValue";
        textNameValue.Size = new Size(151, 27);
        textNameValue.TabIndex = 14;
        // 
        // textIDValue
        // 
        textIDValue.Cursor = Cursors.Hand;
        textIDValue.Location = new Point(382, 134);
        textIDValue.Name = "textIDValue";
        textIDValue.Size = new Size(151, 27);
        textIDValue.TabIndex = 13;
        // 
        // txtSalary
        // 
        txtSalary.AutoSize = true;
        txtSalary.Location = new Point(294, 293);
        txtSalary.Name = "txtSalary";
        txtSalary.Size = new Size(49, 20);
        txtSalary.TabIndex = 12;
        txtSalary.Text = "Salary";
        // 
        // txtDegree
        // 
        txtDegree.AutoSize = true;
        txtDegree.Location = new Point(294, 239);
        txtDegree.Name = "txtDegree";
        txtDegree.Size = new Size(58, 20);
        txtDegree.TabIndex = 11;
        txtDegree.Text = "Degree";
        // 
        // txtName
        // 
        txtName.AutoSize = true;
        txtName.Location = new Point(294, 182);
        txtName.Name = "txtName";
        txtName.Size = new Size(49, 20);
        txtName.TabIndex = 10;
        txtName.Text = "Name";
        // 
        // txtId
        // 
        txtId.AutoSize = true;
        txtId.Location = new Point(294, 136);
        txtId.Name = "txtId";
        txtId.Size = new Size(22, 20);
        txtId.TabIndex = 9;
        txtId.Text = "Id";
        // 
        // button2
        // 
        button2.Location = new Point(490, 368);
        button2.Name = "button2";
        button2.Size = new Size(155, 29);
        button2.TabIndex = 18;
        button2.Text = "Delete";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // Form3
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(textSalaryValue);
        Controls.Add(textDegreeValue);
        Controls.Add(textNameValue);
        Controls.Add(textIDValue);
        Controls.Add(txtSalary);
        Controls.Add(txtDegree);
        Controls.Add(txtName);
        Controls.Add(txtId);
        Controls.Add(label1);
        Controls.Add(comboBox);
        Name = "Form3";
        Text = "Form3";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private ComboBox comboBox;
    private Button button1;
    private TextBox textSalaryValue;
    private TextBox textDegreeValue;
    private TextBox textNameValue;
    private TextBox textIDValue;
    private Label txtSalary;
    private Label txtDegree;
    private Label txtName;
    private Label txtId;
    private Button button2;
}