using ITI.Application.Dtos;
using ITI.Application.Interfaces.Services;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ITI.WinForms
{
    public class DepartmentForm : Form
    {
        private readonly IDepartmentService departmentService;
        private readonly IInstractorService instractorService;

        private DataGridView grid;
        private TextBox nameTxt;
        private TextBox locationTxt;
        private ComboBox managerCombo;
        private Button addBtn;
        private Button updateBtn;
        private Button deleteBtn;

        public DepartmentForm(IDepartmentService departmentService, IInstractorService instractorService)
        {
            this.departmentService = departmentService;
            this.instractorService = instractorService;
            InitializeComponent();
            LoadInstructors();
            LoadDepartments();
        }

        private void InitializeComponent()
        {
            Text = "Departments";
            ClientSize = new Size(1000, 650);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            grid = new DataGridView { Location = new Point(30, 20), Size = new Size(920, 340), ReadOnly = true, AutoGenerateColumns = true, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            nameTxt = new TextBox { Location = new Point(160, 380), Size = new Size(360, 30) };
            locationTxt = new TextBox { Location = new Point(160, 430), Size = new Size(360, 30) };
            managerCombo = new ComboBox { Location = new Point(160, 480), Size = new Size(360, 30), DropDownStyle = ComboBoxStyle.DropDownList };

            var nameLbl = new Label { Text = "Name", Location = new Point(40, 380), Size = new Size(100, 25) };
            var locLbl = new Label { Text = "Location", Location = new Point(40, 430), Size = new Size(100, 25) };
            var manLbl = new Label { Text = "Manager", Location = new Point(40, 480), Size = new Size(100, 25) };

            addBtn = new Button { Text = "Add", Location = new Point(560, 380), Size = new Size(140, 36), Font = new Font("Segoe UI", 10F) };
            updateBtn = new Button { Text = "Update", Location = new Point(560, 430), Size = new Size(140, 36), Font = new Font("Segoe UI", 10F) };
            deleteBtn = new Button { Text = "Delete", Location = new Point(560, 480), Size = new Size(140, 36), Font = new Font("Segoe UI", 10F) };

            Controls.AddRange(new Control[] { grid, nameTxt, locationTxt, managerCombo, nameLbl, locLbl, manLbl, addBtn, updateBtn, deleteBtn });

            addBtn.Click += AddBtn_Click;
            updateBtn.Click += UpdateBtn_Click;
            deleteBtn.Click += DeleteBtn_Click;
            grid.SelectionChanged += Grid_SelectionChanged;

            // Apply modern UI styling
            ITI.WinForms.UI.UIHelpers.ApplyModernStyle(this);
        }

        private void LoadDepartments()
        {
            var list = departmentService.GetAll().ToList();
            grid.DataSource = null;
            grid.DataSource = new BindingList<AllDepartmentDto>(list);
        }

        private void LoadInstructors()
        {
            var list = instractorService.GetAll().ToList();
            // add placeholder for no manager
            var items = new List<AllInstractorDto?>();
            items.Add(null);
            items.AddRange(list);

            managerCombo.DataSource = null;
            // For nullable items, use a small wrapper list with Display and Value
            var displayList = items.Select(i => new { Id = i?.Id ?? 0, Name = i == null ? "-- None --" : i.FullName }).ToList();
            managerCombo.DisplayMember = "Name";
            managerCombo.ValueMember = "Id";
            managerCombo.DataSource = displayList;
        }

        private void AddBtn_Click(object? sender, EventArgs e)
        {
            int? managerId = null;
            if (managerCombo.SelectedValue is int v && v != 0) managerId = v;
            var dto = new CreateDepartmentDto(nameTxt.Text, locationTxt.Text, managerId);
            departmentService.Add(dto);
            ClearInputs();
            LoadDepartments();
        }

        private void UpdateBtn_Click(object? sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is AllDepartmentDto dto)
            {
                int? managerId = null;
                if (managerCombo.SelectedValue is int v && v != 0) managerId = v;
                var update = new UpdateDepartmentDto(dto.Id, nameTxt.Text, locationTxt.Text, managerId);
                departmentService.Update(update);
                LoadDepartments();
            }
        }

        private void DeleteBtn_Click(object? sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is AllDepartmentDto dto)
            {
                var r = MessageBox.Show("Delete this department?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    try
                    {
                        departmentService.Delete(dto.Id);
                        LoadDepartments();
                        ClearInputs();
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message, "Cannot delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Grid_SelectionChanged(object? sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is AllDepartmentDto dto)
            {
                nameTxt.Text = dto.Name;
                locationTxt.Text = dto.Location ?? string.Empty;

                // ManagerId is nullable in AllDepartmentDto; set combo selection
                if (dto.ManagerId.HasValue)
                    managerCombo.SelectedValue = dto.ManagerId.Value;
                else
                    managerCombo.SelectedValue = 0;
            }
        }

        private void ClearInputs()
        {
            nameTxt.Text = string.Empty;
            locationTxt.Text = string.Empty;
            managerCombo.SelectedValue = 0;
        }
    }
}
