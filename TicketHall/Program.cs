using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketHall
{
    class PersonTickets
    {
        public string Name { get; set; }
        public int Tickets { get; set; }
    }

    class TicketBooking
    {
        public void Heading(string text)
        {
            Console.WriteLine();
            Console.WriteLine("**************************************");
            Console.WriteLine(text);
            Console.WriteLine("**************************************");
            Console.WriteLine();
        }

        public int SetRowsSection(string val)
        {
            Console.Write("Please Enter the number of {0} in hall : ", val);
            return int.Parse(Console.ReadLine());
        }

        public int[,] SetHall(int rows, int sections)
        {
            int[,] halls = new int[rows, sections];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < sections; j++)
                {
                    Console.Write("Please Enter the space for row {0} , section {1} : ", i, j);
                    halls[i, j] = int.Parse(Console.ReadLine());
                }
            }

            return halls;
        }

        public List<PersonTickets> SetPersonTickets()
        {
            string[] members = { "Smith", "Jones", "Davis", "Wilson", "Johnson", "Williams", "Brown", "Miller" };

            var list = new List<PersonTickets>();
            foreach (var member in members)
            {
                Console.Write("Please Enter the number of tickets '{0}' Required : ", member);
                int tickets = int.Parse(Console.ReadLine());

                list.Add(new PersonTickets() { Name = member, Tickets = tickets });
            }

            return list;
        }

        public void SetSectionForPerson(int rows, int sections, List<PersonTickets> personTicketList, int[,] halls)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < sections; j++)
                {
                    var match = (from val in personTicketList
                                 where val.Tickets == halls[i, j]
                                 select val).ToList();

                    if (match.Count > 0)
                        Console.WriteLine("{0} Row {1} Section {2}", match.FirstOrDefault().Name, i, j);
                    else
                        Console.WriteLine("Call to split party!");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TicketBooking booking = new TicketBooking();

            int rows, sections;

            booking.Heading("Data for each Hall");

            rows = booking.SetRowsSection("Rows");

            sections = booking.SetRowsSection("Section");

            booking.Heading("Maximum capacity for each section");

            int[,] halls = booking.SetHall(rows, sections);

            booking.Heading("Tickets required by each Person");

            var personTicketList = booking.SetPersonTickets();

            booking.Heading("Section Allocation for Members");

            booking.SetSectionForPerson(rows, sections, personTicketList, halls);

            Console.ReadLine();
        }
    }
}
