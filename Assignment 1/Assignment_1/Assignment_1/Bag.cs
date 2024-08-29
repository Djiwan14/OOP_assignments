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
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using TextFile;

namespace Assignment_1
{
    public class Bag
    {
        public class NegativeBorderException : Exception { } // when the upper border for the Bag is less than 0|
        public class InvalidEntryException : Exception { } // when the Entry is not in the interval [0 .. border]|
        public class EmptyBagException : Exception { } // when getting LargestFrequency the bag is empty|
        public class NotNumberException : Exception { } // when entered number is not integer|
        public class NumberNotFoundException : Exception { } // when number user trying to reach is not in the bag|

        //Representation of bag (attributes)|
        private int largestValue; // The largest value in the bag| 
        private int[] nums; // Array which will collect the numbers in it|

        public Bag(int border) 
        {
            // Constructor to initialize new bag with the exception of negative border|
            if (border < 0)
            {
                throw new NegativeBorderException();
            }
            nums = new int[border + 1];
            for (int i = 0; i <= border; i++)
            {
                nums[i] = 0;
            }
            this.largestValue = 0;
        }

        // 1. Operation in the menu|
        public void PrintAllElements()
        {
            // Printing all elements of the bag|
            Console.Write("Elements of the bag: ");
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Sets the text color to green|
                    Console.Write(i + " ");
                    Console.ResetColor(); // Resets to the default color|
                }
            }
            Console.WriteLine();
        }

        // 2. Operation in the menu| 
        public void InsertValue(int num)
        {
            // This method is for inserting new num into the bag with InvalidEntryException that won't let incorrect value in the bag|
            if (num >= nums.Length || num < 0)
            {
                throw new InvalidEntryException();
            }

            // Increment the count for the given num in nums array|
            nums[num] = nums[num] + 1;

            // Updating the largetValue in the bag with the help of helper function after inserting new num|
            if (num > largestValue) { UpdateLargestNumber(); }
        }

        // 3. Operation in the menu|
        public void RemoveValue(int num)
        {
            // This method for removing selected num from the bag with InvalidEntryException that won't let incorrect value to be processed|
            if (num < 0 || num >= nums.Length)
            {
                throw new InvalidEntryException();
            }

            // This method is to check if the bag, we are trying to remove from, is empty|
            if (largestValue == 0)
            {
                throw new EmptyBagException();
            }

            // Decrement the frequency of num if it is in the bag|
            if (nums[num] > 0)
            {
                nums[num]--;
                
                // Updating the largetValue in the bag with the help of helper function after removal method|
                if (num == largestValue && nums[num] == 0)
                {
                    UpdateLargestNumber();
                }
            }
            else
            {
                throw new InvalidEntryException(); // This exception won't let process num that is not in the bag|
            }
        }

        // 4. Operation in the menu|
        public int GetFrequencyOfGivenElement(int num)
        {
            // This method is to check if the bag we trying to get the frequency of given element is empty|
            if (largestValue == 0)
            {
                throw new EmptyBagException();
            }

            // This method will check the frequency of the requested num and will return it if it is in the bag, otherwise Exception will be triggered|
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == num && nums[i] > 0)
                {
                    return nums[i];
                }
            }
            throw new NumberNotFoundException();
        }

        // 5. Operation in the menu|
        public int GetLargest()
        {
            // If the largest value is still 0, that means Bag is still empty|
            if (largestValue == 0)
            {
                throw new EmptyBagException();
            }
            return largestValue;
        }

        // Helper functions for testing|
        public bool IsNumberIn(int num)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == num && nums[i] > 0)
                {
                    return true;
                }
            }
            return false;
        }
        // Helper function for updating largest number in the bag|
        private int UpdateLargestNumber()
        {
            largestValue = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0 && i > largestValue)
                {
                    largestValue = i;
                }
            }
            return largestValue;
        }
    }
}