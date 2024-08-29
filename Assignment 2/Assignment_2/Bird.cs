/*
    Name: Shokhrukh Nigmatillaev
    
    Neptun : apvavz

    Assignment2: Task 9
 */
using Assignment_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class Bird : Animal
    {
        // child class of abstract Animal class| 
        public Bird(string animalName, int exhilarationLevel) : base(animalName, exhilarationLevel) 
        {

        }
        public override void updateExhilarationBasedOnMood(IMood mood)
        // we are overriding abstract method from parent class|
        {
            mood.ChangeBirdExhilarationLevel(this);
        }
    }
}
