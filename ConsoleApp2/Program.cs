using System;
using System.Text;

string inputString4 = "Tiptoe through the tulips";
string longestWord = GetLongestUnbrokenWord(inputString4);
Console.WriteLine("Longest Word: " + longestWord);

//A program that produces an array of all of the characters that appear more than once in a string.
//For example, the string “Programmatic Python” would result in the array ['p','r','o','a','m','t'].

string inputString = "Programmatic Python";
char[] repeatedChars = GetRepeatedCharacters(inputString);
Console.WriteLine("Repeated Characters: " + string.Join(", ", repeatedChars));
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

//2nd
//    array ['p','r','o','a','m','t'].
//A program returns an array of strings that are unique words found in the argument.
//For example, the string “To be or not to be” returns ["to","be","or","not"].

string inputString2 = "To be or not to be";
string[] uniqueWords = GetUniqueWords(inputString2);
Console.WriteLine("Unique Words: " + string.Join(", ", uniqueWords));
string[] GetUniqueWords(string input)
{
    string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    HashSet<string> uniqueWords = new HashSet<string>(words, StringComparer.OrdinalIgnoreCase);

    return uniqueWords.ToArray();
}


//3rd
//A program that reverses a provided string

string inputString3 = "Reverse this string";
string reversedString = ReverseString(inputString3);
Console.WriteLine("Reversed String: " + reversedString);
string ReverseString(string input)
{
    StringBuilder reversed = new StringBuilder();

    for (int i = input.Length - 1; i >= 0; i--)
    {
        reversed.Append(input[i]);
    }

    return reversed.ToString();
}

//4th
//A program that finds the longest unbroken word in a string and prints it
//For example, the string "Tiptoe through the tulips" would print "through"
//If there are multiple words tied for greatest length, print the last one

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

// StringBuilder provides faster and more memory-efficient string manipulation by allowing changes
// to be made without creating new string instances each time.

//Advantages of StringBuilder:
//Can be changed: StringBuilder allows modifying strings without creating new ones.
//Efficient memory usage: StringBuilder dynamically allocates memory as needed, avoiding unnecessary
//overhead and resizing operations.

//Disadvantages of StringBuilder:
//No immutability guarantees: StringBuilder allows for mutable strings, which may not be suitable
//if you need to ensure that a string remains unchanged after creation.
//Additional complexity: Working with StringBuilder requires using its specific methods for string manipulation.