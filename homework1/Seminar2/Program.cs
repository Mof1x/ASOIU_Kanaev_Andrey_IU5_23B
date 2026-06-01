List<List<int>> dense = new List<List<int>>
{
    new List<int> { 1, 0, 0, 0, 0, 1 },
    new List<int> { 0, 2, 0, 0, 0, 0 },
    new List<int> { 3, 0, 0, 0, 0, 0 },
    new List<int> { 0, 0, 0, 0, 0, 4 },
    new List<int> { 0, 0, 5, 0, 0, 0 }
};

PrintTable(dense);

Console.WriteLine("Dense to COO");
var coo = DenseToCOO(dense);
PrintTable(coo);
Console.WriteLine();

Console.WriteLine("Dense to LIL");
var (rows, data) =  DenseToLIL(dense);
Console.WriteLine("Rows");
PrintTable(rows);
Console.WriteLine();
Console.WriteLine("Data");
PrintTable(data);
Console.WriteLine();

Console.WriteLine("Dense to CSR");
var (index_pointers, indices, data_CSR) = DenseToCSR(dense);
Console.WriteLine("Index pinters");
Print(index_pointers);
Console.WriteLine();
Console.WriteLine("Indices");
Print(indices);
Console.WriteLine();
Console.WriteLine("Data");
Print(data_CSR);
Console.WriteLine();


static List<List<int>> DenseToCOO(List<List<int>> arr)
{
    var res = new List<List<int>>();
    for (int i = 0; i < arr.Count(); i++) {
        for (int j = 0; j < arr[0].Count(); j++) {
            if (arr[i][j] != 0) res.Add(new List<int>{ i, j, arr[i][j] });
        }
    }
    return res;
}

static (List<List<int>>, List<List<int>>) DenseToLIL(List<List<int>> arr)
{
    var rows = new List<List<int>>();
    var data = new List<List<int>>();
    for (int i = 0; i < arr.Count(); i++) {
        rows.Add(new List<int>());
        data.Add(new List<int>());
        for (int j = 0; j < arr[0].Count(); j++) {
            if (arr[i][j] != 0) {
                rows[i].Add(j);
                data[i].Add(arr[i][j]);
            }
        }
    }
    return (rows, data);
}

static (List<int>, List<int>, List<int>) DenseToCSR(List<List<int>> arr)
{
    var index_pointers = new List<int> { 0};
    var indices = new List<int>();
    var data = new List<int>();

    for (int i = 0; i < arr.Count(); i++) {
        int count = 0;
        for (int j = 0; j < arr[0].Count(); j++) {
            if (arr[i][j] != 0) { 
                indices.Add(j);
                data.Add(arr[i][j]);
                count++;
            }
        }
        index_pointers.Add(index_pointers[i] + count);
    }
    return (index_pointers, indices, data);

}

static void Print(List<int> arr)
{  
    Console.Write("[ ");
    for (int i = 0; i < arr.Count - 1; i++) Console.Write($"{arr[i]}, ");
    Console.WriteLine($"{arr[arr.Count - 1]} ]");
}


static void PrintTable(List<List<int>> arr)
{
    foreach (var x in arr) Print(x);
}
