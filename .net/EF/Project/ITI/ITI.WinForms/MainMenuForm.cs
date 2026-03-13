using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace ITI.WinForms
{
    public class MainMenuForm : Form
    {
        private Button studentsBtn;
        private Button departmentsBtn;
        private Button coursesBtn;
        private Button instructorsBtn;
        private Button studentCoursesBtn;
        private Button courseSessionsBtn;
        private Button attendanceBtn;
        private Button exitBtn;

        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            // Form settings
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(400, 600); // larger
            Text = "Main Menu";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            BackColor = SystemColors.Window;

            // Title
            var title = new Label
            {
                Text = "ITI Management",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 80
            };

            // Panel for buttons
            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,      // fill remaining space
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(20),
                WrapContents = false,
                AutoScroll = false          // no scrollbars
            };

            Font btnFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);

            // Buttons
            studentsBtn = new Button { Text = "Students", Size = new Size(340, 56), Font = btnFont, Margin = new Padding(6) };
            departmentsBtn = new Button { Text = "Departments", Size = new Size(340, 56), Font = btnFont, Margin = new Padding(6) };
            coursesBtn = new Button { Text = "Courses", Size = new Size(340, 56), Font = btnFont, Margin = new Padding(6) };
            instructorsBtn = new Button { Text = "Instructors", Size = new Size(340, 56), Font = btnFont, Margin = new Padding(6) };
            studentCoursesBtn = new Button { Text = "Student Courses", Size = new Size(340, 56), Font = btnFont, Margin = new Padding(6) };
            courseSessionsBtn = new Button { Text = "Course Sessions", Size = new Size(340, 56), Font = btnFont, Margin = new Padding(6) };
            attendanceBtn = new Button { Text = "Attendance", Size = new Size(340, 56), Font = btnFont, Margin = new Padding(6) };
            //exitBtn = new Button { Text = "Exit", Size = new Size(100, 40), Font = btnFont, Margin = new Padding(6) };

            // Button events (same as before)
            studentsBtn.Click += StudentsBtn_Click;
            departmentsBtn.Click += DepartmentsBtn_Click;
            coursesBtn.Click += CoursesBtn_Click;
            instructorsBtn.Click += InstructorsBtn_Click;
            studentCoursesBtn.Click += StudentCoursesBtn_Click;
            courseSessionsBtn.Click += CourseSessionsBtn_Click;
            attendanceBtn.Click += AttendanceBtn_Click;
            //exitBtn.Click += ExitBtn_Click;

            // Add buttons to panel
            panel.Controls.Add(studentsBtn);
            panel.Controls.Add(departmentsBtn);
            panel.Controls.Add(coursesBtn);
            panel.Controls.Add(instructorsBtn);
            panel.Controls.Add(studentCoursesBtn);
            panel.Controls.Add(courseSessionsBtn);
            panel.Controls.Add(attendanceBtn);
            panel.Controls.Add(exitBtn); // exit button at bottom of panel

            Controls.Add(panel);
            Controls.Add(title);

            // Apply a modern style to the form
            ITI.WinForms.UI.UIHelpers.ApplyModernStyle(this);
            ResumeLayout(false);
        }

        private void StudentCoursesBtn_Click(object? sender, EventArgs e)
        {
            try
            {
                var form = Program.ServiceProvider.GetRequiredService<StudentCourseForm>();
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open Student Courses form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AttendanceBtn_Click(object? sender, EventArgs e)
        {
            try
            {
                var form = Program.ServiceProvider.GetRequiredService<CourseSessionAttendanceForm>();
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open Attendance form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CourseSessionsBtn_Click(object? sender, EventArgs e)
        {
            try
            {
                var form = Program.ServiceProvider.GetRequiredService<CourseSessionForm>();
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open Course Sessions form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CoursesBtn_Click(object? sender, EventArgs e)
        {
            try
            {
                var form = Program.ServiceProvider.GetRequiredService<CourseForm>();
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open Courses form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StudentsBtn_Click(object? sender, EventArgs e)
        {
            try
            {
                var form = Program.ServiceProvider.GetRequiredService<Form1>();
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open Students form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DepartmentsBtn_Click(object? sender, EventArgs e)
        {
            try
            {
                var form = Program.ServiceProvider.GetRequiredService<DepartmentForm>();
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open Departments form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InstructorsBtn_Click(object? sender, EventArgs e)
        {
            try
            {
                var form = Program.ServiceProvider.GetRequiredService<InstractorForm>();
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open Instructors form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NotImplemented_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("This area is not implemented yet.", "Not implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExitBtn_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
