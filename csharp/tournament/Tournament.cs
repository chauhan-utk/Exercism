using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class Tournament
{
    private static IDictionary<string, int> MatchPlayed = new Dictionary<string, int>();
    private static IDictionary<string, int> Won = new Dictionary<string, int>();
    private static IDictionary<string, int> Draw = new Dictionary<string, int>();
    private static IDictionary<string, int> Lost = new Dictionary<string, int>();
    private static List<Tuple<int, string>> Points = new List<Tuple<int, string>>();

    private static string rowFormat = "{0,-31}|{1,3} |{2,3} |{3,3} |{4,3} |{5,3}";
    public static void Tally(Stream inStream, Stream outStream)
    {
        StreamReader inputStream = new StreamReader(inStream);
        string input = inputStream.ReadToEnd();
        populateData(input);
        List<string> tableRows = processRows();
        StringBuilder tallyTable = new StringBuilder(string.Format(rowFormat, "Team", "MP", "W", "D", "L", "P"));
        foreach(string row in tableRows)
        {
            tallyTable.Append("\n" + row);
        }
        UTF8Encoding encoder = new UTF8Encoding();
        outStream.Write(encoder.GetBytes(tallyTable.ToString()), 0, tallyTable.Length);   
    }

    private static void populateData(string input)
    {
        string[] matches = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        foreach(string match in matches)
        {
            string[] outcome = match.Split(";", StringSplitOptions.RemoveEmptyEntries);
            MatchPlayed.tryIncreaseCount(outcome[0]);
            MatchPlayed.tryIncreaseCount(outcome[1]);

            switch (outcome[2])
            {
                case "win":
                    Won.tryIncreaseCount(outcome[0]);
                    Lost.tryIncreaseCount(outcome[1]);
                    break;
                case "loss":
                    Lost.tryIncreaseCount(outcome[0]);
                    Won.tryIncreaseCount(outcome[1]);
                    break;
                case "draw":
                    Draw.tryIncreaseCount(outcome[0]);
                    Draw.tryIncreaseCount(outcome[1]);
                    break;
            }
        }
    }

    private static void tryIncreaseCount(this IDictionary<string, int> dict, string team)
    {
        if (dict.ContainsKey(team))
            dict[team]++;
        else
            dict[team] = 1;
    }

    private static int tryGetTeamScore(this IDictionary<string, int> dict, string team)
    {
        int score = 0;
        dict.TryGetValue(team, out score);
        return score;
    }

    private static List<string> processRows()
    {
        foreach(string key in MatchPlayed.Keys)
        {
            int point = Won.tryGetTeamScore(key) * 3 + Draw.tryGetTeamScore(key);
            Points.Add(new Tuple<int, string>(point, key));
        }
        Points.Sort(compareTeamPoints);
        List<string> rows = new List<string>();
        foreach (var teamScore in Points)
        {
            string team = teamScore.Item2;
            int points = teamScore.Item1;
            rows.Add(string.Format(rowFormat, team, MatchPlayed.tryGetTeamScore(team), Won.tryGetTeamScore(team), Draw.tryGetTeamScore(team), Lost.tryGetTeamScore(team), points));
        }
        return rows;
        //throw new NotImplementedException();
    }

    private static int compareTeamPoints(Tuple<int,string> team1, Tuple<int, string> team2)
    {
        if (team1.Item1 > team2.Item1) return -1;
        else if (team2.Item1 > team1.Item1) return 1;
        else
        {
            // team1.Item1 == team2.Item1
            return team1.Item2.CompareTo(team2.Item2);
        }
    }
}
