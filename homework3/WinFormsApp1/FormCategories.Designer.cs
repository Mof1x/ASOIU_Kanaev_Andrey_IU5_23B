namespace WinFormsApp1;

partial class FormCategories
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
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
        dgv.Size = new Size(460, 386);
        dgv.TabIndex = 0;
        // 
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.Location = new Point(490, 20);
        lblName.Name = "lblName";
        lblName.Size = new Size(52, 20);
        lblName.TabIndex = 1;
        lblName.Text = "Name:";
        // 
        // txtName
        // 
        txtName.Location = new Point(490, 42);
        txtName.Name = "txtName";
        txtName.Size = new Size(140, 27);
        txtName.TabIndex = 2;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(490, 80);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(140, 32);
        btnAdd.TabIndex = 3;
        btnAdd.Text = "Add";
        btnAdd.UseVisualStyleBackColor = true;
        // 
        // btnEdit
        // 
        btnEdit.Location = new Point(490, 122);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(140, 32);
        btnEdit.TabIndex = 4;
        btnEdit.Text = "Edit";
        btnEdit.UseVisualStyleBackColor = true;
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(490, 164);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(140, 32);
        btnDelete.TabIndex = 5;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;
        // 
        // FormCategories
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(650, 440);
        Controls.Add(btnDelete);
        Controls.Add(btnEdit);
        Controls.Add(btnAdd);
        Controls.Add(txtName);
        Controls.Add(lblName);
        Controls.Add(dgv);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "FormCategories";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Categories";
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
