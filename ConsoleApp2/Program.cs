//PART - 1

using System.Text;

Dictionary<int, int> coins = new Dictionary<int, int>()
    {
        { 1, 10 },
        { 2, 10 },
        { 5, 15 },
        { 10, 10 },
        { 20, 5 }
    };

Dictionary<string, double> items = new Dictionary<string, double>()
    {
        { "A", 3 },
        { "B", 2 },
        { "C", 1 }
    };

Dictionary<int, int> CalculateChange(double amount, double price)
{
    double change = amount - price;
    Dictionary<int, int> changeCoins = new Dictionary<int, int>();

    int[] sortedCoins = new int[] { 20, 10, 5, 2, 1 };

    foreach (int coin in sortedCoins)
    {
        int coinValue = coin;
        if (coinValue <= change && coins[coinValue] > 0)
        {
            int numCoins = (int)(change / coinValue);
            if (numCoins > coins[coinValue])
            {
                numCoins = coins[coinValue];
            }
            changeCoins[coinValue] = numCoins;
            change -= numCoins * coinValue;
            coins[coinValue] -= numCoins; // Update the remaining quantity of coins
            change = Math.Round(change, 2); // Round the change to two decimal places
        }
    }

    if (Math.Abs(change) < 0.01)
    {
        return changeCoins;
    }
    else
    {
        // Restore the initial quantity of coins since change calculation failed
        foreach (KeyValuePair<int, int> kvp in changeCoins)
        {
            coins[kvp.Key] += kvp.Value;
        }
        return null;
    }
}



void VendingMachine()
{
    while (true)
    {
        Console.Write("Enter the amount of money: $");
        double amount = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the item name (or 'CANCEL' to exit): ");
        string input = Console.ReadLine().ToUpper();

        if (input == "CANCEL")
        {
            Console.WriteLine("Transaction canceled.");
            break;
        }

        if (!items.ContainsKey(input))
        {
            Console.WriteLine("Invalid item name. Please try again.");
            continue;
        }

        double itemPrice = items[input];

        if (amount < itemPrice)
        {
            Console.WriteLine("Insufficient amount. Please enter a larger amount.");
            continue;
        }

        Dictionary<int, int> change = CalculateChange(amount, itemPrice);

        if (change == null)
        {
            Console.WriteLine("Insufficient change. Transaction canceled.");
            break;
        }

        Console.WriteLine($"Vended item: {input}");
        Console.WriteLine("Change:");
        foreach (KeyValuePair<int, int> kvp in change)
        {
            Console.WriteLine($"${kvp.Key}: {kvp.Value} piece(s)");
        }

        // Update the quantities of coins
        foreach (KeyValuePair<int, int> kvp in change)
        {
            coins[kvp.Key] -= kvp.Value;
        }

        break;
    }
}
VendingMachine();

// PART-2
string CompressString(string input)
{
    StringBuilder compressedString = new StringBuilder();
    int count = 1;

    for (int i = 1; i <= input.Length; i++)
    {
        if (i < input.Length && input[i] == input[i - 1])
        {
            count++;
        }
        else
        {
            compressedString.Append(input[i - 1]);
            if (count > 1)
            {
                compressedString.Append(count);
            }
            count = 1;
        }
    }

    return compressedString.ToString();
}

string DecompressString(string compressedString)
{
    StringBuilder decompressedString = new StringBuilder();
    int i = 0;

    while (i < compressedString.Length)
    {
        char currentChar = compressedString[i];
        decompressedString.Append(currentChar);
        i++;

        if (i < compressedString.Length && char.IsDigit(compressedString[i]))
        {
            int count = int.Parse(compressedString[i].ToString());
            decompressedString.Append(new string(currentChar, count - 1));
            i++;
        }
    }

    return decompressedString.ToString();
}

// Example: Decompressed to Compressed
string originalString = "RTTFTFFFFRRRR";
string compressedString = CompressString(originalString);
Console.WriteLine($"Original: {originalString}");
Console.WriteLine($"Compressed: {compressedString}");
Console.WriteLine();

// Example: Compressed to Decompressed
compressedString = "T3GL2G3";
string decompressedString = DecompressString(compressedString);
Console.WriteLine($"Compressed: {compressedString}");
Console.WriteLine($"Decompressed: {decompressedString}");

