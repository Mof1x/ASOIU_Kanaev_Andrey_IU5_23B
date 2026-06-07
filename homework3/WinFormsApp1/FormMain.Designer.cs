namespace WinFormsApp1;

partial class FormMain
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
        btnCategories = new Button();
        btnProducts = new Button();
        btnReports = new Button();
        btnExit = new Button();
        SuspendLayout();
        // 
        // btnCategories
        // 
        btnCategories.Location = new Point(80, 25);
        btnCategories.Name = "btnCategories";
        btnCategories.Size = new Size(240, 40);
        btnCategories.TabIndex = 0;
        btnCategories.Text = "Categories";
        btnCategories.UseVisualStyleBackColor = true;
        // 
        // btnProducts
        // 
        btnProducts.Location = new Point(80, 97);
        btnProducts.Name = "btnProducts";
        btnProducts.Size = new Size(240, 40);
        btnProducts.TabIndex = 1;
        btnProducts.Text = "Products";
        btnProducts.UseVisualStyleBackColor = true;
        // 
        // btnReports
        // 
        btnReports.Location = new Point(80, 168);
        btnReports.Name = "btnReports";
        btnReports.Size = new Size(240, 40);
        btnReports.TabIndex = 2;
        btnReports.Text = "Reports";
        btnReports.UseVisualStyleBackColor = true;
        // 
        // btnExit
        // 
        btnExit.Location = new Point(80, 235);
        btnExit.Name = "btnExit";
        btnExit.Size = new Size(240, 35);
        btnExit.TabIndex = 4;
        btnExit.Text = "Exit";
        btnExit.UseVisualStyleBackColor = true;
        // 
        // FormMain
        // 
        ClientSize = new Size(400, 320);
        Controls.Add(btnExit);
        Controls.Add(btnReports);
        Controls.Add(btnProducts);
        Controls.Add(btnCategories);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "FormMain";
        StartPosition = FormStartPosition.CenterScreen;
        ResumeLayout(false);
    }

    private Button btnCategories;
    private Button btnProducts;
    private Button btnReports;
    private Button btnExit;
}
