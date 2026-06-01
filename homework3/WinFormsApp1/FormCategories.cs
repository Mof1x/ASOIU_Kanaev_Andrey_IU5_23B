using Microsoft.EntityFrameworkCore;
using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1;

public partial class FormCategories : Form
{
    private AppDbContext _context = null!;

    public FormCategories()
    {
        InitializeComponent();

        btnAdd.Click += BtnAdd_Click;
        btnEdit.Click += BtnEdit_Click;
        btnDelete.Click += BtnDelete_Click;

        _context = new AppDbContext();
        LoadData();
    }

    private void LoadData()
    {
        var categories = _context.Categories
            .OrderBy(c => c.Id)
            .ToList();
        dgv.DataSource = categories;
        dgv.Columns["Id"]!.HeaderText = "Id";
        dgv.Columns["Name"]!.HeaderText = "Name";
        dgv.Columns["Products"]!.Visible = false;

        if (dgv.Rows.Count > 0)
            dgv.CurrentCell = dgv.Rows[0].Cells[0];
    }

    private void BtnAdd_Click(object? sender, EventArgs e)
    {
        var name = txtName.Text.Trim();
        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show(this, "Enter category name.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _context.Categories.Add(new Category { Name = name });
        _context.SaveChanges();
        txtName.Clear();
        LoadData();
    }

    private void BtnEdit_Click(object? sender, EventArgs e)
    {
        if (dgv.CurrentRow == null) return;

        var id = (int)dgv.CurrentRow.Cells["Id"].Value;
        var newName = txtName.Text.Trim();

        if (string.IsNullOrEmpty(newName))
        {
            MessageBox.Show(this, "Enter new category name.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var category = _context.Categories.Find(id);
        if (category != null)
        {
            category.Name = newName;
            _context.SaveChanges();
            LoadData();
        }
    }

    private void BtnDelete_Click(object? sender, EventArgs e)
    {
        if (dgv.CurrentRow == null) return;

        var id = (int)dgv.CurrentRow.Cells["Id"].Value;
        var name = dgv.CurrentRow.Cells["Name"].Value?.ToString();

        var result = MessageBox.Show(this,
            $"Delete category \"{name}\" and all its products?",
            "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result != DialogResult.Yes) return;

        var category = _context.Categories
            .Include(c => c.Products)
            .FirstOrDefault(c => c.Id == id);

        if (category != null)
        {
            _context.Products.RemoveRange(category.Products);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            LoadData();
        }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _context.Dispose();
        base.OnFormClosed(e);
    }
}
