namespace Calculator
{
    partial class formCalculator
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCalc = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbHistory = new System.Windows.Forms.RichTextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(299, 13);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 0;
            this.btnCalc.Text = "calc";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtbHistory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 309);
            this.panel1.TabIndex = 1;
            // 
            // rtbHistory
            // 
            this.rtbHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbHistory.Location = new System.Drawing.Point(0, 162);
            this.rtbHistory.Name = "rtbHistory";
            this.rtbHistory.Size = new System.Drawing.Size(393, 147);
            this.rtbHistory.TabIndex = 0;
            this.rtbHistory.Text = "";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(13, 15);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(89, 20);
            this.txtX.TabIndex = 2;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(124, 15);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(89, 20);
            this.txtY.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(239, 18);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 13);
            this.lblResult.TabIndex = 5;
            // 
            // formCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 351);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCalc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formCalculator";
            this.Text = "Calculator";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtbHistory;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblResult;
    }
}

