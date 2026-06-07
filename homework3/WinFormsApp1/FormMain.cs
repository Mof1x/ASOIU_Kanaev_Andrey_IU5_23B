namespace WinFormsApp1;

public partial class FormMain : Form
{
    public FormMain()
    {
        InitializeComponent();

        btnCategories.Click += BtnCategories_Click;
        btnProducts.Click += BtnProducts_Click;
        btnReports.Click += BtnReports_Click;
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

    private void BtnExit_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }
}
