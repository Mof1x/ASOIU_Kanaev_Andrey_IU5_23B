using WinFormsApp1.Data;

namespace WinFormsApp1;

public partial class FormMain : Form
{
    public FormMain()
    {
        InitializeComponent();

        btnCategories.Click += BtnCategories_Click;
        btnProducts.Click += BtnProducts_Click;
        btnReports.Click += BtnReports_Click;
        btnExportXml.Click += BtnExportXml_Click;
        btnExit.Click += BtnExit_Click;

        using var context = new AppDbContext();
        context.Database.EnsureCreated();
        AppDbContext.Seed(context);
    }

    private void BtnCategories_Click(object? sender, EventArgs e)
    {
        using var form = new FormCategories();
        form.ShowDialog(this);
    }

    private void BtnProducts_Click(object? sender, EventArgs e)
    {
        using var form = new FormProducts();
        form.ShowDialog(this);
    }

    private void BtnReports_Click(object? sender, EventArgs e)
    {
        using var form = new FormReports();
        form.ShowDialog(this);
    }

    private void BtnExportXml_Click(object? sender, EventArgs e)
    {
        using var sfd = new SaveFileDialog
        {
            Filter = "XML files (*.xml)|*.xml",
            FileName = "export.xml",
            Title = "Save XML"
        };

        if (sfd.ShowDialog(this) == DialogResult.OK)
        {
            try
            {
                Data.ExportService.ExportToXml(sfd.FileName);
                MessageBox.Show(this, "Exported to:\n" + sfd.FileName, "XML Export",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void BtnExit_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }
}
