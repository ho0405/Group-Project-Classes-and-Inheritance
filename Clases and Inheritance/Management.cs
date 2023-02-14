using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Management
    {
        //Method that parses the appliances.txt file into a single list. 
        List<Appliance> appliances = new List<Appliance>();

        public Management() //Calls required functions to make the program run
        {
            loadAppliancesListFromFile();
            Menu();
            //Checkout method here (1) (void)
            //isAvailable method here (2) (bool)
            //??? method to display appliances by type (3) 
            //??? method to produce random appliance list (4)
            //formatForFile method to save and exit (5) 

            Console.ReadKey();
        }

        //Methods
        //Method that parses the appliances.txt file into a single list
        public void loadAppliancesListFromFile()
        {
            //Commented code used to test appliances.txt file path
            //string text = File.ReadAllText("C://Users//Anton//OneDrive - Southern Alberta Institute of Technology//Desktop//Object Oriented Programming 2//Assignments//Classes and Inheritance//Inheritance//appliances.txt");
            //Console.WriteLine(text);

            string[] lines = File.ReadAllLines("appliances.txt");

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');
                string applianceNumber = fields[0];
                char firstNumber = applianceNumber[0];
                switch (firstNumber)
                {
                    case '1':
                        //method/function Refrigerator                        
                        appliances.Add(new Refrigerator(long.Parse(fields[0]), fields[1], Convert.ToInt32(fields[2]), Convert.ToInt32(fields[3]),
                            fields[4], double.Parse(fields[5]), Convert.ToInt32(fields[6]), Convert.ToInt32(fields[7]), Convert.ToInt32(fields[8])));
                        break;
                    case '2':
                        //method/function Vacuum
                        appliances.Add(new Vacuum(long.Parse(fields[0]), fields[1], Convert.ToInt32(fields[2]), Convert.ToInt32(fields[3]),
                            fields[4], double.Parse(fields[5]), fields[6], Convert.ToInt32(fields[7])));

                        break;
                    case '3':
                        //method/function Microwave
                        appliances.Add(new Microwave(long.Parse(fields[0]), fields[1], Convert.ToInt32(fields[2]), Convert.ToInt32(fields[3]),
                            fields[4], double.Parse(fields[5]), double.Parse(fields[6]), fields[7]));
                        break;
                    case '4':
                    case '5':
                        //method/function Dishwasher
                        appliances.Add(new Dishwasher(long.Parse(fields[0]), fields[1], Convert.ToInt32(fields[2]), Convert.ToInt32(fields[3]),
                            fields[4], double.Parse(fields[5]), fields[6], fields[7]));
                        break;
                }
            }

        }

        //Method that operates the menu
        public void Menu()
        {
            bool con = true;
            while (con)
            {
                Console.WriteLine("Welcome to Modern Appliances! " +
                "\nHow may we assist you?" +
                "\n1 – Check out appliance" +
                "\n2 – Find appliances by brand" +
                "\n3 – Display appliances by type" +
                "\n4 – Produce random appliance list" +
                "\n5 – Save & exit");

            int input = Convert.ToInt32(Console.ReadLine());

            //if else statment using user input
            
                if (input == 1)
                {
                    Console.WriteLine("Enter the item number of an appliance:");
                    string itemNumber = Console.ReadLine();
                    Checkout(appliances);
                }
                else if (input == 2)
                {
                    SearchByBrand(appliances);
                }
                else if (input == 3)
                {
                    DisplayAppliancesByType(appliances);


                }
                else if (input == 4)
                {
                    RandomApplianceList();
                }
                else if (input == 5)
                {
                    Console.WriteLine("Save and Exit");
                    //Save & Exit method
                    break;
                }
                else { Console.WriteLine("Error, invalid user input, please try again."); }
            continue;
            }
        }
        //Method that allows a customer to purchase an appliance = Checkout()       
        public void Checkout(List<Appliance> appliances)
        {
            Console.WriteLine("Enter the item number of an appliance:");
            int input = Convert.ToInt32(Console.ReadLine());
            bool itemFound = false;

            foreach (Appliance appliance in appliances)
            {
                if (input == appliance.itemNumber)
                {
                    itemFound = true;
                    if (appliance.quantity >= 1)
                    {
                        appliance.quantity--;
                        Console.WriteLine($"Appliance {input} has been checked out");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"The {input} is not available to be checked out.");
                        break;
                    }
                }
            }

            if (!itemFound)
            {
                Console.WriteLine($"Item {input} is not a valid product.");
            }
        }




        //Method to display appliances by type (2) = SearchByBrand
        public static void SearchByBrand(List<Appliance> appliances)
            {
                Console.WriteLine("Enter brand to search for: ");
                // input has to be a string
                string input = Console.ReadLine();
                // makes the input uppercase for a case insensitive search
                foreach (Appliance appliance in appliances)
                {
                    // Case insesnitive search by ToLower() everything
                    if (input.ToLower() == appliance.brand.ToLower())
                    {
                        //item.FormatFile();
                        Console.WriteLine(appliance.ToString());
                        //item.ToString();
                    }
                }
            }

        public void DisplayAppliancesByType(List<Appliance> appliances)
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("1 - Refrigerators");
            Console.WriteLine("2 - Vacuums");
            Console.WriteLine("3 - Microwaves");
            Console.WriteLine("4 - Dishwashers");
            Console.WriteLine("\nEnter type of appliance:");
            int input = Convert.ToInt32(Console.ReadLine());            
            foreach (Appliance appliance in appliances)
            {
                
                if (input == 1)
                {
                    Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
                    int inputNum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Matching refrigerators: ");
                    if (inputNum == appliance.firstNumber)
                    {
                        //item.FormatFile();
                        Console.WriteLine(appliance.ToString());
                        //item.ToString();
                    }

                }
                else if (input == 2)
                {
                    Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high):");
                }
                else if (input == 3)
                {
                    Console.WriteLine("RoomWhere the microwave will be installed: K (kitchen) or W (work site):");
                }
                else if (input == 4)
                {
                    Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                }

                else
                {
                    Console.WriteLine("Invalid Number Please input 1-4");
                }

            }
        }
        public void RandomApplianceList()
        {
            Console.WriteLine("Enther number of appliacnes ");
            int input = int.Parse(Console.ReadLine());
            List<Appliance> newapp = new List<Appliance>();
            foreach (Appliance appliances in appliances)
            {
                
                if (input == 1)
                {
                    if
                        { }
                    Console.WriteLine("1");
                }
                else if (input == 2)
                {
                    Console.WriteLine("2");
                }
                else if (input == 3)
                {
                    Console.WriteLine("3");
                }
                else if (input == 4)
                {
                    Console.WriteLine("4");
                }
                else 
                { 
                    Console.WriteLine("Invalid Number Please input 0-4"); 
                }
               
            }
            Console.WriteLine(appliances.ToString());
        }
    }
}