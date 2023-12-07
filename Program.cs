List<string> lines = new List<string>();
using (StreamReader reader = new StreamReader(args[0]))
{
    while (!reader.EndOfStream)
    {
        lines.Add(reader.ReadLine());
    }
}

sln(false);
sln(true);
void sln(bool part2)
{
    int runTotal = 1;

    List<string> times_s = lines[0].Split(':').ToList<string>()[1].Split(' ').ToList<string>();
    List<string> distances_s = lines[1].Split(':').ToList<string>()[1].Trim().Split(' ').ToList<string>();

    List<ulong> times = new List<ulong>();
    List<ulong> distances = new List<ulong>();

    foreach (string s in times_s.Where(s => s.Length>0))
        times.Add(ulong.Parse(s));

    foreach (string s in distances_s.Where(s=>s.Length>0))
        distances.Add(ulong.Parse(s));

    if (part2)
    {
        times = new() { Convert.ToUInt64(string.Concat(times)) };
        distances = new() { Convert.ToUInt64(string.Concat(distances)) };
    }

    for (int r = 0; r < times.Count; r++)
    {
        int beatMethods = 0;

        for (ulong hold = 0; hold < times[r]; hold++)
        {
            ulong distance = (times[r] - hold) * hold;
            if (distance > distances[r])
            {
                beatMethods++;
            }
        }

        runTotal *= beatMethods;

    }
    Console.WriteLine(runTotal);
}