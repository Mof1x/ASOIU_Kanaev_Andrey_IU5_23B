while (true)
{
    var s1 = Console.ReadLine();
    if (s1 == "exit") break;
    var s2 = Console.ReadLine();
    if (s2 == "exit") break;

    var arr = DamerauLevenshteinDistance(s1, s2);
    Console.WriteLine(arr[s1.Length - 1, s2.Length - 1]);
    //Console.WriteLine();
    //PrintTable(arr);
}




static int[,] LevenshteinDistance(string s1, string s2)
{

    int[,] res = new int[s1.Length + 1, s2.Length + 1];

    for (int i = 0; i < res.GetLength(0); i++) {
        for (int j = 0; j < res.GetLength(1); j++) {
            res[i, j] = (i, j) switch
            {
                (0, 0) => 0,
                ( > 0, 0) => i,
                (0, > 0) => j,
                (_, _) => new int[] { res[i - 1, j] + 1, res[i, j - 1] + 1, res[i - 1, j - 1] + Convert.ToInt32(s1[i - 1] != s2[j - 1])}.Min()
            };
        }
    }
    return res;
}

static int[,] DamerauLevenshteinDistance(string s1, string s2)
{
    int[,] res = new int[s1.Length + 1, s2.Length + 1];
    var arr = LevenshteinDistance(s1, s2);
    var m = arr.GetLength(0);
    var n = arr.GetLength(1);   
 
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (i > 1 && j > 1 && s1[i - 1] == s2[j - 2] && s1[i - 2] == s2[j - 1]) {
                res[i, j] = new int[] { arr[n - 1, m - 1], arr[i - 2, j - 2] + Convert.ToInt32(s1[i - 1] != s2[j - 1]) }.Min();
            } else {
                res[i, j] = arr[i, j];
            }
        }
    }
    return res;
}

static void PrintTable(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1) - 1; j++) {
            Console.Write($"{arr[i, j]}, ");
        }
        Console.WriteLine(arr[i, arr.GetLength(1) - 1]);
    }
}
