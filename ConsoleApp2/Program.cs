//Algorithms and Data Structures
//Lab 4 (Lists)

/*
    List<int> MaxNumbersInLists(List<List<int>>) accepts as a parameter a List of Lists of Integers.
    It returns a new list with each element representing the maximum number found in the corresponding original list. 

    For example, { {1, 5, 3}, {9, 7, 3, -2}, {2, 1, 2} } returns {5, 9, 2}.
    Output the results with a message like: “List 1 has a maximum of 5.
    List 2 has a maximum of 9. List 3 has a maximum of 2.”
*/

List<List<int>> list1 = new List<List<int>>
{
    new List<int> { 1, 5, 3 },
    new List<int> { 9, 7, 3, -2 },
    new List<int> { 2, 1, 2 }
};

List<int> maxNumbers1 = MaxNumbersInLists(list1);
Console.WriteLine("Max Numbers in Lists:");
for (int i = 0; i < maxNumbers1.Count; i++)
{
    Console.WriteLine($"List {i + 1} has a maximum of {maxNumbers1[i]}");
}

List<int> MaxNumbersInLists(List<List<int>> lists)
{
    List<int> maxNumbers = new List<int>();

    foreach (List<int> list in lists)
    {
        if (list.Count > 0)
        {
            int max = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] > max)
                {
                    max = list[i];
                }
            }
            maxNumbers.Add(max);
        }
        else
        {
            maxNumbers.Add(0);
        }
    }

    return maxNumbers;
}


/*
    String HighestGrade(List<List<int>>) accepts a list of number grades among students in different courses
    (where each list represents a single course), between 0 and 100. It returns the highest grade among
    all students in all courses.

    For example: { {85,92, 67, 94, 94}, {50, 60, 57, 95}, {95} } returns "The highest grade is 95.
    This grade was found in class(es) {index}".
*/

List<List<int>> list2 = new List<List<int>> 
{
    new List<int> { 85, 92, 67, 94, 94 },
    new List<int> { 50, 60, 57, 95 },
    new List<int> { 50, 95 },
    new List<int> { 95 } 
};
string highestGrade = HighestGrade(list2);
Console.WriteLine($"Highest Grade:");
Console.WriteLine(highestGrade);

string HighestGrade(List<List<int>> grades)
{
    int highestGrade = 0;
    List<int> indexes = new List<int>();

    for (int i = 0; i < grades.Count; i++)
    {
        List<int> courseGrades = grades[i];
        if (courseGrades.Count > 0)
        {
            int max = courseGrades.Max();
            if (max > highestGrade)
            {
                highestGrade = max;
                indexes.Clear();
                indexes.Add(i + 1);
            }
            else if (max == highestGrade)
            {
                indexes.Add(i + 1);
            }
        }
    }

    string indexString = string.Join(", ", indexes);
    return ($"The highest grade is {highestGrade}. This grade was found in class(es) {indexString}.");
}

/*

    List<int> OrderByLooping (List<int>) orders a list of integers, from least to greatest,
    using only basic control statements (ie. if/else, for/while).

    For example, argument {6, -2, 5, 3} returns {-2, 3, 5, 6}.
*/

List<int> list3 = new List<int> { 9, 7, -1, -5, 0 };
List<int> orderedList = OrderByLooping(list3);
Console.WriteLine($"Ordered List: ");
foreach (int num in orderedList)
{
    Console.Write(num + " ");
}

List<int> OrderByLooping(List<int> numbers)
{
    for (int i = 0; i < numbers.Count - 1; i++)
    {
        for (int j = 0; j < numbers.Count - i - 1; j++)
        {
            if (numbers[j] > numbers[j + 1])
            {
                int temp = numbers[j];
                numbers[j] = numbers[j + 1];
                numbers[j + 1] = temp;
            }
        }
    }

    return numbers;
}

