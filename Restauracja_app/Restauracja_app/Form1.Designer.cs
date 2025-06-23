
namespace Restauracja_app
{
    partial class Form1
    {
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Label = new Label();
            groupBoxFilters = new GroupBox();
            checkBoxReserved = new CheckBox();
            checkBoxEmpty = new CheckBox();
            textBoxName = new TextBox();
            label1 = new Label();
            buttonSearch = new Button();
            dataGridViewResults = new DataGridView();
            buttonChange = new Button();
            buttonRegister = new Button();
            toolTip1 = new ToolTip(components);
            groupBoxFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // Label
            // 
            Label.AutoSize = true;
            Label.Font = new Font("Cambria", 36F, FontStyle.Bold);
            Label.ForeColor = Color.DarkSlateBlue;
            Label.Location = new Point(280, 15);
            Label.Margin = new Padding(2, 0, 2, 0);
            Label.Name = "Label";
            Label.Size = new Size(397, 57);
            Label.TabIndex = 0;
            Label.Text = "Stoły Restauracji";
            Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBoxFilters
            // 
            groupBoxFilters.BackColor = Color.Lavender;
            groupBoxFilters.Controls.Add(checkBoxReserved);
            groupBoxFilters.Controls.Add(checkBoxEmpty);
            groupBoxFilters.Controls.Add(textBoxName);
            groupBoxFilters.Controls.Add(label1);
            groupBoxFilters.Font = new Font("Microsoft Sans Serif", 14F);
            groupBoxFilters.Location = new Point(35, 75);
            groupBoxFilters.Margin = new Padding(2, 2, 2, 2);
            groupBoxFilters.Name = "groupBoxFilters";
            groupBoxFilters.Padding = new Padding(2, 2, 2, 2);
            groupBoxFilters.Size = new Size(350, 165);
            groupBoxFilters.TabIndex = 1;
            groupBoxFilters.TabStop = false;
            groupBoxFilters.Text = "Filtry";
            // 
            // checkBoxReserved
            // 
            checkBoxReserved.AutoSize = true;
            checkBoxReserved.Location = new Point(14, 30);
            checkBoxReserved.Margin = new Padding(2, 2, 2, 2);
            checkBoxReserved.Name = "checkBoxReserved";
            checkBoxReserved.Size = new Size(165, 28);
            checkBoxReserved.TabIndex = 0;
            checkBoxReserved.Text = "Zarezerwowane";
            toolTip1.SetToolTip(checkBoxReserved, "Pokaż tylko zarezerwowane stoły");
            checkBoxReserved.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmpty
            // 
            checkBoxEmpty.AutoSize = true;
            checkBoxEmpty.Location = new Point(14, 60);
            checkBoxEmpty.Margin = new Padding(2, 2, 2, 2);
            checkBoxEmpty.Name = "checkBoxEmpty";
            checkBoxEmpty.Size = new Size(84, 28);
            checkBoxEmpty.TabIndex = 1;
            checkBoxEmpty.Text = "Wolne";
            toolTip1.SetToolTip(checkBoxEmpty, "Pokaż tylko wolne stoły");
            checkBoxEmpty.UseVisualStyleBackColor = true;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(112, 105);
            textBoxName.Margin = new Padding(2, 2, 2, 2);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(211, 29);
            textBoxName.TabIndex = 2;
            toolTip1.SetToolTip(textBoxName, "Podaj nazwę przypisaną do stołu");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 109);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(129, 24);
            label1.TabIndex = 3;
            label1.Text = "Przypisane do";
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.DarkSlateBlue;
            buttonSearch.Font = new Font("Microsoft Sans Serif", 16F);
            buttonSearch.ForeColor = Color.Black;
            buttonSearch.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSearch.Location = new Point(420, 105);
            buttonSearch.Margin = new Padding(2, 2, 2, 2);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(140, 45);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "Wyszukaj";
            buttonSearch.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(buttonSearch, "Kliknij, aby wyszukać stoły");
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.BackgroundColor = Color.LavenderBlush;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Location = new Point(35, 270);
            dataGridViewResults.Margin = new Padding(2, 2, 2, 2);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.Size = new Size(770, 262);
            dataGridViewResults.TabIndex = 3;
            // 
            // buttonChange
            // 
            buttonChange.BackColor = Color.DarkSlateBlue;
            buttonChange.Font = new Font("Microsoft Sans Serif", 16F);
            buttonChange.ForeColor = Color.Black;
            buttonChange.ImageAlign = ContentAlignment.MiddleLeft;
            buttonChange.Location = new Point(574, 105);
            buttonChange.Margin = new Padding(2, 2, 2, 2);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new Size(175, 45);
            buttonChange.TabIndex = 4;
            buttonChange.Text = "Zmień Status";
            buttonChange.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(buttonChange, "Kliknij, aby zmienić status stołu");
            buttonChange.UseVisualStyleBackColor = true;
            // 
            // buttonRegister
            // 
            buttonRegister.BackColor = Color.DarkSlateBlue;
            buttonRegister.Font = new Font("Microsoft Sans Serif", 16F);
            buttonRegister.ForeColor = Color.Black;
            buttonRegister.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRegister.Location = new Point(574, 165);
            buttonRegister.Margin = new Padding(2, 2, 2, 2);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(175, 45);
            buttonRegister.TabIndex = 5;
            buttonRegister.Text = "Rejestruj";
            buttonRegister.TextAlign = ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(buttonRegister, "Kliknij, aby zarejestrować stół");
            buttonRegister.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(831, 600);
            Controls.Add(buttonRegister);
            Controls.Add(buttonChange);
            Controls.Add(dataGridViewResults);
            Controls.Add(buttonSearch);
            Controls.Add(groupBoxFilters);
            Controls.Add(Label);
            Margin = new Padding(2, 2, 2, 2);
            MinimumSize = new Size(705, 460);
            Name = "Form1";
            Text = "Stoły Restauracji";
            groupBoxFilters.ResumeLayout(false);
            groupBoxFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
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
        private System.ComponentModel.IContainer components;
    }
}