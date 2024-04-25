
namespace Exercise004
{
    using System.Text.RegularExpressions;
    public class Checker
    {
        public bool DayOfWeek(string str)
        {
            return Regex.IsMatch(str, "^(mon|tue|wed|thu|fri|sat|sun)$", RegexOptions.IgnoreCase);
        }

        public bool AllVowels(string str)
        {
            return Regex.IsMatch(str, "^[aeiou]+$", RegexOptions.IgnoreCase);
        }

        public bool TimeOfDay(string str)
        {
            return Regex.IsMatch(str, @"^([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$");
        }
    }
}