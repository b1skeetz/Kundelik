using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zhurnal
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void guna2ImageButton_Close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Вы действительно хотите выйти?",
        "Предупреждение",
        MessageBoxButtons.OKCancel,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
            if (result == DialogResult.Cancel)
            {
                this.TopMost = true;

            }
        }

        private void guna2ImageButton_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void guna2Button_Enter_Click(object sender, EventArgs e)
        {
            using (KundelikContext db = new KundelikContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                var roles = db.Authorities.ToList();
                var people = db.People.ToList();
                var marks = db.Calendar.ToList();
                var semester = db.Semesterassessment.ToList();
                var teachers = db.Teachers.ToList();
                var calendarPass = db.Calendarpass.ToList();
                List<Calendar> calendars = new List<Calendar>();
                List<Semesterassessment> semesters = new List<Semesterassessment>();
                List<Calendarpass> calendarPasses = new List<Calendarpass>();
                foreach (Users u in users)
                {
                    if (guna2TextBox_Login.Text == u.Username && guna2TextBox_Password.Text == u.Password)
                    {
                        foreach (Authorities a in roles)
                        {
                            if (a.Username == u.Username)
                            {
                                foreach (People p in people)
                                {
                                    if (p.Username == u.Username)
                                    {
                                        var role = a.Authority;
                                        if (role == "ROLE_STUDENT")
                                        {
                                            guna2HtmlLabel_Welcome.Text = "Добро пожаловать!";
                                            guna2HtmlLabel_Error.Visible = false;
                                            foreach (Calendar c in marks)
                                            {
                                                if (c.Student == u.Username)
                                                {
                                                    calendars.Add(c);
                                                }
                                            }
                                            foreach (Semesterassessment s in semester)
                                            {
                                                if (s.Student == u.Username)
                                                {
                                                    semesters.Add(s);
                                                }
                                            }
                                            Form_Student form_Student = new Form_Student(p, calendars, semesters, teachers);
                                            form_Student.Show();
                                            this.Hide();
                                        }
                                        else if (role == "ROLE_TEACHER")
                                        {
                                            guna2HtmlLabel_Welcome.Text = "Добро пожаловать!";
                                            guna2HtmlLabel_Error.Visible = false;
                                            foreach (Calendar c in marks)
                                            {
                                                if (c.Teacher == p.Teacher)
                                                {
                                                    calendars.Add(c);
                                                }
                                            }
                                            foreach (Semesterassessment s in semester)
                                            {
                                                if (s.Teacher == p.Teacher)
                                                {
                                                    semesters.Add(s);
                                                }
                                            }
                                            foreach (Calendarpass cp in calendarPass)
                                            {
                                                if(cp.Teacher == p.Teacher)
                                                {
                                                    calendarPasses.Add(cp);
                                                }
                                            }
                                            Form_Teacher form_Teacher = new Form_Teacher(p, calendars, semesters, people, calendarPasses);
                                            form_Teacher.Show();
                                            this.Hide();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        guna2HtmlLabel_Error.Text = "Неверный логин или пароль!";
                        guna2HtmlLabel_Error.Visible = true;
                    }
                }
            }
        }
    }
}
