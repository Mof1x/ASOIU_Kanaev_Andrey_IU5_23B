namespace WinFormsApp1;

partial class FormCategories
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
        btnAdd = new Button();
        btnEdit = new Button();
        btnDelete = new Button();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        SuspendLayout();

        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgv.Location = new Point(12, 12);
        dgv.Name = "dgv";
        dgv.Size = new Size(460, 386);
        dgv.TabIndex = 0;
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;

        lblName.AutoSize = true;
        lblName.Location = new Point(490, 20);
        lblName.Name = "lblName";
        lblName.Size = new Size(44, 20);
        lblName.TabIndex = 1;
        lblName.Text = "Name:";

        txtName.Location = new Point(490, 42);
        txtName.Name = "txtName";
        txtName.Size = new Size(140, 27);
        txtName.TabIndex = 2;

        btnAdd.Location = new Point(490, 80);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(140, 32);
        btnAdd.TabIndex = 3;
        btnAdd.Text = "Add";
        btnAdd.UseVisualStyleBackColor = true;

        btnEdit.Location = new Point(490, 122);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(140, 32);
        btnEdit.TabIndex = 4;
        btnEdit.Text = "Save";
        btnEdit.UseVisualStyleBackColor = true;

        btnDelete.Location = new Point(490, 164);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(140, 32);
        btnDelete.TabIndex = 5;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;

        ClientSize = new Size(650, 440);
        Controls.Add(btnDelete);
        Controls.Add(btnEdit);
        Controls.Add(btnAdd);
        Controls.Add(txtName);
        Controls.Add(lblName);
        Controls.Add(dgv);
        Name = "FormCategories";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Categories (Master)";
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private DataGridView dgv;
    private Label lblName;
    private TextBox txtName;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnDelete;
}
