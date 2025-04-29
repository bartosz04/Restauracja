namespace Restauracja_Stoly
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label = new Label();
            checkBoxReserved = new CheckBox();
            textBoxName = new TextBox();
            label1 = new Label();
            buttonSearch = new Button();
            dataGridViewResults = new DataGridView();
            buttonChange = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // Label
            // 
            Label.AutoSize = true;
            Label.Font = new Font("Cambria", 36F, FontStyle.Bold, GraphicsUnit.Point, 238);
            Label.Location = new Point(421, 26);
            Label.Name = "Label";
            Label.Size = new Size(133, 57);
            Label.TabIndex = 0;
            Label.Text = "Stoly";
            Label.TextAlign = ContentAlignment.MiddleCenter;
            Label.Click += label1_Click;
            // 
            // checkBoxReserved
            // 
            checkBoxReserved.AutoSize = true;
            checkBoxReserved.Font = new Font("DejaVu Serif Condensed", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            checkBoxReserved.Location = new Point(400, 108);
            checkBoxReserved.Name = "checkBoxReserved";
            checkBoxReserved.Size = new Size(180, 28);
            checkBoxReserved.TabIndex = 1;
            checkBoxReserved.Text = "Zarezerwowane";
            checkBoxReserved.UseVisualStyleBackColor = true;
            // 
            // textBoxName
            // 
            textBoxName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxName.Font = new Font("DejaVu Serif Condensed", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBoxName.Location = new Point(489, 163);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(190, 32);
            textBoxName.TabIndex = 2;
            textBoxName.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("DejaVu Serif Condensed", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(339, 166);
            label1.Name = "label1";
            label1.Size = new Size(144, 24);
            label1.TabIndex = 3;
            label1.Text = "Przypisane do";
            // 
            // buttonSearch
            // 
            buttonSearch.Font = new Font("DejaVu Serif Condensed", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            buttonSearch.Location = new Point(411, 233);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(133, 52);
            buttonSearch.TabIndex = 5;
            buttonSearch.Text = "Wyszukaj";
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.GridColor = SystemColors.Info;
            dataGridViewResults.Location = new Point(99, 310);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.Size = new Size(757, 212);
            dataGridViewResults.TabIndex = 6;
            dataGridViewResults.CellContentClick += dataGridViewResults_CellContentClick;
            // 
            // buttonChange
            // 
            buttonChange.Font = new Font("DejaVu Serif Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            buttonChange.Location = new Point(712, 26);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new Size(186, 71);
            buttonChange.TabIndex = 7;
            buttonChange.Text = "Zmien Status";
            buttonChange.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 552);
            Controls.Add(buttonChange);
            Controls.Add(dataGridViewResults);
            Controls.Add(buttonSearch);
            Controls.Add(label1);
            Controls.Add(textBoxName);
            Controls.Add(checkBoxReserved);
            Controls.Add(Label);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Label;
        private CheckBox checkBoxReserved;
        private TextBox textBoxName;
        private Label label1;
        private Button buttonSearch;
        private DataGridView dataGridViewResults;
        private Button buttonChange;
    }
}
