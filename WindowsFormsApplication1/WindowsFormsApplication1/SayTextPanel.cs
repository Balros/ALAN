﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class SayTextPanel : Panel
    {
        public Label forLabel = new Label();
        public TextBox forTextBox = new TextBox();

        public SayTextPanel(int panelNumber, int tabIndex)
        {
            InitializeComponent();

            setSettings(panelNumber, tabIndex);

            addLabel(panelNumber, tabIndex);
            addTextBox(panelNumber, tabIndex);
        }

        private void addTextBox(int panelNumber, int tabIndex)
        {
            setTextBox(panelNumber, tabIndex);
            this.Controls.Add(forTextBox);
        }

        private void addLabel(int panelNumber, int tabIndex)
        {
            setLabel(panelNumber, tabIndex);
            this.Controls.Add(forLabel);
        }

        private void setSettings(int panelNumber, int tabIndex)
        {
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Location = new System.Drawing.Point(63, 33 * panelNumber);
            this.Name = "SayText" + panelNumber;
            this.Size = new System.Drawing.Size(150, 32);
            this.TabIndex = tabIndex; //toto nastavuje kolkate to bude pomocou Tabu
        }

        private void setTextBox(int panelNumber, int tabIndex)
        {
            forTextBox.Location = new System.Drawing.Point(61, 10);
            forTextBox.Name = "textBox" + panelNumber;
            forTextBox.Size = new System.Drawing.Size(51, 32);
            forTextBox.TabIndex = tabIndex + 2;
        }

        private void setLabel(int panelNumber, int tabIndex)
        {
            forLabel.AutoSize = true;
            forLabel.Location = new System.Drawing.Point(10, 10);
            forLabel.Name = "label" + panelNumber;
            forLabel.Size = new System.Drawing.Size(50, 32);
            forLabel.TabIndex = tabIndex + 1;
            forLabel.Text = "Say Text";
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}