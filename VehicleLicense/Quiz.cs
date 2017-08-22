using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VehicleLicense
{
    public partial class Quiz : Form
    {
        public Quiz()
        {
            InitializeComponent();
            Clear();
            btnReport.Enabled = false;
            btnSubmit.Enabled = false;
        }

        int score = 0;
        int i = -1;
        int a = 0;

        string[] questions = new string[] { "1. What is the meaning of this Sign ?",
            "2. What is the meaning of this Sign ?", "3. What is the meaning of this Sign ?" };

        string[] answers = new string[] { "No U-Turn", "U_Turn", "Right Turn", "Left Turn",
            "One Way Street Sign","Two Way Street Sign","One Way Road","Two Way Road",
            "Right Lane Ends Sign","Middle Lane Ends Sign","Left Lane Ends Sign","Road Damaged Ahead"
        };

        string[] quizAnswers = new string[] { "No U-Turn",
            "Two Way Street Sign",
            "Left Lane Ends Sign"
        };



        string getSelectedAnswer()
        {
            if (radA.Checked)
                return radA.Text.ToString();
            if (radB.Checked)
                return radB.Text.ToString();
            if (radC.Checked)
                return radC.Text.ToString();
            if (radD.Checked)
                return radD.Text.ToString();
            return "";
        }

        public void Show()
        {
            lblQuestion.Visible = true;
            pictureBox1.Visible = true;
            radA.Visible = true;
            radB.Visible = true;
            radC.Visible = true;
            radD.Visible = true;
            //txtScore.Visible = true;
            lblScore.Visible = true;
        }

        public void Clear()
        {
            lblQuestion.Visible = false;
            pictureBox1.Visible = false;
            radA.Visible = false;
            radB.Visible = false;
            radC.Visible = false;
            radD.Visible = false;
            //txtScore.Visible = false;
            lblScore.Visible = false;
        }

        
        public void Picture()
        {
            if (questions[i] == "1. What is the meaning of this Sign ?")
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\user\Documents\Visual Studio 2015\Projects\VehicleLicense\no uturn.png");
            }
            else if (questions[i] == "2. What is the meaning of this Sign ?")
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\user\Documents\Visual Studio 2015\Projects\VehicleLicense\two way street sign.png");
            }
            else if (questions[i]== "3. What is the meaning of this Sign ?")
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\user\Documents\Visual Studio 2015\Projects\VehicleLicense\left-lane-ends-sign-x-w4-2l.png");
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = true;
            i++;
            Show();
            if (i < questions.Length)
            {


                //txtScore.Text = score.ToString();
                lblScore.Text = score.ToString();
                lblQuestion.Text = questions[i];
                Picture();
                //pictureBox1.Image = Image.FromFile(@"C:\Users\user\Desktop\Alum Night Pictures\11336857_1046530855377105_2077201697281755271_o.jpg");
                radA.Text = answers[a];    
                a++;
                radB.Text = answers[a];
                a++;
                radC.Text = answers[a];
                a++;
                radD.Text = answers[a];
                a++;

                btnStart.Visible = false;
                btnStart.Enabled = false;
                btnSubmit.Visible = true;
                btnSubmit.Enabled = true;


            }

            else
            {
                if (score > 1)
                {
                    btnReport.Enabled = true;
                    MessageBox.Show("Congratulations you have cleared the test\nYour Final Score is: " + score.ToString(), "Quiz Completed");
                    MessageBox.Show("Please Enter the Report button to get your Final Report!");
                }
                else
                {
                    MessageBox.Show("Your Final Score: " + score.ToString());
                    MessageBox.Show("You cannot get your License until you clear the Exam!","Try again Later!");
                    Application.Exit();
                }
                //MessageBox.Show("Completed");

                //this.Close();
                //Application.Exit();
            }

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (getSelectedAnswer().Equals(quizAnswers[i]))
            {
                MessageBox.Show("Correct");
                score++;
                lblScore.Text = Convert.ToString(score);
                btnSubmit.Enabled = false;
                btnSubmit.Visible = false;
                btnStart.Visible = true;
                btnStart.Enabled = true;
                btnStart.Text = "Next";
            }

            else
            {
                MessageBox.Show("Incorrect");
                score--;
                lblScore.Text = Convert.ToString(score);
                btnSubmit.Enabled = false;
                btnSubmit.Visible = false;
                btnStart.Visible = true;
                btnStart.Enabled = true;
                btnStart.Text = "Next";
            }
        }

        private void Quiz_Load(object sender, EventArgs e)
        {

        }

        private void txtScore_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rv.ShowDialog();
            this.Close();
        }
    }
}
