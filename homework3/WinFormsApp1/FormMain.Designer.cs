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
        btnExportXml = new Button();
        btnExit = new Button();
        SuspendLayout();

        btnCategories.Location = new Point(80, 25);
        btnCategories.Name = "btnCategories";
        btnCategories.Size = new Size(240, 40);
        btnCategories.TabIndex = 0;
        btnCategories.Text = "Categories (Master)";
        btnCategories.UseVisualStyleBackColor = true;

        btnProducts.Location = new Point(80, 75);
        btnProducts.Name = "btnProducts";
        btnProducts.Size = new Size(240, 40);
        btnProducts.TabIndex = 1;
        btnProducts.Text = "Products (Detail)";
        btnProducts.UseVisualStyleBackColor = true;

        btnReports.Location = new Point(80, 125);
        btnReports.Name = "btnReports";
        btnReports.Size = new Size(240, 40);
        btnReports.TabIndex = 2;
        btnReports.Text = "Reports (LINQ)";
        btnReports.UseVisualStyleBackColor = true;

        btnExportXml.Location = new Point(80, 175);
        btnExportXml.Name = "btnExportXml";
        btnExportXml.Size = new Size(240, 40);
        btnExportXml.TabIndex = 3;
        btnExportXml.Text = "Export to XML";
        btnExportXml.UseVisualStyleBackColor = true;

        btnExit.Location = new Point(80, 235);
        btnExit.Name = "btnExit";
        btnExit.Size = new Size(240, 35);
        btnExit.TabIndex = 4;
        btnExit.Text = "Exit";
        btnExit.UseVisualStyleBackColor = true;

        ClientSize = new Size(400, 320);
        Controls.Add(btnExit);
        Controls.Add(btnExportXml);
        Controls.Add(btnReports);
        Controls.Add(btnProducts);
        Controls.Add(btnCategories);
        Name = "FormMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Homework3 — Variant 12";
        ResumeLayout(false);
    }

    private Button btnCategories;
    private Button btnProducts;
    private Button btnReports;
    private Button btnExportXml;
    private Button btnExit;
}
