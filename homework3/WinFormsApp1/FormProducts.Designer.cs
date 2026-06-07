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
        // 
        // dgv
        // 
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgv.Location = new Point(12, 12);
        dgv.MultiSelect = false;
        dgv.Name = "dgv";
        dgv.ReadOnly = true;
        dgv.RowHeadersWidth = 51;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.Size = new Size(550, 426);
        dgv.TabIndex = 0;
        // 
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.Location = new Point(580, 20);
        lblName.Name = "lblName";
        lblName.Size = new Size(52, 20);
        lblName.TabIndex = 1;
        lblName.Text = "Name:";
        // 
        // txtName
        // 
        txtName.Location = new Point(580, 42);
        txtName.Name = "txtName";
        txtName.Size = new Size(175, 27);
        txtName.TabIndex = 2;
        // 
        // lblCategory
        // 
        lblCategory.AutoSize = true;
        lblCategory.Location = new Point(580, 78);
        lblCategory.Name = "lblCategory";
        lblCategory.Size = new Size(72, 20);
        lblCategory.TabIndex = 3;
        lblCategory.Text = "Category:";
        // 
        // cmbCategory
        // 
        cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCategory.FormattingEnabled = true;
        cmbCategory.Location = new Point(580, 100);
        cmbCategory.Name = "cmbCategory";
        cmbCategory.Size = new Size(175, 28);
        cmbCategory.TabIndex = 4;
        // 
        // lblRating
        // 
        lblRating.AutoSize = true;
        lblRating.Location = new Point(580, 140);
        lblRating.Name = "lblRating";
        lblRating.Size = new Size(107, 20);
        lblRating.TabIndex = 5;
        lblRating.Text = "Rating (0-100):";
        // 
        // nudRating
        // 
        nudRating.Location = new Point(580, 162);
        nudRating.Name = "nudRating";
        nudRating.Size = new Size(175, 27);
        nudRating.TabIndex = 6;
        nudRating.Value = new decimal(new int[] { 50, 0, 0, 0 });
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(580, 210);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(175, 34);
        btnAdd.TabIndex = 7;
        btnAdd.Text = "Add";
        btnAdd.UseVisualStyleBackColor = true;
        // 
        // btnEdit
        // 
        btnEdit.Location = new Point(580, 254);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(175, 34);
        btnEdit.TabIndex = 8;
        btnEdit.Text = "Edit";
        btnEdit.UseVisualStyleBackColor = true;
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(580, 298);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(175, 34);
        btnDelete.TabIndex = 9;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;
        // 
        // FormProducts
        // 
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
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "FormProducts";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Products";
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
