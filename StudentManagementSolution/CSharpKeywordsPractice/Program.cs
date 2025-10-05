using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpKeywordsPractice
{
    class Program
    {
        // Constants - implicitly static, must be initialized at declaration
        private const string APP_NAME = "C# Keywords Demo";
        private const double TAX_RATE = 0.07;

        // Readonly fields - can only be assigned in declaration or constructor
        private readonly DateTime startTime;

        // Static fields - shared across all instances
        private static int instanceCount = 0;

        // Constructor
        public Program()
        {
            // Initialize readonly field
            startTime = DateTime.Now;
            // Increment static counter
            instanceCount++;
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"=== {APP_NAME} ===\n");
            
            bool exit = false;
            while (!exit)
            {
                PrintMenu();
                string choice = Console.ReadLine();
                Console.Clear();
                
                switch (choice)
                {
                    case "1":
                        DemoBasicKeywords();
                        break;
                    case "2":
                        DemoModifierKeywords();
                        break;
                    case "3":
                        DemoControlFlowKeywords();
                        break;
                    case "4":
                        DemoTypeRelatedKeywords();
                        break;
                    case "5":
                        DemoExceptionKeywords();
                        break;
                    case "6":
                        DemoParameterKeywords();
                        break;
                    case "7":
                        AsyncDemo().Wait(); // Wait for async demo to complete
                        break;
                    case "8":
                        DemoDelegatesAndEvents();
                        break;
                    case "9":
                        exit = true;
                        continue;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("Select a keyword category to explore:");
            Console.WriteLine("1. Basic Keywords (var, dynamic, object)");
            Console.WriteLine("2. Modifier Keywords (public, private, static, readonly, const)");
            Console.WriteLine("3. Control Flow Keywords (if, switch, loops, break, continue)");
            Console.WriteLine("4. Type-Related Keywords (class, struct, enum, interface)");
            Console.WriteLine("5. Exception Keywords (try, catch, finally, throw)");
            Console.WriteLine("6. Parameter Keywords (ref, out, in, params)");
            Console.WriteLine("7. Async/Await Keywords");
            Console.WriteLine("8. Delegates and Events");
            Console.WriteLine("9. Exit");
            Console.Write("\nYour choice: ");
        }

        #region 1. Basic Keywords
        static void DemoBasicKeywords()
        {
            Console.WriteLine("=== Basic Keywords ===\n");

            // var - implicitly typed local variable
            Console.WriteLine("--- var keyword ---");
            var number = 10;               // Compiler infers int
            var text = "Hello";            // Compiler infers string
            var date = DateTime.Now;       // Compiler infers DateTime
            var items = new List<int>();   // Compiler infers List<int>
            
            Console.WriteLine($"var number is type: {number.GetType().Name}, value: {number}");
            Console.WriteLine($"var text is type: {text.GetType().Name}, value: {text}");
            Console.WriteLine($"var date is type: {date.GetType().Name}, value: {date}");
            Console.WriteLine($"var items is type: {items.GetType().Name}");

            // dynamic - resolved at runtime (no compile-time type checking)
            Console.WriteLine("\n--- dynamic keyword ---");
            dynamic dynamicValue = 100;
            Console.WriteLine($"dynamic value: {dynamicValue}, type: {dynamicValue.GetType().Name}");
            
            dynamicValue = "Now I'm a string";
            Console.WriteLine($"dynamic value: {dynamicValue}, type: {dynamicValue.GetType().Name}");
            
            dynamicValue = new DateTime(2023, 1, 1);
            Console.WriteLine($"dynamic value: {dynamicValue}, type: {dynamicValue.GetType().Name}");

            // object - base type for all types
            Console.WriteLine("\n--- object keyword ---");
            object obj1 = 42;          // Boxing int
            object obj2 = "text";      // Reference type
            object obj3 = DateTime.Now;// Boxing DateTime
            
            Console.WriteLine($"object value: {obj1}, type: {obj1.GetType().Name}");
            Console.WriteLine($"object value: {obj2}, type: {obj2.GetType().Name}");
            Console.WriteLine($"object value: {obj3}, type: {obj3.GetType().Name}");

            // Type conversion with 'as' and 'is' keywords
            Console.WriteLine("\n--- as and is keywords ---");
            object someValue = "Hello World";
            
            // 'is' checks if object is compatible with a type
            bool isString = someValue is string;
            Console.WriteLine($"someValue is string: {isString}");
            
            // 'as' converts if possible, otherwise returns null
            string textValue = someValue as string;
            Console.WriteLine($"someValue as string: {textValue}");
        }
        #endregion

        #region 2. Modifier Keywords
        static void DemoModifierKeywords()
        {
            Console.WriteLine("=== Modifier Keywords ===\n");
            
            // Create instances to demonstrate
            Program program1 = new Program();
            Program program2 = new Program();
            
            Console.WriteLine("--- Access Modifiers ---");
            Console.WriteLine("public: Accessible from anywhere");
            Console.WriteLine("private: Accessible only within the containing class");
            Console.WriteLine("protected: Accessible within the containing class and derived classes");
            Console.WriteLine("internal: Accessible within the containing assembly");
            Console.WriteLine("protected internal: Accessible within the containing assembly or derived classes");
            
            Console.WriteLine("\n--- Type Modifiers ---");
            Console.WriteLine("static: Belongs to the type rather than an instance");
            Console.WriteLine($"static instanceCount: {instanceCount}");
            
            Console.WriteLine("\nconst: Compile-time constants that cannot be changed");
            Console.WriteLine($"const APP_NAME: {APP_NAME}");
            Console.WriteLine($"const TAX_RATE: {TAX_RATE}");
            
            Console.WriteLine("\nreadonly: Runtime constants that can only be set in declaration or constructor");
            Console.WriteLine($"readonly startTime for instance 1: {program1.startTime}");
            Console.WriteLine($"readonly startTime for instance 2: {program2.startTime}");
            
            Console.WriteLine("\n--- Other Important Modifiers ---");
            Console.WriteLine("abstract: Classes that cannot be instantiated, methods that must be implemented by derived classes");
            Console.WriteLine("sealed: Classes that cannot be inherited from");
            Console.WriteLine("virtual: Methods that can be overridden in derived classes");
            Console.WriteLine("override: Implementation of a virtual method in a derived class");
            Console.WriteLine("partial: Splitting a class, struct, or interface across multiple files");
        }
        #endregion

        #region 3. Control Flow Keywords
        static void DemoControlFlowKeywords()
        {
            Console.WriteLine("=== Control Flow Keywords ===\n");
            
            // if-else statement
            Console.WriteLine("--- if, else, else if keywords ---");
            int score = 85;
            
            if (score >= 90)
            {
                Console.WriteLine("Grade: A");
            }
            else if (score >= 80)
            {
                Console.WriteLine("Grade: B");
            }
            else if (score >= 70)
            {
                Console.WriteLine("Grade: C");
            }
            else
            {
                Console.WriteLine("Grade: F");
            }
            
            // switch statement
            Console.WriteLine("\n--- switch, case, default, when keywords ---");
            int dayOfWeek = (int)DateTime.Now.DayOfWeek;
            string dayType;
            
            switch (dayOfWeek)
            {
                case 0:
                    dayType = "Weekend (Sunday)";
                    break;
                case 6:
                    dayType = "Weekend (Saturday)";
                    break;
                case int day when day >= 1 && day <= 5:  // Pattern matching with 'when'
                    dayType = "Weekday";
                    break;
                default:
                    dayType = "Unknown";
                    break;
            }
            
            Console.WriteLine($"Today is a {dayType}");
            
            // for loop
            Console.WriteLine("\n--- for, break, continue keywords ---");
            Console.WriteLine("Counting with breaks and continues:");
            for (int i = 1; i <= 10; i++)
            {
                if (i == 5)
                {
                    Console.WriteLine("  Skipping 5 (continue)");
                    continue; // Skip this iteration
                }
                
                if (i == 8)
                {
                    Console.WriteLine("  Stopping at 8 (break)");
                    break; // Exit the loop
                }
                
                Console.WriteLine($"  Count: {i}");
            }
            
            // while and do-while loops
            Console.WriteLine("\n--- while and do-while keywords ---");
            int counter = 0;
            
            Console.WriteLine("While loop (may execute zero times):");
            while (counter < 3)
            {
                Console.WriteLine($"  counter: {counter}");
                counter++;
            }
            
            counter = 0;
            Console.WriteLine("\nDo-while loop (always executes at least once):");
            do
            {
                Console.WriteLine($"  counter: {counter}");
                counter++;
            } while (counter < 3);
            
            // foreach loop
            Console.WriteLine("\n--- foreach keyword ---");
            string[] colors = { "red", "green", "blue" };
            
            Console.WriteLine("Colors:");
            foreach (string color in colors)
            {
                Console.WriteLine($"  {color}");
            }
            
            // return keyword
            Console.WriteLine("\n--- return keyword ---");
            int sum = AddNumbers(10, 20);
            Console.WriteLine($"Sum returned from method: {sum}");
        }
        
        static int AddNumbers(int a, int b)
        {
            return a + b; // Return statement
        }
        #endregion

        #region 4. Type-Related Keywords
        static void DemoTypeRelatedKeywords()
        {
            Console.WriteLine("=== Type-Related Keywords ===\n");
            
            // class and new keywords
            Console.WriteLine("--- class and new keywords ---");
            Person person = new Person("Alice", 30);
            Console.WriteLine(person.GetInfo());
            
            // struct keyword
            Console.WriteLine("\n--- struct keyword ---");
            Point point = new Point(10, 20);
            Console.WriteLine($"Point coordinates: ({point.X}, {point.Y})");
            
            // enum keyword
            Console.WriteLine("\n--- enum keyword ---");
            Console.WriteLine("Available colors:");
            foreach (Color color in Enum.GetValues(typeof(Color)))
            {
                Console.WriteLine($"  {color} ({(int)color})");
            }
            
            // interface keyword
            Console.WriteLine("\n--- interface keyword ---");
            IDrawable circle = new Circle(5.0);
            Console.WriteLine($"Circle: {circle.Draw()}");
            
            // namespace keyword
            Console.WriteLine("\n--- namespace keyword ---");
            Console.WriteLine($"Current namespace: {typeof(Program).Namespace}");
            
            // using keyword (for namespaces)
            Console.WriteLine("\n--- using keyword ---");
            Console.WriteLine("using System; // Imports the System namespace");
            Console.WriteLine("using static System.Math; // Imports static members");
            Console.WriteLine("using alias = FullName; // Creates a namespace alias");
        }
        
        // Example class
        class Person
        {
            private string name;
            private int age;
            
            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
            
            public string GetInfo()
            {
                return $"Person: {name}, Age: {age}";
            }
        }
        
        // Example struct
        struct Point
        {
            public int X { get; }
            public int Y { get; }
            
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
        
        // Example enum
        enum Color
        {
            Red = 1,
            Green = 2,
            Blue = 3,
            Yellow = 4
        }
        
        // Example interface
        interface IDrawable
        {
            string Draw();
        }
        
        // Class implementing interface
        class Circle : IDrawable
        {
            private double radius;
            
            public Circle(double radius)
            {
                this.radius = radius;
            }
            
            public string Draw()
            {
                return $"Drawing circle with radius {radius}";
            }
        }
        #endregion

        #region 5. Exception Keywords
        static void DemoExceptionKeywords()
        {
            Console.WriteLine("=== Exception Keywords ===\n");
            
            Console.WriteLine("--- try, catch, finally, throw keywords ---");
            
            try
            {
                Console.WriteLine("Executing code in try block...");
                
                // Divide by zero - will cause exception
                int numerator = 10;
                int denominator = 0;
                
                // This will throw DivideByZeroException
                Console.WriteLine("Attempting to divide by zero...");
                int result = numerator / denominator;
                
                // This line won't execute
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                // Catch specific exception
                Console.WriteLine($"Caught DivideByZeroException: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Catch any other exceptions
                Console.WriteLine($"Caught generic Exception: {ex.Message}");
            }
            finally
            {
                // Always executes, regardless of exception
                Console.WriteLine("Finally block executed - cleanup code goes here");
            }
            
            // Throwing an exception
            Console.WriteLine("\nDemonstrating throw keyword:");
            try
            {
                ValidateAge(-5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Validation error: {ex.Message}");
            }
        }
        
        static void ValidateAge(int age)
        {
            if (age < 0)
            {
                // throw keyword creates an exception
                throw new ArgumentException("Age cannot be negative");
            }
            
            Console.WriteLine($"Age {age} is valid");
        }
        #endregion

        #region 6. Parameter Keywords
        static void DemoParameterKeywords()
        {
            Console.WriteLine("=== Parameter Keywords ===\n");
            
            // ref keyword - pass by reference
            Console.WriteLine("--- ref keyword ---");
            int number = 10;
            Console.WriteLine($"Before ModifyValue: {number}");
            ModifyValue(ref number);
            Console.WriteLine($"After ModifyValue: {number}");
            
            // out keyword - output parameter
            Console.WriteLine("\n--- out keyword ---");
            int quotient, remainder;
            Divide(10, 3, out quotient, out remainder);
            Console.WriteLine($"10 ÷ 3 = {quotient} remainder {remainder}");
            
            // C# 7+ allows out variable declaration in method call
            if (int.TryParse("42", out int result))
            {
                Console.WriteLine($"Parsed value: {result}");
            }
            
            // in keyword - read-only reference
            Console.WriteLine("\n--- in keyword ---");
            Point3D point = new Point3D(10, 20, 30);
            Console.WriteLine($"Distance from origin: {CalculateDistance(in point)}");
            
            // params keyword - variable number of arguments
            Console.WriteLine("\n--- params keyword ---");
            int sum1 = Sum(1, 2);
            int sum2 = Sum(1, 2, 3, 4, 5);
            Console.WriteLine($"Sum of 2 numbers: {sum1}");
            Console.WriteLine($"Sum of 5 numbers: {sum2}");
        }
        
        static void ModifyValue(ref int value)
        {
            value *= 2; // Changes the original variable
        }
        
        static void Divide(int dividend, int divisor, out int quotient, out int remainder)
        {
            quotient = dividend / divisor;
            remainder = dividend % divisor;
        }
        
        struct Point3D
        {
            public int X { get; }
            public int Y { get; }
            public int Z { get; }
            
            public Point3D(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }
        
        static double CalculateDistance(in Point3D point)
        {
            // 'in' ensures we don't modify the point (read-only reference)
            // point = new Point3D(0, 0, 0); // This would cause compiler error
            
            return Math.Sqrt(point.X * point.X + point.Y * point.Y + point.Z * point.Z);
        }
        
        static int Sum(params int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            return sum;
        }
        #endregion

        #region 7. Async/Await Keywords
        static async Task AsyncDemo()
        {
            Console.WriteLine("=== Async/Await Keywords ===\n");
            
            Console.WriteLine("Starting asynchronous operations...");
            
            // Task.Delay simulates an asynchronous operation like network call
            await Task.Delay(1000);
            Console.WriteLine("First operation completed after 1 second");
            
            // We can await multiple tasks
            Task task1 = SimulateWorkAsync("Task 1", 2);
            Task task2 = SimulateWorkAsync("Task 2", 3);
            
            // Wait for both tasks to complete
            await Task.WhenAll(task1, task2);
            
            // Get result from async function
            int result = await CalculateAsync(5);
            Console.WriteLine($"Calculation result: {result}");
            
            Console.WriteLine("All async operations completed!");
        }
        
        static async Task SimulateWorkAsync(string taskName, int seconds)
        {
            Console.WriteLine($"{taskName} starting, will take {seconds} seconds...");
            await Task.Delay(seconds * 1000);
            Console.WriteLine($"{taskName} completed after {seconds} seconds");
        }
        
        static async Task<int> CalculateAsync(int input)
        {
            // Simulate CPU-bound work
            await Task.Delay(1000);
            return input * input;
        }
        #endregion

        #region 8. Delegates and Events
        // Define delegate types
        public delegate void SimpleDelegate();
        public delegate int MathOperation(int x, int y);
        public delegate void MessageHandler(string message);
        
        // Event related
        public event MessageHandler MessageReceived;
        
        static void DemoDelegatesAndEvents()
        {
            Console.WriteLine("=== Delegates and Events ===\n");
            
            // 1. Basic delegate
            Console.WriteLine("--- Basic delegate ---");
            SimpleDelegate greetingDelegate = SayHello;
            Console.WriteLine("Invoking delegate:");
            greetingDelegate(); // Calls SayHello()
            
            // Change the method the delegate points to
            greetingDelegate = SayGoodbye;
            Console.WriteLine("Invoking delegate after reassignment:");
            greetingDelegate(); // Calls SayGoodbye()
            
            // 2. Delegate with parameters and return value
            Console.WriteLine("\n--- Delegates with parameters and return values ---");
            MathOperation addDelegate = Add;
            MathOperation subtractDelegate = Subtract;
            
            Console.WriteLine($"Add via delegate: 5 + 3 = {addDelegate(5, 3)}");
            Console.WriteLine($"Subtract via delegate: 10 - 4 = {subtractDelegate(10, 4)}");
            
            // 3. Multicast delegates (delegate chain)
            Console.WriteLine("\n--- Multicast delegates ---");
            SimpleDelegate multiDelegate = SayHello;
            multiDelegate += SayGoodbye; // Add another method
            multiDelegate += () => Console.WriteLine("Anonymous method in delegate chain");
            
            Console.WriteLine("Invoking multicast delegate (calls all methods in chain):");
            multiDelegate();
            
            // 4. Anonymous methods
            Console.WriteLine("\n--- Anonymous methods ---");
            SimpleDelegate anonymousDelegate = delegate()
            {
                Console.WriteLine("This is an anonymous method");
            };
            anonymousDelegate();
            
            // 5. Lambda expressions
            Console.WriteLine("\n--- Lambda expressions ---");
            
            // Simple lambda with no parameters
            SimpleDelegate lambdaDelegate = () => Console.WriteLine("Lambda expression with no parameters");
            lambdaDelegate();
            
            // Lambda with parameters and return value
            MathOperation multiplyDelegate = (x, y) => x * y;
            Console.WriteLine($"Multiply via lambda: 6 * 7 = {multiplyDelegate(6, 7)}");
            
            // Lambda with multiple statements
            MathOperation complexDelegate = (x, y) =>
            {
                Console.WriteLine($"Calculating power of {x} to {y}...");
                return (int)Math.Pow(x, y);
            };
            Console.WriteLine($"Power via lambda: 2^3 = {complexDelegate(2, 3)}");
            
            // 6. Action and Func delegates
            Console.WriteLine("\n--- Action and Func delegates ---");
            
            // Action - delegate with void return type
            Action simpleAction = () => Console.WriteLine("Simple Action delegate (no parameters)");
            simpleAction();
            
            Action<string> printAction = message => Console.WriteLine($"Message: {message}");
            printAction("Hello via Action delegate");
            
            // Func - delegate with return type
            Func<int, int, int> divideFunc = (x, y) => x / y;
            Console.WriteLine($"Divide via Func delegate: 20 / 4 = {divideFunc(20, 4)}");
            
            Func<string, int> stringLengthFunc = str => str.Length;
            Console.WriteLine($"Length of 'Hello' via Func: {stringLengthFunc("Hello")}");
            
            // 7. Events
            Console.WriteLine("\n--- Events ---");
            
            // Create instance of Program to use instance events
            Program program = new Program();
            
            // Subscribe to the event
            program.MessageReceived += HandleMessage;
            program.MessageReceived += msg => Console.WriteLine($"Lambda handler received: {msg}");
            
            // Raise the event
            Console.WriteLine("Raising the MessageReceived event:");
            program.OnMessageReceived("Hello, events world!");
            
            // Unsubscribe from event
            program.MessageReceived -= HandleMessage;
            Console.WriteLine("\nAfter unsubscribing one handler:");
            program.OnMessageReceived("Second message");
            
            // 8. Predicate delegate
            Console.WriteLine("\n--- Predicate delegate ---");
            Predicate<int> isEven = num => num % 2 == 0;
            Console.WriteLine($"Is 4 even? {isEven(4)}");
            Console.WriteLine($"Is 5 even? {isEven(5)}");
            
            // Using predicate with list
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> evenNumbers = numbers.FindAll(isEven);
            Console.WriteLine($"Even numbers: {string.Join(", ", evenNumbers)}");
        }
        
        // Method to raise the event
        private void OnMessageReceived(string message)
        {
            // Check if there are any subscribers
            MessageHandler handler = MessageReceived;
            if (handler != null)
            {
                handler(message);
            }
            
            // C# 6.0+ null conditional operator alternative:
            // MessageReceived?.Invoke(message);
        }
        
        // Event handler method
        private static void HandleMessage(string message)
        {
            Console.WriteLine($"Handler received: {message}");
        }
        
        // Methods for use with delegates
        private static void SayHello()
        {
            Console.WriteLine("Hello, World!");
        }
        
        private static void SayGoodbye()
        {
            Console.WriteLine("Goodbye!");
        }
        
        private static int Add(int a, int b)
        {
            return a + b;
        }
        
        private static int Subtract(int a, int b)
        {
            return a - b;
        }
        #endregion
    }
}
