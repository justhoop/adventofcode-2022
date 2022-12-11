using System;
string[] elves = File.ReadAllLines(@"..\day1.txt");
List<Int32> calories = new List<Int32>(); 
Int32 total = 0;
foreach (string elf in elves)
{
	if (elf != "")
	{
		total += Int32.Parse(elf);
	}
	else
	{
		calories.Add(total);
		total = 0;
	}
}
Int32 partOne = calories.Max();
Console.WriteLine($"part one {partOne}");

calories.Sort();
total = 0;
for (int i = 3; i > 0; i--)
{
	total += calories[^i];
}
Console.WriteLine($"part two {total}");