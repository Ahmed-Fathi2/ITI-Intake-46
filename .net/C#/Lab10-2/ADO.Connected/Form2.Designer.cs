namespace ADO.Connected;

partial class Form2
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
        txtId = new Label();
        txtName = new Label();
        txtDegree = new Label();
        txtSalary = new Label();
        textIDValue = new TextBox();
        textNameValue = new TextBox();
        textDegreeValue = new TextBox();
        textSalaryValue = new TextBox();
        button1 = new Button();
        SuspendLayout();
        // 
        // txtId
        // 
        txtId.AutoSize = true;
        txtId.Location = new Point(281, 73);
        txtId.Name = "txtId";
        txtId.Size = new Size(22, 20);
        txtId.TabIndex = 0;
        txtId.Text = "Id";
        // 
        // txtName
        // 
        txtName.AutoSize = true;
        txtName.Location = new Point(281, 119);
        txtName.Name = "txtName";
        txtName.Size = new Size(49, 20);
        txtName.TabIndex = 1;
        txtName.Text = "Name";
        // 
        // txtDegree
        // 
        txtDegree.AutoSize = true;
        txtDegree.Location = new Point(281, 176);
        txtDegree.Name = "txtDegree";
        txtDegree.Size = new Size(58, 20);
        txtDegree.TabIndex = 2;
        txtDegree.Text = "Degree";
        // 
        // txtSalary
        // 
        txtSalary.AutoSize = true;
        txtSalary.Location = new Point(281, 230);
        txtSalary.Name = "txtSalary";
        txtSalary.Size = new Size(49, 20);
        txtSalary.TabIndex = 3;
        txtSalary.Text = "Salary";
        // 
        // textIDValue
        // 
        textIDValue.Cursor = Cursors.Hand;
        textIDValue.Location = new Point(369, 71);
        textIDValue.Name = "textIDValue";
        textIDValue.Size = new Size(125, 27);
        textIDValue.TabIndex = 4;
        // 
        // textNameValue
        // 
        textNameValue.Location = new Point(369, 120);
        textNameValue.Name = "textNameValue";
        textNameValue.Size = new Size(125, 27);
        textNameValue.TabIndex = 5;
        // 
        // textDegreeValue
        // 
        textDegreeValue.Location = new Point(369, 176);
        textDegreeValue.Name = "textDegreeValue";
        textDegreeValue.Size = new Size(125, 27);
        textDegreeValue.TabIndex = 6;
        // 
        // textSalaryValue
        // 
        textSalaryValue.Location = new Point(369, 231);
        textSalaryValue.Name = "textSalaryValue";
        textSalaryValue.Size = new Size(125, 27);
        textSalaryValue.TabIndex = 7;
        // 
        // button1
        // 
        button1.Location = new Point(346, 305);
        button1.Name = "button1";
        button1.Size = new Size(175, 29);
        button1.TabIndex = 8;
        button1.Text = "ADD";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // Form2
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(button1);
        Controls.Add(textSalaryValue);
        Controls.Add(textDegreeValue);
        Controls.Add(textNameValue);
        Controls.Add(textIDValue);
        Controls.Add(txtSalary);
        Controls.Add(txtDegree);
        Controls.Add(txtName);
        Controls.Add(txtId);
        Name = "Form2";
        Text = "Form2";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label txtId;
    private Label txtName;
    private Label txtDegree;
    private Label txtSalary;
    private TextBox textIDValue;
    private TextBox textNameValue;
    private TextBox textDegreeValue;
    private TextBox textSalaryValue;
    private Button button1;
}