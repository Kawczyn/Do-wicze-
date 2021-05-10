using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Do_ćwiczeń
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime today =  DateTime.Today;
            int dayOfWeek = (int)today.DayOfWeek;
            Console.WriteLine(dayOfWeek);
            int dateAdd = 0;
            int dateSubtract = 0;

            switch (dayOfWeek)
            {
                case 1:
                    dateAdd = 6;
                    break;
                case 2:
                    dateAdd = 5;
                    dateSubtract = 1;
                    break;
                case 3:
                    dateAdd = 4;
                    dateSubtract = 2;
                    break;
                case 4:
                    dateAdd = 3;
                    dateSubtract = 3;
                    break;
                case 5:
                    dateAdd = 2;
                    dateSubtract = 4;
                    break;
                case 6:
                    dateAdd = 1;
                    dateSubtract = 5;
                    break;
                case 7:
                    dateSubtract = 6;
                    break;
            }

            DateTime startDate = today.AddDays(-dateSubtract);
            DateTime endDate = today.AddDays(dateAdd);

            Console.WriteLine(today + "          " + startDate + "   " + endDate);



            DateTime newDate = new DateTime(2021, 04, 01, 00, 00, 00);

            var workingHours = new StylistsWorkingHours().GenarateList(newDate);

            var aaa = workingHours.Where(w => w.StartDate >= startDate && w.StartDate <= endDate && w.StylistId == 1 ).ToList();


            List<ListWorkingHours> listWorkingHours = new List<ListWorkingHours>();
            foreach (var item in aaa)
            {
                Console.WriteLine("Id " + item.Id);
                Console.WriteLine("StylistId " + item.StylistId);
                Console.WriteLine("StartDate " + item.StartDate);
                Console.WriteLine("EndDate " + item.EndDate);
                Console.WriteLine("------------------------------------");


                DateTime d;
                double n = 2.5;
                DateTime sd = item.StartDate;
                
                for (DateTime ed = item.StartDate.AddHours(n); ed < item.EndDate; ed = ed.AddHours(n))
                {
                    listWorkingHours.Add(new ListWorkingHours {
                        DateStart = sd,
                        DateEnd = ed,
                        DayOfWeek = (int)sd.DayOfWeek,
                        ViewHours = sd.ToString("HH:mm") + "-" + ed.ToString("HH:mm")
                    });
                    Console.WriteLine(sd.ToString("HH:mm") + "-" + ed.ToString("HH:mm") + "       " + (int)sd.DayOfWeek);
                    sd = ed;
                }

                Console.WriteLine("----------------");

            }
        }
    }

    public class ListWorkingHours
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int DayOfWeek { get; set; }
        public string ViewHours { get; set; }
    }

    public class StylistsWorkingHours
    {
        public int Id { get; set; }
        public int StylistId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<StylistsWorkingHours> GenarateList(DateTime newDate)
        {
            var workingHours = new List<StylistsWorkingHours>();

            int firstId = 1;
            int secondId = 2;
            int id = 1;

            for (int i = 0; i < 50; i++)
            {
                int dzienTygodnia = (int)newDate.DayOfWeek;
                switch (dzienTygodnia)
                {
                    case 7:
                        int temp = secondId;
                        secondId = firstId;
                        firstId = temp;
                        i++;
                        break;
                    case 1:
                        i++;
                        break;
                    case 6:
                        workingHours.Add(new StylistsWorkingHours
                        {
                            Id = id,
                            StylistId = firstId,
                            StartDate = newDate.AddHours(8),
                            EndDate = newDate.AddHours(14)
                        });
                        workingHours.Add(new StylistsWorkingHours
                        {
                            Id = id + 1,
                            StylistId = secondId,
                            StartDate = newDate.AddHours(8),
                            EndDate = newDate.AddHours(14)
                        });
                        id++;
                        id++;
                        break;
                    default:
                        workingHours.Add(new StylistsWorkingHours
                        {
                            Id = id,
                            StylistId = firstId,
                            StartDate = newDate.AddHours(9),
                            EndDate = newDate.AddHours(17)
                        });
                        workingHours.Add(new StylistsWorkingHours
                        {
                            Id = id + 1,
                            StylistId = secondId,
                            StartDate = newDate.AddHours(13),
                            EndDate = newDate.AddHours(21)
                        });
                        id++;
                        id++;
                        break;
                }
                newDate = newDate.AddDays(1);
            }

            return workingHours;
        }
    }
}
