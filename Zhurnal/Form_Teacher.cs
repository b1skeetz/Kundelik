using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Zhurnal
{
    public partial class Form_Teacher : Form
    {
        private People Human { get; set; }
        private List<Calendar> Calendars { get; set; }
        private List<Semesterassessment> Semesters { get; set; }
        private List<People> Peoples { get; set; }
        private List<Calendarpass> Calendarpasses { get; set; }
        //-------------------------------------------------------
        private int MonthIndex { get; set; }
        private int SubjectIndex { get; set; }
        private int GroupIndex { get; set; }
        private int SemesterIndex { get; set; }
        private int SemesterMonthIndex { get; set; }
        private int SemesterGroupIndex { get; set; }
        private int AbsenceGroupIndex { get; set; }
        private int AbsenceSubjectIndex { get; set; }
        private int AbsenceMonthIndex { get; set; }
        //-------------------------------------------------------
        private string MonthValue { get; set; }
        private string SubjectValue { get; set; }
        private string GroupValue { get; set; }
        private string SemesterSubject { get; set; }
        private string SemesterMonth { get; set; }
        private string SemesterGroupValue { get; set; }
        private string AbsenceGroupValue { get; set; }
        private string AbsenceSubjectValue { get; set; }
        private string AbsenceMonthValue { get; set; }
        //-------------------------------------------------------
        private string History { get; set; }
        private string StudentsName { get; set; }
        private string StudentsGroupName { get; set; }
        //-------------------------------------------------------
        public Form_Teacher(People human, List<Calendar> calendars, List<Semesterassessment> semesters, List<People> peoples, List<Calendarpass> calendarpasses)
        {
            InitializeComponent();
            Human = human;
            Calendars = calendars;
            Semesters = semesters;
            Peoples = peoples;
            Calendarpasses = calendarpasses;

            foreach (Semesterassessment s in Semesters)
            {
                using (KundelikContext db = new KundelikContext())
                {
                    if (s.SemesterResult == null)
                    {
                        s.SemesterResult = s.GiveResult(Calendars);
                        db.Entry(s).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            foreach (Semesterassessment s in Semesters)
            {
                using (KundelikContext db = new KundelikContext())
                {
                    if (s.MonthlyEstimate == null)
                    {
                        s.SemesterResult = s.GiveMonthlyEstimate(Calendars);
                        db.Entry(s).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            for (int i = 100; i >= 50; i--)
            {
                guna2ComboBox_ListMarks.Items.Add(i);
            }
            guna2ComboBox_ListMarks.Items.Add(0);

            for (int i = 100; i >= 50; i--)
            {
                guna2ComboBox_SemesterMarks.Items.Add(i);
            }
            guna2ComboBox_SemesterMarks.Items.Add(0);
            string[] reasons = { "Н", "Б", "У" };
            for(int i = 0; i < reasons.Length; i++)
            {
                guna2ComboBox_AbsenceReason.Items.Add(reasons[i]);
            }
        }

        private void Form_Teacher_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel_Welcome.Text = "Добро пожаловать, " + Human.FirstName + " " + Human.MiddleName + "!";
            guna2TextBox_FIO.Text = Human.LastName + " " + Human.FirstName + " " + Human.MiddleName;
            guna2TextBox_DateOfBirth.Text = Human.Birth;
            guna2TextBox_Gender.Text = Human.Gender;
            guna2TextBox_Age.Text = GetAge(Human.Birth);
            guna2TextBox_Nationality.Text = Human.Nationality;
            guna2TextBox_Phone.Text = Human.Phone;
            guna2TextBox_Address.Text = Human.Address;
            guna2TextBox_IIN.Text = Human.Iin + " " + Human.Certificates;
            //-------------------------------------------------------
            List<string> Temp_FromCalendar = new List<string>();
            IEnumerable<string> Temp_ToComboBox = Temp_FromCalendar.Distinct();
            foreach (var calendar in Calendars)
            {
                var temp = calendar.ItemName;
                Temp_FromCalendar.Add(temp);
            }
            foreach (var items in Temp_ToComboBox)
            {
                guna2ComboBox_Subject.Items.Add(items);
            }

            List<string> Temp_FromGroup = new List<string>();
            IEnumerable<string> Temp_ToGroup = Temp_FromGroup.Distinct();
            foreach (var calendar in Calendars)
            {
                var temp = calendar.GroupName;
                Temp_FromGroup.Add(temp);
            }
            foreach (var items in Temp_ToGroup)
            {
                guna2ComboBox_Groups.Items.Add(items);
            }
            //-------------------------------------------------------
            List<string> Temp_FromCalendarPass = new List<string>();
            IEnumerable<string> Temp_ToComboBoxPass = Temp_FromCalendarPass.Distinct();
            foreach (var calendar in Calendars)
            {
                var temp = calendar.ItemName;
                Temp_FromCalendarPass.Add(temp);
            }
            foreach (var items in Temp_ToComboBoxPass)
            {
                guna2ComboBox_AbsenceSubject.Items.Add(items);
            }

            List<string> Temp_FromGroupPass = new List<string>();
            IEnumerable<string> Temp_ToGroupPass = Temp_FromGroupPass.Distinct();
            foreach (var calendar in Calendars)
            {
                var temp = calendar.GroupName;
                Temp_FromGroupPass.Add(temp);
            }
            foreach (var items in Temp_ToGroupPass)
            {
                guna2ComboBox_AbsenceGroups.Items.Add(items);
            }
            //-------------------------------------------------------
            List<string> Temp_FromSemester = new List<string>();
            IEnumerable<string> Temp_ToComboBoxSemester = Temp_FromSemester.Distinct();
            foreach (var semester in Semesters)
            {
                var temp = semester.ItemName;
                Temp_FromSemester.Add(temp);
            }
            foreach (var items in Temp_ToComboBoxSemester)
            {
                guna2ComboBox_SemesterItem.Items.Add(items);
            }

            List<string> Temp_FromSemesterGroup = new List<string>();
            IEnumerable<string> Temp_SemesterToGroup = Temp_FromSemesterGroup.Distinct();
            foreach (var calendar in Calendars)
            {
                var temp = calendar.GroupName;
                Temp_FromSemesterGroup.Add(temp);
            }
            foreach (var items in Temp_SemesterToGroup)
            {
                guna2ComboBox_SemesterGroups.Items.Add(items);
            }
            //-------------------------------------------------------
            List<string> From_TeacherNameStudent = new List<string>();
            IEnumerable<string> Temp_ToTeacherNameStudent = From_TeacherNameStudent.Distinct();
            foreach (var calendar in Calendars)
            {
                var temp = calendar.GroupName;
                From_TeacherNameStudent.Add(temp);
            }
            foreach (var items in Temp_ToTeacherNameStudent)
            {
                guna2ComboBox_GroupsForStudent.Items.Add(items);
            }
            //-------------------------------------------------------
            for (int i = 1; i <= 31; i++)
            {
                guna2ComboBox_Days.Items.Add("Day " + Convert.ToString(i));
            }

            for (int i = 1; i <= 31; i++)
            {
                guna2ComboBox_AbsenceDays.Items.Add("Day " + Convert.ToString(i));
            }
            //-------------------------------------------------------
        }

        private void guna2ComboBox_SemesterStudent_Initialize()
        {
            string temp = Semesters[0].LastName + " " + Semesters[0].FirstName;
            for (int i = 0; i < Semesters.Count; i++)
            {
                temp = Semesters[i].LastName + " " + Semesters[i].FirstName;
                if (Semesters[i].GroupName == guna2ComboBox_SemesterGroups.SelectedItem.ToString().Trim())
                {
                    if (!guna2ComboBox_SemesterStudent.Items.Contains(temp))
                    {
                        guna2ComboBox_SemesterStudent.Items.Add(temp);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private void guna2ComboBox_Students_Initialize()
        {
            string temp = Calendars[0].LastName + " " + Calendars[0].FirstName;
            for (int i = 0; i < Calendars.Count; i++)
            {
                temp = Calendars[i].LastName + " " + Calendars[i].FirstName;
                if (Calendars[i].GroupName == guna2ComboBox_Groups.SelectedItem.ToString().Trim())
                {
                    if (!guna2ComboBox_Students.Items.Contains(temp))
                    {
                        guna2ComboBox_Students.Items.Add(temp);                        
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private void guna2ComboBox_AbsenceStudents_Initialize()
        {
            string temp = Calendarpasses[0].LastName + " " + Calendarpasses[0].FirstName;
            for (int i = 0; i < Calendarpasses.Count; i++)
            {
                temp = Calendarpasses[i].LastName + " " + Calendarpasses[i].FirstName;
                if (Calendarpasses[i].GroupName == guna2ComboBox_AbsenceGroups.SelectedItem.ToString().Trim())
                {
                    if (!guna2ComboBox_AbsenceStudent.Items.Contains(temp))
                    {
                        guna2ComboBox_AbsenceStudent.Items.Add(temp);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private string GetAge(string dateOfBirth)
        {
            string[] temp = dateOfBirth.Split('.');
            int day = Convert.ToInt32(temp[0]);
            int month = Convert.ToInt32(temp[1]);
            int year = Convert.ToInt32(temp[2]);
            DateTime today = DateTime.Today;
            int a = (today.Year * 100 + today.Month) * 100 + today.Day;
            int b = (year * 100 + month) * 100 + day;
            return Convert.ToString((a - b) / 10000);
        }

        private void guna2ImageButton_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ImageButton_Close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Вы действительно хотите выйти?\n Вас перекинет на экран входа.",
        "Предупреждение",
        MessageBoxButtons.OKCancel,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {
                Form_Login form_Login = new Form_Login();
                form_Login.Show();
                this.Close();
            }
            if (result == DialogResult.Cancel)
            {
                this.TopMost = true;

            }
        }

        private void учебники1011КлассToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://drive.google.com/drive/folders/1lhwhw2iAxdBCPkNvJQn6W9W1DDzTqhGg");
        }

        private void электронныеИзданияПоСпецДисциплинамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://drive.google.com/drive/folders/16215EwZ_M2F6cr3lL1Ugw9kU7SdD82Vs");
        }

        private void дополнительнаяЛитератураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://drive.google.com/drive/folders/17CGHTlI1ztYb_EmoC7lyrlU4CoqltyRH/");
        }

        private void национальнаяЭлектроннаяБиблиотекаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://kazneb.kz/");
        }

        private void guna2ComboBox_Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox_Month.SelectedIndex != -1)
            {
                MonthIndex = guna2ComboBox_Month.SelectedIndex;
                MonthValue = guna2ComboBox_Month.Items[MonthIndex].ToString().Trim();
            }
        }

        private void guna2ComboBox_Subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox_Subject.SelectedIndex != -1)
            {
                SubjectIndex = guna2ComboBox_Subject.SelectedIndex;
                SubjectValue = guna2ComboBox_Subject.Items[SubjectIndex].ToString().Trim();
            }
        }

        private void guna2Button_Search_Click(object sender, EventArgs e)
        {

            if (guna2ComboBox_Month.SelectedItem != null && guna2ComboBox_Subject.SelectedItem != null && guna2ComboBox_Groups.SelectedItem != null)
            {
                //guna2ComboBox_Students.Items.Clear();
                var query =
                    (from calendar in Calendars
                     where (calendar.ItemName == SubjectValue) && (calendar.Month == MonthValue) && (calendar.GroupName == GroupValue)
                     select new
                     {
                         ФИО_студента = calendar.LastName + " " + calendar.FirstName + " " + calendar.MiddleName,
                         Предмет = calendar.ItemName,
                         День1 = calendar.Day1,
                         День2 = calendar.Day2,
                         День3 = calendar.Day3,
                         День4 = calendar.Day4,
                         День5 = calendar.Day5,
                         День6 = calendar.Day6,
                         День7 = calendar.Day7,
                         День8 = calendar.Day8,
                         День9 = calendar.Day9,
                         День10 = calendar.Day10,
                         День11 = calendar.Day11,
                         День12 = calendar.Day12,
                         День13 = calendar.Day13,
                         День14 = calendar.Day14,
                         День15 = calendar.Day15,
                         День16 = calendar.Day16,
                         День17 = calendar.Day17,
                         День18 = calendar.Day18,
                         День19 = calendar.Day19,
                         День20 = calendar.Day20,
                         День21 = calendar.Day21,
                         День22 = calendar.Day22,
                         День23 = calendar.Day23,
                         День24 = calendar.Day24,
                         День25 = calendar.Day25,
                         День26 = calendar.Day26,
                         День27 = calendar.Day27,
                         День28 = calendar.Day28,
                         День29 = calendar.Day29,
                         День30 = calendar.Day30,
                         День31 = calendar.Day31,
                         Итоговая = calendar.GiveResult(),
                     }).ToList();

                dataGridView_Marks.DataSource = query;
                if (guna2ComboBox_Groups.SelectedIndex != -1)
                {
                    guna2ComboBox_Students_Initialize();
                }
            }
            else
            {
                MessageBox.Show("Выберите предмет, месяц и группу!");
            }
        }

        private void guna2ComboBox_Groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox_Groups.SelectedIndex != -1)
            {
                GroupIndex = guna2ComboBox_Groups.SelectedIndex;
                GroupValue = guna2ComboBox_Groups.Items[GroupIndex].ToString().Trim();
                guna2ComboBox_Students_Initialize();
            }
        }

        private void guna2Button_Clear_Click(object sender, EventArgs e)
        {
            dataGridView_Marks.DataSource = null;
            guna2ComboBox_Month.SelectedItem = null;
            guna2ComboBox_Subject.SelectedItem = null;
            guna2ComboBox_Groups.SelectedItem = null;
            guna2ComboBox_ListMarks.SelectedItem = null;
            guna2ComboBox_Students.SelectedItem = null;
            guna2ComboBox_Days.SelectedItem = null;
            guna2ShadowPanel_Edit.Enabled = false;
            guna2ComboBox_Students.Items.Clear();
        }

        private void guna2Button_SemesterSearch_Click(object sender, EventArgs e)
        {
            guna2ComboBox_SemesterStudent.Items.Clear();
            if (guna2ComboBox_SemesterCount.SelectedItem != null && guna2ComboBox_SemesterItem.SelectedItem != null && guna2ComboBox_SemesterGroups.SelectedItem != null)
            {
                var query =
                    (from semester in Semesters
                     where (semester.ItemName == SemesterSubject) && (semester.Semester == SemesterMonth && (semester.GroupName == SemesterGroupValue))
                     select new
                     {
                         ФИО_студента = semester.LastName + " " + semester.FirstName + " " + semester.MiddleName,
                         Предмет = semester.ItemName,
                         Семестр = semester.Semester,
                         Оценка_за_месяцы = semester.GiveMonthlyEstimate(Calendars),
                         Зачетная_работа = semester.CreditWork,
                         Итоговая = semester.GiveResult(Calendars),
                     }).ToList();

                dataGridView_Semester.DataSource = query;
            }
            else
            {
                MessageBox.Show("Выберите предмет, семестр и группу!");
            }
            if (guna2ComboBox_SemesterGroups.SelectedIndex != -1)
            {
                guna2ComboBox_SemesterStudent_Initialize();
            }
        }

        private void guna2Button_SemestrClear_Click(object sender, EventArgs e)
        {
            dataGridView_Semester.DataSource = null;
            guna2ComboBox_SemesterItem.SelectedItem = null;
            guna2ComboBox_SemesterCount.SelectedItem = null;
            guna2ComboBox_SemesterGroups.SelectedItem = null;
            guna2ComboBox_SemesterMarks.SelectedItem = null;
            guna2ComboBox_SemesterStudent.SelectedItem = null;
            guna2ShadowPanel_SemesterEdit.Enabled = false;
            guna2TextBox_History.Clear();
            guna2ComboBox_SemesterStudent.Items.Clear();
        }

        private void guna2ComboBox_SemesterCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox_SemesterCount.SelectedIndex != -1)
            {
                SemesterMonthIndex = guna2ComboBox_SemesterCount.SelectedIndex;
                SemesterMonth = guna2ComboBox_SemesterCount.Items[SemesterMonthIndex].ToString().Trim();
            }
        }

        private void guna2ComboBox_SemesterItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox_SemesterItem.SelectedIndex != -1)
            {
                SemesterIndex = guna2ComboBox_SemesterItem.SelectedIndex;
                SemesterSubject = guna2ComboBox_SemesterItem.Items[SemesterIndex].ToString().Trim();
            }
        }

        private void guna2ComboBox_SemesterGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox_SemesterGroups.SelectedIndex != -1)
            {
                SemesterGroupIndex = guna2ComboBox_SemesterGroups.SelectedIndex;
                SemesterGroupValue = guna2ComboBox_SemesterGroups.Items[SemesterGroupIndex].ToString().Trim();
                guna2ComboBox_SemesterStudent_Initialize();
            }
        }

        private void guna2Button_Solve_Click(object sender, EventArgs e)
        {
            try
            {
                double month = Convert.ToDouble(guna2TextBox_Month.Text);
                double control = Convert.ToDouble(guna2TextBox_ControlWork.Text);
                if (month <= 100 && month >= 0 && control <= 100 && control >= 0)
                {
                    int result = Convert.ToInt32(month * 0.6 + control * 0.4);
                    guna2TextBox_Answer.Text = Convert.ToString(result);
                    History = $"{month} * 0.6 + {control} * 0.4 = {result}" + Environment.NewLine;
                    guna2TextBox_History.Text += History;
                }
                else
                {
                    MessageBox.Show("Оценки должны быть в диапазоне от 0 до 100");
                }
            }
            catch (Exception except)
            {
                except.ToString();
                MessageBox.Show("Убедитесь, что вы ввели именно оценки!");
            }
        }

        private void guna2Button_CalcClear_Click(object sender, EventArgs e)
        {
            guna2TextBox_Month.Clear();
            guna2TextBox_ControlWork.Clear();
            guna2TextBox_Answer.Clear();
        }

        private void guna2Button_EditEnable_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox_Month.SelectedItem != null && guna2ComboBox_Subject.SelectedItem != null && guna2ComboBox_Groups.SelectedItem != null)
            {
                if (guna2ShadowPanel_Edit.Enabled)
                {
                    guna2ShadowPanel_Edit.Enabled = false;
                }
                else if (!guna2ShadowPanel_Edit.Enabled)
                {
                    guna2ShadowPanel_Edit.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Выберите предмет, месяц и группу!");
            }

        }

        private void guna2Button_EditClear_Click(object sender, EventArgs e)
        {
            guna2ComboBox_ListMarks.SelectedItem = null;
            guna2ComboBox_Students.SelectedItem = null;
            guna2ComboBox_Days.SelectedItem = null;
        }

        private void guna2Button_SubmitMark_Click(object sender, EventArgs e)
        {
            string[] temp = new string[2];
            int number;
            if (guna2ComboBox_ListMarks.SelectedItem != null && guna2ComboBox_Students.SelectedItem != null && guna2ComboBox_Days.SelectedItem != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите сохранить значения?", "Подтвердить", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    using (KundelikContext db = new KundelikContext())
                    {
                        foreach (Calendar c in Calendars)
                        {
                            if (c.GroupName == guna2ComboBox_Groups.SelectedItem.ToString().Trim())
                            {
                                if ((c.LastName + " " + c.FirstName) == (guna2ComboBox_Students.SelectedItem.ToString().Trim()))
                                {
                                    if (c.Month == guna2ComboBox_Month.SelectedItem.ToString().Trim())
                                    {
                                        if (c.ItemName == guna2ComboBox_Subject.SelectedItem.ToString().Trim())
                                        {
                                            temp = guna2ComboBox_Days.SelectedItem.ToString().Split(' ');
                                            number = Convert.ToInt32(temp[1]);
                                            switch (number)
                                            {
                                                case 1:
                                                    c.Day1 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 2:
                                                    c.Day2 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 3:
                                                    c.Day3 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 4:
                                                    c.Day4 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 5:
                                                    c.Day5 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 6:
                                                    c.Day6 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 7:
                                                    c.Day7 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 8:
                                                    c.Day8 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 9:
                                                    c.Day9 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 10:
                                                    c.Day10 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 11:
                                                    c.Day11 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 12:
                                                    c.Day12 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 13:
                                                    c.Day13 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 14:
                                                    c.Day14 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 15:
                                                    c.Day15 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 16:
                                                    c.Day16 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 17:
                                                    c.Day17 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 18:
                                                    c.Day18 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 19:
                                                    c.Day19 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 20:
                                                    c.Day20 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 21:
                                                    c.Day21 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 22:
                                                    c.Day22 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 23:
                                                    c.Day23 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 24:
                                                    c.Day24 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 25:
                                                    c.Day25 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 26:
                                                    c.Day26 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 27:
                                                    c.Day27 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 28:
                                                    c.Day28 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 29:
                                                    c.Day29 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 30:
                                                    c.Day30 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 31:
                                                    c.Day31 = guna2ComboBox_ListMarks.SelectedItem.ToString();
                                                    db.Calendar.Update(c);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                default:
                                                    MessageBox.Show("Ошибка обновления оценки!");
                                                    break;
                                            }
                                            db.SaveChanges();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите все поля в редакторе оценок!");
            }
        }

        private void guna2Button_SemesterEnableEdit_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox_SemesterGroups.SelectedItem != null && guna2ComboBox_SemesterCount.SelectedItem != null && guna2ComboBox_SemesterItem.SelectedItem != null)
            {
                if (guna2ShadowPanel_SemesterEdit.Enabled)
                {
                    guna2ShadowPanel_SemesterEdit.Enabled = false;
                }
                else if (!guna2ShadowPanel_SemesterEdit.Enabled)
                {
                    guna2ShadowPanel_SemesterEdit.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Выберите предмет, семестр и группу!");
            }
        }

        private void guna2Button_SemesterEditClear_Click(object sender, EventArgs e)
        {
            guna2ComboBox_SemesterMarks.SelectedItem = null;
            guna2ComboBox_SemesterStudent.SelectedItem = null;
           
        }

        private void guna2Button_SemesterSubmit_Click(object sender, EventArgs e)
        {
            string[] temp = new string[2];
            int number;
            if (guna2ComboBox_SemesterCount.SelectedItem != null && guna2ComboBox_SemesterItem.SelectedItem != null && guna2ComboBox_SemesterGroups.SelectedItem != null)
            {
                if (guna2ComboBox_SemesterMarks.SelectedItem != null && guna2ComboBox_SemesterStudent.SelectedItem != null)
                {
                    if (MessageBox.Show("Вы уверены, что хотите сохранить значения?", "Подтвердить", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        using (KundelikContext db = new KundelikContext())
                        {
                            foreach (Semesterassessment s in Semesters)
                            {
                                if (s.GroupName == guna2ComboBox_SemesterGroups.SelectedItem.ToString().Trim())
                                {
                                    if ((s.LastName + " " + s.FirstName) == (guna2ComboBox_SemesterStudent.SelectedItem.ToString().Trim()))
                                    {
                                        if (s.Semester == guna2ComboBox_SemesterCount.SelectedItem.ToString().Trim())
                                        {
                                            if (s.ItemName == guna2ComboBox_SemesterItem.SelectedItem.ToString().Trim())
                                            {
                                                number = Convert.ToInt32(guna2ComboBox_SemesterCount.SelectedItem);
                                                switch (number)
                                                {
                                                    case 1:
                                                        s.CreditWork = guna2ComboBox_SemesterMarks.SelectedItem.ToString();
                                                        db.Semesterassessment.Update(s);
                                                        MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                        break;
                                                    case 2:
                                                        s.CreditWork = guna2ComboBox_SemesterMarks.SelectedItem.ToString();
                                                        db.Semesterassessment.Update(s);
                                                        MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                        break;
                                                    default:
                                                        MessageBox.Show("Ошибка обновления оценки!");
                                                        break;
                                                }
                                                db.SaveChanges();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите все поля в редакторе оценок!");
                }
            }
            else
            {
                MessageBox.Show("Выберите все поля в редакторе оценок!");
            }
        }

        private void guna2ComboBox_StudentsTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox_StudentsTeacher.SelectedIndex != -1)
            {
                StudentsName = guna2ComboBox_StudentsTeacher.SelectedItem.ToString().Trim();
            }
        }

        private void guna2Button_StudentSearch_Click(object sender, EventArgs e)
        {
            if ((guna2ComboBox_StudentsTeacher.SelectedItem != null && guna2ComboBox_GroupsForStudent.SelectedItem != null) && guna2ComboBox_StudentsTeacher.Enabled == true)
            {
                var query =
                    (from person in Peoples
                     where (person.LastName + " " + person.FirstName) == (guna2ComboBox_StudentsTeacher.SelectedItem.ToString().Trim())
                     select new
                     {
                         ФИО = person.LastName + " " + person.FirstName + " " + person.MiddleName,
                         Дата_рождения = person.Birth,
                         Пол = person.Gender,
                         Возраст = GetAge(person.Birth),
                         Национальность = person.Nationality,
                         Телефон = person.Phone,
                         Адрес = person.Address,
                         ИИН = person.Iin + " " + person.Certificates,
                     }).ToList();

                dataGridView_Students.DataSource = query;
            }
            else
            {
                MessageBox.Show("Выберите студента!");
            }
        }

        private void guna2Button_StudentsClear_Click(object sender, EventArgs e)
        {
            dataGridView_Students.DataSource = null;
            guna2ComboBox_StudentsTeacher.Items.Clear();
            guna2ComboBox_StudentsTeacher.SelectedItem = null;
            guna2ComboBox_GroupsForStudent.SelectedItem = null;
            guna2ComboBox_StudentsTeacher.Enabled = false;
        }

        private void guna2ComboBox_GroupsForStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string temp;
            if (guna2ComboBox_GroupsForStudent.SelectedIndex != -1)
            {
                temp = Calendars[0].LastName + " " + Calendars[0].FirstName;
                for (int i = 0; i < Calendars.Count; i++)
                {
                    temp = Calendars[i].LastName + " " + Calendars[i].FirstName;
                    if (Calendars[i].GroupName == guna2ComboBox_GroupsForStudent.SelectedItem.ToString().Trim())
                    {
                        if (!guna2ComboBox_StudentsTeacher.Items.Contains(temp))
                        {
                            guna2ComboBox_StudentsTeacher.Items.Add(temp);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            guna2ComboBox_StudentsTeacher.Enabled = true;
        }

        private void guna2ComboBox_AbsenceMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox_AbsenceMonth.SelectedIndex != -1)
            {
                AbsenceMonthIndex = guna2ComboBox_AbsenceMonth.SelectedIndex;
                AbsenceMonthValue = guna2ComboBox_AbsenceMonth.Items[AbsenceMonthIndex].ToString().Trim();
            }
        }

        private void guna2ComboBox_AbsenceSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox_AbsenceSubject.SelectedIndex != -1)
            {
                AbsenceSubjectIndex = guna2ComboBox_AbsenceSubject.SelectedIndex;
                AbsenceSubjectValue = guna2ComboBox_AbsenceSubject.Items[AbsenceSubjectIndex].ToString().Trim();
            }
        }
        private void guna2Button_AbsenceSearch_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox_AbsenceMonth.SelectedItem != null && guna2ComboBox_AbsenceSubject.SelectedItem != null && guna2ComboBox_AbsenceGroups.SelectedItem != null)
            {
                //guna2ComboBox_AbsenceStudent.Items.Clear();
                var query =
                    (from calendarPass in Calendarpasses
                     where (calendarPass.ItemName == AbsenceSubjectValue) && (calendarPass.Month == AbsenceMonthValue) && (calendarPass.GroupName == AbsenceGroupValue)
                     select new
                     {
                         ФИО_студента = calendarPass.LastName + " " + calendarPass.FirstName + " " + calendarPass.MiddleName,
                         Предмет = calendarPass.ItemName,
                         День1 = calendarPass.Day1,
                         День2 = calendarPass.Day2,
                         День3 = calendarPass.Day3,
                         День4 = calendarPass.Day4,
                         День5 = calendarPass.Day5,
                         День6 = calendarPass.Day6,
                         День7 = calendarPass.Day7,
                         День8 = calendarPass.Day8,
                         День9 = calendarPass.Day9,
                         День10 = calendarPass.Day10,
                         День11 = calendarPass.Day11,
                         День12 = calendarPass.Day12,
                         День13 = calendarPass.Day13,
                         День14 = calendarPass.Day14,
                         День15 = calendarPass.Day15,
                         День16 = calendarPass.Day16,
                         День17 = calendarPass.Day17,
                         День18 = calendarPass.Day18,
                         День19 = calendarPass.Day19,
                         День20 = calendarPass.Day20,
                         День21 = calendarPass.Day21,
                         День22 = calendarPass.Day22,
                         День23 = calendarPass.Day23,
                         День24 = calendarPass.Day24,
                         День25 = calendarPass.Day25,
                         День26 = calendarPass.Day26,
                         День27 = calendarPass.Day27,
                         День28 = calendarPass.Day28,
                         День29 = calendarPass.Day29,
                         День30 = calendarPass.Day30,
                         День31 = calendarPass.Day31,
                         Все_пропуски = calendarPass.GiveResult(),
                     }).ToList();

                dataGridView_Absence.DataSource = query;
                if (guna2ComboBox_AbsenceGroups.SelectedIndex != -1)
                {
                    guna2ComboBox_AbsenceStudents_Initialize();
                }
            }
            else
            {
                MessageBox.Show("Выберите предмет, месяц и группу!");
            }
        }

        private void guna2ComboBox_AbsenceGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox_AbsenceGroups.SelectedIndex != -1)
            {
                AbsenceGroupIndex = guna2ComboBox_AbsenceGroups.SelectedIndex;
                AbsenceGroupValue = guna2ComboBox_AbsenceGroups.Items[AbsenceGroupIndex].ToString().Trim();
                guna2ComboBox_AbsenceStudents_Initialize();
            }
        }

        private void guna2Button_AbsenceEditSubmit_Click(object sender, EventArgs e)
        {
            string[] temp = new string[2];
            int number;
            if (guna2ComboBox_AbsenceReason.SelectedItem != null && guna2ComboBox_AbsenceStudent.SelectedItem != null && guna2ComboBox_AbsenceDays.SelectedItem != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите сохранить значения?", "Подтвердить", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    using (KundelikContext db = new KundelikContext())
                    {
                        foreach (Calendarpass cp in Calendarpasses)
                        {
                            if (cp.GroupName == guna2ComboBox_AbsenceGroups.SelectedItem.ToString().Trim())
                            {
                                if ((cp.LastName + " " + cp.FirstName) == (guna2ComboBox_AbsenceStudent.SelectedItem.ToString().Trim()))
                                {
                                    if (cp.Month == guna2ComboBox_AbsenceMonth.SelectedItem.ToString().Trim())
                                    {
                                        if (cp.ItemName == guna2ComboBox_AbsenceSubject.SelectedItem.ToString().Trim())
                                        {
                                            temp = guna2ComboBox_AbsenceDays.SelectedItem.ToString().Split(' ');
                                            number = Convert.ToInt32(temp[1]);
                                            switch (number)
                                            {
                                                case 1:
                                                    cp.Day1 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 2:
                                                    cp.Day2 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 3:
                                                    cp.Day3 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 4:
                                                    cp.Day4 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 5:
                                                    cp.Day5 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 6:
                                                    cp.Day6 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 7:
                                                    cp.Day7 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 8:
                                                    cp.Day8 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 9:
                                                    cp.Day9 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 10:
                                                    cp.Day10 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 11:
                                                    cp.Day11 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 12:
                                                    cp.Day12 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 13:
                                                    cp.Day13 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 14:
                                                    cp.Day14 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 15:
                                                    cp.Day15 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 16:
                                                    cp.Day16 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 17:
                                                    cp.Day17 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 18:
                                                    cp.Day18 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 19:
                                                    cp.Day19 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 20:
                                                    cp.Day20 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 21:
                                                    cp.Day21 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 22:
                                                    cp.Day22 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 23:
                                                    cp.Day23 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 24:
                                                    cp.Day24 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 25:
                                                    cp.Day25 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 26:
                                                    cp.Day26 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 27:
                                                    cp.Day27 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 28:
                                                    cp.Day28 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 29:
                                                    cp.Day29 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 30:
                                                    cp.Day30 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                case 31:
                                                    cp.Day31 = guna2ComboBox_AbsenceReason.SelectedItem.ToString();
                                                    db.Calendarpass.Update(cp);
                                                    MessageBox.Show("Данные успешно добавлены! Нажмите кнопку Найти/Обновить, чтобы увидеть обновленные данные.", "Успех!");
                                                    break;
                                                default:
                                                    MessageBox.Show("Ошибка обновления пропуска!");
                                                    break;
                                            }
                                            db.SaveChanges();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите все поля в редакторе пропусков!");
            }
        }

        private void guna2Button_AbsenceEditClear_Click(object sender, EventArgs e)
        {
            guna2ComboBox_AbsenceReason.SelectedItem = null;
            guna2ComboBox_AbsenceStudent.SelectedItem = null;
            guna2ComboBox_AbsenceDays.SelectedItem = null;
        }

        private void guna2Button_AbsenceClear_Click(object sender, EventArgs e)
        {
            dataGridView_Absence.DataSource = null;
            guna2ComboBox_AbsenceMonth.SelectedItem = null;
            guna2ComboBox_AbsenceSubject.SelectedItem = null;
            guna2ComboBox_AbsenceGroups.SelectedItem = null;
            guna2ComboBox_AbsenceReason.SelectedItem = null;
            guna2ComboBox_AbsenceStudent.SelectedItem = null;
            guna2ComboBox_AbsenceDays.SelectedItem = null;
            guna2ShadowPanel_AbsenceEdit.Enabled = false;
            guna2ComboBox_AbsenceStudent.Items.Clear();
        }

        private void guna2Button_AbsenceEditOn_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox_AbsenceMonth.SelectedItem != null && guna2ComboBox_AbsenceSubject.SelectedItem != null && guna2ComboBox_AbsenceGroups.SelectedItem != null)
            {
                if (guna2ShadowPanel_AbsenceEdit.Enabled)
                {
                    guna2ShadowPanel_AbsenceEdit.Enabled = false;
                }
                else if (!guna2ShadowPanel_AbsenceEdit.Enabled)
                {
                    guna2ShadowPanel_AbsenceEdit.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Выберите предмет, месяц и группу!");
            }
        }
    }
}
