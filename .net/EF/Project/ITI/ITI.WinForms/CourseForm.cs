using ITI.Application.Dtos;
using ITI.Application.Interfaces.Services;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ITI.WinForms
{
    public class CourseForm : Form
    {
        private readonly ICourseService courseService;
        private readonly IInstractorService instractorService;
        private readonly IDepartmentService departmentService;

        private DataGridView grid;
        private TextBox nameTxt;
        private NumericUpDown durationNum;
        private ComboBox instractorCombo;
        private ComboBox departmentCombo;
        private Button addBtn;
        private Button updateBtn;
        private Label nameLbl;
        private Label durLbl;
        private Label insLbl;
        private Label depLbl;
        private Button deleteBtn;

        public CourseForm(ICourseService courseService, IInstractorService instractorService, IDepartmentService departmentService)
        {
            this.courseService = courseService;
            this.instractorService = instractorService;
            this.departmentService = departmentService;

            InitializeComponent();
            LoadLookups();
            LoadCourses();
            // Apply modern UI styling
            ITI.WinForms.UI.UIHelpers.ApplyModernStyle(this);
        }

        private void InitializeComponent()
        {
            grid = new DataGridView();
            nameTxt = new TextBox();
            durationNum = new NumericUpDown();
            instractorCombo = new ComboBox();
            departmentCombo = new ComboBox();
            nameLbl = new Label();
            durLbl = new Label();
            insLbl = new Label();
            depLbl = new Label();
            addBtn = new Button();
            updateBtn = new Button();
            deleteBtn = new Button();
            ((ISupportInitialize)grid).BeginInit();
            ((ISupportInitialize)durationNum).BeginInit();
            SuspendLayout();
            // 
            // grid
            // 
            grid.ColumnHeadersHeight = 29;
            grid.Location = new Point(20, 20);
            grid.Name = "grid";
            grid.RowHeadersWidth = 51;
            grid.Size = new Size(1040, 360);
            grid.TabIndex = 0;
            grid.CellContentClick += grid_CellContentClick;
            grid.SelectionChanged += Grid_SelectionChanged;
            // 
            // nameTxt
            // 
            nameTxt.Location = new Point(160, 400);
            nameTxt.Name = "nameTxt";
            nameTxt.Size = new Size(420, 32);
            nameTxt.TabIndex = 1;
            // 
            // durationNum
            // 
            durationNum.Location = new Point(160, 450);
            durationNum.Name = "durationNum";
            durationNum.Size = new Size(140, 32);
            durationNum.TabIndex = 2;
            // 
            // instractorCombo
            // 
            instractorCombo.Location = new Point(160, 500);
            instractorCombo.Name = "instractorCombo";
            instractorCombo.Size = new Size(420, 32);
            instractorCombo.TabIndex = 3;
            // 
            // departmentCombo
            // 
            departmentCombo.Location = new Point(160, 550);
            departmentCombo.Name = "departmentCombo";
            departmentCombo.Size = new Size(420, 32);
            departmentCombo.TabIndex = 4;
            // 
            // nameLbl
            // 
            nameLbl.Location = new Point(20, 400);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(120, 25);
            nameLbl.TabIndex = 5;
            nameLbl.Text = "Name";
            // 
            // durLbl
            // 
            durLbl.Location = new Point(20, 450);
            durLbl.Name = "durLbl";
            durLbl.Size = new Size(120, 25);
            durLbl.TabIndex = 6;
            durLbl.Text = "Duration (hours)";
            // 
            // insLbl
            // 
            insLbl.Location = new Point(20, 500);
            insLbl.Name = "insLbl";
            insLbl.Size = new Size(120, 25);
            insLbl.TabIndex = 7;
            insLbl.Text = "Instructor";
            // 
            // depLbl
            // 
            depLbl.Location = new Point(20, 550);
            depLbl.Name = "depLbl";
            depLbl.Size = new Size(120, 25);
            depLbl.TabIndex = 8;
            depLbl.Text = "Department";
            // 
            // addBtn
            // 
            addBtn.Location = new Point(600, 400);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(160, 40);
            addBtn.TabIndex = 9;
            addBtn.Font = new Font("Segoe UI", 10F);
            addBtn.Click += AddBtn_Click;
            addBtn.Text= "Add";
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(600, 460);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(160, 40);
            updateBtn.TabIndex = 10;
            updateBtn.Font = new Font("Segoe UI", 10F);
            updateBtn.Click += UpdateBtn_Click;
            updateBtn.Text = "Update";
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(600, 520);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(160, 40);
            deleteBtn.TabIndex = 11;
            deleteBtn.Font = new Font("Segoe UI", 10F);
            deleteBtn.Click += DeleteBtn_Click;
            deleteBtn.Text = "Delete";
            // 
            // CourseForm
            // 
            ClientSize = new Size(1100, 700);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Controls.Add(grid);
            Controls.Add(nameTxt);
            Controls.Add(durationNum);
            Controls.Add(instractorCombo);
            Controls.Add(departmentCombo);
            Controls.Add(nameLbl);
            Controls.Add(durLbl);
            Controls.Add(insLbl);
            Controls.Add(depLbl);
            Controls.Add(addBtn);
            Controls.Add(updateBtn);
            Controls.Add(deleteBtn);
            Name = "CourseForm";
            Text = "Courses";
            ((ISupportInitialize)grid).EndInit();
            ((ISupportInitialize)durationNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void LoadLookups()
        {
            var ins = instractorService.GetAll().ToList();
            var insItems = new List<object>();
            insItems.Add(new { Id = 0, Name = "-- Select Instructor --" });
            insItems.AddRange(ins.Select(i => new { Id = i.Id, Name = i.FullName }));
            instractorCombo.DataSource = insItems;
            instractorCombo.DisplayMember = "Name";
            instractorCombo.ValueMember = "Id";

            var deps = departmentService.GetAll().ToList();
            var depItems = new List<object>();
            depItems.Add(new { Id = 0, Name = "-- Select Department --" });
            depItems.AddRange(deps.Select(d => new { Id = d.Id, Name = d.Name }));
            departmentCombo.DataSource = depItems;
            departmentCombo.DisplayMember = "Name";
            departmentCombo.ValueMember = "Id";
        }

        private void LoadCourses()
        {
            var list = courseService.GetAll().ToList();
            grid.DataSource = null;
            grid.DataSource = new BindingList<AllCourseDto>(list);
        }

        private void AddBtn_Click(object? sender, EventArgs e)
        {
            if (!(instractorCombo.SelectedValue is int insId) || insId == 0)
            {
                MessageBox.Show("Select an instructor.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!(departmentCombo.SelectedValue is int depId) || depId == 0)
            {
                MessageBox.Show("Select a department.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new CreateCourseDto(nameTxt.Text, (int?)durationNum.Value, insId, depId);
            courseService.Add(dto);
            ClearInputs();
            LoadCourses();
        }

        private void UpdateBtn_Click(object? sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is AllCourseDto dto)
            {
                if (!(instractorCombo.SelectedValue is int insId) || insId == 0)
                {
                    MessageBox.Show("Select an instructor.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!(departmentCombo.SelectedValue is int depId) || depId == 0)
                {
                    MessageBox.Show("Select a department.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var update = new UpdateCourseDto(dto.Id, nameTxt.Text, (int?)durationNum.Value, insId, depId);
                courseService.Update(update);
                LoadCourses();
            }
        }

        private void DeleteBtn_Click(object? sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is AllCourseDto dto)
            {
                var r = MessageBox.Show("Delete this course?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    courseService.Delete(dto.Id);
                    LoadCourses();
                    ClearInputs();
                }
            }
        }

        private void Grid_SelectionChanged(object? sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is AllCourseDto dto)
            {
                nameTxt.Text = dto.Name ?? string.Empty;
                durationNum.Value = dto.Duration ?? 0;
                instractorCombo.SelectedValue = dto.InstractorId;
                departmentCombo.SelectedValue = dto.DepartmentId;
            }
        }

        private void ClearInputs()
        {
            nameTxt.Text = string.Empty;
            durationNum.Value = 0;
            instractorCombo.SelectedValue = 0;
            departmentCombo.SelectedValue = 0;
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
