using System;
using System.Collections.Generic;

namespace Jones_James_CE06
{
    class Program
    {
        static void Main(string[] args)
        {
            /* James M. Jones
             * 03/19/2021
             * DEV2000-O 02: Introduction to Development II
             * 2.6 Code Exercise 06: Synthesis
             */

            //First, I want to greet the user and explain what the program is
            //and what the programs purpose is.
            Console.WriteLine("Hello and welcome to the Loan Tracker!");

            Console.WriteLine("\r\nThis program will help you keep track on the total amount each of your friends owes you.");

            Console.WriteLine("\r\nHow many friends owe you money?");

            //Next, I need to create a Dictionary that will hold List values.
            Dictionary<string, List<decimal>> friendsThatOwe = new Dictionary<string, List<decimal>>();

            //I need a variable to store the friend's name in.
            string friendName;

            //I need a decimal variable for the amount the friend borrowed.
            string amountFriendBorrowedString;

            //I need a variable that will listen for the user's input for the number of friends that owe money.
            string numFriendsString = Console.ReadLine();

            //Next, I need to convert this string variable to a whole number value.
            int numFriends;

            //I also want to validate this ReadLine(); to only accept positive whole numbers.
            while (!int.TryParse(numFriendsString, out numFriends) || numFriends < 0)
            {
                //Tell the user the error
                Console.WriteLine("Please only type in positive whole number values.");

                //Re-state the question
                Console.WriteLine("\r\nHow many friends owe you money?");

                //Re-prompt the user
                numFriendsString = Console.ReadLine();
            }

            //Next, I want to use a for loop to allow the user to input the names of the friends that owe money and add them to the dictionary.
            for (int i = 0; i < numFriends; i++)
            {
                Console.WriteLine("Please type in your Friend #{0}", i + 1);

                friendName = Console.ReadLine();

                //use a while loop to validate that it is not left blank.
                while (string.IsNullOrWhiteSpace(friendName))
                {
                    //Tell the user the error
                    Console.WriteLine("Please do not leave this blank.");

                    //Re-state the question
                    Console.WriteLine("Please type in the name of friend #{0}", i + 1);

                    //Re-prompt the user
                    friendName = Console.ReadLine();
                }

                ////// you need to add the key and create your empty list here
                ///
                //  myDictionary.Add(friendName, new List<decimal>()); 
                ///////////

                friendsThatOwe.Add(friendName, new List<decimal>());

                //I need a variable that keeps the loop going
                //As long as the user wants to add another amount the friend owes.
                string anotherValue = "yes";

                while (anotherValue.ToLower() == "yes")
                {
                    //Prompt for the amount the friend owes
                    Console.WriteLine("\r\nHow much did {0} borrow from you?", friendName);

                    amountFriendBorrowedString = Console.ReadLine();

                    decimal amountFriendBorrowed;

                    while (!decimal.TryParse(amountFriendBorrowedString, out amountFriendBorrowed) || amountFriendBorrowed <= 0)
                    {
                        //Tell the user the error
                        Console.WriteLine("Please only type in positive decimal values. This amount must be greater than zero.");

                        //Re-state the question
                        Console.WriteLine("\r\nHow much did {0} borrow from you?", friendName);

                        //Re-prompt the user
                        amountFriendBorrowedString = Console.ReadLine();
                    }

                    //Ask if the friend borrowed another amount
                    Console.WriteLine("\r\nDid {0} borrow another value? (yes or no)", friendName);

                    //Listen for the user's input. This should only be yes or no.
                    anotherValue = Console.ReadLine();

                    ///////
                    // You need to add the owed amount to yuor list here
                    /// myDictionary[friendName].Add(amount);
                    friendsThatOwe[friendName].Add(amountFriendBorrowed);
                    ///////

                    //Validate that yes or no are only allowed.
                    while (anotherValue.ToLower() != "yes" && anotherValue.ToLower() != "no")
                    {
                        //Tell the user the error
                        Console.WriteLine("Please only type in yes or no.");

                        //Re-state the question
                        Console.WriteLine("\r\nDid {0} borrow another value? (yes or no)", friendName);

                        //Re-prompt the user
                        anotherValue = Console.ReadLine();
                    }
                }
            }
           
            //Final Results - use a foreach loop to display the names of all the friends that owe the user.
            foreach (KeyValuePair<string, List<decimal>> friend in friendsThatOwe)
            {   //Create a new variable for the total amount each friend owes.
                decimal total = 0;

                Console.WriteLine("Your friend {0} owes you:", friend.Key);
                //Use a second foreach loop 
                foreach (decimal amount in friend.Value)
                {
                    Console.WriteLine(amount.ToString("c"));
                    //Add all the amounts each friend owe to get a total value.
                    total += amount;
                }
                //Print the total value to the console.
                Console.WriteLine("For a total amount owed of {0}", total.ToString("c"));
            }
        }
    }
}
