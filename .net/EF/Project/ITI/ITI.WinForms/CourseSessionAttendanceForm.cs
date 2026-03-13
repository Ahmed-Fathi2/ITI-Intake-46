using ITI.Application.Dtos;
using ITI.Application.Interfaces.Services;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ITI.WinForms
{
    public class CourseSessionAttendanceForm : Form
    {
        private readonly ICourseSessionAttendanceService attendanceService;
        private readonly IStudentService studentService;
        private readonly ICourseSessionService courseSessionService;

        private DataGridView grid;
        private ComboBox sessionCombo;
        private ComboBox studentCombo;
        private TextBox gradeTxt;
        private TextBox notesTxt;
        private Button addBtn;
        private Button updateBtn;
        private Button deleteBtn;

        public CourseSessionAttendanceForm(ICourseSessionAttendanceService attendanceService, IStudentService studentService, ICourseSessionService courseSessionService)
        {
            this.attendanceService = attendanceService;
            this.studentService = studentService;
            this.courseSessionService = courseSessionService;

            InitializeComponent();
            LoadLookups();
            LoadAttendances();
        }

        private void InitializeComponent()
        {
            Text = "Attendance";
            ClientSize = new Size(1100, 700);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            grid = new DataGridView { Location = new Point(20, 20), Size = new Size(1040, 360), ReadOnly = true, AutoGenerateColumns = true, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            sessionCombo = new ComboBox { Location = new Point(160, 400), Size = new Size(600, 32), DropDownStyle = ComboBoxStyle.DropDownList };
            studentCombo = new ComboBox { Location = new Point(160, 450), Size = new Size(600, 32), DropDownStyle = ComboBoxStyle.DropDownList };
            gradeTxt = new TextBox { Location = new Point(160, 500), Size = new Size(140, 32) };
            notesTxt = new TextBox { Location = new Point(160, 550), Size = new Size(600, 32) };

            var sessionLbl = new Label { Text = "Session", Location = new Point(20, 400), Size = new Size(120, 25) };
            var studentLbl = new Label { Text = "Student", Location = new Point(20, 450), Size = new Size(120, 25) };
            var gradeLbl = new Label { Text = "Grade", Location = new Point(20, 500), Size = new Size(120, 25) };
            var notesLbl = new Label { Text = "Notes", Location = new Point(20, 550), Size = new Size(120, 25) };

            addBtn = new Button { Text = "Add", Location = new Point(800, 400), Size = new Size(160, 40), Font = new Font("Segoe UI", 10F) };
            updateBtn = new Button { Text = "Update", Location = new Point(800, 460), Size = new Size(160, 40), Font = new Font("Segoe UI", 10F) };
            deleteBtn = new Button { Text = "Delete", Location = new Point(800, 520), Size = new Size(160, 40), Font = new Font("Segoe UI", 10F) };

            Controls.AddRange(new Control[] { grid, sessionCombo, studentCombo, gradeTxt, notesTxt, sessionLbl, studentLbl, gradeLbl, notesLbl, addBtn, updateBtn, deleteBtn });

            addBtn.Click += AddBtn_Click;
            updateBtn.Click += UpdateBtn_Click;
            deleteBtn.Click += DeleteBtn_Click;
            grid.SelectionChanged += Grid_SelectionChanged;

            // Apply modern UI styling
            ITI.WinForms.UI.UIHelpers.ApplyModernStyle(this);
        }

        private void LoadLookups()
        {
            var sessions = courseSessionService.GetAll().ToList();
            var sessionItems = new List<object>();
            sessionItems.Add(new { Id = 0, Name = "-- Select Session --" });
            sessionItems.AddRange(sessions.Select(s => new { Id = s.Id, Name = $"{s.CourseName} - {s.Title} ({s.Date.ToShortDateString()})" }));
            sessionCombo.DataSource = sessionItems;
            sessionCombo.DisplayMember = "Name";
            sessionCombo.ValueMember = "Id";

            var students = studentService.GetAll().ToList();
            var studentItems = new List<object>();
            studentItems.Add(new { Id = 0, Name = "-- Select Student --" });
            studentItems.AddRange(students.Select(s => new { Id = s.Id, Name = $"{s.FirstName} {s.LastName}" }));
            studentCombo.DataSource = studentItems;
            studentCombo.DisplayMember = "Name";
            studentCombo.ValueMember = "Id";
        }

        private void LoadAttendances()
        {
            var list = attendanceService.GetAll().ToList();
            grid.DataSource = null;
            grid.DataSource = new BindingList<AllCourseSessionAttendanceDto>(list);
        }

        private void AddBtn_Click(object? sender, EventArgs e)
        {
            if (!(sessionCombo.SelectedValue is int sId) || sId == 0)
            {
                MessageBox.Show("Select a session.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!(studentCombo.SelectedValue is int stId) || stId == 0)
            {
                MessageBox.Show("Select a student.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? grade = null;
            if (!string.IsNullOrWhiteSpace(gradeTxt.Text))
            {
                if (int.TryParse(gradeTxt.Text, out var g)) grade = g;
                else
                {
                    MessageBox.Show("Grade must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var dto = new CreateCourseSessionAttendanceDto(grade, notesTxt.Text, stId, sId);
            attendanceService.Add(dto);
            ClearInputs();
            LoadAttendances();
        }

        private void UpdateBtn_Click(object? sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is AllCourseSessionAttendanceDto dto)
            {
                if (!(sessionCombo.SelectedValue is int sId) || sId == 0)
                {
                    MessageBox.Show("Select a session.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!(studentCombo.SelectedValue is int stId) || stId == 0)
                {
                    MessageBox.Show("Select a student.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? grade = null;
                if (!string.IsNullOrWhiteSpace(gradeTxt.Text))
                {
                    if (int.TryParse(gradeTxt.Text, out var g)) grade = g;
                    else
                    {
                        MessageBox.Show("Grade must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var update = new UpdateCourseSessionAttendanceDto(dto.Id, grade, notesTxt.Text, stId, sId);
                attendanceService.Update(update);
                LoadAttendances();
            }
        }

        private void DeleteBtn_Click(object? sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is AllCourseSessionAttendanceDto dto)
            {
                var r = MessageBox.Show("Delete this attendance?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    attendanceService.Delete(dto.Id);
                    LoadAttendances();
                    ClearInputs();
                }
            }
        }

        private void Grid_SelectionChanged(object? sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is AllCourseSessionAttendanceDto dto)
            {
                sessionCombo.SelectedValue = dto.CourseSessionId;
                studentCombo.SelectedValue = dto.StudentId;
                gradeTxt.Text = dto.Grade?.ToString() ?? string.Empty;
                notesTxt.Text = dto.Notes ?? string.Empty;
            }
        }

        private void ClearInputs()
        {
            sessionCombo.SelectedValue = 0;
            studentCombo.SelectedValue = 0;
            gradeTxt.Text = string.Empty;
            notesTxt.Text = string.Empty;
        }
    }
}
