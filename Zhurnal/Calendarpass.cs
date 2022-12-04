using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Zhurnal
{
    public partial class Calendarpass
    {
        public int Id { get; set; }
        public string Teacher { get; set; }
        public string Student { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string GroupName { get; set; }
        public string ItemName { get; set; }
        public string Month { get; set; }
        public string Days { get; set; }
        public string Day1 { get; set; }
        public string Day2 { get; set; }
        public string Day3 { get; set; }
        public string Day4 { get; set; }
        public string Day5 { get; set; }
        public string Day6 { get; set; }
        public string Day7 { get; set; }
        public string Day8 { get; set; }
        public string Day9 { get; set; }
        public string Day10 { get; set; }
        public string Day11 { get; set; }
        public string Day12 { get; set; }
        public string Day13 { get; set; }
        public string Day14 { get; set; }
        public string Day15 { get; set; }
        public string Day16 { get; set; }
        public string Day17 { get; set; }
        public string Day18 { get; set; }
        public string Day19 { get; set; }
        public string Day20 { get; set; }
        public string Day21 { get; set; }
        public string Day22 { get; set; }
        public string Day23 { get; set; }
        public string Day24 { get; set; }
        public string Day25 { get; set; }
        public string Day26 { get; set; }
        public string Day27 { get; set; }
        public string Day28 { get; set; }
        public string Day29 { get; set; }
        public string Day30 { get; set; }
        public string Day31 { get; set; }
        public string Result { get; set; }

        public string GiveResult()
        {
            List<int> arrayList = new List<int>();
            int count = 0;
            int day1 = Day1 != null && Day1 != string.Empty ? count++ : -1;
            int day2 = Day2 != null && Day2 != string.Empty ? count ++ : -1;
            int day3 = Day3 != null && Day3 != string.Empty ? count ++ : -1;
            int day4 = Day4 != null && Day4 != string.Empty ? count ++ : -1;
            int day5 = Day5 != null && Day5 != string.Empty ? count ++ : -1;
            int day6 = Day6 != null && Day6 != string.Empty ? count ++ : -1;
            int day7 = Day7 != null && Day7 != string.Empty ? count ++ : -1;
            int day8 = Day8 != null && Day8 != string.Empty ? count ++ : -1;
            int day9 = Day9 != null && Day9 != string.Empty ? count ++ : -1;
            int day10 = Day10 != null && Day10 != string.Empty ? count ++ : -1;
            int day11 = Day11 != null && Day11 != string.Empty ? count ++ : -1;
            int day12 = Day12 != null && Day12 != string.Empty ? count ++ : -1;
            int day13 = Day13 != null && Day13 != string.Empty ? count ++ : -1;
            int day14 = Day14 != null && Day14 != string.Empty ? count ++ : -1;
            int day15 = Day15 != null && Day15 != string.Empty ? count ++ : -1;
            int day16 = Day16 != null && Day16 != string.Empty ? count ++ : -1;
            int day17 = Day17 != null && Day17 != string.Empty ? count ++ : -1;
            int day18 = Day18 != null && Day18 != string.Empty ? count ++ : -1;
            int day19 = Day19 != null && Day19 != string.Empty ? count ++ : -1;
            int day20 = Day20 != null && Day20 != string.Empty ? count ++ : -1;
            int day21 = Day21 != null && Day21 != string.Empty ? count ++ : -1;
            int day22 = Day22 != null && Day22 != string.Empty ? count ++ : -1;
            int day23 = Day23 != null && Day23 != string.Empty ? count ++ : -1;
            int day24 = Day24 != null && Day24 != string.Empty ? count ++ : -1;
            int day25 = Day25 != null && Day25 != string.Empty ? count ++ : -1;
            int day26 = Day26 != null && Day26 != string.Empty ? count ++ : -1;
            int day27 = Day27 != null && Day27 != string.Empty ? count ++ : -1;
            int day28 = Day28 != null && Day28 != string.Empty ? count ++ : -1;
            int day29 = Day29 != null && Day29 != string.Empty ? count ++ : -1;
            int day30 = Day30 != null && Day30 != string.Empty ? count ++ : -1;
            int day31 = Day31 != null && Day31 != string.Empty ? count ++ : -1;

            Result = Convert.ToString(count);
            return Result;
        }
    }
}
