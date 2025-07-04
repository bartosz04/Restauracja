﻿namespace Restauracja_app
{
    partial class pulpit
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
       
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStoliki = new System.Windows.Forms.Button();
            this.btnZamówienia = new System.Windows.Forms.Button();
            this.btnWyloguj = new System.Windows.Forms.Button();
            this.btnRejestrujStolik = new System.Windows.Forms.Button();
            this.lblWybierzStolik = new System.Windows.Forms.Label();
            this.lblOkno = new System.Windows.Forms.Label();
            this.lblSchody = new System.Windows.Forms.Label();
            this.lblSrodek1 = new System.Windows.Forms.Label();
            this.lblSrodek2 = new System.Windows.Forms.Label();
            this.lblDrwi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStoliki
            // 
            this.btnStoliki.Font = new System.Drawing.Font("Inter", 16F, System.Drawing.FontStyle.Bold);
            this.btnStoliki.ForeColor = System.Drawing.Color.FromArgb(122, 79, 255);
            this.btnStoliki.Location = new System.Drawing.Point(20, 20);
            this.btnStoliki.Name = "btnStoliki";
            this.btnStoliki.Size = new System.Drawing.Size(180, 40);
            this.btnStoliki.TabIndex = 0;
            this.btnStoliki.Text = "Zmień status";
            this.btnStoliki.UseVisualStyleBackColor = false;
            this.btnStoliki.BackColor = System.Drawing.Color.Transparent;
            this.btnStoliki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStoliki.TextAlign = ContentAlignment.MiddleCenter;
            this.btnStoliki.FlatAppearance.BorderSize = 0;
            this.btnStoliki.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStoliki.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(230, 240, 255); 
            this.btnStoliki.Click += BtnStoliki_Click;
            // 
            // btnWyloguj
            // 
            this.btnWyloguj.Font = new System.Drawing.Font("Inter", 16F, System.Drawing.FontStyle.Bold);
            this.btnWyloguj.ForeColor = System.Drawing.Color.FromArgb(122, 79, 255);
            this.btnWyloguj.Location = new System.Drawing.Point(400, 20);
            this.btnWyloguj.Name = "btnWyloguj";
            this.btnWyloguj.Size = new System.Drawing.Size(180, 40);
            this.btnWyloguj.TabIndex = 2;
            this.btnWyloguj.Text = "Wyloguj";
            this.btnWyloguj.UseVisualStyleBackColor = false;
            this.btnWyloguj.BackColor = System.Drawing.Color.Transparent;
            this.btnWyloguj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWyloguj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnWyloguj.FlatAppearance.BorderSize = 0;
            this.btnWyloguj.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnWyloguj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.btnWyloguj.Click += BtnWyloguj_Click;
            // 
            // btnRejestrujStolik
            // 
            this.btnRejestrujStolik.Font = new System.Drawing.Font("Inter", 16F, System.Drawing.FontStyle.Bold);
            this.btnRejestrujStolik.ForeColor = System.Drawing.Color.FromArgb(122, 79, 255);
            this.btnRejestrujStolik.Location = new System.Drawing.Point(210, 20);
            this.btnRejestrujStolik.Name = "btnRejestrujStolik";
            this.btnRejestrujStolik.Size = new System.Drawing.Size(180, 40);
            this.btnRejestrujStolik.TabIndex = 3;
            this.btnRejestrujStolik.Text = "Rejestruj klenera";
            this.btnRejestrujStolik.UseVisualStyleBackColor = false;
            this.btnRejestrujStolik.BackColor = System.Drawing.Color.Transparent;
            this.btnRejestrujStolik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRejestrujStolik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRejestrujStolik.FlatAppearance.BorderSize = 0;
            this.btnRejestrujStolik.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRejestrujStolik.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(230, 240, 255);
            this.btnRejestrujStolik.Click += BtnRejestrujStolik_Click;
            // 
            // lblWybierzStolik
            // 
            this.lblWybierzStolik.AutoSize = true;
            this.lblWybierzStolik.Font = new System.Drawing.Font("Inter", 13F, System.Drawing.FontStyle.Bold);
            this.lblWybierzStolik.ForeColor = System.Drawing.Color.FromArgb(122, 79, 255);
            this.lblWybierzStolik.Location = new System.Drawing.Point(20, 70);
            this.lblWybierzStolik.Name = "lblWybierzStolik";
            this.lblWybierzStolik.Size = new System.Drawing.Size(103, 22);
            this.lblWybierzStolik.TabIndex = 3;
            this.lblWybierzStolik.Text = "Rozkład stolików";
            // 
           
            // pulpit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(215, 240, 240);
            this.ClientSize = new Size(1200, 700);
            this.Controls.Add(this.lblDrwi);
            this.Controls.Add(this.lblSrodek2);
            this.Controls.Add(this.lblSrodek1);
            this.Controls.Add(this.lblSchody);
            this.Controls.Add(this.lblOkno);
            this.Controls.Add(this.lblWybierzStolik);
            this.Controls.Add(this.btnWyloguj);
            this.Controls.Add(this.btnRejestrujStolik);
            this.Controls.Add(this.btnZamówienia);
            this.Controls.Add(this.btnStoliki);
            this.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "pulpit";
            this.Text = "Stoliki";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnStoliki;
        private System.Windows.Forms.Button btnZamówienia;
        private System.Windows.Forms.Button btnWyloguj;
        private System.Windows.Forms.Button btnRejestrujStolik;
        private System.Windows.Forms.Label lblWybierzStolik;
        private System.Windows.Forms.Label lblOkno;
        private System.Windows.Forms.Label lblSchody;
        private System.Windows.Forms.Label lblSrodek1;
        private System.Windows.Forms.Label lblSrodek2;
        private System.Windows.Forms.Label lblDrwi;

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }
}