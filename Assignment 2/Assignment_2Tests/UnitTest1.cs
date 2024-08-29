/*
    Name: Shokhrukh Nigmatillaev
    
    Neptun : apvavz

    Assignment2: Task 9
 */
using Assignment_2;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using TextFile;
namespace Assignment_2Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        //1.1 We check if the updateExhilarationBasedOnMood method works fine for all animals with all moods|
        //Good: fish += 1; bird += 2; dog += 3|
        //Ordinary: fish += -3; bird += -1|
        //Bad: fish += -5; bird += -3; dog += -10|
        public void updateExhilarationBasedOnMoodTest()
        {
            // Assign
            Fish fish = new Fish("Sharki", 50);
            Bird bird = new Bird("Bird1", 50);
            Dog dog = new Dog("Sitka", 50);
            IMood good = Good.Instance();
            IMood ordinary = Ordinary.Instance();
            IMood bad = Bad.Instance();


            // Act
            fish.updateExhilarationBasedOnMood(good);
            bird.updateExhilarationBasedOnMood(good);
            dog.updateExhilarationBasedOnMood(good);

            fish.updateExhilarationBasedOnMood(ordinary);
            bird.updateExhilarationBasedOnMood(ordinary);
            dog.updateExhilarationBasedOnMood(ordinary);

            fish.updateExhilarationBasedOnMood(bad);
            bird.updateExhilarationBasedOnMood(bad);
            dog.updateExhilarationBasedOnMood(bad);

            // Assert
            Assert.AreEqual(fish.exhilarationLevel, 43);
            Assert.AreEqual(bird.exhilarationLevel, 48);
            Assert.AreEqual(dog.exhilarationLevel, 43);
        }

        [Test]
        //2. We check if given animals are alive. Checking if their exhilarationLevel is greater than 0|
        public void isAliveTest()
        {
            // Assign
            Fish fish = new Fish("MagiCarp", 50);
            Bird bird = new Bird("AngryBird", 0);
            Dog dog = new Dog("Rokki", 12);


            // Act
            fish.isAlive();
            bird.isAlive();
            dog.isAlive();


            // Assert
            Assert.IsTrue(fish.isAlive());
            Assert.IsFalse(bird.isAlive());
            Assert.IsTrue(dog.isAlive());
        }

        //3. We check if triggered negativeAmountOfAnimals works passes test case|
        [Test]
        public void NegativeAmountOfAnimalsExceptionTest()
        {
            try
            {
                // Assign 
                TextFileReader reader = new("negativeAmountOfAnimals.txt");

                reader.ReadLine(out string line);
                int n = int.Parse(line);
                Simulation cathy = new Simulation();

                // Act
                cathy.CheckIfNIsNegative(n);
                Assert.Fail("Error was found!");
            }
            catch (Exception ex)
            {
                // Asserting
                Assert.IsTrue(ex is Animal.NegativeAmountOfAnimalsException);
            }
        }
        //4. Checking if the exhilarationLevel of animal in the file was given correctly|
        [Test]
        public void ChechIfExLevelOfAnimalIsNegativeTest()
        {
            try
            {
                // Assign 
                TextFileReader reader = new("negativeAmountOfAnimals.txt");
                Simulation cathy = new Simulation();
                reader.ReadLine(out string line);
                int n = int.Parse(line);
                List<Animal> animals = new();
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


                        // Act
                        cathy.CheckIfExLevelOfAnimalIsNegative(n);
                        Assert.Fail("Exception");
                    }
                }
            }
            catch (Exception ex)
            {
                // Asserting
                Assert.IsTrue(ex is Animal.InvalidExhilarationLevelException);
            }
        }
        [Test]
        //5. Checking method that improves mood Good -> Good, Ordinary -> Good, Bad -> Ordinary|
        public void MoodImprovementTest()
        {
            // Assign
            IMood moodB = Bad.Instance();
            IMood moodO = Ordinary.Instance();
            IMood moodG = Good.Instance();

           
            // Act
            moodB.MoodImprovement();
            moodO.MoodImprovement();
            moodG.MoodImprovement();


            // Assert
            Assert.AreEqual(moodB.MoodImprovement(), Ordinary.Instance());
            Assert.AreEqual(moodO.MoodImprovement(), Good.Instance());
            Assert.AreEqual(moodG.MoodImprovement(), Good.Instance());
        }
    }
}