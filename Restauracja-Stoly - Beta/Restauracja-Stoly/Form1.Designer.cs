namespace Restauracja_Stoly
{
    partial class Form1
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Label = new System.Windows.Forms.Label();
            groupBoxFilters = new System.Windows.Forms.GroupBox();
            checkBoxReserved = new System.Windows.Forms.CheckBox();
            checkBoxEmpty = new System.Windows.Forms.CheckBox();
            textBoxName = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            buttonSearch = new System.Windows.Forms.Button();
            dataGridViewResults = new System.Windows.Forms.DataGridView();
            buttonChange = new System.Windows.Forms.Button();
            buttonRegister = new System.Windows.Forms.Button(); // Register Button
            toolTip1 = new System.Windows.Forms.ToolTip();
            ((System.ComponentModel.ISupportInitialize)(dataGridViewResults)).BeginInit();
            groupBoxFilters.SuspendLayout();
            SuspendLayout();
            // 
            // Label
            // 
            Label.AutoSize = true;
            Label.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            Label.ForeColor = System.Drawing.Color.DarkSlateBlue;
            Label.Location = new System.Drawing.Point(400, 20);
            Label.Name = "Label";
            Label.Size = new System.Drawing.Size(330, 57);
            Label.TabIndex = 0;
            Label.Text = "Stoły Restauracji";
            Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxFilters
            // 
            groupBoxFilters.Controls.Add(checkBoxReserved);
            groupBoxFilters.Controls.Add(checkBoxEmpty);
            groupBoxFilters.Controls.Add(textBoxName);
            groupBoxFilters.Controls.Add(label1);
            groupBoxFilters.Font = new System.Drawing.Font("DejaVu Serif Condensed", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupBoxFilters.Location = new System.Drawing.Point(50, 100);
            groupBoxFilters.Name = "groupBoxFilters";
            groupBoxFilters.Size = new System.Drawing.Size(500, 220);
            groupBoxFilters.TabIndex = 1;
            groupBoxFilters.TabStop = false;
            groupBoxFilters.Text = "Filtry";
            groupBoxFilters.BackColor = System.Drawing.Color.Lavender;
            // 
            // checkBoxReserved
            // 
            checkBoxReserved.AutoSize = true;
            checkBoxReserved.Location = new System.Drawing.Point(20, 40);
            checkBoxReserved.Name = "checkBoxReserved";
            checkBoxReserved.Size = new System.Drawing.Size(180, 26);
            checkBoxReserved.TabIndex = 0;
            checkBoxReserved.Text = "Zarezerwowane";
            toolTip1.SetToolTip(checkBoxReserved, "Pokaż tylko zarezerwowane stoły");
            checkBoxReserved.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmpty
            // 
            checkBoxEmpty.AutoSize = true;
            checkBoxEmpty.Location = new System.Drawing.Point(20, 80);
            checkBoxEmpty.Name = "checkBoxEmpty";
            checkBoxEmpty.Size = new System.Drawing.Size(80, 26);
            checkBoxEmpty.TabIndex = 1;
            checkBoxEmpty.Text = "Wolne";
            toolTip1.SetToolTip(checkBoxEmpty, "Pokaż tylko wolne stoły");
            checkBoxEmpty.UseVisualStyleBackColor = true;
            // 
            // textBoxName
            // 
            textBoxName.Location = new System.Drawing.Point(160, 140);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new System.Drawing.Size(300, 30);
            textBoxName.TabIndex = 2;
            toolTip1.SetToolTip(textBoxName, "Podaj nazwę przypisaną do stołu");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(20, 145);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(134, 22);
            label1.TabIndex = 3;
            label1.Text = "Przypisane do";
            // 
            // buttonSearch
            // 
            buttonSearch.Font = new System.Drawing.Font("DejaVu Serif Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonSearch.ForeColor = System.Drawing.Color.Black;
            buttonSearch.BackColor = System.Drawing.Color.DarkSlateBlue;
            buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("searchIcon")));
            buttonSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            buttonSearch.Location = new System.Drawing.Point(600, 140);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new System.Drawing.Size(200, 60);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "Wyszukaj";
            buttonSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(buttonSearch, "Kliknij, aby wyszukać stoły");
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Location = new System.Drawing.Point(50, 360);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.Size = new System.Drawing.Size(1100, 350);
            dataGridViewResults.TabIndex = 3;
            dataGridViewResults.BackgroundColor = System.Drawing.Color.LavenderBlush;
            // 
            // buttonChange
            // 
            buttonChange.Font = new System.Drawing.Font("DejaVu Serif Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonChange.ForeColor = System.Drawing.Color.Black;
            buttonChange.BackColor = System.Drawing.Color.DarkSlateBlue;
            buttonChange.Image = ((System.Drawing.Image)(resources.GetObject("editIcon")));
            buttonChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            buttonChange.Location = new System.Drawing.Point(820, 140);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new System.Drawing.Size(250, 60);
            buttonChange.TabIndex = 4;
            buttonChange.Text = "Zmień Status";
            buttonChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(buttonChange, "Kliknij, aby zmienić status stołu");
            buttonChange.UseVisualStyleBackColor = true;
            // 
            // buttonRegister
            // 
            buttonRegister.Font = new System.Drawing.Font("DejaVu Serif Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonRegister.ForeColor = System.Drawing.Color.Black;
            buttonRegister.BackColor = System.Drawing.Color.DarkSlateBlue;
            buttonRegister.Image = ((System.Drawing.Image)(resources.GetObject("registerIcon")));
            buttonRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            buttonRegister.Location = new System.Drawing.Point(820, 220); // Position below Change button
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new System.Drawing.Size(250, 60);
            buttonRegister.TabIndex = 5;
            buttonRegister.Text = "Rejestruj";
            buttonRegister.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(buttonRegister, "Kliknij, aby zarejestrować stół");
            buttonRegister.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1200, 800); // Increased window size
            MinimumSize = new System.Drawing.Size(1000, 600); // Prevent shrinking too small
            BackColor = System.Drawing.Color.AliceBlue;
            Controls.Add(buttonRegister);
            Controls.Add(buttonChange);
            Controls.Add(dataGridViewResults);
            Controls.Add(buttonSearch);
            Controls.Add(groupBoxFilters);
            Controls.Add(Label);
            Text = "Stoły Restauracji";
            ((System.ComponentModel.ISupportInitialize)(dataGridViewResults)).EndInit();
            groupBoxFilters.ResumeLayout(false);
            groupBoxFilters.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.CheckBox checkBoxReserved;
        private System.Windows.Forms.CheckBox checkBoxEmpty;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonRegister; // Register Button
        private System.Windows.Forms.ToolTip toolTip1;
    }
}