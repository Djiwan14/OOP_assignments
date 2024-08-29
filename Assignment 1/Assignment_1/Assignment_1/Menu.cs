// Assignment: 1

// Name: Shokhrukh Nigmatillaev

// Neptun code: APVAVZ

// Task 10

/*
 Description:     10. Implement the bag type which contains integers. Represent the bag as a sequence of 
                  (element, frequency) pairs. Implement as methods: inserting an element, removing an 
                  element, returning the frequency of an element, returning the largest element in the bag 
                  (suggestion: store the largest element and update it when the bag changes), printing the 
                  bag. Lecture code cannot be submitted
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TextFile;
using static Assignment_1.Bag;

namespace Assignment_1
{
    public class Menu
    {
        private Bag bag;
        private int border;
        public Menu()
        {
            bool invalidFileName = true;

            while (invalidFileName)
            {
                try
                {
                    Console.Write("What is the name of your file? ");
                    string nameOfFile = Console.ReadLine();
                    TextFileReader reader = new TextFileReader(nameOfFile);
                    reader.ReadInt(out this.border);
                    this.bag = new Bag(this.border);
                    while (reader.ReadInt(out int e))
                    {
                        bag.InsertValue(e);
                    }

                    // If everything succeeds, set invalidInputFile to false to exit the loop|
                    invalidFileName = false;
                }
                catch (NegativeBorderException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your border can't be negative. Try again!");
                    Console.ResetColor();
                    // Setting invalidInputFile to true ensures the loop continues and the user is prompted again|
                    invalidFileName = true;
                }
                catch (System.IO.FileNotFoundException)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Sets the text color to red|
                    Console.WriteLine("The file you are trying to reach does not exist. Try again!");
                    Console.ResetColor(); // Resets to the default color|
                    invalidFileName = true;
                }
            }
        }



        public string MenuDisplay()
        {
            // Method for displaying menu in the program|
            string chosenAction;
            Console.WriteLine("Hi user. Greetings from control center of Bag! Please act according to the number and description!");
            Console.WriteLine("1. Please press 1 to print the bag. ");
            Console.WriteLine("2. Please press 2 to Insert an element inth the bag. ");
            Console.WriteLine("3. Please press 3 to Remove an element from the bag. ");
            Console.WriteLine("4. Please press 4 to Return the Frequency of an element. ");
            Console.WriteLine("5. Please press 5 to return the Largest element of the bag. ");
            Console.WriteLine("0. Please press 0 to quit the program.");
            Console.Write("Please enter the operation's number: ");
            chosenAction = Console.ReadLine();
            return chosenAction;
        }
        
        //1. Operation in the menu|
        public void PrintAll()
        {
            bag.PrintAllElements();
        }

        //2. Operation in the menu|
        public void Insert()
        {
            try
            {
                Console.WriteLine("Please type number you would like to insert into the bag.");
                Console.Write($"Remember your number should be in [0 .. {border}]: ");
                string newEntryAsString = Console.ReadLine();
                bool positive = int.TryParse(newEntryAsString, out int newEntry);
                if (positive)
                {
                    bag.InsertValue(newEntry);
                    Console.ForegroundColor = ConsoleColor.Green; // Sets the text color to green|
                    Console.WriteLine($"{newEntry} is inserted!");
                    Console.ResetColor();
                }
                else
                {
                    throw new NotNumberException();
                }
            }
            catch (InvalidEntryException)
            {
                Console.ForegroundColor = ConsoleColor.Red; // Sets the text color to red|
                Console.WriteLine("You are trying to insert/remove invalid entry. Try again!");
                Console.ResetColor(); // Resets to the default color|
            }
            catch(NotNumberException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The input element is not a number. Try again!");
                Console.ResetColor();
            }
        }

        //3. Operation in the menu|
        public void Remove()
        {
            try
            {
                Console.WriteLine("Please type number you would like to remove from the bag.");
                Console.Write($"Remember your number should be in [0 .. {border}]: ");
                string removeEntryAsString = Console.ReadLine();
                bool successful = int.TryParse(removeEntryAsString, out int removeEntry);
                if (successful)
                {
                    bag.RemoveValue(removeEntry);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{removeEntry} is removed!");
                    Console.ResetColor();
                }
                else
                {
                    throw new NotNumberException();
                }
            }
            catch (InvalidEntryException)
            {
                Console.ForegroundColor = ConsoleColor.Red; // Sets the text color to red|
                Console.WriteLine("You are trying to insert/remove invalid entry. Try again!");
                Console.ResetColor(); // Resets to the default color|
            }
            catch (NotNumberException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The input element is not a number. Try again!");
                Console.ResetColor();
            }
            catch (EmptyBagException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your bag is empty. Try again!");
                Console.ResetColor();
            }
        }
        
        // 4. Operation in the menu|
        public void GetFrequency()
        {
            try
            {
                Console.Write("Please type the frequency of which number you would like to see: ");
                string elementAsString = Console.ReadLine();
                bool victory = int.TryParse(elementAsString, out int element);
                if (victory)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The element {element} occurs in the bag {bag.GetFrequencyOfGivenElement(element)} time(s)!");
                    Console.ResetColor();
                }
                else
                {
                    throw new NotNumberException();
                }
            }
            catch (NumberNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your input is not found. Try again!");
                Console.ResetColor();
            }
            catch (NotNumberException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The input element is not a number. Try again!");
                Console.ResetColor();
            }
            catch (EmptyBagException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your bag is empty. Try again!");
                Console.ResetColor();
            }
        }
        
        // 5. Operation in the menu|
        public void Largest()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The largest element in our bag is {bag.GetLargest()}");
                Console.ResetColor();
            }
            catch (EmptyBagException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your bag is empty. Try again!");
                Console.ResetColor();
            }
        }

        // Choosing action and running program with all interaction methods of Bag|
        public void RunProgramm()
        {
            string chosenAction;
            do
            {
                chosenAction = MenuDisplay();
                switch (chosenAction)
                {
                    case "0":
                        Console.WriteLine("You quit the program. Bye!");
                        break;
                    case "1":
                        PrintAll();
                        break;
                    case "2":
                        Insert();
                        break;
                    case "3":
                        Remove();
                        break;
                    case "4":
                        GetFrequency();
                        break;
                    case "5":
                        Largest();
                        break;
                    default:
                        Console.WriteLine("Try again!");
                        break;
                }
            } while (!chosenAction.Equals("0"));
            }
        }
    }
