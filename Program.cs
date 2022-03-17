using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;

namespace TicketingSystem
{
    class Program
    {
       private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {

        /*  string file = "Tickets.csv";
            StreamReader sr = new StreamReader(file);
                List<string> originalFile = new List<string>();
                while (!sr.EndOfStream)
                {
                    originalFile.Add(sr.ReadLine());
                    
                }
                sr.Close(); */
            TicketManager manager = new TicketManager("Tickets.csv");
            manager.loadTicketsFromFile();


              string choice;
            do
            {
                Console.WriteLine("1) Read data from CSV file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                /*  if (File.Exists(file))
                    {
                     
                        StreamReader sr1 = new StreamReader(file);

                        while (!sr1.EndOfStream)
                        {
                            string line = sr1.ReadLine();
                            string[] arr = line.Split(',');
                         
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}",
                            arr[0],arr[1] , arr[2] , arr[3] , arr[4],arr[5], arr[6]);
                        }
                        sr1.Close();
                        
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    } */
                    manager.listTickets();
                    manager.createTicket();
                }
                else if (choice == "2")
                {
                    /*
                    StreamWriter sw = new StreamWriter(file);
    
                    Console.WriteLine("Do you want to create more data?(Y/N)");
                    string resp = Console.ReadLine().ToUpper();

                    if (resp != "Y") { break; }
                    Console.WriteLine("What is the TicketID (Type only number)?");
                    int ticketID = Convert.ToInt32(Console.ReadLine());                        
                    
                    Console.WriteLine("Enter a summary.");                        
                    string summary = Console.ReadLine();
                    
                    Console.WriteLine("Enter the status(Open/Close)");
                    string status = Console.ReadLine();
                    
                    Console.WriteLine("Enter the priority");   
                    string priority = Console.ReadLine();

                    Console.WriteLine("Enter the submitter");
                    string submitter = Console.ReadLine();

                    Console.WriteLine("Enter the assigned");
                    string assigned = Console.ReadLine();

                    Console.WriteLine("Enter the watching");
                    string watching = Console.ReadLine();
                    
                    originalFile.Add(ticketID + "," + summary + "," + status + "," + priority + "," + submitter + "," + assigned + "," + watching);

                    foreach (var line in originalFile) {
                        sw.WriteLine(line);
                    }
                    
                    sw.Close(); */
                    manager.writeTicketsToFile();

                }
            } while (choice == "1" || choice == "2");
        }   
    }
}