using System;
using System.IO;
using System.Collections.Generic;


namespace TicketingSystem
{
    public class TicketManager
    {
        public List<BugTicket> bugTickets = new List<BugTicket>();
        public List<TaskTicket> taskTickets = new List<TaskTicket>();
        public List<EnhancementTicket> enhancementTickets = new List<EnhancementTicket>();


        string bugHeaders;
        string taskHeaders;
        string enhancementHeaders;


/*        public TicketManager(String ticketFilePath)
        {
            ticketFilePath = ticketFilePath;
            Tickets = new List<Ticket>();
        }
*/
        public void loadTicketsFromFile(string ticketType, string filename)
        {
            if (File.Exists(filename))
            {
                StreamReader sr1 = new StreamReader(filename);
                Boolean firstLine = true;
                while (!sr1.EndOfStream)
                {

                    string line = sr1.ReadLine();
                    if(firstLine) {

                        if (ticketType == "bugTicket") {
                            this.bugHeaders = line;
                        } else if (ticketType == "taskTicket") {
                            this.taskHeaders = line;
                        } else if (ticketType == "enhancementTicket") {
                            this.enhancementHeaders = line;
                        }
                        firstLine = false;
                    } else {                        
                        if (ticketType == "bugTicket") {
                            this.bugTickets.Add(BugTicket.createTicketFromFile(line));
                        } else if (ticketType == "taskTicket") {
                            this.taskTickets.Add(TaskTicket.createTicketFromFile(line));
                        } else if (ticketType == "enhancementTicket") {
                            this.enhancementTickets.Add(EnhancementTicket.createTicketFromFile(line));
                        } else {

                        }
                        //this.tickets.Add();
                    }
                }
                sr1.Close();
            }
            else
            {
                Console.WriteLine("File does not exist" + filename);
            }
        }

        public void writeTicketsToFile(string ticketType, string filename)
        {

            if (File.Exists(filename))
            {
                StreamWriter sw = new StreamWriter(filename);

                if (ticketType == "bugTicket") {
                    sw.WriteLine(this.bugHeaders);
                    foreach (var ticket in this.bugTickets)
                    {
                        sw.WriteLine(ticket.formatTicket());
                    }
                } else if (ticketType == "taskTicket") {
                    sw.WriteLine(this.taskHeaders);
                    foreach (var ticket in this.taskTickets)
                    {
                        sw.WriteLine(ticket.formatTicket());
                    }
                } else if (ticketType == "enhancementTicket") {
                    sw.WriteLine(this.enhancementHeaders);
                    foreach (var ticket in this.enhancementTickets)
                    {
                        sw.WriteLine(ticket.formatTicket());
                    }
                } else {

                }
                
                sw.Close();
            }
        }

        public void listTickets(string ticketType)
        {
            if (ticketType == "bugTicket") {
                Console.WriteLine("\n" + this.bugHeaders);
                foreach (var ticket in this.bugTickets) {
                    Console.WriteLine(ticket.formatTicket());
                }
            } else if (ticketType == "taskTicket") {
                Console.WriteLine("\n" + this.taskHeaders);
                foreach (var ticket in this.taskTickets) {
                    Console.WriteLine(ticket.formatTicket());
                }
            } else if (ticketType == "enhancementTicket") {
                Console.WriteLine("\n" + this.enhancementHeaders);
                foreach (var ticket in this.enhancementTickets) {
                    Console.WriteLine(ticket.formatTicket());
                }
            } else {

            }
        }

    
        public void FindTickets(string searchCriteria) {
            var ticketsFound = this.taskTickets.FindAll(t => t.status.Contains(searchCriteria) || t.priority.Contains(searchCriteria) || t.submitter.Contains(searchCriteria));
            Console.WriteLine(ticketsFound.Count + " Matches Found");
            foreach(Ticket t in ticketsFound)
            {
                Console.WriteLine($" - {t.ticketId}, {t.summary}, {t.status}, {t.priority}, {t.submitter}, {t.assigned}");
            }
        }
        
    }
}