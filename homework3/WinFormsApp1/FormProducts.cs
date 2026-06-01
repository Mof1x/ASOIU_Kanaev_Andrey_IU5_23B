using Microsoft.EntityFrameworkCore;
using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1;

public partial class FormProducts : Form
{
    private AppDbContext _context = null!;

    public FormProducts()
    {
        InitializeComponent();

        dgv.SelectionChanged += Dgv_SelectionChanged;
        btnAdd.Click += BtnAdd_Click;
        btnEdit.Click += BtnEdit_Click;
        btnDelete.Click += BtnDelete_Click;

        _context = new AppDbContext();
        LoadCategories();
        LoadData();
    }

    private void LoadCategories()
    {
        var categories = _context.Categories.OrderBy(c => c.Name).ToList();
        cmbCategory.DataSource = categories;
        cmbCategory.DisplayMember = "Name";
        cmbCategory.ValueMember = "Id";
    }

    private void LoadData()
    {
        var products = _context.Products
            .Include(p => p.Category)
            .OrderBy(p => p.Id)
            .Select(p => new
            {
                p.Id,
                p.Name,
                Category = p.Category!.Name,
                p.Rating
            })
            .ToList();

        dgv.DataSource = products;
        dgv.Columns["Id"]!.HeaderText = "Id";
        dgv.Columns["Name"]!.HeaderText = "Name";
        dgv.Columns["Category"]!.HeaderText = "Category";
        dgv.Columns["Rating"]!.HeaderText = "Rating";

        if (dgv.Rows.Count > 0)
            dgv.CurrentCell = dgv.Rows[0].Cells[0];
    }

    private void Dgv_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgv.CurrentRow == null) return;

        var id = (int)dgv.CurrentRow.Cells["Id"].Value;
        var product = _context.Products.Find(id);
        if (product != null)
        {
            txtName.Text = product.Name;
            cmbCategory.SelectedValue = product.CategoryId;
            nudRating.Value = product.Rating;
        }
    }

    private void BtnAdd_Click(object? sender, EventArgs e)
    {
        var name = txtName.Text.Trim();
        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show(this, "Enter product name.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _context.Products.Add(new Product
        {
            Name = name,
            CategoryId = (int)cmbCategory.SelectedValue,
            Rating = (int)nudRating.Value
        });
        _context.SaveChanges();
        txtName.Clear();
        nudRating.Value = 50;
        LoadData();
    }

    private void BtnEdit_Click(object? sender, EventArgs e)
    {
        if (dgv.CurrentRow == null) return;

        var id = (int)dgv.CurrentRow.Cells["Id"].Value;
        var newName = txtName.Text.Trim();

        if (string.IsNullOrEmpty(newName))
        {
            MessageBox.Show(this, "Enter new product name.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var product = _context.Products.Find(id);
        if (product != null)
        {
            product.Name = newName;
            product.CategoryId = (int)cmbCategory.SelectedValue;
            product.Rating = (int)nudRating.Value;
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
            $"Delete product \"{name}\"?",
            "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result != DialogResult.Yes) return;

        var product = _context.Products.Find(id);
        if (product != null)
        {
            _context.Products.Remove(product);
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
