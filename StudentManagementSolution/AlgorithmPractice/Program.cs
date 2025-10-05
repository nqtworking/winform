using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("C# Collections Practice");
                Console.WriteLine("=====================");
                Console.WriteLine("1. Array Operations");
                Console.WriteLine("2. List Operations");
                Console.WriteLine("3. Dictionary Operations");
                Console.WriteLine("4. HashSet Operations");
                Console.WriteLine("5. Queue Operations");
                Console.WriteLine("6. Stack Operations");
                Console.WriteLine("7. LinkedList Operations");
                Console.WriteLine("8. String and Char Operations");
                Console.WriteLine("9. Element Access Examples");
                Console.WriteLine("0. Exit");
                
                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                Console.Clear();
                
                switch (choice)
                {
                    case "1":
                        PracticeWithArray();
                        break;
                    case "2":
                        PracticeWithList();
                        break;
                    case "3":
                        PracticeWithDictionary();
                        break;
                    case "4":
                        PracticeWithHashSet();
                        break;
                    case "5":
                        PracticeWithQueue();
                        break;
                    case "6":
                        PracticeWithStack();
                        break;
                    case "7":
                        PracticeWithLinkedList();
                        break;
                    case "8":
                        PracticeWithStrings();
                        break;
                    case "9":
                        ElementAccessExamples();
                        break;
                    case "0":
                        exit = true;
                        continue;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }
        }

        static void ElementAccessExamples()
        {
            Console.WriteLine("Collection Element Access Examples");
            Console.WriteLine("================================\n");

            // Array access
            Console.WriteLine("ARRAY ACCESS:");
            int[] array = { 10, 20, 30, 40, 50 };
            
            // Direct access by index
            Console.WriteLine($"Array[0]: {array[0]}");
            Console.WriteLine($"Array[4]: {array[4]}");
            
            // Looping through array
            Console.WriteLine("\nArray iteration (for loop):");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"  array[{i}] = {array[i]}");
            }

            Console.WriteLine("\nArray iteration (foreach):");
            foreach (int item in array)
            {
                Console.WriteLine($"  value: {item}");
            }

            // List access
            Console.WriteLine("\nLIST ACCESS:");
            List<string> list = new List<string> { "apple", "banana", "cherry", "date" };
            
            // Direct access by index
            Console.WriteLine($"list[0]: {list[0]}");
            Console.WriteLine($"list[3]: {list[3]}");
            
            // Using indexers for both get and set
            list[1] = "blueberry";
            Console.WriteLine($"After changing list[1]: {list[1]}");
            
            // Dictionary access
            Console.WriteLine("\nDICTIONARY ACCESS:");
            Dictionary<string, int> dict = new Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 }
            };
            
            // Direct access by key
            Console.WriteLine($"dict[\"one\"]: {dict["one"]}");
            
            // Safe access with TryGetValue
            if (dict.TryGetValue("four", out int value))
            {
                Console.WriteLine($"Value of \"four\": {value}");
            }
            else
            {
                Console.WriteLine("Key \"four\" not found");
            }
            
            // Add or update using indexer
            dict["four"] = 4;
            Console.WriteLine($"After adding, dict[\"four\"]: {dict["four"]}");
            
            // Dictionary iteration
            Console.WriteLine("\nDictionary iteration:");
            foreach (KeyValuePair<string, int> pair in dict)
            {
                Console.WriteLine($"  {pair.Key}: {pair.Value}");
            }
            
            // HashSet access
            Console.WriteLine("\nHASHSET ACCESS:");
            HashSet<char> charSet = new HashSet<char> { 'A', 'B', 'C', 'D' };
            
            // Check if element exists
            Console.WriteLine($"Contains 'A': {charSet.Contains('A')}");
            Console.WriteLine($"Contains 'Z': {charSet.Contains('Z')}");
            
            // No direct indexer for HashSet
            Console.WriteLine("\nHashSet iteration:");
            foreach (char c in charSet)
            {
                Console.WriteLine($"  value: {c}");
            }
            
            // Queue access
            Console.WriteLine("\nQUEUE ACCESS:");
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            
            // Peek at first item without removing
            Console.WriteLine($"First item (Peek): {queue.Peek()}");
            
            // Dequeue to get and remove first item
            Console.WriteLine($"Dequeue first item: {queue.Dequeue()}");
            Console.WriteLine($"New first item: {queue.Peek()}");
            
            // Stack access
            Console.WriteLine("\nSTACK ACCESS:");
            Stack<string> stack = new Stack<string>();
            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");
            
            // Peek at top item without removing
            Console.WriteLine($"Top item (Peek): {stack.Peek()}");
            
            // Pop to get and remove top item
            Console.WriteLine($"Pop top item: {stack.Pop()}");
            Console.WriteLine($"New top item: {stack.Peek()}");
            
            // LinkedList access
            Console.WriteLine("\nLINKEDLIST ACCESS:");
            LinkedList<double> linkedList = new LinkedList<double>();
            linkedList.AddLast(1.1);
            linkedList.AddLast(2.2);
            linkedList.AddLast(3.3);
            
            // Access first and last nodes
            Console.WriteLine($"First value: {linkedList.First.Value}");
            Console.WriteLine($"Last value: {linkedList.Last.Value}");
            
            // Navigating nodes
            LinkedListNode<double> currentNode = linkedList.First;
            Console.WriteLine("\nNavigating nodes:");
            while (currentNode != null)
            {
                Console.WriteLine($"  Current value: {currentNode.Value}");
                currentNode = currentNode.Next;
            }
            
            // String access
            Console.WriteLine("\nSTRING ACCESS:");
            string text = "Hello World";
            
            // Accessing characters by index
            Console.WriteLine($"text[0]: {text[0]}");
            Console.WriteLine($"text[6]: {text[6]}");
            
            // Iterating through characters
            Console.WriteLine("\nString character iteration:");
            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine($"  text[{i}]: '{text[i]}'");
            }
            
            // Strings are immutable - need to create new strings for changes
            // This creates a new string with a modified character
            char[] textChars = text.ToCharArray();
            textChars[0] = 'J';
            string modifiedText = new string(textChars);
            Console.WriteLine($"\nModified text: {modifiedText}");

            // String character iteration with foreach
            Console.WriteLine("\nString character iteration using foreach:");
            foreach (char c in text)
            {
                Console.WriteLine($"  character: '{c}'");
            }
            
            // Summary
            Console.WriteLine("\nELEMENT ACCESS SUMMARY:");
            Console.WriteLine("- Array:       arrayName[index]");
            Console.WriteLine("- List:        listName[index]");
            Console.WriteLine("- Dictionary:  dictName[key] or dictName.TryGetValue(key, out value)");
            Console.WriteLine("- HashSet:     No direct access - use Contains() and foreach");
            Console.WriteLine("- Queue:       queue.Peek() and queue.Dequeue()");
            Console.WriteLine("- Stack:       stack.Peek() and stack.Pop()");
            Console.WriteLine("- LinkedList:  First.Value, Last.Value, or navigate with node.Next/node.Previous");
            Console.WriteLine("- String:      stringName[index] (read-only)");
        }

        static void PracticeWithArray()
        {
            Console.WriteLine("Array Practice Demo");
            Console.WriteLine("=================");
            
            // Creating and initializing arrays
            int[] numbers = { 45, 12, 78, 23, 56, 89, 34, 67, 9, 41 };
            Console.WriteLine("Original array:");
            PrintArray(numbers);

            // Finding min and max values
            int min = numbers.Min();
            int max = numbers.Max();
            Console.WriteLine($"\nMinimum value: {min}");
            Console.WriteLine($"Maximum value: {max}");

            // Calculating sum and average
            int sum = numbers.Sum();
            double average = numbers.Average();
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Average: {average:F2}");

            // Searching for an element
            int searchValue = 56;
            int position = Array.IndexOf(numbers, searchValue);
            if (position != -1)
                Console.WriteLine($"\nFound {searchValue} at position {position}");
            else
                Console.WriteLine($"\n{searchValue} was not found in the array");

            // Sorting the array
            int[] sortedArray = (int[])numbers.Clone();
            Array.Sort(sortedArray);
            Console.WriteLine("\nSorted array:");
            PrintArray(sortedArray);

            // Reversing the array
            int[] reversedArray = (int[])sortedArray.Clone();
            Array.Reverse(reversedArray);
            Console.WriteLine("\nReversed sorted array (descending order):");
            PrintArray(reversedArray);

            // Filtering even numbers
            var evenNumbers = numbers.Where(n => n % 2 == 0).ToArray();
            Console.WriteLine("\nEven numbers from original array:");
            PrintArray(evenNumbers);

            // Creating a modified array (multiply each element by 2)
            int[] doubledNumbers = numbers.Select(n => n * 2).ToArray();
            Console.WriteLine("\nEach element multiplied by 2:");
            PrintArray(doubledNumbers);
        }

        static void PracticeWithList()
        {
            Console.WriteLine("List Practice Demo");
            Console.WriteLine("=================");
            
            // Creating and initializing a List
            List<int> numbersList = new List<int> { 45, 12, 78, 23, 56 };
            Console.WriteLine("Original list:");
            PrintList(numbersList);

            // Adding elements to the list
            numbersList.Add(99);
            numbersList.Add(7);
            Console.WriteLine("\nAfter adding 99 and 7:");
            PrintList(numbersList);

            // Inserting an element at a specific position
            numbersList.Insert(2, 50);
            Console.WriteLine("\nAfter inserting 50 at position 2:");
            PrintList(numbersList);

            // Removing elements
            numbersList.Remove(56);
            Console.WriteLine("\nAfter removing 56:");
            PrintList(numbersList);

            // Removing element at specific index
            numbersList.RemoveAt(0);
            Console.WriteLine("\nAfter removing element at index 0:");
            PrintList(numbersList);

            // Checking if an element exists
            int checkValue = 78;
            bool containsValue = numbersList.Contains(checkValue);
            Console.WriteLine($"\nDoes list contain {checkValue}? {containsValue}");

            // Finding an element using a predicate
            int foundValue = numbersList.Find(x => x > 50);
            Console.WriteLine($"First value greater than 50: {foundValue}");

            // Sorting the list
            numbersList.Sort();
            Console.WriteLine("\nSorted list:");
            PrintList(numbersList);

            // Reversing the list
            numbersList.Reverse();
            Console.WriteLine("\nReversed list:");
            PrintList(numbersList);

            // Filtering with LINQ
            List<int> evenNumbers = numbersList.Where(n => n % 2 == 0).ToList();
            Console.WriteLine("\nEven numbers from the list:");
            PrintList(evenNumbers);

            // List capacity
            Console.WriteLine($"\nList count: {numbersList.Count}");
            Console.WriteLine($"List capacity: {numbersList.Capacity}");
            
            // Converting list to array
            int[] numbersArray = numbersList.ToArray();
            Console.WriteLine("\nConverted to array:");
            PrintArray(numbersArray);
            
            // Clearing the list
            numbersList.Clear();
            Console.WriteLine($"\nAfter clearing, list count: {numbersList.Count}");
        }

        static void PracticeWithDictionary()
        {
            Console.WriteLine("Dictionary Practice Demo");
            Console.WriteLine("======================");
            
            // Creating a dictionary
            Dictionary<string, int> studentScores = new Dictionary<string, int>
            {
                { "Alice", 95 },
                { "Bob", 87 },
                { "Charlie", 72 }
            };
            
            Console.WriteLine("Original dictionary:");
            PrintDictionary(studentScores);
            
            // Adding elements
            studentScores.Add("David", 89);
            studentScores["Emma"] = 91;  // Another way to add or set values
            Console.WriteLine("\nAfter adding new students:");
            PrintDictionary(studentScores);
            
            // Updating values
            studentScores["Charlie"] = 75;
            Console.WriteLine("\nAfter updating Charlie's score:");
            PrintDictionary(studentScores);
            
            // Checking if key exists
            string keyToCheck = "Bob";
            if (studentScores.ContainsKey(keyToCheck))
                Console.WriteLine($"\nFound {keyToCheck}'s score: {studentScores[keyToCheck]}");
            else
                Console.WriteLine($"\n{keyToCheck} not found in the dictionary");
            
            // Safe way to get values
            string keyToFind = "Frank";
            if (studentScores.TryGetValue(keyToFind, out int score))
                Console.WriteLine($"Found {keyToFind}'s score: {score}");
            else
                Console.WriteLine($"{keyToFind} not found in the dictionary");
            
            // Removing an element
            studentScores.Remove("Alice");
            Console.WriteLine("\nAfter removing Alice:");
            PrintDictionary(studentScores);
            
            // Iterating through keys and values separately
            Console.WriteLine("\nAll students:");
            foreach (string student in studentScores.Keys)
                Console.WriteLine(student);
                
            Console.WriteLine("\nAll scores:");
            foreach (int value in studentScores.Values)
                Console.WriteLine(value);
                
            // Getting count
            Console.WriteLine($"\nDictionary count: {studentScores.Count}");
            
            // Clearing the dictionary
            studentScores.Clear();
            Console.WriteLine($"After clearing, dictionary count: {studentScores.Count}");
        }

        static void PracticeWithHashSet()
        {
            Console.WriteLine("HashSet Practice Demo");
            Console.WriteLine("===================");
            
            // Creating HashSets
            HashSet<int> set1 = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> set2 = new HashSet<int> { 3, 4, 5, 6, 7 };
            
            Console.WriteLine("Set 1:");
            PrintSet(set1);
            Console.WriteLine("\nSet 2:");
            PrintSet(set2);
            
            // Adding elements (won't add duplicates)
            set1.Add(5);  // Already exists, won't be added
            set1.Add(6);  // New element, will be added
            Console.WriteLine("\nSet 1 after adding 5 and 6:");
            PrintSet(set1);
            
            // Removing elements
            set1.Remove(1);
            Console.WriteLine("\nSet 1 after removing 1:");
            PrintSet(set1);
            
            // Checking if element exists
            int elementToCheck = 4;
            Console.WriteLine($"\nDoes Set 1 contain {elementToCheck}? {set1.Contains(elementToCheck)}");
            
            // Set operations
            // Union (elements from either set)
            HashSet<int> unionSet = new HashSet<int>(set1);
            unionSet.UnionWith(set2);
            Console.WriteLine("\nUnion of Set 1 and Set 2:");
            PrintSet(unionSet);
            
            // Intersection (elements in both sets)
            HashSet<int> intersectionSet = new HashSet<int>(set1);
            intersectionSet.IntersectWith(set2);
            Console.WriteLine("\nIntersection of Set 1 and Set 2:");
            PrintSet(intersectionSet);
            
            // Difference (elements in set1 but not in set2)
            HashSet<int> differenceSet = new HashSet<int>(set1);
            differenceSet.ExceptWith(set2);
            Console.WriteLine("\nSet 1 - Set 2 (Difference):");
            PrintSet(differenceSet);
            
            // Symmetric Difference (elements in either set, but not in both)
            HashSet<int> symmetricDifferenceSet = new HashSet<int>(set1);
            symmetricDifferenceSet.SymmetricExceptWith(set2);
            Console.WriteLine("\nSymmetric Difference of Set 1 and Set 2:");
            PrintSet(symmetricDifferenceSet);
            
            // Check if one set is a subset of another
            HashSet<int> subset = new HashSet<int> { 3, 4 };
            Console.WriteLine($"\nIs {{{string.Join(", ", subset)}}} a subset of Set 1? {subset.IsSubsetOf(set1)}");
            
            // Count and Clear
            Console.WriteLine($"\nSet 1 count: {set1.Count}");
            set1.Clear();
            Console.WriteLine($"After clearing, Set 1 count: {set1.Count}");
        }

        static void PracticeWithQueue()
        {
            Console.WriteLine("Queue Practice Demo (FIFO)");
            Console.WriteLine("========================");
            
            // Creating a queue
            Queue<string> processQueue = new Queue<string>();
            
            // Enqueue (adding) elements
            processQueue.Enqueue("Process 1");
            processQueue.Enqueue("Process 2");
            processQueue.Enqueue("Process 3");
            
            Console.WriteLine("Queue after adding 3 processes:");
            PrintQueue(processQueue);
            
            // Peek (view next item without removing)
            Console.WriteLine($"\nNext process to be processed: {processQueue.Peek()}");
            
            // Dequeue (removing and returning) elements
            string nextProcess = processQueue.Dequeue();
            Console.WriteLine($"\nProcessed: {nextProcess}");
            
            Console.WriteLine("\nQueue after processing one item:");
            PrintQueue(processQueue);
            
            // Check if queue contains an element
            string processToFind = "Process 2";
            Console.WriteLine($"\nDoes queue contain '{processToFind}'? {processQueue.Contains(processToFind)}");
            
            // Convert queue to array
            string[] processArray = processQueue.ToArray();
            Console.WriteLine("\nQueue as array:");
            Console.WriteLine(string.Join(", ", processArray));
            
            // Count and Clear
            Console.WriteLine($"\nQueue count: {processQueue.Count}");
            processQueue.Clear();
            Console.WriteLine($"After clearing, queue count: {processQueue.Count}");
            
            // Real-world example: Processing tasks in order
            Console.WriteLine("\nSimulating task processing:");
            
            Queue<string> tasks = new Queue<string>();
            tasks.Enqueue("Send email");
            tasks.Enqueue("Generate report");
            tasks.Enqueue("Backup data");
            
            while (tasks.Count > 0)
            {
                string currentTask = tasks.Dequeue();
                Console.WriteLine($"Processing task: {currentTask}");
                // Simulate processing
                Console.WriteLine($"Task '{currentTask}' completed");
            }
        }

        static void PracticeWithStack()
        {
            Console.WriteLine("Stack Practice Demo (LIFO)");
            Console.WriteLine("========================");
            
            // Creating a stack
            Stack<string> browserHistory = new Stack<string>();
            
            // Push (adding) elements
            browserHistory.Push("https://www.homepage.com");
            browserHistory.Push("https://www.search.com");
            browserHistory.Push("https://www.results.com");
            
            Console.WriteLine("Browser history stack:");
            PrintStack(browserHistory);
            
            // Peek (view top item without removing)
            Console.WriteLine($"\nCurrent page: {browserHistory.Peek()}");
            
            // Pop (removing and returning) elements
            string previousPage = browserHistory.Pop();
            Console.WriteLine($"\nNavigated back from: {previousPage}");
            
            Console.WriteLine("\nBrowser history after going back once:");
            PrintStack(browserHistory);
            
            // Check if stack contains an element
            string urlToFind = "https://www.homepage.com";
            Console.WriteLine($"\nDoes history contain '{urlToFind}'? {browserHistory.Contains(urlToFind)}");
            
            // Convert stack to array (order is reversed)
            string[] historyArray = browserHistory.ToArray();
            Console.WriteLine("\nHistory as array (most recent first):");
            Console.WriteLine(string.Join(", ", historyArray));
            
            // Count and Clear
            Console.WriteLine($"\nStack count: {browserHistory.Count}");
            browserHistory.Clear();
            Console.WriteLine($"After clearing, stack count: {browserHistory.Count}");
            
            // Real-world example: Undo operations
            Console.WriteLine("\nSimulating undo operations:");
            
            Stack<string> undoStack = new Stack<string>();
            undoStack.Push("Added text");
            undoStack.Push("Changed formatting");
            undoStack.Push("Deleted paragraph");
            
            Console.WriteLine("Action history:");
            PrintStack(undoStack);
            
            Console.WriteLine("\nPerforming undo operations:");
            while (undoStack.Count > 0)
            {
                string action = undoStack.Pop();
                Console.WriteLine($"Undoing: {action}");
            }
        }

        static void PracticeWithLinkedList()
        {
            Console.WriteLine("LinkedList Practice Demo");
            Console.WriteLine("======================");
            
            // Creating a LinkedList
            LinkedList<string> playlist = new LinkedList<string>();
            
            // Adding elements
            playlist.AddLast("Song 1");  // Add to end
            playlist.AddLast("Song 3");
            
            // Adding at specific position
            LinkedListNode<string> node = playlist.First;
            playlist.AddAfter(node, "Song 2");
            
            // Adding at beginning
            playlist.AddFirst("Intro");
            
            Console.WriteLine("Playlist:");
            PrintLinkedList(playlist);
            
            // Accessing first and last nodes
            Console.WriteLine($"\nFirst song: {playlist.First.Value}");
            Console.WriteLine($"Last song: {playlist.Last.Value}");
            
            // Finding a node
            LinkedListNode<string> songNode = playlist.Find("Song 2");
            if (songNode != null)
            {
                Console.WriteLine($"\nFound Song 2");
                
                // Getting previous and next nodes
                if (songNode.Previous != null)
                    Console.WriteLine($"Previous song: {songNode.Previous.Value}");
                    
                if (songNode.Next != null)
                    Console.WriteLine($"Next song: {songNode.Next.Value}");
                    
                // Insert before specific node
                playlist.AddBefore(songNode, "Song 1.5");
            }
            
            Console.WriteLine("\nUpdated playlist:");
            PrintLinkedList(playlist);
            
            // Removing elements
            playlist.Remove("Song 1.5");
            Console.WriteLine("\nAfter removing Song 1.5:");
            PrintLinkedList(playlist);
            
            // Remove first and last
            playlist.RemoveFirst();
            playlist.RemoveLast();
            Console.WriteLine("\nAfter removing first and last songs:");
            PrintLinkedList(playlist);
            
            // Check contains
            string songToFind = "Song 2";
            Console.WriteLine($"\nDoes playlist contain '{songToFind}'? {playlist.Contains(songToFind)}");
            
            // Count and Clear
            Console.WriteLine($"\nLinkedList count: {playlist.Count}");
            playlist.Clear();
            Console.WriteLine($"After clearing, LinkedList count: {playlist.Count}");
        }

        static void PracticeWithStrings()
        {
            Console.WriteLine("String and Character Practice Demo");
            Console.WriteLine("===============================");
            
            // String creation and basic operations
            string str1 = "Hello";
            string str2 = "World";
            
            Console.WriteLine("Basic Strings:");
            Console.WriteLine($"String 1: \"{str1}\"");
            Console.WriteLine($"String 2: \"{str2}\"");
            
            // String concatenation
            string combined = str1 + " " + str2;
            Console.WriteLine($"\nConcatenation: \"{combined}\"");
            
            string combined2 = string.Concat(str1, ", ", str2, "!");
            Console.WriteLine($"Using String.Concat: \"{combined2}\"");
            
            // String interpolation
            string interpolated = $"{str1}, {str2}!";
            Console.WriteLine($"String interpolation: \"{interpolated}\"");
            
            // String Length
            Console.WriteLine($"\nLength of \"{combined}\": {combined.Length}");
            
            // String comparison
            bool areEqual = str1 == "Hello";
            Console.WriteLine($"\nIs str1 equal to \"Hello\"?: {areEqual}");
            
            // Case-sensitive comparison
            bool caseEqual = string.Equals("hello", "Hello", StringComparison.Ordinal);
            Console.WriteLine($"Case-sensitive equality: {caseEqual}");
            
            // Case-insensitive comparison
            bool caseInsensitiveEqual = string.Equals("hello", "Hello", StringComparison.OrdinalIgnoreCase);
            Console.WriteLine($"Case-insensitive equality: {caseInsensitiveEqual}");
            
            // String methods
            // Substring
            string substr = combined.Substring(6, 5);  // Start at 6, take 5 chars
            Console.WriteLine($"\nSubstring (6,5): \"{substr}\"");
            
            // IndexOf and LastIndexOf
            string text = "The quick brown fox jumps over the lazy dog";
            int firstThe = text.IndexOf("the");
            int lastThe = text.LastIndexOf("the");
            Console.WriteLine($"\nText: \"{text}\"");
            Console.WriteLine($"First occurrence of \"the\": {firstThe}");
            Console.WriteLine($"Last occurrence of \"the\": {lastThe}");
            
            // Contains, StartsWith, EndsWith
            bool containsFox = text.Contains("fox");
            bool startsWithThe = text.StartsWith("The");
            bool endsWithDog = text.EndsWith("dog");
            
            Console.WriteLine($"\nContains \"fox\"?: {containsFox}");
            Console.WriteLine($"Starts with \"The\"?: {startsWithThe}");
            Console.WriteLine($"Ends with \"dog\"?: {endsWithDog}");
            
            // Replace
            string replaced = text.Replace("fox", "cat");
            Console.WriteLine($"\nAfter replacing \"fox\" with \"cat\": \"{replaced}\"");
            
            // ToUpper and ToLower
            string upper = text.ToUpper();
            string lower = text.ToLower();
            Console.WriteLine($"\nUpper case: \"{upper}\"");
            Console.WriteLine($"Lower case: \"{lower}\"");
            
            // Trim, TrimStart, TrimEnd
            string padded = "   Padded String   ";
            Console.WriteLine($"\nPadded string: \"{padded}\"");
            Console.WriteLine($"After Trim: \"{padded.Trim()}\"");
            Console.WriteLine($"After TrimStart: \"{padded.TrimStart()}\"");
            Console.WriteLine($"After TrimEnd: \"{padded.TrimEnd()}\"");
            
            // Split and Join
            string csvData = "Alice,Bob,Charlie,David";
            string[] names = csvData.Split(',');
            
            Console.WriteLine($"\nCSV data: \"{csvData}\"");
            Console.WriteLine("After Split:");
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"  {i}: {names[i]}");
            }
            
            string joined = string.Join(" | ", names);
            Console.WriteLine($"\nAfter Join: \"{joined}\"");
            
            // StringBuilder for performance
            Console.WriteLine("\nStringBuilder Demo:");
            StringBuilder sb = new StringBuilder();
            
            // Using StringBuilder is more efficient for multiple operations
            sb.Append("Building ");
            sb.Append("a ");
            sb.Append("string ");
            sb.Append("efficiently.");
            
            string sbResult = sb.ToString();
            Console.WriteLine($"StringBuilder result: \"{sbResult}\"");
            
            // Insert, Remove, Replace
            sb.Insert(0, "Start: ");
            Console.WriteLine($"After Insert: \"{sb}\"");
            
            sb.Remove(0, 7);
            Console.WriteLine($"After Remove: \"{sb}\"");
            
            sb.Replace("string", "StringBuilder");
            Console.WriteLine($"After Replace: \"{sb}\"");
            
            // Character operations
            Console.WriteLine("\nCharacter Operations:");
            
            // Accessing characters
            char firstChar = text[0];
            char lastChar = text[text.Length - 1];
            Console.WriteLine($"First character of text: '{firstChar}'");
            Console.WriteLine($"Last character of text: '{lastChar}'");
            
            // Character methods
            Console.WriteLine("\nCharacter testing methods:");
            Console.WriteLine($"Is 'A' a letter? {char.IsLetter('A')}");
            Console.WriteLine($"Is '5' a digit? {char.IsDigit('5')}");
            Console.WriteLine($"Is 'A' uppercase? {char.IsUpper('A')}");
            Console.WriteLine($"Is 'a' lowercase? {char.IsLower('a')}");
            Console.WriteLine($"Is ' ' whitespace? {char.IsWhiteSpace(' ')}");
            
            // Character conversion
            Console.WriteLine("\nCharacter conversion:");
            char lowerChar = 'a';
            char upperChar = char.ToUpper(lowerChar);
            Console.WriteLine($"'{lowerChar}' to uppercase: '{upperChar}'");
            
            char upperChar2 = 'Z';
            char lowerChar2 = char.ToLower(upperChar2);
            Console.WriteLine($"'{upperChar2}' to lowercase: '{lowerChar2}'");
            
            // Character as integer (ASCII/Unicode value)
            Console.WriteLine("\nCharacter numeric values:");
            Console.WriteLine($"ASCII value of 'A': {(int)'A'}");
            Console.WriteLine($"ASCII value of 'a': {(int)'a'}");
            Console.WriteLine($"ASCII value of '0': {(int)'0'}");
            
            // Converting between character and integer
            int asciiValue = 65;
            char charFromAscii = (char)asciiValue;
            Console.WriteLine($"Character for ASCII 65: '{charFromAscii}'");
            
            // Converting digit character to numeric value
            char digitChar = '7';
            int digitValue = digitChar - '0';  // Convert char digit to actual number
            Console.WriteLine($"Numeric value of '{digitChar}': {digitValue}");
            
            // String Formatting
            Console.WriteLine("\nString Formatting:");
            
            decimal price = 123.45m;
            Console.WriteLine($"Currency: {price:C}");
            Console.WriteLine($"Number with 2 decimals: {price:F2}");
            Console.WriteLine($"Percentage: {0.75:P}");
            
            DateTime now = DateTime.Now;
            Console.WriteLine($"Date (short): {now:d}");
            Console.WriteLine($"Date (long): {now:D}");
            Console.WriteLine($"Date and time: {now:G}");
            Console.WriteLine($"Custom format: {now:yyyy-MM-dd HH:mm:ss}");
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }
        
        static void PrintList<T>(List<T> list)
        {
            Console.WriteLine(string.Join(", ", list));
        }
        
        static void PrintDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            foreach (var pair in dictionary)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
        
        static void PrintSet<T>(HashSet<T> set)
        {
            Console.WriteLine(string.Join(", ", set));
        }
        
        static void PrintQueue<T>(Queue<T> queue)
        {
            Console.WriteLine(string.Join(" <- ", queue));
        }
        
        static void PrintStack<T>(Stack<T> stack)
        {
            // Stack is LIFO, so top element is first
            Console.WriteLine(string.Join(" -> ", stack));
        }
        
        static void PrintLinkedList<T>(LinkedList<T> linkedList)
        {
            Console.WriteLine(string.Join(" <-> ", linkedList));
        }
    }
}
