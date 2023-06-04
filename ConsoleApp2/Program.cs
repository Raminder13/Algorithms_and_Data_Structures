//Algorithms and Data Structures
//Lab 3 (Complexity)

/* 1. We have a list of integers where elements appear either once or twice.
 * Find the elements that appeared twice in O(n) time.
   example: {1, 2, 3, 4, 7, 9, 2, 4} returns '{2, 4}
*/

List<int> nums = new List<int> { 1, 2, 3, 4, 7, 9, 2, 4 };
List<int> duplicates = FindDuplicates(nums);

Console.WriteLine(string.Join(", ", duplicates));

// Function
List<int> FindDuplicates(List<int> nums)
{
    HashSet<int> seen = new HashSet<int>(); // HashSet 4 unique elements
    List<int> duplicates = new List<int>(); // List 4 duplicate els

    foreach (int num in nums)
    {
        if (seen.Contains(num))
        {
            duplicates.Add(num); // If the els is already in the HashSet then it's a duplicate
        }
        else
        {
            seen.Add(num); // If the element is not in the HashSet add it to the HashSet
        }
    }

    return duplicates;
}



/* 2. We have two sorted int arrays which could be with different sizes.
 * We need to merge them in a third array while keeping this result array sorted.
 * Can you do that in O(n) time? Don't use any extra structures like Sets or Dictionaries
   example: {{1, 2, 3, 4, 5}, {2, 5, 7, 9, 13}}
        returns {1, 2, 2, 3, 4, 5, 5, 7, 9, 13}
*/

int[] nums1 = { 1, 2, 3, 4, 5 };
int[] nums2 = { 2, 5, 7, 9, 13 };
int[] merged = MergeSortedArrays(nums1, nums2);

Console.WriteLine(string.Join(", ", merged));

// Function
int[] MergeSortedArrays(int[] nums1, int[] nums2)
{
    int n1 = nums1.Length; // Length of the first array
    int n2 = nums2.Length; // second
    int[] merged = new int[n1 + n2]; // Array 4 merged result
    int i = 0, j = 0, k = 0;

    while (i < n1 && j < n2)
    {
        if (nums1[i] <= nums2[j])
        {
            merged[k] = nums1[i]; 
            i++;
        }
        else
        {
            merged[k] = nums2[j]; 
            j++; 
        }
        k++;
    }

    while (i < n1)
    {
        merged[k] = nums1[i];
        i++;
        k++;
    }

    while (j < n2)
    {
        merged[k] = nums2[j];
        j++;
        k++;
    }

    return merged;
}


/* 3. Given an integer, reverse the digits of that integer,
 * e. g. input is 3415, output is 5143. What is the time complexity of your solution?
*/

int num = 3415;
int reversedNum = ReverseInteger(num);
Console.WriteLine(reversedNum);
int ReverseInteger(int num)
{
    int reversed = 0;
    while (num != 0)
    {
        int digit = num % 10;
        reversed = reversed * 10 + digit;
        num /= 10;
    }
    return reversed;
}




