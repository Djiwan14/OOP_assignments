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
    public interface IMood
    // interface for moods of animals|
    {
        void ChangeFishExhilarationLevel(Fish fish);
        void ChangeBirdExhilarationLevel(Bird bird);
        void ChangeDogExhilarationLevel(Dog dog);
        IMood MoodImprovement();
        // error is being triggered if the mood given in the file is invalid|
        public class NoSuchMoodException : Exception { }
    }

    public class Good : IMood
    // child class inherited from interface overriding all its methods|
    {
        public void ChangeFishExhilarationLevel(Fish fish)
        {
            fish.ModifyExhilaration(1);
        }

        public void ChangeBirdExhilarationLevel(Bird bird)
        {
            bird.ModifyExhilaration(2);
        }

        public void ChangeDogExhilarationLevel(Dog dog)
        {
            dog.ModifyExhilaration(3);
        }
        // singleton design pattern which allows us to create only one object and then only returning it avoiding creation of multiple objects|
        private Good() { }

        private static Good instance = null;
        public static Good Instance()
        {
            if (instance == null)
            {
                instance = new Good();
            }
            return instance;
        }
        public IMood MoodImprovement()
        // method that will be used if animals' exhilarationLevel goes to at least 5|
        {
            // Good mood is the best mood, cannot get improved|
            return this;
        }
    }

    public class Ordinary : IMood
    // child class inherited from interface overriding all its methods|
    {
        public void ChangeFishExhilarationLevel(Fish fish)
        {
            fish.ModifyExhilaration(-3);
        }

        public void ChangeBirdExhilarationLevel(Bird bird)
        {
            bird.ModifyExhilaration(-1);
        }

        public void ChangeDogExhilarationLevel(Dog dog)
        {
            dog.ModifyExhilaration(0);
        }
        // singleton design pattern which allows us to create only one object and then only returning it avoiding creation of multiple objects|
        private Ordinary() { }

        private static Ordinary instance = null;

        public static Ordinary Instance()
        {
            if (instance == null)
            {
                instance = new Ordinary();
            }
            return instance;
        }
        public IMood MoodImprovement()
        // method that will be used if animals' exhilarationLevel goes to at least 5|

        {
            // Ordinary mood can get improved to Good|
            return Good.Instance();
        }
    }

    public class Bad : IMood
    // child class inherited from interface overriding all its methods|
    {
        public void ChangeFishExhilarationLevel(Fish fish)
        {
            fish.ModifyExhilaration(-5);
        }

        public void ChangeBirdExhilarationLevel(Bird bird)
        {
            bird.ModifyExhilaration(-3);
        }

        public void ChangeDogExhilarationLevel(Dog dog)
        {
            dog.ModifyExhilaration(-10);
        }
        // singleton design pattern which allows us to create only one object and then only returning it avoiding creation of multiple objects|
        private Bad() { }

        private static Bad instance = null;
        public static Bad Instance()
        {
            if (instance == null)
            {
                instance = new Bad();
            }
            return instance;
        }
        public IMood MoodImprovement()
        // method that will be used if animals' exhilarationLevel goes to at least 5|
        {
            // Bad mood might get improved to Ordinary|
            return Ordinary.Instance();
        }
    }
}