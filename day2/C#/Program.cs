using System;

static int PartOne(string[] rounds)
{
	Dictionary<string, int> elfPlay = new Dictionary<string, int>();
	elfPlay.Add("A", 1);
	elfPlay.Add("B", 2);
	elfPlay.Add("C", 3);

	Dictionary<string, int> myPlay = new Dictionary<string, int>();
	myPlay.Add("X", 1);
	myPlay.Add("Y", 2);
	myPlay.Add("Z", 3);

	int score = 0;

	foreach (var round in rounds)
	{
		int elf = elfPlay[round.Split(" ")[0]];
		int me = myPlay[round.Split(" ")[1]];
		score += me;
		if (elf == 3 && me == 1)
		{
			score += 6;
		}
		else if (elf == 1 && me == 3)
		{
			score += 0;
		}
		else if (me > elf)
		{
			score += 6;
		}
		else if (me == elf)
		{
			score += 3;
		}
	}
	return score;
}

string[] rounds = File.ReadAllLines(@"..\day2.txt");
int partOne = PartOne(rounds);
Console.WriteLine($"part one {partOne}");

List<string> newRounds = new List<string>();
foreach (var round in rounds)
{
	string elfPlays = round.Split(" ")[0];
	string outcome = round.Split(" ")[1];
	Dictionary<string, string> iPlay = new Dictionary<string, string>();

	if (outcome == "X")
	{
		iPlay.Add("A", "Z");
		iPlay.Add("B", "X");
		iPlay.Add("C", "Y");
	}
	else if (outcome == "Y")
	{
		iPlay.Add("A", "X");
		iPlay.Add("B", "Y");
		iPlay.Add("C", "Z");
	}
	else if (outcome == "Z")
	{
		iPlay.Add("A", "Y");
		iPlay.Add("B", "Z");
		iPlay.Add("C", "X");
	}
	newRounds.Add(elfPlays + " " + iPlay[elfPlays]);
}
string[] newRoundsArray = newRounds.ToArray();
int score = PartOne(newRoundsArray);
Console.WriteLine($"part two {score}");