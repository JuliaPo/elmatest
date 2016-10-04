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
using CalcLog;


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
            var methods = Calc.GetType().GetMethods();
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

            rtbHistory.Text = Writer.ReadHistory().ToString();
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

            if (!int.TryParse(txtX.Text, out x))
            {
                x = 10;
            }

            y = int.Parse(txtY.Text);


            //magic

            var calcType = Calc.GetType();
            var method = calcType.GetMethod(ActiveOperation);

            var result = method.Invoke(Calc, new object[] { x, y });
            //Calc.Sum(x, y);

            lblResult.Text = result.ToString();

            string currentLine = string.Format("{0} {1} {2} = {3}{4}", x, ActiveOperation, y, result, Environment.NewLine);
            rtbHistory.Text += currentLine;
            this.Writer.WriteHistory(currentLine);
            
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
