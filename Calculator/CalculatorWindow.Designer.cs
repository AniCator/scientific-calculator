namespace Calculator
{
    partial class CalculatorWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.calculationLabel = new System.Windows.Forms.Label();
            this.calcResultLabel = new System.Windows.Forms.Label();
            this.buttonMemorySubtract = new System.Windows.Forms.Button();
            this.buttonMemoryAdd = new System.Windows.Forms.Button();
            this.buttonMemoryAssign = new System.Windows.Forms.Button();
            this.buttonMemoryRead = new System.Windows.Forms.Button();
            this.buttonMemoryClear = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.buttonSeven = new System.Windows.Forms.Button();
            this.buttonEight = new System.Windows.Forms.Button();
            this.buttonNine = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.buttonFour = new System.Windows.Forms.Button();
            this.buttonFive = new System.Windows.Forms.Button();
            this.buttonSix = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.buttonOne = new System.Windows.Forms.Button();
            this.buttonTwo = new System.Windows.Forms.Button();
            this.buttonThree = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.buttonZero = new System.Windows.Forms.Button();
            this.buttonPeriod = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.buttonEquals = new System.Windows.Forms.Button();
            this.debugBox = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.calculationLabel);
            this.panel1.Controls.Add(this.calcResultLabel);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 84);
            this.panel1.TabIndex = 0;
            // 
            // calculationLabel
            // 
            this.calculationLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculationLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.calculationLabel.Location = new System.Drawing.Point(3, 3);
            this.calculationLabel.Name = "calculationLabel";
            this.calculationLabel.Size = new System.Drawing.Size(529, 48);
            this.calculationLabel.TabIndex = 1;
            this.calculationLabel.Text = "0";
            this.calculationLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // calcResultLabel
            // 
            this.calcResultLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calcResultLabel.Location = new System.Drawing.Point(3, 51);
            this.calcResultLabel.Name = "calcResultLabel";
            this.calcResultLabel.Size = new System.Drawing.Size(529, 33);
            this.calcResultLabel.TabIndex = 0;
            this.calcResultLabel.Text = "0";
            this.calcResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonMemorySubtract
            // 
            this.buttonMemorySubtract.Location = new System.Drawing.Point(508, 103);
            this.buttonMemorySubtract.Name = "buttonMemorySubtract";
            this.buttonMemorySubtract.Size = new System.Drawing.Size(40, 32);
            this.buttonMemorySubtract.TabIndex = 1;
            this.buttonMemorySubtract.Text = "M-";
            this.buttonMemorySubtract.UseVisualStyleBackColor = true;
            this.buttonMemorySubtract.Click += new System.EventHandler(this.buttonMemorySubtract_Click);
            // 
            // buttonMemoryAdd
            // 
            this.buttonMemoryAdd.Location = new System.Drawing.Point(462, 103);
            this.buttonMemoryAdd.Name = "buttonMemoryAdd";
            this.buttonMemoryAdd.Size = new System.Drawing.Size(40, 32);
            this.buttonMemoryAdd.TabIndex = 2;
            this.buttonMemoryAdd.Text = "M+";
            this.buttonMemoryAdd.UseVisualStyleBackColor = true;
            this.buttonMemoryAdd.Click += new System.EventHandler(this.buttonMemoryAdd_Click);
            // 
            // buttonMemoryAssign
            // 
            this.buttonMemoryAssign.Location = new System.Drawing.Point(416, 103);
            this.buttonMemoryAssign.Name = "buttonMemoryAssign";
            this.buttonMemoryAssign.Size = new System.Drawing.Size(40, 32);
            this.buttonMemoryAssign.TabIndex = 3;
            this.buttonMemoryAssign.Text = "MS";
            this.buttonMemoryAssign.UseVisualStyleBackColor = true;
            this.buttonMemoryAssign.Click += new System.EventHandler(this.buttonMemoryAssign_Click);
            // 
            // buttonMemoryRead
            // 
            this.buttonMemoryRead.Location = new System.Drawing.Point(370, 103);
            this.buttonMemoryRead.Name = "buttonMemoryRead";
            this.buttonMemoryRead.Size = new System.Drawing.Size(40, 32);
            this.buttonMemoryRead.TabIndex = 4;
            this.buttonMemoryRead.Text = "MR";
            this.buttonMemoryRead.UseVisualStyleBackColor = true;
            this.buttonMemoryRead.Click += new System.EventHandler(this.buttonMemoryRead_Click);
            // 
            // buttonMemoryClear
            // 
            this.buttonMemoryClear.Location = new System.Drawing.Point(324, 103);
            this.buttonMemoryClear.Name = "buttonMemoryClear";
            this.buttonMemoryClear.Size = new System.Drawing.Size(40, 32);
            this.buttonMemoryClear.TabIndex = 5;
            this.buttonMemoryClear.Text = "MC";
            this.buttonMemoryClear.UseVisualStyleBackColor = true;
            this.buttonMemoryClear.Click += new System.EventHandler(this.buttomMemoryClear_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(324, 141);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(40, 32);
            this.button6.TabIndex = 10;
            this.button6.Text = "←";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(370, 141);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(40, 32);
            this.button7.TabIndex = 9;
            this.button7.Text = "CE";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.buttonClearEntry_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(416, 141);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(40, 32);
            this.buttonClear.TabIndex = 8;
            this.buttonClear.Text = "C";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(462, 141);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(40, 32);
            this.button9.TabIndex = 7;
            this.button9.Text = "+/-";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.buttonParseAndAddCalculation_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(508, 141);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(40, 32);
            this.button10.TabIndex = 6;
            this.button10.Text = "√";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.buttonParseAndAddCalculation_Click);
            // 
            // buttonSeven
            // 
            this.buttonSeven.Location = new System.Drawing.Point(324, 179);
            this.buttonSeven.Name = "buttonSeven";
            this.buttonSeven.Size = new System.Drawing.Size(40, 32);
            this.buttonSeven.TabIndex = 15;
            this.buttonSeven.Text = "7";
            this.buttonSeven.UseVisualStyleBackColor = true;
            this.buttonSeven.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // buttonEight
            // 
            this.buttonEight.Location = new System.Drawing.Point(370, 179);
            this.buttonEight.Name = "buttonEight";
            this.buttonEight.Size = new System.Drawing.Size(40, 32);
            this.buttonEight.TabIndex = 14;
            this.buttonEight.Text = "8";
            this.buttonEight.UseVisualStyleBackColor = true;
            this.buttonEight.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // buttonNine
            // 
            this.buttonNine.Location = new System.Drawing.Point(416, 179);
            this.buttonNine.Name = "buttonNine";
            this.buttonNine.Size = new System.Drawing.Size(40, 32);
            this.buttonNine.TabIndex = 13;
            this.buttonNine.Text = "9";
            this.buttonNine.UseVisualStyleBackColor = true;
            this.buttonNine.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(462, 179);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(40, 32);
            this.button14.TabIndex = 12;
            this.button14.Text = "/";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.buttonParseAndAddCalculation_Click);
            // 
            // button15
            // 
            this.button15.Enabled = false;
            this.button15.Location = new System.Drawing.Point(508, 179);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(40, 32);
            this.button15.TabIndex = 11;
            this.button15.Text = "%";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.buttonParseAndAddCalculation_Click);
            // 
            // buttonFour
            // 
            this.buttonFour.Location = new System.Drawing.Point(324, 217);
            this.buttonFour.Name = "buttonFour";
            this.buttonFour.Size = new System.Drawing.Size(40, 32);
            this.buttonFour.TabIndex = 20;
            this.buttonFour.Text = "4";
            this.buttonFour.UseVisualStyleBackColor = true;
            this.buttonFour.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // buttonFive
            // 
            this.buttonFive.Location = new System.Drawing.Point(370, 217);
            this.buttonFive.Name = "buttonFive";
            this.buttonFive.Size = new System.Drawing.Size(40, 32);
            this.buttonFive.TabIndex = 19;
            this.buttonFive.Text = "5";
            this.buttonFive.UseVisualStyleBackColor = true;
            this.buttonFive.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // buttonSix
            // 
            this.buttonSix.Location = new System.Drawing.Point(416, 217);
            this.buttonSix.Name = "buttonSix";
            this.buttonSix.Size = new System.Drawing.Size(40, 32);
            this.buttonSix.TabIndex = 18;
            this.buttonSix.Text = "6";
            this.buttonSix.UseVisualStyleBackColor = true;
            this.buttonSix.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(462, 217);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(40, 32);
            this.button19.TabIndex = 17;
            this.button19.Text = "*";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.buttonParseAndAddCalculation_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(508, 217);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(40, 32);
            this.button20.TabIndex = 16;
            this.button20.Text = "1/x";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.buttonParseAndAddCalculation_Click);
            // 
            // buttonOne
            // 
            this.buttonOne.Location = new System.Drawing.Point(324, 255);
            this.buttonOne.Name = "buttonOne";
            this.buttonOne.Size = new System.Drawing.Size(40, 32);
            this.buttonOne.TabIndex = 25;
            this.buttonOne.Text = "1";
            this.buttonOne.UseVisualStyleBackColor = true;
            this.buttonOne.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // buttonTwo
            // 
            this.buttonTwo.Location = new System.Drawing.Point(370, 255);
            this.buttonTwo.Name = "buttonTwo";
            this.buttonTwo.Size = new System.Drawing.Size(40, 32);
            this.buttonTwo.TabIndex = 24;
            this.buttonTwo.Text = "2";
            this.buttonTwo.UseVisualStyleBackColor = true;
            this.buttonTwo.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // buttonThree
            // 
            this.buttonThree.Location = new System.Drawing.Point(416, 255);
            this.buttonThree.Name = "buttonThree";
            this.buttonThree.Size = new System.Drawing.Size(40, 32);
            this.buttonThree.TabIndex = 23;
            this.buttonThree.Text = "3";
            this.buttonThree.UseVisualStyleBackColor = true;
            this.buttonThree.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(462, 255);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(40, 32);
            this.button24.TabIndex = 22;
            this.button24.Text = "-";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.buttonParseAndAddCalculation_Click);
            // 
            // buttonZero
            // 
            this.buttonZero.Location = new System.Drawing.Point(324, 293);
            this.buttonZero.Name = "buttonZero";
            this.buttonZero.Size = new System.Drawing.Size(86, 32);
            this.buttonZero.TabIndex = 30;
            this.buttonZero.Text = "0";
            this.buttonZero.UseVisualStyleBackColor = true;
            this.buttonZero.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // buttonPeriod
            // 
            this.buttonPeriod.Location = new System.Drawing.Point(416, 293);
            this.buttonPeriod.Name = "buttonPeriod";
            this.buttonPeriod.Size = new System.Drawing.Size(40, 32);
            this.buttonPeriod.TabIndex = 28;
            this.buttonPeriod.Text = ".";
            this.buttonPeriod.UseVisualStyleBackColor = true;
            this.buttonPeriod.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // button29
            // 
            this.button29.Location = new System.Drawing.Point(462, 293);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(40, 32);
            this.button29.TabIndex = 27;
            this.button29.Text = "+";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.buttonParseAndAddCalculation_Click);
            // 
            // buttonEquals
            // 
            this.buttonEquals.Location = new System.Drawing.Point(508, 255);
            this.buttonEquals.Name = "buttonEquals";
            this.buttonEquals.Size = new System.Drawing.Size(40, 70);
            this.buttonEquals.TabIndex = 26;
            this.buttonEquals.Text = "=";
            this.buttonEquals.UseVisualStyleBackColor = true;
            this.buttonEquals.Click += new System.EventHandler(this.buttonParseAndAddCalculation_Click);
            // 
            // debugBox
            // 
            this.debugBox.Location = new System.Drawing.Point(13, 349);
            this.debugBox.Multiline = true;
            this.debugBox.Name = "debugBox";
            this.debugBox.Size = new System.Drawing.Size(532, 92);
            this.debugBox.TabIndex = 31;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(278, 141);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(40, 32);
            this.button8.TabIndex = 32;
            this.button8.Text = ")";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.buttonParseAndAddCalculation_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(232, 141);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(40, 32);
            this.button11.TabIndex = 33;
            this.button11.Text = "(";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.buttonParseAndAddCalculation_Click);
            // 
            // CalculatorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 453);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.debugBox);
            this.Controls.Add(this.buttonZero);
            this.Controls.Add(this.buttonPeriod);
            this.Controls.Add(this.button29);
            this.Controls.Add(this.buttonEquals);
            this.Controls.Add(this.buttonOne);
            this.Controls.Add(this.buttonTwo);
            this.Controls.Add(this.buttonThree);
            this.Controls.Add(this.button24);
            this.Controls.Add(this.buttonFour);
            this.Controls.Add(this.buttonFive);
            this.Controls.Add(this.buttonSix);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.buttonSeven);
            this.Controls.Add(this.buttonEight);
            this.Controls.Add(this.buttonNine);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.buttonMemoryClear);
            this.Controls.Add(this.buttonMemoryRead);
            this.Controls.Add(this.buttonMemoryAssign);
            this.Controls.Add(this.buttonMemoryAdd);
            this.Controls.Add(this.buttonMemorySubtract);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "CalculatorWindow";
            this.Text = "Catorator | Calculator";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CalculatorWindow_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label calcResultLabel;
        private System.Windows.Forms.Button buttonMemorySubtract;
        private System.Windows.Forms.Button buttonMemoryAdd;
        private System.Windows.Forms.Button buttonMemoryAssign;
        private System.Windows.Forms.Button buttonMemoryRead;
        private System.Windows.Forms.Button buttonMemoryClear;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button buttonSeven;
        private System.Windows.Forms.Button buttonEight;
        private System.Windows.Forms.Button buttonNine;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button buttonFour;
        private System.Windows.Forms.Button buttonFive;
        private System.Windows.Forms.Button buttonSix;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button buttonOne;
        private System.Windows.Forms.Button buttonTwo;
        private System.Windows.Forms.Button buttonThree;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button buttonZero;
        private System.Windows.Forms.Button buttonPeriod;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button buttonEquals;
        private System.Windows.Forms.TextBox debugBox;
        private System.Windows.Forms.Label calculationLabel;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button11;
    }
}

