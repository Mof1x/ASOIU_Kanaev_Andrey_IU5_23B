Console.Write("Введите количество участников: ");
int.TryParse(Console.ReadLine(), out int n);
Console.WriteLine();

Team[] teams = new Team[n];
for (int i = 0; i < teams.Length; i++)
{
    (string, double) input = Team.inputData();
    teams[i] = new Team(input.Item1, input.Item2);
}

CalculateStatistics(teams);
PrintTable(teams);
PrintResults(teams);
FilterByMinSpeed(teams);


static Team[] sortingTeams(Team[] teams)
{
    for (int i = 0; i < teams.Length; i++)
    {
        for (int j = 0; j < teams.Length - i - 1; j++)
        {
            if (teams[j] > teams[j + 1])
            {
                var c = teams[j];
                teams[j] = teams[j + 1];
                teams[j + 1] = c;
            }
        }
    }
    return teams;
}

static void CalculateStatistics(Team[] teams)
{
    double average = 0;
    Team[] sortedTeams = sortingTeams(teams);

    var mini = sortedTeams[0];
    var maxi = sortedTeams[sortedTeams.Length - 1];

    foreach (var team in sortedTeams)
    {
        average += team.Speed;
    }
    average /= sortedTeams.Length; 

    Console.WriteLine("--- СТАТИСТИКА КВАЛИФИКАЦИИ ---\r");
    Console.WriteLine($"Средняя скорость: {average}  км/ч\r");
    Console.WriteLine($"Лидер: {maxi.Name}({maxi.Speed})\r");
    Console.WriteLine($"Самый медленный: {mini.Name}({mini.Speed})\r");
    Console.WriteLine($"Разница темпа: {maxi.Speed - mini.Speed:F2} км / ч");
}


static void PrintTable(Team[] teams)
{
    var sorted_teams = sortingTeams(teams);
    Console.WriteLine(String.Concat(Enumerable.Repeat("-", 46)));
    Console.WriteLine($"|{"Команда",-20} | {"Скорость(км / ч)",20} |");
    foreach ( var team in sorted_teams)
    {
        Console.WriteLine($"|{team.Name,-20} | {team.Speed,20:F2} |");
    }
    Console.WriteLine(String.Concat(Enumerable.Repeat("-", 46)));
}

static void PrintResults(Team[] teams)
{
    var sorted_teams = sortingTeams(teams);
    var team1 = sorted_teams[sorted_teams.Length - 1];
    var team2 = sorted_teams[sorted_teams.Length - 2];
    var team3 = sorted_teams[sorted_teams.Length - 3];
    Console.WriteLine("--- ИТОГОВЫЙ ПРОТОКОЛ КВАЛИФИКАЦИИ ---");
    Console.WriteLine(String.Concat(Enumerable.Repeat("-", 46)));
    Console.WriteLine("| Поз. | Команда              | Скорость     |");
    Console.WriteLine(String.Concat(Enumerable.Repeat("-", 46)));
    Console.WriteLine($"|  1   | {team1.Name,-20} | {team1.Speed,12:F2} |");
    Console.WriteLine($"|  2   | {team2.Name,-20} | {team2.Speed,12:F2} |");
    Console.WriteLine($"|  3   | {team3.Name,-20} | {team3.Speed,12:F2} |");
    Console.WriteLine(String.Concat(Enumerable.Repeat("-", 46)));
}

static void FilterByMinSpeed(Team[] teams)
{
    Console.Write("Введите минимальную скорость для отбора(км / ч):");
    double.TryParse(Console.ReadLine().Replace('.', ','), out double min_speed);
    var sorted_teams = sortingTeams(teams);
    Console.WriteLine($"Команды со скоростью >= {min_speed:F2} км / ч:");
    int count = 0;
    foreach (var team in sorted_teams)
    {
        if (team.Speed > min_speed)
        {
            Console.WriteLine($"- {team.Name} ({team.Speed:F2} км/ч)");
            count++;
        }
    }
    Console.WriteLine();
    Console.WriteLine($"Отобрано команд: {count}");
}



class Team
{
    private string name;
    private double speed;

    public Team(string name, double speed)
    {
        this.name = name;
        this.speed = speed;
    }

    public string Name { get { return name; } }
    public double Speed { get { return speed; } }

    public static (string, double) inputData()
    {
        string name;
        Console.Write("Введите название команды: ");
        try
        {
            name = Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            name = "";
        }
        Console.WriteLine();

        Console.Write("Введите среднюю скорость: ");

        bool flag = double.TryParse(Console.ReadLine().Replace('.', ','), out double avgSpeed);
        

        Console.WriteLine();
        return (name, avgSpeed);
    }

    public static bool operator >(Team team1, Team team2) { return team1.Speed > team2.Speed; }
    public static bool operator <(Team team1, Team team2) { return team1.Speed < team2.Speed; }
    public static bool operator ==(Team team1, Team team2) { return team1.Speed == team2.Speed; }
    public static bool operator !=(Team team1, Team team2) { return team1.Speed != team2.Speed; }


};
