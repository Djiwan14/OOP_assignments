/*
    Name: Shokhrukh Nigmatillaev
    
    Neptun : apvavz

    Assignment2: Task 9
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public abstract class Animal
    {
        // Exceptions|
        public class NegativeAmountOfAnimalsException : Exception { } // error is being triggered if the number given in the file is negative|
        public class NoSuchAnimalException : Exception { } // error is being triggered if the different type animal is listed in the file|
        public class InvalidExhilarationLevelException : Exception { } // error is being triggered if the exhilaration level in the file is given out of bounds (0..100]|

        // attributes of Parent class|
        public string animalName { get; private set; }
        public int exhilarationLevel { get; private set; }

        // constructor of a Parent class|
        protected Animal(string animalName, int exhilarationLevel) 
        {
            this.animalName = animalName;
            this.exhilarationLevel = exhilarationLevel;
        }
        
        // methods of Parent class|
        public bool isAlive()
        {
            if(this.exhilarationLevel > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ModifyExhilaration(int number) 
        {
            this.exhilarationLevel += number;
            if(this.exhilarationLevel > 100)
            {
                this.exhilarationLevel = 100;
            }
            else if(this.exhilarationLevel < 0)
            {
                this.exhilarationLevel = 0;
            }
        }
        // abstract method that will be overriden in the child classes that will update Ex level accoring to mood given as a parameter|
        public abstract void updateExhilarationBasedOnMood(IMood mood);
    }
}
