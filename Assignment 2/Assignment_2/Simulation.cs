/*
    Name: Shokhrukh Nigmatillaev
    
    Neptun : apvavz

    Assignment2: Task 9
*/
using System;
using System.Collections.Generic;
using TextFile;

namespace Assignment_2
{
    public class Simulation 
    {
        // we create List of Animal type to store animals in it|
        public List<Animal> animals = new List<Animal>();
        public void RunSimulation(string fileName) // run simulation
        {
            TextFileReader reader = new TextFileReader(fileName);
            reader.ReadLine(out string line);
            int n = int.Parse(line);

            // we throw error if the number in the given file is negative|
            CheckIfNIsNegative(n);

            for (int i = 0; i < n; ++i)
            {
                char[] separators = new char[] { ' ', '\t' };
                Animal animal = null;

                if (reader.ReadLine(out line))
                {
                    string[] parts = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    char letter = char.Parse(parts[0]);
                    string animalName = parts[1];
                    int exhilarationLevel = int.Parse(parts[2]);

                    // we throw error if the exhilaration level in the given file is out of bounds (0..100]|
                    CheckIfExLevelOfAnimalIsNegative(exhilarationLevel);


                    switch (letter)
                    {
                        case 'F':
                            animal = new Fish(animalName, exhilarationLevel);
                            break;
                        case 'B':
                            animal = new Bird(animalName, exhilarationLevel);
                            break;
                        case 'D':
                            animal = new Dog(animalName, exhilarationLevel);
                            break;
                        default:
                            // if the wrong letter is given in the file, then error is being triggered|
                            throw new Animal.NoSuchAnimalException();
                    }
                }
                animals.Add(animal);
            }

            // we read the last line where moods of Cathy are enumerated by a list of characters|
            reader.ReadLine(out line);
            string moods = line;

            bool areAllAnimalsExhilarationLevelMoreThan5 = false;
            for (int j = 0; j < moods.Length; ++j)
            {
                char c = moods[j];
                IMood mood = null;
                switch (c)
                {
                    case 'g':
                        mood = Good.Instance();
                        break;
                    case 'o':
                        mood = Ordinary.Instance();
                        break;
                    case 'b':
                        mood = Bad.Instance();
                        break;
                    default:
                        // if there is any other letter(mood) error gets triggered|
                        throw new IMood.NoSuchMoodException();
                }

                if (areAllAnimalsExhilarationLevelMoreThan5)
                // if all animals' exhilarationLevel is greater than 5, mood of Cathy improves|
                {
                    mood = mood.MoodImprovement();
                }

                areAllAnimalsExhilarationLevelMoreThan5 = true;
                for (int i = 0; i < animals.Count; i++)
                {
                    if (animals[i].isAlive())
                    {
                        animals[i].updateExhilarationBasedOnMood(mood);
                        if (animals[i].isAlive() && animals[i].exhilarationLevel < 5)
                        {
                            // if animal is still alive and exhilarationLevel of it is less than 5, we turn areAllAnimalsExhilarationLevelMoreThan5|
                            // to false, so MoodImprovement does not get triggered|
                            areAllAnimalsExhilarationLevelMoreThan5 = false;
                        }
                    }
                }
            }
        }

        public void PrintAnimalsWithLeastExhilarationLevel()
        {
            // in the implmentation of this method Minimum search algorithmic pattern was used|
            // using minimum search we add Animals to the List, if we find animal with even less exhilarationLevl we clear the list and then add new animal into it|
            List<Animal> animalsWithLeastExhilarationLevel = new List<Animal>();
            int minimumExhilarationLevel = 100;
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].isAlive())
                {
                    if (animals[i].exhilarationLevel > minimumExhilarationLevel)
                    {
                        continue;
                    }
                    else if (animals[i].exhilarationLevel == minimumExhilarationLevel)
                    {
                        animalsWithLeastExhilarationLevel.Add(animals[i]);
                    }
                    else if (animals[i].exhilarationLevel < minimumExhilarationLevel)
                    {
                        animalsWithLeastExhilarationLevel.Clear();
                        animalsWithLeastExhilarationLevel.Add(animals[i]);
                        minimumExhilarationLevel = animals[i].exhilarationLevel;
                    }
                }
            }
            for (int i = 0; i < animalsWithLeastExhilarationLevel.Count; i++)
            {
                // after all finished we print all elements' animalName attributes of List containing Animal class objects|
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(animalsWithLeastExhilarationLevel[i].animalName);
                Console.ResetColor();
            }
        }

        // helper function for implementation of test cases|
        public void CheckIfNIsNegative(int n)
        {
            if (n < 0)
            {
                throw new Animal.NegativeAmountOfAnimalsException();
            }
        }
        // helper function for implementation of test cases|
        public void CheckIfExLevelOfAnimalIsNegative(int exhilarationLevel)
        {
            if (exhilarationLevel < 0 || exhilarationLevel > 100)
            {
                throw new Animal.InvalidExhilarationLevelException();
            }
        }

    }
}
