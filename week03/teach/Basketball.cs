using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // skip header

        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            string playerId = fields[0];
            int points = int.Parse(fields[8]);

            if (!players.ContainsKey(playerId))
                players[playerId] = 0;

            players[playerId] += points;
        }

        var topPlayers = new List<KeyValuePair<string, int>>(players);
        topPlayers.Sort((a, b) => b.Value.CompareTo(a.Value));

        Console.WriteLine("Top 10 Players by Career Points:");
        for (int i = 0; i < Math.Min(10, topPlayers.Count); i++)
        {
            Console.WriteLine($"{i + 1}. Player {topPlayers[i].Key}: {topPlayers[i].Value} points");
        }
    }
}
