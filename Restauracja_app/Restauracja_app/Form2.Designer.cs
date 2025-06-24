
namespace Restauracja_app
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tableNumber = new TextBox();
            Handler = new TextBox();
            radioStatus1 = new RadioButton();
            radioStatus2 = new RadioButton();
            buttonChange = new Button();
            changeButton2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("DejaVu Serif Condensed", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(333, 72);
            label1.Name = "label1";
            label1.Size = new Size(359, 41);
            label1.TabIndex = 0;
            label1.Text = "Zmien Status Stolu";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("DejaVu Serif Condensed", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(345, 209);
            label2.Name = "label2";
            label2.Size = new Size(96, 24);
            label2.TabIndex = 1;
            label2.Text = "Nr. Stolu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("DejaVu Serif Condensed", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(345, 270);
            label3.Name = "label3";
            label3.Size = new Size(72, 24);
            label3.TabIndex = 2;
            label3.Text = "Kelner";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("DejaVu Serif Condensed", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(345, 334);
            label4.Name = "label4";
            label4.Size = new Size(72, 24);
            label4.TabIndex = 3;
            label4.Text = "Status";
            // 
            // tableNumber
            // 
            tableNumber.Font = new Font("DejaVu Serif Condensed", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            tableNumber.Location = new Point(459, 206);
            tableNumber.Name = "tableNumber";
            tableNumber.Size = new Size(115, 32);
            tableNumber.TabIndex = 4;
            // 
            // Handler
            // 
            Handler.Font = new Font("DejaVu Serif Condensed", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Handler.Location = new Point(459, 267);
            Handler.Name = "Handler";
            Handler.Size = new Size(115, 32);
            Handler.TabIndex = 5;
            // 
            // radioStatus1
            // 
            radioStatus1.AutoSize = true;
            radioStatus1.Font = new Font("DejaVu Serif Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            radioStatus1.Location = new Point(449, 319);
            radioStatus1.Name = "radioStatus1";
            radioStatus1.Size = new Size(73, 23);
            radioStatus1.TabIndex = 6;
            radioStatus1.TabStop = true;
            radioStatus1.Text = "Zajety";
            radioStatus1.UseVisualStyleBackColor = true;
            radioStatus1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioStatus2
            // 
            radioStatus2.AutoSize = true;
            radioStatus2.Font = new Font("DejaVu Serif Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            radioStatus2.Location = new Point(449, 348);
            radioStatus2.Name = "radioStatus2";
            radioStatus2.Size = new Size(72, 23);
            radioStatus2.TabIndex = 7;
            radioStatus2.TabStop = true;
            radioStatus2.Text = "Wolny";
            radioStatus2.UseVisualStyleBackColor = true;
            // 
            // buttonChange
            // 
            buttonChange.Font = new Font("DejaVu Serif Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            buttonChange.Location = new Point(809, 12);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new Size(149, 101);
            buttonChange.TabIndex = 8;
            buttonChange.Text = "Wróć";
            buttonChange.UseVisualStyleBackColor = true;
            buttonChange.Click += button1_Click;
            // 
            // changeButton2
            // 
            changeButton2.Font = new Font("DejaVu Serif Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            changeButton2.Location = new Point(385, 393);
            changeButton2.Name = "changeButton2";
            changeButton2.Size = new Size(189, 94);
            changeButton2.TabIndex = 9;
            changeButton2.Text = "Zmien";
            changeButton2.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(986, 556);
            Controls.Add(changeButton2);
            Controls.Add(buttonChange);
            Controls.Add(radioStatus2);
            Controls.Add(radioStatus1);
            Controls.Add(Handler);
            Controls.Add(tableNumber);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tableNumber;
        private TextBox Handler;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioStatus1;
        private RadioButton radioStatus2;
        private Button buttonChange;
        private Button changeButton2;
    }
}