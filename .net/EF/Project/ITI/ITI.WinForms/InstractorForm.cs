using ITI.Application.Dtos;
using ITI.Application.Interfaces.Services;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ITI.WinForms
{
    public class InstractorForm : Form
    {
        private readonly IInstractorService instractorService;
        private readonly IDepartmentService departmentService;

        private DataGridView grid;
        private TextBox fNameTxt;
        private TextBox lNameTxt;
        private TextBox phoneTxt;
        private ComboBox deptCombo;
        private Button addBtn;
        private Button updateBtn;
        private Button deleteBtn;

        public InstractorForm(IInstractorService instractorService, IDepartmentService departmentService)
        {
            this.instractorService = instractorService;
            this.departmentService = departmentService;
            InitializeComponent();
            LoadDepartments();
            LoadInstractors();
        }

        private void InitializeComponent()
        {
            Text = "Instructors";
            ClientSize = new Size(1000, 650);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            grid = new DataGridView { Location = new Point(30, 20), Size = new Size(920, 340), ReadOnly = true, AutoGenerateColumns = true, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            fNameTxt = new TextBox { Location = new Point(160, 380), Size = new Size(360, 30) };
            lNameTxt = new TextBox { Location = new Point(160, 430), Size = new Size(360, 30) };
            phoneTxt = new TextBox { Location = new Point(160, 480), Size = new Size(360, 30) };
            deptCombo = new ComboBox { Location = new Point(160, 530), Size = new Size(360, 30), DropDownStyle = ComboBoxStyle.DropDownList };

            var fnLbl = new Label { Text = "First Name", Location = new Point(40, 380), Size = new Size(100, 25) };
            var lnLbl = new Label { Text = "Last Name", Location = new Point(40, 430), Size = new Size(100, 25) };
            var phLbl = new Label { Text = "Phone", Location = new Point(40, 480), Size = new Size(100, 25) };
            var diLbl = new Label { Text = "Department", Location = new Point(40, 530), Size = new Size(100, 25) };

            addBtn = new Button { Text = "Add", Location = new Point(560, 380), Size = new Size(140, 36), Font = new Font("Segoe UI", 10F) };
            updateBtn = new Button { Text = "Update", Location = new Point(560, 430), Size = new Size(140, 36), Font = new Font("Segoe UI", 10F) };
            deleteBtn = new Button { Text = "Delete", Location = new Point(560, 480), Size = new Size(140, 36), Font = new Font("Segoe UI", 10F) };

            Controls.AddRange(new Control[] { grid, fNameTxt, lNameTxt, phoneTxt, deptCombo, fnLbl, lnLbl, phLbl, diLbl, addBtn, updateBtn, deleteBtn });

            addBtn.Click += AddBtn_Click;
            updateBtn.Click += UpdateBtn_Click;
            deleteBtn.Click += DeleteBtn_Click;
            grid.SelectionChanged += Grid_SelectionChanged;

            // Apply modern UI styling
            ITI.WinForms.UI.UIHelpers.ApplyModernStyle(this);
        }

        private void LoadInstractors()
        {
            var list = instractorService.GetAll().ToList();
            grid.DataSource = null;
            grid.DataSource = new BindingList<AllInstractorDto>(list);
        }

        private void LoadDepartments()
        {
            var list = departmentService.GetAll().ToList();
            var items = new List<object>();
            items.Add(new { Id = 0, Name = "-- Select Department --" });
            items.AddRange(list.Select(d => new { Id = d.Id, Name = d.Name }));

            deptCombo.DataSource = null;
            deptCombo.DisplayMember = "Name";
            deptCombo.ValueMember = "Id";
            deptCombo.DataSource = items;
        }

        private void AddBtn_Click(object? sender, EventArgs e)
        {
            if (!(deptCombo.SelectedValue is int deptId) || deptId == 0)
            {
                MessageBox.Show("Please select a department.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var dto = new CreateInstractorDto(fNameTxt.Text, lNameTxt.Text, phoneTxt.Text, deptId);
            instractorService.Add(dto);
            ClearInputs();
            LoadInstractors();
        }

        private void UpdateBtn_Click(object? sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is AllInstractorDto dto)
            {
                if (!(deptCombo.SelectedValue is int deptId) || deptId == 0)
                {
                    MessageBox.Show("Please select a department.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var update = new UpdateInstractorDto(dto.Id, fNameTxt.Text, lNameTxt.Text, phoneTxt.Text, deptId);
                instractorService.Update(update);
                LoadInstractors();
            }
        }

        private void DeleteBtn_Click(object? sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is AllInstractorDto dto)
            {
                var r = MessageBox.Show("Delete this instructor?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    instractorService.Delete(dto.Id);
                    LoadInstractors();
                    ClearInputs();
                }
            }
        }

        private void Grid_SelectionChanged(object? sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is AllInstractorDto dto)
            {
                fNameTxt.Text = dto.FirstName ?? string.Empty;
                lNameTxt.Text = dto.LastName ?? string.Empty;
                phoneTxt.Text = dto.Phone ?? string.Empty;
                deptCombo.SelectedValue = dto.DepartmentId;
            }
        }

        private void ClearInputs()
        {
            fNameTxt.Text = string.Empty;
            lNameTxt.Text = string.Empty;
            phoneTxt.Text = string.Empty;
            deptCombo.SelectedValue = 0;
        }
    }
}
