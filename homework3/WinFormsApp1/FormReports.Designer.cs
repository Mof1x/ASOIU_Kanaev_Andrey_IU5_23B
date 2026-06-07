namespace WinFormsApp1;

partial class FormReports
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
        tabControl = new TabControl();
        tabReport1 = new TabPage();
        dgvReport1 = new DataGridView();
        tabReport2 = new TabPage();
        dgvReport2 = new DataGridView();
        tabReport3 = new TabPage();
        dgvReport3 = new DataGridView();
        tabControl.SuspendLayout();
        tabReport1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvReport1).BeginInit();
        tabReport2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvReport2).BeginInit();
        tabReport3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvReport3).BeginInit();
        SuspendLayout();
        // 
        // tabControl
        // 
        tabControl.Controls.Add(tabReport1);
        tabControl.Controls.Add(tabReport2);
        tabControl.Controls.Add(tabReport3);
        tabControl.Location = new Point(12, 12);
        tabControl.Name = "tabControl";
        tabControl.SelectedIndex = 0;
        tabControl.Size = new Size(796, 496);
        tabControl.TabIndex = 0;
        // 
        // tabReport1
        // 
        tabReport1.Controls.Add(dgvReport1);
        tabReport1.Location = new Point(4, 29);
        tabReport1.Name = "tabReport1";
        tabReport1.Padding = new Padding(3);
        tabReport1.Size = new Size(788, 463);
        tabReport1.TabIndex = 0;
        tabReport1.Text = "Report 1: Products with categories";
        tabReport1.UseVisualStyleBackColor = true;
        // 
        // dgvReport1
        // 
        dgvReport1.AllowUserToAddRows = false;
        dgvReport1.AllowUserToDeleteRows = false;
        dgvReport1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvReport1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvReport1.Dock = DockStyle.Fill;
        dgvReport1.Location = new Point(3, 3);
        dgvReport1.Name = "dgvReport1";
        dgvReport1.ReadOnly = true;
        dgvReport1.RowHeadersWidth = 51;
        dgvReport1.Size = new Size(782, 457);
        dgvReport1.TabIndex = 0;
        // 
        // tabReport2
        // 
        tabReport2.Controls.Add(dgvReport2);
        tabReport2.Location = new Point(4, 29);
        tabReport2.Name = "tabReport2";
        tabReport2.Padding = new Padding(3);
        tabReport2.Size = new Size(788, 463);
        tabReport2.TabIndex = 1;
        tabReport2.Text = "Report 2: Count by category";
        tabReport2.UseVisualStyleBackColor = true;
        // 
        // dgvReport2
        // 
        dgvReport2.AllowUserToAddRows = false;
        dgvReport2.AllowUserToDeleteRows = false;
        dgvReport2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvReport2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvReport2.Dock = DockStyle.Fill;
        dgvReport2.Location = new Point(3, 3);
        dgvReport2.Name = "dgvReport2";
        dgvReport2.ReadOnly = true;
        dgvReport2.RowHeadersWidth = 51;
        dgvReport2.Size = new Size(782, 457);
        dgvReport2.TabIndex = 0;
        // 
        // tabReport3
        // 
        tabReport3.Controls.Add(dgvReport3);
        tabReport3.Location = new Point(4, 29);
        tabReport3.Name = "tabReport3";
        tabReport3.Padding = new Padding(3);
        tabReport3.Size = new Size(788, 463);
        tabReport3.TabIndex = 2;
        tabReport3.Text = "Report 3: Avg rating by category";
        tabReport3.UseVisualStyleBackColor = true;
        // 
        // dgvReport3
        // 
        dgvReport3.AllowUserToAddRows = false;
        dgvReport3.AllowUserToDeleteRows = false;
        dgvReport3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvReport3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvReport3.Dock = DockStyle.Fill;
        dgvReport3.Location = new Point(3, 3);
        dgvReport3.Name = "dgvReport3";
        dgvReport3.ReadOnly = true;
        dgvReport3.RowHeadersWidth = 51;
        dgvReport3.Size = new Size(782, 457);
        dgvReport3.TabIndex = 0;
        // 
        // FormReports
        // 
        ClientSize = new Size(820, 520);
        Controls.Add(tabControl);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "FormReports";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Reports";
        tabControl.ResumeLayout(false);
        tabReport1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvReport1).EndInit();
        tabReport2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvReport2).EndInit();
        tabReport3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvReport3).EndInit();
        ResumeLayout(false);
    }

    private TabControl tabControl;
    private TabPage tabReport1;
    private TabPage tabReport2;
    private TabPage tabReport3;
    private DataGridView dgvReport1;
    private DataGridView dgvReport2;
    private DataGridView dgvReport3;
}
