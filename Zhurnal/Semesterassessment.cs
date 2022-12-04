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
    public partial class Semesterassessment
    {
        public int Id { get; set; }
        public string Teacher { get; set; }
        public string Student { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string GroupName { get; set; }
        public string ItemName { get; set; }
        public string Semester { get; set; }
        public string MonthlyEstimate { get; set; }
        public string CreditWork { get; set; }
        public string SemesterResult { get; set; }
        public string GiveMonthlyEstimate(List<Calendar> calendars)
        {
            List<Calendar> calendarEstimatesArrayList = new List<Calendar>();
            int sum = 0;
            int count = 0;
            int averageMouth = 0;
            int creditWork = CreditWork != null && CreditWork != string.Empty ? Convert.ToInt32(CreditWork.Trim()) : -1;
            if (creditWork > 100 || creditWork < -1)
            {
                throw new Exception();
            }
            if (Semester == "1")
            {
                List<Calendar> calendarEstimatesList =
                    (from calendar in calendars
                     where (calendar.ItemName == this.ItemName) && (calendar.GroupName == this.GroupName) && (calendar.Teacher == this.Teacher) && (calendar.Month == "Сентябрь")
                     select calendar).ToList();

                List<Calendar> calendarEstimatesList2 = (from calendar in calendars
                                                         where (calendar.ItemName == this.ItemName) && (calendar.GroupName == this.GroupName) && (calendar.Teacher == this.Teacher) && (calendar.Month == "Октябрь")
                                                         select calendar).ToList();
                List<Calendar> calendarEstimatesList3 = (from calendar in calendars
                                                         where (calendar.ItemName == this.ItemName) && (calendar.GroupName == this.GroupName) && (calendar.Teacher == this.Teacher) && (calendar.Month == "Ноябрь")
                                                         select calendar).ToList();
                List<Calendar> calendarEstimatesList4 = (from calendar in calendars
                                                         where (calendar.ItemName == this.ItemName) && (calendar.GroupName == this.GroupName) && (calendar.Teacher == this.Teacher) && (calendar.Month == "Декабрь")
                                                         select calendar).ToList();
                List<Calendar> calendarEstimatesList5 = (from calendar in calendars
                                                         where (calendar.ItemName == this.ItemName) && (calendar.GroupName == this.GroupName) && (calendar.Teacher == this.Teacher) && (calendar.Month == "Январь")
                                                         select calendar).ToList();
                calendarEstimatesArrayList.Add(calendarEstimatesList[0]);
                calendarEstimatesArrayList.Add(calendarEstimatesList2[0]);
                calendarEstimatesArrayList.Add(calendarEstimatesList3[0]);
                calendarEstimatesArrayList.Add(calendarEstimatesList4[0]);
                calendarEstimatesArrayList.Add(calendarEstimatesList5[0]);
            }
            if (Semester == "2")
            {
                List<Calendar> calendarEstimatesList =
                    (from calendar in calendars
                     where (calendar.ItemName == this.ItemName) && (calendar.GroupName == this.GroupName) && (calendar.Teacher == this.Teacher) && (calendar.Month == "Февраль")
                     select calendar).ToList();

                List<Calendar> calendarEstimatesList2 = (from calendar in calendars
                                                         where (calendar.ItemName == this.ItemName) && (calendar.GroupName == this.GroupName) && (calendar.Teacher == this.Teacher) && (calendar.Month == "Март")
                                                         select calendar).ToList();
                List<Calendar> calendarEstimatesList3 = (from calendar in calendars
                                                         where (calendar.ItemName == this.ItemName) && (calendar.GroupName == this.GroupName) && (calendar.Teacher == this.Teacher) && (calendar.Month == "Апрель")
                                                         select calendar).ToList();
                List<Calendar> calendarEstimatesList4 = (from calendar in calendars
                                                         where (calendar.ItemName == this.ItemName) && (calendar.GroupName == this.GroupName) && (calendar.Teacher == this.Teacher) && (calendar.Month == "Март")
                                                         select calendar).ToList();
                List<Calendar> calendarEstimatesList5 = (from calendar in calendars
                                                         where (calendar.ItemName == this.ItemName) && (calendar.GroupName == this.GroupName) && (calendar.Teacher == this.Teacher) && (calendar.Month == "Июнь")
                                                         select calendar).ToList();
                calendarEstimatesArrayList.Add(calendarEstimatesList[0]);
                calendarEstimatesArrayList.Add(calendarEstimatesList2[0]);
                calendarEstimatesArrayList.Add(calendarEstimatesList3[0]);
                calendarEstimatesArrayList.Add(calendarEstimatesList4[0]);
                calendarEstimatesArrayList.Add(calendarEstimatesList5[0]);
            }

            for (int i = 0; i < calendarEstimatesArrayList.Count; i++)
            {
                Calendar calendarEstimates = calendarEstimatesArrayList[i];
                string str = calendarEstimates.Result;
                if (str != null)
                {
                    int tempResult = Convert.ToInt32(calendarEstimates.Result);
                    if (tempResult != 0)
                    {
                        count++;
                        sum = sum + tempResult;
                    }
                }
            }
            if (creditWork != -1)
            {
                averageMouth = sum / count;
            }
            return Convert.ToString(averageMouth);
        }

        public string GiveResult(List<Calendar> calendars)
        {
            int result;
            int creditWork = CreditWork != null && CreditWork != string.Empty ? Convert.ToInt32(CreditWork.Trim()) : -1;
            int averageMouth = Convert.ToInt32(GiveMonthlyEstimate(calendars));
            int temp60 = (int)(averageMouth * 0.60);
            int temp40 = (int)(creditWork * 0.40);
            result = temp40 + temp60;
            return Convert.ToString(result);
        }
    }
}
