using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public static class Extentionmethods
    {
        public static bool SearchInString(this string str,string word)
        {
            string Common="";
            int z=0;
            str=str.ToLower();
            word=word.ToLower();
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    if (str[i] == word[j])
                    {
                        Common += word[j];
                        i++;
                        if(Common==word) 
                        {
                            return true;
                        }
                    }
                    else if (str[i] != word[j])
                    {
                        Common = "";
                        i = z;
                        break;
                    }
                }
                z++;
            }
            return false;
        }
        public static bool Isprime(this int number)
        {
            if (number == 0 || number == 1)
            {
                return false;
            }
            else
            {
                for (int a = 2; a <= number / 2; a++)
                {
                    if (number % a == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            
        }
        public static string  shamsi(this DateTime date)
        {
            PersianCalendar pC = new PersianCalendar();
            var hijriYear = pC.GetYear(date);
            var hijriMonth = pC.GetMonth(date);
            var hijriDay = pC.GetDayOfMonth(date);
            DateTime Date = new DateTime(hijriYear, hijriMonth, hijriDay);
            var day1 =
            pC.GetDayOfWeek(date);
            return $" Today {(WeekEnum)(int)day1} {hijriDay} {(MonthEnum)hijriMonth} {hijriYear}. ";
            //var year = date.Year;
            //double d = 0;
            //for (int i = 1; i<=year; i++)
            //{
            //    if(i%400==0)
            //    {
            //        d += 366;
            //    }
            //    else if(i%4==0)
            //    {
            //        d += 366;
            //    }
            //    else
            //    {
            //        d += 365;
            //    }
            //}
            //d = (d * 3600 * 24) + (278 * 24 * 3600) + 16 * 3600 + 39 * 60;
            //double days = 0;
            //for (int j = 1;j<=1403; j++)
            //{
            //   44239654350;
            //}

            //days += 6 * 31 * 3600 * 24 + 13 * 3600 * 24 + 16 * 3600 + 39 * 60;
            //double dif = d - days;
            //DateTime date1= date.AddSeconds(-dif);
            //return date1;
        }
    }
}
