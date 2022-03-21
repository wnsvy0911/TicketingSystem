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
            TicketManager<TaskTicket> manager = new TicketManager<TaskTicket>("Tickets.csv", typeof(TaskTicket));
            manager.loadTicketsFromFile();

              string choice;
            do
            {
                Console.WriteLine("\n1) List Tickets From File.");
                Console.WriteLine("2) Create New Ticket And Write To File.");
                Console.WriteLine("\nEnter any other key to exit.");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    manager.listTickets();
                    
                } else if (choice == "2")
                {
                    manager.createTicket();
                    manager.writeTicketsToFile();

                }
            } while (choice == "1" || choice == "2");
        }
    }
}