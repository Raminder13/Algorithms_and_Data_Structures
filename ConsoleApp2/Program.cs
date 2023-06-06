using System;
using System.Text;

//A program that produces an array of all of the characters that appear more than once in a string.
//For example, the string “Programmatic Python” would result in the array ['p','r','o','a','m','t'].

string inputString = "Programmatic Python";
string inputStringLower = inputString.ToLower();
List<char> duplicateChars = new List<char>();

foreach (char c in inputStringLower)
{
    int count = 0;
    for (int i = 0; i < inputStringLower.Length; i++)
    {
        if (c == inputStringLower[i])
        {
            count++;
        }
        if (count > 1 && !duplicateChars.Contains(c))
        {
            duplicateChars.Add(c);
            break;
        }
    }
}

char[] duplicateCharsArray = duplicateChars.ToArray();
Console.WriteLine("Duplicate characters in the string: " + string.Join(", ", duplicateCharsArray));


//2nd
//    array ['p','r','o','a','m','t'].
//A program returns an array of strings that are unique words found in the argument.
//For example, the string “To be or not to be” returns ["to","be","or","not"].

string i2 = "To be or not to be";
string[] uniqueWords = GetUniqueWords(i2);
Console.WriteLine("Unique Words: " + string.Join(", ", uniqueWords));

string[] GetUniqueWords(string input)
{
    // Split into an array of words
    string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    List<string> uniqueWords = new List<string>();

    for (int i = 0; i < words.Length; i++)
    {
        string word = words[i];
        bool isDuplicate = false;

        for (int j = 0; j < uniqueWords.Count; j++)
        {
            if (string.Equals(word, uniqueWords[j], StringComparison.OrdinalIgnoreCase))
            {
                isDuplicate = true;
                break;
            }
        }

        // If the word is not a duplicate add it
        if (!isDuplicate)
        {
            uniqueWords.Add(word);
        }
    }
    return uniqueWords.ToArray();
}



//3rd
//A program that reverses a provided string

string i3 = "Reverse this string";
string reversedString = ReverseString(i3);
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
//If there are multiple words tied for greatest length, print the last one.

string i4 = "Tiptoe through the tulips";
string longestWord = GetLongestUnbrokenWord(i4);
Console.WriteLine("Longest Word: " + longestWord);

string GetLongestUnbrokenWord(string input)
{
    string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    string longestWord = "";

    for (int i = 0; i < words.Length; i++)
    {
        string word = words[i];

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