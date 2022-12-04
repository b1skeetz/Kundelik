using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Zhurnal
{
    public partial class Form_Student : Form
    {
        private People Human { get; set; }
        private List<Calendar> Calendars { get; set; }
        private List<Semesterassessment> Semesters { get; set; }
        private List<Teachers> Teachers { get; set; }
        private int MonthIndex { get; set; }
        private int SubjectIndex { get; set; }
        private int SemesterIndex { get; set; }
        private int SemesterMonthIndex { get; set; }
        KundelikContext KundelikContext { get; set; }
        private string MonthValue { get; set; }
        private string SubjectValue { get; set; }
        private string SemesterSubject { get; set; }
        private string SemesterMonth { get; set; }
        private string TeacherItemValue { get; set; }
        private string History { get; set; }

        public Form_Student(People human, List<Calendar> calendars, List<Semesterassessment> semesters, List<Teachers> teachers)
        {
            InitializeComponent();
            Human = human;
            Calendars = calendars;
            Semesters = semesters;
            Teachers = teachers;
            if (Directory.Exists(Directory.GetCurrentDirectory() + "/students/" + Human.Username + "/avatars/"))
            {
                string Path = Directory.GetCurrentDirectory() + "/students/" + Human.Username + "/avatars/";
                //guna2PictureBox_Avatar.Image = new Bitmap(Image.FromFile($"{Path}{Human.NameImg}"));
            }
            else
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/students/" + Human.Username + "/avatars/");
            }
            KundelikContext = new KundelikContext();

            foreach (Calendar c in Calendars)
            {
                using (KundelikContext db = new KundelikContext())
                {
                    if (c.Result == null)
                    {
                        c.Result = c.GiveResult();
                        db.Entry(c).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
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
        }

        private void Form_Student_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel_Welcome.Text = "Добро пожаловать, " + Human.FirstName + "!";
            guna2TextBox_FIO.Text = Human.LastName + " " + Human.FirstName + " " + Human.MiddleName;
            guna2TextBox_DateOfBirth.Text = Human.Birth;
            guna2TextBox_Gender.Text = Human.Gender;
            guna2TextBox_Age.Text = GetAge(Human.Birth);
            guna2TextBox_Nationality.Text = Human.Nationality;
            guna2TextBox_Phone.Text = Human.Phone;
            guna2TextBox_Address.Text = Human.Address;
            guna2TextBox_IIN.Text = Human.Iin + " " + Human.Certificates;
            guna2TextBox_Hobby.Text = Human.Hobby;
            guna2TextBox_Social.Text = Human.SocialStatus;
            guna2TextBox_WorkPlace.Text = Human.WorkPlace;
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
            List<string> Temp_FromTeacherSubject = new List<string>();
            IEnumerable<string> Temp_ToTeacherSubject = Temp_FromTeacherSubject.Distinct();
            foreach (var teacher in Teachers)
            {
                var temp = teacher.ItemName;
                Temp_FromTeacherSubject.Add(temp);
            }
            foreach (var items in Temp_ToTeacherSubject)
            {
                guna2ComboBox_TeacherSubject.Items.Add(items);
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
            chart_marks.Series[0].Points.Clear();
            if (guna2ComboBox_Month.SelectedItem != null && guna2ComboBox_Subject.SelectedItem != null)
            {
                var query =
                    (from calendar in Calendars
                     where (calendar.ItemName == SubjectValue) && (calendar.Month == MonthValue)
                     select new
                     {
                         Предмет = calendar.ItemName,
                         Месяц = calendar.Month,
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
                guna2HtmlLabel_Tip.Visible = false;

                for (int i = 2; i <= dataGridView_Marks.ColumnCount - 3; i++)
                {
                    chart_marks.Series[0].Points.AddXY(Convert.ToDouble(i - 1), Convert.ToDouble(dataGridView_Marks[i, 0].Value));
                }
                chart_marks.ChartAreas[0].AxisX.Interval = 1;
                chart_marks.ChartAreas[0].AxisY.Interval = 5;
                chart_marks.ChartAreas[0].AxisY.Maximum = 100;
                chart_marks.ChartAreas[0].AxisX.Minimum = 1;
                chart_marks.ChartAreas[0].AxisX.Maximum = 31;
                chart_marks.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chart_marks.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            }
            else if (guna2ComboBox_Month.SelectedItem == null && guna2ComboBox_Subject.SelectedItem != null)
            {
                var query =
                    (from calendar in Calendars
                     where calendar.ItemName == SubjectValue
                     select new
                     {
                         Предмет = calendar.ItemName,
                         Месяц = calendar.Month,
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
                         Итоговая = calendar.Result,
                     }).ToList();

                dataGridView_Marks.DataSource = query;
                guna2HtmlLabel_Tip.Visible = true;
            }
            else if (guna2ComboBox_Month.SelectedItem != null && guna2ComboBox_Subject.SelectedItem == null)
            {
                var query =
                    (from calendar in Calendars
                     where calendar.Month == MonthValue
                     select new
                     {
                         Предмет = calendar.ItemName,
                         Месяц = calendar.Month,
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
                         Итоговая = calendar.Result,
                     }).ToList();

                dataGridView_Marks.DataSource = query;
                guna2HtmlLabel_Tip.Visible = true;
            }
            else
            {
                MessageBox.Show("Выберите предмет и месяц!");
            }
        }

        private void guna2Button_Clear_Click(object sender, EventArgs e)
        {
            dataGridView_Marks.DataSource = null;
            guna2ComboBox_Month.SelectedItem = null;
            guna2ComboBox_Subject.SelectedItem = null;
            chart_marks.Series[0].Points.Clear();
            guna2HtmlLabel_Tip.Visible = false;
        }

        private void guna2Button_SemesterSearch_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox_SemesterCount.SelectedItem != null && guna2ComboBox_SemesterItem.SelectedItem != null)
            {
                var query =
                    (from semester in Semesters
                     where (semester.ItemName == SemesterSubject) && (semester.Semester == SemesterMonth)
                     select new
                     {
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
                MessageBox.Show("Выберите предмет и семестр!");
            }
        }

        private void guna2ComboBox_SemesterMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox_SemesterCount.SelectedIndex != -1)
            {
                SemesterMonthIndex = guna2ComboBox_SemesterCount.SelectedIndex;
                SemesterMonth = guna2ComboBox_SemesterCount.Items[SemesterMonthIndex].ToString().Trim();
            }
        }

        private void guna2ComboBox_Semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox_SemesterItem.SelectedIndex != -1)
            {
                SemesterIndex = guna2ComboBox_SemesterItem.SelectedIndex;
                SemesterSubject = guna2ComboBox_SemesterItem.Items[SemesterIndex].ToString().Trim();
            }
        }

        private void guna2Button_SemesterClear_Click(object sender, EventArgs e)
        {
            dataGridView_Semester.DataSource = null;
            guna2ComboBox_SemesterItem.SelectedItem = null;
            guna2ComboBox_SemesterCount.SelectedItem = null;
            guna2TextBox_History.Clear();
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
            catch(Exception except)
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

        private void guna2Button_TeacherSearch_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox_TeacherSubject.SelectedItem != null)
            {
                var query =
                    (from teacher in Teachers
                     where teacher.ItemName == TeacherItemValue
                     select new
                     {                         
                         Фамилия = teacher.LastName,
                         Имя = teacher.FirstName,
                         Отчество = teacher.MiddleName,
                         Предмет = teacher.ItemName,
                         Аудитория = teacher.Audience,
                     }).ToList();

                dataGridView_Teachers.DataSource = query;
            }
            else
            {
                MessageBox.Show("Выберите предмет преподавателя!");
            }
        }

        private void guna2ComboBox_TeacherSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox_TeacherSubject.SelectedIndex != -1)
            {
                TeacherItemValue = guna2ComboBox_TeacherSubject.Items[guna2ComboBox_TeacherSubject.SelectedIndex].ToString().Trim();
            }
        }

        private void guna2Button_TeacherClear_Click(object sender, EventArgs e)
        {
            dataGridView_Teachers.DataSource = null;
            guna2ComboBox_TeacherSubject.SelectedItem = null;
        }
    }
}
