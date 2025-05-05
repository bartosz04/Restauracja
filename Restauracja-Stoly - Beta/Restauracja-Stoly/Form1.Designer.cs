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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label = new System.Windows.Forms.Label();
            checkBoxReserved = new System.Windows.Forms.CheckBox();
            textBoxName = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            buttonSearch = new System.Windows.Forms.Button();
            dataGridViewResults = new System.Windows.Forms.DataGridView();
            buttonChange = new System.Windows.Forms.Button();
            checkBoxEmpty = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // Label
            // 
            Label.AutoSize = true;
            Label.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)238));
            Label.Location = new System.Drawing.Point(421, 26);
            Label.Name = "Label";
            Label.Size = new System.Drawing.Size(133, 57);
            Label.TabIndex = 0;
            Label.Text = "Stoly";
            Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Label.Click += label1_Click;
            // 
            // checkBoxReserved
            // 
            checkBoxReserved.AutoSize = true;
            checkBoxReserved.Font = new System.Drawing.Font("DejaVu Serif Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            checkBoxReserved.Location = new System.Drawing.Point(400, 108);
            checkBoxReserved.Name = "checkBoxReserved";
            checkBoxReserved.Size = new System.Drawing.Size(180, 28);
            checkBoxReserved.TabIndex = 1;
            checkBoxReserved.Text = "Zarezerwowane";
            checkBoxReserved.UseVisualStyleBackColor = true;
            // 
            // textBoxName
            // 
            textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            textBoxName.Font = new System.Drawing.Font("DejaVu Serif Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            textBoxName.Location = new System.Drawing.Point(489, 186);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new System.Drawing.Size(190, 32);
            textBoxName.TabIndex = 2;
            textBoxName.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("DejaVu Serif Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            label1.Location = new System.Drawing.Point(339, 189);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(144, 24);
            label1.TabIndex = 3;
            label1.Text = "Przypisane do";
            // 
            // buttonSearch
            // 
            buttonSearch.Font = new System.Drawing.Font("DejaVu Serif Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            buttonSearch.Location = new System.Drawing.Point(411, 233);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new System.Drawing.Size(133, 52);
            buttonSearch.TabIndex = 5;
            buttonSearch.Text = "Wyszukaj";
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.GridColor = System.Drawing.SystemColors.Info;
            dataGridViewResults.Location = new System.Drawing.Point(99, 310);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.Size = new System.Drawing.Size(757, 212);
            dataGridViewResults.TabIndex = 6;
            dataGridViewResults.CellContentClick += dataGridViewResults_CellContentClick;
            // 
            // buttonChange
            // 
            buttonChange.Font = new System.Drawing.Font("DejaVu Serif Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            buttonChange.Location = new System.Drawing.Point(712, 26);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new System.Drawing.Size(186, 71);
            buttonChange.TabIndex = 7;
            buttonChange.Text = "Zmien Status";
            buttonChange.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmpty
            // 
            checkBoxEmpty.Font = new System.Drawing.Font("DejaVu Serif Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            checkBoxEmpty.Location = new System.Drawing.Point(400, 142);
            checkBoxEmpty.Name = "checkBoxEmpty";
            checkBoxEmpty.Size = new System.Drawing.Size(144, 38);
            checkBoxEmpty.TabIndex = 8;
            checkBoxEmpty.Text = "Wolne";
            checkBoxEmpty.UseVisualStyleBackColor = true;
            checkBoxEmpty.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(948, 552);
            Controls.Add(checkBoxEmpty);
            Controls.Add(buttonChange);
            Controls.Add(dataGridViewResults);
            Controls.Add(buttonSearch);
            Controls.Add(label1);
            Controls.Add(textBoxName);
            Controls.Add(checkBoxReserved);
            Controls.Add(Label);
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.CheckBox checkBoxEmpty;

        #endregion

        private Label Label;
        private CheckBox checkBoxReserved;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private Button buttonSearch;
        private DataGridView dataGridViewResults;
        private Button buttonChange;
    }
}
