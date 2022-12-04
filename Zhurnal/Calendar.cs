using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Zhurnal
{
    public partial class Calendar
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
            int sum = 0;
            int day1 = Day1 != null && Day1 != string.Empty ? Convert.ToInt32(Day1.Trim()) : -1;
            int day2 = Day2 != null && Day2 != string.Empty ? Convert.ToInt32(Day2.Trim()) : -1;
            int day3 = Day3 != null && Day3 != string.Empty ? Convert.ToInt32(Day3.Trim()) : -1;
            int day4 = Day4 != null && Day4 != string.Empty ? Convert.ToInt32(Day4.Trim()) : -1;
            int day5 = Day5 != null && Day5 != string.Empty ? Convert.ToInt32(Day5.Trim()) : -1;
            int day6 = Day6 != null && Day6 != string.Empty ? Convert.ToInt32(Day6.Trim()) : -1;
            int day7 = Day7 != null && Day7 != string.Empty ? Convert.ToInt32(Day7.Trim()) : -1;
            int day8 = Day8 != null && Day8 != string.Empty ? Convert.ToInt32(Day8.Trim()) : -1;
            int day9 = Day9 != null && Day9 != string.Empty ? Convert.ToInt32(Day9.Trim()) : -1;
            int day10 = Day10 != null && Day10 != string.Empty ? Convert.ToInt32(Day10.Trim()) : -1;
            int day11 = Day11 != null && Day11 != string.Empty ? Convert.ToInt32(Day11.Trim()) : -1;
            int day12 = Day12 != null && Day12 != string.Empty ? Convert.ToInt32(Day12.Trim()) : -1;
            int day13 = Day13 != null && Day13 != string.Empty ? Convert.ToInt32(Day13.Trim()) : -1;
            int day14 = Day14 != null && Day14 != string.Empty ? Convert.ToInt32(Day14.Trim()) : -1;
            int day15 = Day15 != null && Day15 != string.Empty ? Convert.ToInt32(Day15.Trim()) : -1;
            int day16 = Day16 != null && Day16 != string.Empty ? Convert.ToInt32(Day16.Trim()) : -1;
            int day17 = Day17 != null && Day17 != string.Empty ? Convert.ToInt32(Day17.Trim()) : -1;
            int day18 = Day18 != null && Day18 != string.Empty ? Convert.ToInt32(Day18.Trim()) : -1;
            int day19 = Day19 != null && Day19 != string.Empty ? Convert.ToInt32(Day19.Trim()) : -1;
            int day20 = Day20 != null && Day20 != string.Empty ? Convert.ToInt32(Day20.Trim()) : -1;
            int day21 = Day21 != null && Day21 != string.Empty ? Convert.ToInt32(Day21.Trim()) : -1;
            int day22 = Day22 != null && Day22 != string.Empty ? Convert.ToInt32(Day22.Trim()) : -1;
            int day23 = Day23 != null && Day23 != string.Empty ? Convert.ToInt32(Day23.Trim()) : -1;
            int day24 = Day24 != null && Day24 != string.Empty ? Convert.ToInt32(Day24.Trim()) : -1;
            int day25 = Day25 != null && Day25 != string.Empty ? Convert.ToInt32(Day25.Trim()) : -1;
            int day26 = Day26 != null && Day26 != string.Empty ? Convert.ToInt32(Day26.Trim()) : -1;
            int day27 = Day27 != null && Day27 != string.Empty ? Convert.ToInt32(Day27.Trim()) : -1;
            int day28 = Day28 != null && Day28 != string.Empty ? Convert.ToInt32(Day28.Trim()) : -1;
            int day29 = Day29 != null && Day29 != string.Empty ? Convert.ToInt32(Day29.Trim()) : -1;
            int day30 = Day30 != null && Day30 != string.Empty ? Convert.ToInt32(Day30.Trim()) : -1;
            int day31 = Day31 != null && Day31 != string.Empty ? Convert.ToInt32(Day31.Trim()) : -1;
            arrayList.Add(day1);
            arrayList.Add(day2);
            arrayList.Add(day3);
            arrayList.Add(day4);
            arrayList.Add(day5);
            arrayList.Add(day6);
            arrayList.Add(day7);
            arrayList.Add(day8);
            arrayList.Add(day9);
            arrayList.Add(day10);
            arrayList.Add(day11);
            arrayList.Add(day12);
            arrayList.Add(day13);
            arrayList.Add(day14);
            arrayList.Add(day15);
            arrayList.Add(day16);
            arrayList.Add(day17);
            arrayList.Add(day18);
            arrayList.Add(day19);
            arrayList.Add(day20);
            arrayList.Add(day21);
            arrayList.Add(day22);
            arrayList.Add(day23);
            arrayList.Add(day24);
            arrayList.Add(day25);
            arrayList.Add(day26);
            arrayList.Add(day27);
            arrayList.Add(day28);
            arrayList.Add(day29);
            arrayList.Add(day30);
            arrayList.Add(day31);
            for (int i = 0; i < arrayList.Count; i++)
            {
                int temp = arrayList[i];
                if (temp > 100 || temp < -1)
                {
                    throw new Exception();
                }
                else if (temp != -1)
                {
                    count++;
                    sum = sum + temp;
                }
            }

            string result = Convert.ToString(sum / count);
            Result = result;
            return result;
        }
    }
}
