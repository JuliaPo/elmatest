using Calc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using History;

namespace WindowsFormsApplication1
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
            var methods = Calc.GetType().GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
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
            rtbHistory.Text = Writer.ReadHistory();
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


        private void btnCalc_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;

            //валидность текстбоксов
            bool xIsValid = true;
            bool yIsValid = true;

            //отлавливаем некорректный ввод параметров
            try
            {
                x = int.Parse(txtX.Text);
            }

            catch
            {
                xIsValid = false;
            }

            try
            {
                y = int.Parse(txtY.Text);
            }

            catch
            {
                yIsValid = false;
            }


            //magic

            var calcType = Calc.GetType();
            string currentLine = "";
            txtX.ForeColor = Color.Black;
            txtY.ForeColor = Color.Black;
            if (ActiveOperation != null)
            {
                var method = calcType.GetMethod(ActiveOperation);

                //текущая строка в истории
                var result = method.Invoke(Calc, new object[] { x, y });

                lblResult.Text = result.ToString();

                //без ошибок
                if (yIsValid && xIsValid)
                {
                    currentLine = string.Format("{0} {1} {2} = {3}\n", x, ActiveOperation, y, result);
                    rtbHistory.Text += currentLine;
                }
                //x и y не int
                else if (!yIsValid && !xIsValid)
                {
                    currentLine = string.Format("ERROR: X and Y are not valid\n");
                    rtbHistory.Text += currentLine;
                    txtX.ForeColor = Color.HotPink;
                    txtY.ForeColor = Color.HotPink;
                    lblResult.Text = "";
                }
                else
                {
                    if (xIsValid)
                    {
                        txtY.ForeColor = Color.HotPink;
                        currentLine = "ERROR: Y is not valid\n";
                        rtbHistory.Text += currentLine;
                        lblResult.Text = "";
                    }
                    else
                    {
                        txtX.ForeColor = Color.HotPink;
                        currentLine = "ERROR: X is not valid\n";
                        rtbHistory.Text += currentLine;
                        lblResult.Text = "";
                    }
                }
                this.Writer.WriteHistory(currentLine);
            } else
            {
                currentLine = string.Format("ERROR: Choose the operation firstly\n");
                rtbHistory.Text += currentLine;
                this.Writer.WriteHistory(currentLine);
            }
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
    }
}
