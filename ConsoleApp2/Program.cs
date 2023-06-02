using System.Text;

string inputString = "Programmatic Python";
char[] repeatedChars = GetRepeatedCharacters(inputString);
Console.WriteLine("Repeated Characters: " + string.Join(", ", repeatedChars));

string inputString2 = "To be or not to be";
string[] uniqueWords = GetUniqueWords(inputString2);
Console.WriteLine("Unique Words: " + string.Join(", ", uniqueWords));

string inputString3 = "Reverse this string";
string reversedString = ReverseString(inputString3);
Console.WriteLine("Reversed String: " + reversedString);

string inputString4 = "Tiptoe through the tulips";
string longestWord = GetLongestUnbrokenWord(inputString4);
Console.WriteLine("Longest Word: " + longestWord);

char[] GetRepeatedCharacters(string input)
{
    List<char> repeatedChars = new List<char>();
    HashSet<char> uniqueChars = new HashSet<char>();
    HashSet<char> duplicateChars = new HashSet<char>();

    foreach (char c in input)
    {
        if (uniqueChars.Contains(c))
        {
            if (!duplicateChars.Contains(c))
            {
                repeatedChars.Add(c);
                duplicateChars.Add(c);
            }
        }
        else
        {
            uniqueChars.Add(c);
        }
    }

    return repeatedChars.ToArray();
}

string[] GetUniqueWords(string input)
{
    string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    HashSet<string> uniqueWords = new HashSet<string>(words, StringComparer.OrdinalIgnoreCase);

    return uniqueWords.ToArray();
}

string ReverseString(string input)
{
    StringBuilder reversed = new StringBuilder();

    for (int i = input.Length - 1; i >= 0; i--)
    {
        reversed.Append(input[i]);
    }

    return reversed.ToString();
}

string GetLongestUnbrokenWord(string input)
{
    string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    string longestWord = "";

    foreach (string word in words)
    {
        if (word.Length > longestWord.Length)
        {
            longestWord = word;
        }
    }

    return longestWord;
}