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

        dgvReport1.DataSource = (from p in context.Products
                                orderby p.Name
                                select p).ToList();

        //dgvReport2.DataSource = context.Products
        //    .GroupBy(p => p.Category!.Name)
        //    .Select(g => new { Category = g.Key, Count = g.Count() })
        //    .OrderBy(r => r.Category)
        //    .ToList();

        dgvReport2.DataSource = (from p in context.Products
                                group p by p.Category!.Name into g                            
                                select new { Category = g.Key, Count = g.Count() } into r
                                orderby r.Category
                                select r).ToList();



        //    dgvReport3.DataSource = context.Products
        //        .GroupBy(p => p.Category!.Name)
        //        .Select(g => new
        //        {
        //            Category = g.Key,
        //            AvgRating = Math.Round(g.Average(p => p.Rating), 1),
        //            Count = g.Count()
        //        })
        //        .OrderByDescending(r => r.AvgRating)
        //        .ToList();

        dgvReport3.DataSource = (from p in context.Products
                                 group p by p.Category!.Name into g
                                 select new { Category = g.Key, Avg = g.Average(p => p.Rating), Count = g.Count() } into l
                                 orderby l.Avg descending
                                 select l).ToList();
    }
}
