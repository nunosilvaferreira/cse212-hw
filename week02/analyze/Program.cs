Console.WriteLine("\n======================\nMysteryStack1\n======================");
Console.WriteLine(MysteryStack1.Run("racecar"));
Console.WriteLine(MysteryStack1.Run("stressed"));
Console.WriteLine(MysteryStack1.Run("a nut for a jar of tuna"));

Console.WriteLine("\n======================\nMysteryStack2\n======================");
Console.WriteLine(MysteryStack2.Run("5 3 7 + *"));
Console.WriteLine(MysteryStack2.Run("6 2 + 5 3 - /"));

try { MysteryStack2.Run("3 +"); }
catch (ApplicationException e) { Console.WriteLine(e.Message); }

try { MysteryStack2.Run("5 0 /"); }
catch (ApplicationException e) { Console.WriteLine(e.Message); }

try { MysteryStack2.Run("3 8 %"); }
catch (ApplicationException e) { Console.WriteLine(e.Message); }

try { MysteryStack2.Run("5 3 4 +"); }
catch (ApplicationException e) { Console.WriteLine(e.Message); }
