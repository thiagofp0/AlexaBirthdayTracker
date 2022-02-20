using System;
using System.Collections.Generic;
using System.Linq;
using AlexaBirthdayTracker.Interfaces;
using AlexaBirthdayTracker.Models;

namespace AlexaBirthdayTracker.Providers
{
    public class BirthdayDataProvider : IBirthdayDataProvider
    {
        static List<Birthday> birthdays;

        public BirthdayDataProvider()
        {
            Init();
        }
        
        public void Init()
        {
            if (birthdays == null)
            {
                birthdays = new List<Birthday>();
                birthdays.Add(new Birthday()
                {
                    Name = "Thiago",
                    Date = new DateTime(2022, 11, 29),
                    DayofYear = new DateTime(2022, 11, 29).DayOfYear
                });
                birthdays.Add(new Birthday()
                {
                    Name = "Renata",
                    Date = new DateTime(2023, 1, 2),
                    DayofYear = new DateTime(2023, 1, 2).DayOfYear
                });
                birthdays.Add(new Birthday()
                {
                    Name = "Genilza",
                    Date = new DateTime(2022, 2, 2),
                    DayofYear = new DateTime(2022, 2, 2).DayOfYear
                });
                birthdays.Add(new Birthday()
                {
                    Name = "Bruno",
                    Date = new DateTime(2022, 4, 11),
                    DayofYear = new DateTime(2022, 4, 11).DayOfYear
                });
            }
        }

        public Birthday GetNextBirthday()
        {
            List<Birthday> birthdaysSorted = birthdays.OrderBy(b => b.DayofYear).ToList();
            int currentDayOfYear = DateTime.Today.DayOfYear;
            Birthday next = birthdaysSorted.Find(b => b.DayofYear >= currentDayOfYear)!;
            if (next == null && birthdaysSorted.Count > 0)
            {
                next = birthdaysSorted[0];
            }

            if (next != null)
            {
                if (next.Date < DateTime.Today)
                {
                    next.Date = new DateTime(DateTime.Today.Year + 1, next.Date.Month, next.Date.Day);
                }
            }
            return next;
        }
    }
}