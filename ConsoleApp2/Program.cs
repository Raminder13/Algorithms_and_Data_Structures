//Algorithms and Data Structures-SD-2023
//Lab 1: Introduction to .NET and C#

int n = 0;

while (n <= 0)
{
    Console.WriteLine("Please enter an integer value greater than zero.");
    n = Int32.Parse(Console.ReadLine());
}

//Point-:1
//While the user is entering words, prevent the user from continuing if that word contains a space.

string[] words = new string[n];

for (int i = 0; i < n; i++)
{
    Console.WriteLine($"Enter word {i + 1}:");
    string newWord = Console.ReadLine();

    if (newWord.Contains(" "))
    {
        Console.WriteLine("Sorry, but the word cannot contain spaces. Please try again.");
        i--;
    }
    else if (newWord.Length > 0)
    {
        words[i] = newWord;
    }
    else
    {
        Console.WriteLine("Sorry, but you must enter at least one character. Please try again.");
        i--;
    }
}

char charToCount;

while (true)
{
    Console.WriteLine("Please enter a character to count:");

    ConsoleKeyInfo keyInfo = Console.ReadKey();
    charToCount = keyInfo.KeyChar;

//Point-:2
//Confirm the char entered is a letter (not a number or symbol),
//and if it is not a letter, prompt the user to enter one again.You can use Char.IsLetter() for validation.


    if ((charToCount >= 'a' && charToCount <= 'z') || (charToCount >= 'A' && charToCount <= 'Z'))
    {
        break;
    }
    else
    {
        Console.WriteLine("\nThe character entered is not a letter. Please try again.");
    }
}

Console.WriteLine($"\nYou entered the character '{charToCount}'");


//Point-:3
// if your array of words has all lowercase letters and the user searches for an uppercase char like 'A'.

int charCount = 0;

foreach (string word in words)
{
    if (word != null)
    {
        char[] chars = word.ToLower().ToCharArray();

        foreach (char c in chars)
        {
            if (Char.ToLower(c) == Char.ToLower(charToCount))
            {
                charCount++;
            }
        }
    }
}

Console.WriteLine($"{charCount} times");


//point 4
//What do you think would be the best numeric datatype to store the total count of letters?
//Why not just use BigInteger?

//Answer-:
// It totally depends on the expected range of counts.
// If the count can exceed the maximum value of an int, you can use BigInteger
// but if the count is within the range of int, you can use int to save memory.