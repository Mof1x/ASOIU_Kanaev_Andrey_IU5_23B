namespace WinFormsApp1;

partial class FormProducts
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        dgv = new DataGridView();
        lblName = new Label();
        txtName = new TextBox();
        lblCategory = new Label();
        cmbCategory = new ComboBox();
        lblRating = new Label();
        nudRating = new NumericUpDown();
        btnAdd = new Button();
        btnEdit = new Button();
        btnDelete = new Button();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudRating).BeginInit();
        SuspendLayout();

        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgv.Location = new Point(12, 12);
        dgv.Name = "dgv";
        dgv.Size = new Size(550, 426);
        dgv.TabIndex = 0;
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;

        lblName.AutoSize = true;
        lblName.Location = new Point(580, 20);
        lblName.Name = "lblName";
        lblName.Size = new Size(49, 20);
        lblName.TabIndex = 1;
        lblName.Text = "Name:";

        txtName.Location = new Point(580, 42);
        txtName.Name = "txtName";
        txtName.Size = new Size(175, 27);
        txtName.TabIndex = 2;

        lblCategory.AutoSize = true;
        lblCategory.Location = new Point(580, 78);
        lblCategory.Name = "lblCategory";
        lblCategory.Size = new Size(72, 20);
        lblCategory.TabIndex = 3;
        lblCategory.Text = "Category:";

        cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCategory.FormattingEnabled = true;
        cmbCategory.Location = new Point(580, 100);
        cmbCategory.Name = "cmbCategory";
        cmbCategory.Size = new Size(175, 28);
        cmbCategory.TabIndex = 4;

        lblRating.AutoSize = true;
        lblRating.Location = new Point(580, 140);
        lblRating.Name = "lblRating";
        lblRating.Size = new Size(97, 20);
        lblRating.TabIndex = 5;
        lblRating.Text = "Rating (0-100):";

        nudRating.Location = new Point(580, 162);
        nudRating.Name = "nudRating";
        nudRating.Size = new Size(175, 27);
        nudRating.TabIndex = 6;
        nudRating.Minimum = 0;
        nudRating.Maximum = 100;
        nudRating.Value = 50;

        btnAdd.Location = new Point(580, 210);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(175, 34);
        btnAdd.TabIndex = 7;
        btnAdd.Text = "Add";
        btnAdd.UseVisualStyleBackColor = true;

        btnEdit.Location = new Point(580, 254);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(175, 34);
        btnEdit.TabIndex = 8;
        btnEdit.Text = "Save";
        btnEdit.UseVisualStyleBackColor = true;

        btnDelete.Location = new Point(580, 298);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(175, 34);
        btnDelete.TabIndex = 9;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;

        ClientSize = new Size(780, 480);
        Controls.Add(btnDelete);
        Controls.Add(btnEdit);
        Controls.Add(btnAdd);
        Controls.Add(nudRating);
        Controls.Add(lblRating);
        Controls.Add(cmbCategory);
        Controls.Add(lblCategory);
        Controls.Add(txtName);
        Controls.Add(lblName);
        Controls.Add(dgv);
        Name = "FormProducts";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Products (Detail)";
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudRating).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private DataGridView dgv;
    private Label lblName;
    private TextBox txtName;
    private Label lblCategory;
    private ComboBox cmbCategory;
    private Label lblRating;
    private NumericUpDown nudRating;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnDelete;
}
