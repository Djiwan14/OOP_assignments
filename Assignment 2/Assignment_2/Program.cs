/*
    Name: Shokhrukh Nigmatillaev
    
    Neptun : apvavz

    Assignment2: Task 9

Hobby animals need several things to preserve their exhilaration. Cathy has some hobby animals: 

fishes, birds and dogs. 

Every animal has a name and their exhilaration level is between 0 and 100 (0 means that the animal sdies). 

If their keeper is in a good mood, she takes care of everything to cheer up her animals, and their exhilaration
level increases: of the fishes by 1, of the birds by 2, and of the dogs by 3.

On an ordinary day, Cathy takes care of only the dogs (their exhilaration level does not change), so the exhilaration
level of the rest decreases: of the fishes by 3, of the birds by 1. 

On a bad day, every animal becomes a bit sadder and their exhilaration level decreases: of the fishes by 5, of the birds by 3, and of the dogs by 10.

Cathy’s mood improves by one if the exhilaration level of every alive animal is at least 5.

Every data is stored in a text file. The first line contains the number of animals. Each of the following lines contain
the data of one animal: one character for the type (F – Fish, B – Bird, D – Dog), name of the animal (one word), and the initial level of exhilaration.
In the last line, the daily moods of Cathy are enumerated by a list of characters (g – good, o – ordinary, b – bad).
The file is assumed to be correct.

Name the animal of the lowest level of exhilaration which is still alive at the end of the simulation. If there are
more, name all of them!
 */
using TextFile;
using static Assignment_2.Animal;

using System;
using System.IO;

namespace Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // we take the name of the file by input from user|
                Console.WriteLine("This is assignment 9. Insert filename please to run the program!");
                string fileName = Console.ReadLine();

                Simulation cathy = new Simulation();
                cathy.RunSimulation(fileName);
                cathy.PrintAnimalsWithLeastExhilarationLevel();
            }
            catch (Animal.NegativeAmountOfAnimalsException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Animal amount cannot be negative, file is corrupted!");
                Console.ResetColor();
            }
            catch (Animal.InvalidExhilarationLevelException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Given exhilaration level in the file is invalid!");
                Console.ResetColor();
            }
            catch (IMood.NoSuchMoodException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No such mood is found in the file!");
                Console.ResetColor();
            }
            catch (Animal.NoSuchAnimalException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No such animal is found in the file!");
                Console.ResetColor();
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File not found! Please try to insert another file!");
                Console.ResetColor();
            }
        }
    }
}
