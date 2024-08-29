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
using NUnit.Framework;
using Assignment_1;
using System;
using NUnit.Framework.Internal;


namespace BagTest.nUnitTests
{
    [TestFixture]
    public class BagTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        //1. Testing if inserted value is in the bag|
        public void InsertValueTest()
        {
            // Assign
            Bag bag = new Bag(5);
            int num = 4;

            // Act
            bag.InsertValue(num);
            
            // Assert
            Assert.That(bag.IsNumberIn(num), Is.True);
        }
        
        //1.1. Testing inserted value that causes InvalidEntryException|
        [Test]
        public void InsertInvalidEntryTest()
        {
            try
            {
                // Assign
                Bag bag = new Bag(5);
                int num = 11;

                // Act
                bag.InsertValue(num);
                Assert.Fail("Exception was not called!");
            }
            catch(Exception ex) 
            {
                // Asserting
                Assert.IsTrue(ex is Bag.InvalidEntryException);
            }
        }

        //1.2 Testing the frequency of inserted value|
        [Test]
        public void FrequencyIncreaseOfInsertedValue()
        {
            // Assign
            Bag bag = new Bag(5);
            int num = 4;
            int insertion = 3;

            // Act
            for (int i = 0; i < insertion; i++)
            {
                bag.InsertValue(num);
            }

            // Assertion
            Assert.AreEqual(bag.GetFrequencyOfGivenElement(num), insertion);
        }
        
        //1.3 Testing if inserted largest value is actually largest in the bag|
        [Test]
        public void GetLargestTest()
        {
            // Assign
            Bag bag = new Bag(11);
            int num1 = 5;
            int num2 = 8;

            // Act
            bag.InsertValue(num1);
            bag.InsertValue(num2);
            
            // Assert
            Assert.AreEqual(num2, bag.GetLargest());
        }

        //2. Testing if the removed value is still in the bag|
        [Test]
        public void RemoveValueTest()
        {
            // Assign
            Bag bag = new Bag(10);
            int num = 5;
            
            // Act
            bag.InsertValue(num);
            bag.RemoveValue(num);
            
            // Assert
            Assert.That(bag.IsNumberIn(num), Is.False);
        }

        //2.1. Testing removed value that causes InvalidEntryException|
        [Test]
        public void RemoveInvalidEntryTest()
        {
            try
            {
                // Assign
                Bag bag = new Bag(5);

                // Act
                bag.RemoveValue(11);
                Assert.Fail("Exception was not called!");
            }
            catch (Exception ex)
            {
                // Asserting
                Assert.IsTrue(ex is Bag.InvalidEntryException);
            }
        }

        //2.2 Testing RemovedValue that reduces the frequency of the num in the bag|
        [Test]
        public void FrequencyReducedOfRemovedValueTest()
        {
            // Assign
            Bag bag = new Bag(5);
            int num = 4;
            int insertion = 3;
            // Act
            for (int i = 0; i < insertion; i++)
            {
                bag.InsertValue(num);
            }
            bag.RemoveValue(num);
            // Assertion
            Assert.AreEqual(bag.GetFrequencyOfGivenElement(num), insertion - 1);
        }

        //2.3 Testing if RemoveValue removes and updates largest num in the Bag|
        [Test]
        public void RemoveValueLargestUpdate()
        {
            // Assign
            Bag bag = new Bag(10);
            int num1 = 5;
            int num2 = 9;

            // Act
            bag.InsertValue(num1);
            bag.InsertValue(num2);
            bag.RemoveValue(num2);

            // Assert
            Assert.AreEqual(bag.GetLargest(), num1);
        }


        //3. Testing the frequency of the given num|
        [Test]
        public void GetFrequencyOfGivenElement()
        {
            // Assign
            Bag bag = new Bag(10);
            int num = 7;

            // Act
            bag.InsertValue(num);
            bag.InsertValue(num);

            // Assert
            Assert.AreEqual(bag.GetFrequencyOfGivenElement(num), 2);
        }

        // 3.1 Testing frequency of the given num in the empty bag|
        [Test]
        public void GetFrequencyOfGivenElementInEmptyBag()
        {
            try
            {
                // Assign 
                Bag bag = new Bag(0);
                int num = 4;

                // Act
                bag.GetFrequencyOfGivenElement(num);
                Assert.Fail("Exception was not called!");
            }
            catch (Exception ex)
            {
                // Asserting
                Assert.IsTrue(ex is Bag.EmptyBagException);
            }
        }

        // 4. Testing getting the largest number from the bag|
        [Test]
        public void TestGetLargest()
        {
            //Assign
            Bag bag = new Bag(10);
            int[] els = { 4, 8, 6 };

            //Act
            for(int i = 0; i < els.Length; i++)
            {
                bag.InsertValue(els[i]);
            }

            //Assert
            Assert.AreEqual(8, bag.GetLargest());
        }

        // 4.1 Testing the largest number in the empty bag|
        [Test]
        public void TestGetLargestFromEmptyBag()
        {
            try
            {
                // Assign 
                Bag bag = new Bag(0);

                // Act
                bag.GetLargest();
                Assert.Fail("Exception was not called!");
            }
            catch (Exception ex)
            {
                // Asserting
                Assert.IsTrue(ex is Bag.EmptyBagException);
            }
        }
    }
}

