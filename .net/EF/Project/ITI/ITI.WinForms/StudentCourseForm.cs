using ITI.Application.Dtos;
using ITI.Application.Interfaces.Services;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ITI.WinForms
{
    public class StudentCourseForm : Form
    {
        private readonly IStudentCourseService studentCourseService;
        private readonly IStudentService studentService;
        private readonly ICourseService courseService;

        private DataGridView grid;
        private ComboBox studentCombo;
        private ComboBox courseCombo;
        private Button addBtn;
        private Button deleteBtn;

        public StudentCourseForm(IStudentCourseService studentCourseService, IStudentService studentService, ICourseService courseService)
        {
            this.studentCourseService = studentCourseService;
            this.studentService = studentService;
            this.courseService = courseService;

            InitializeComponent();
            LoadLookups();
            LoadAssignments();
        }

        private void InitializeComponent()
        {
            Text = "Student Courses";
            ClientSize = new Size(900, 600);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            grid = new DataGridView { Location = new Point(20, 20), Size = new Size(860, 360), ReadOnly = true, AutoGenerateColumns = true };
            studentCombo = new ComboBox { Location = new Point(140, 400), Size = new Size(400, 32), DropDownStyle = ComboBoxStyle.DropDownList };
            courseCombo = new ComboBox { Location = new Point(140, 450), Size = new Size(400, 32), DropDownStyle = ComboBoxStyle.DropDownList };

            var studentLbl = new Label { Text = "Student", Location = new Point(20, 400), Size = new Size(100, 25) };
            var courseLbl = new Label { Text = "Course", Location = new Point(20, 450), Size = new Size(100, 25) };

            addBtn = new Button { Text = "Add", Location = new Point(560, 400), Size = new Size(140, 36) };
            deleteBtn = new Button { Text = "Delete", Location = new Point(560, 450), Size = new Size(140, 36) };

            Controls.AddRange(new Control[] { grid, studentCombo, courseCombo, studentLbl, courseLbl, addBtn, deleteBtn });

            addBtn.Click += AddBtn_Click;
            deleteBtn.Click += DeleteBtn_Click;
            grid.SelectionChanged += Grid_SelectionChanged;
            
            // Apply modern UI styling
            ITI.WinForms.UI.UIHelpers.ApplyModernStyle(this);
        }

        private void LoadLookups()
        {
            var students = studentService.GetAll().ToList();
            var studentItems = new List<object>();
            studentItems.Add(new { Id = 0, Name = "-- Select Student --" });
            studentItems.AddRange(students.Select(s => new { Id = s.Id, Name = $"{s.FirstName} {s.LastName}" }));
            studentCombo.DataSource = studentItems;
            studentCombo.DisplayMember = "Name";
            studentCombo.ValueMember = "Id";

            var courses = courseService.GetAll().ToList();
            var courseItems = new List<object>();
            courseItems.Add(new { Id = 0, Name = "-- Select Course --" });
            courseItems.AddRange(courses.Select(c => new { Id = c.Id, Name = c.Name }));
            courseCombo.DataSource = courseItems;
            courseCombo.DisplayMember = "Name";
            courseCombo.ValueMember = "Id";
        }

        private void LoadAssignments()
        {
            var list = studentCourseService.GetAll().ToList();
            grid.DataSource = null;
            grid.DataSource = new BindingList<AllStudentCourseDto>(list);
        }

        private void AddBtn_Click(object? sender, EventArgs e)
        {
            if (!(studentCombo.SelectedValue is int sId) || sId == 0)
            {
                MessageBox.Show("Select a student.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!(courseCombo.SelectedValue is int cId) || cId == 0)
            {
                MessageBox.Show("Select a course.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new CreateStudentCourseDto(sId, cId);
            studentCourseService.Add(dto);
            LoadAssignments();
        }

        private void DeleteBtn_Click(object? sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is AllStudentCourseDto dto)
            {
                var r = MessageBox.Show("Delete this assignment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    studentCourseService.Delete(dto.StudentId, dto.CourseId);
                    LoadAssignments();
                }
            }
        }

        private void Grid_SelectionChanged(object? sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is AllStudentCourseDto dto)
            {
                studentCombo.SelectedValue = dto.StudentId;
                courseCombo.SelectedValue = dto.CourseId;
            }
        }
    }
}
