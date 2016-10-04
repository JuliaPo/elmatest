using Calc;
using CalcHistory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Skype ava_var
namespace Calculator
{
    public partial class formCalculator : Form
    {
        private Helper Calc { get; set; }

        private string ActiveOperation { get; set; }

        private HistoryManager Writer { get; set; }


        public formCalculator()
        {
            InitializeComponent();
            Calc = new Helper();
            Writer = new HistoryManager();

            // получить все методы с Calc
            var methods = Calc.GetType().GetMethods(BindingFlags.DeclaredOnly | BindingFlags.CreateInstance | BindingFlags.Public);
            // ЦИКЛ по методам
            var count = 0;
            this.panel1.SuspendLayout();
            foreach (var m in methods)
            {
                // для каждого метода _ свой радио
                CreateRadioButton(m.Name, count++);
                //m.Name;
            }
            this.panel1.ResumeLayout();


            //проверяем историю
            if (File.Exists(@"C:/calcLog.txt"))
            {
                string[] tempHistory = Writer.ReadHistory().ToArray();
                for(int i = 0; i <tempHistory.Count(); i++)
                {
                    rtbHistory.Text += tempHistory[i] + Environment.NewLine;
                }
            }
        }
        private void CreateRadioButton(string Name, int index)
        {
            var rbBtn = new RadioButton();

            this.panel1.Controls.Add(rbBtn);


            rbBtn.AutoSize = true;
            rbBtn.Location = new System.Drawing.Point(12, 12 + index * 18);
            rbBtn.Name = "rbBtn" + index.ToString();
            rbBtn.Size = new System.Drawing.Size(53, 17);
            rbBtn.TabIndex = 5;
            rbBtn.TabStop = true;
            rbBtn.Tag = Name;
            rbBtn.Text = Name;
            rbBtn.UseVisualStyleBackColor = true;
            rbBtn.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
        }


        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb == null)
            {
                return;
            }
            ActiveOperation = rb.Tag.ToString();
        }

        private void btnCalc_Click_1(object sender, EventArgs e)
        {

            int x = 0;
            int y = 0;
            bool validX = true;
            bool validY = true;

            try
            {
                validX = true;
                txtX.BackColor = Color.White;
                x = int.Parse(txtX.Text);
            }

            catch (System.FormatException)
            {
                validX = false;
                txtX.BackColor = Color.Coral;
            }

            try
            {
                validY = true;
                txtY.BackColor = Color.White;
                y = int.Parse(txtY.Text);
            }

            catch (System.FormatException)
            {
                validY = false;
                txtY.BackColor = Color.Coral;
            }


            //magic
            if (validX && validY)
            {
                var calcType = Calc.GetType();
                var method = calcType.GetMethod(ActiveOperation);

                var result = method.Invoke(Calc, new object[] { x, y });
                //Calc.Sum(x, y);

                lblResult.Text = result.ToString();

                string currentLine = string.Format("{0} {1} {2} = {3}{4}", x, ActiveOperation, y, result, Environment.NewLine);
                rtbHistory.Text += currentLine;
                this.Writer.WriteHistory(currentLine);
            } else
            {
                lblResult.Text = "";
                if (!validX && !validY)
                {
                    string currentLine = "Values for X & Y are not valid" + Environment.NewLine;
                    rtbHistory.Text += currentLine;
                    this.Writer.WriteHistory(currentLine);
                }
                else
                {
                    if (!validX)
                    {
                        string currentLine = "Value for X is not valid" + Environment.NewLine;
                        rtbHistory.Text += currentLine;
                        this.Writer.WriteHistory(currentLine);
                    }
                    if (!validY)
                    {
                        string currentLine = "Value for Y is not valid" + Environment.NewLine;
                        rtbHistory.Text += currentLine;
                        this.Writer.WriteHistory(currentLine);
                    }
                }
            }
        }
    }
}
