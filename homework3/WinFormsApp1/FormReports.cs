using Microsoft.EntityFrameworkCore;
using WinFormsApp1.Data;

namespace WinFormsApp1;

public partial class FormReports : Form
{
    public FormReports()
    {
        InitializeComponent();
        LoadReports();
    }

    private void LoadReports()
    {
        using var context = new AppDbContext();

        dgvReport1.DataSource = context.Products
                                .Include(p => p.Category)
                                .OrderBy(p => p.Name)
                                .Select(p => new { p.Id, p.Name, p.Rating, p.CategoryId, Category = p.Category!.Name})
                                .ToList();

        dgvReport2.DataSource = (from p in context.Products
                                group p by p.Category!.Name into g                            
                                select new { Category = g.Key, Count = g.Count() } into r
                                orderby r.Category
                                select r).ToList();


        dgvReport3.DataSource = (from p in context.Products
                                 group p by p.Category!.Name into g
                                 select new { Category = g.Key, Avg = g.Average(p => p.Rating), Count = g.Count() } into l
                                 orderby l.Avg descending
                                 select l).ToList();
    }
}
