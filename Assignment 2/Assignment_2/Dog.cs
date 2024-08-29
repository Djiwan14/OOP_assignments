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
    public class Dog : Animal
    {
        //child class of abstract Animal class|
        public Dog(string animalName, int exhilarationLevel) : base(animalName, exhilarationLevel) 
        {

        }
        public override void updateExhilarationBasedOnMood(IMood mood)
        // we are overriding abstract method from parent class|
        {
            mood.ChangeDogExhilarationLevel(this);
        }
    }
}
