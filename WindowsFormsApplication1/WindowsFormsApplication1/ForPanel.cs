using System;
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
    public partial class ForPanel : Panel
    {
        public Label forLabel = new Label();
        public TextBox forTextBox = new TextBox();

        public ForPanel(int panelNumber, int tabIndex)
        {
            InitializeComponent();

            forLabel.AutoSize = true;
            forLabel.Location = new System.Drawing.Point(10, 10);
            forLabel.Name = "label" + panelNumber;
            forLabel.Size = new System.Drawing.Size(50, 32);
            forLabel.TabIndex = tabIndex + 1;
            forLabel.Text = "label" + panelNumber;


            forTextBox.Location = new System.Drawing.Point(51, 10);
            forTextBox.Name = "textBox" + panelNumber;
            forTextBox.Size = new System.Drawing.Size(51, 32);
            forTextBox.TabIndex = tabIndex + 2;

            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(forLabel);
            this.Controls.Add(forTextBox);
            this.Location = new System.Drawing.Point(63, 33 * panelNumber);
            this.Name = "panel" + panelNumber;
            this.Size = new System.Drawing.Size(150, 32);
            this.TabIndex = tabIndex; //toto nastavuje kolkate to bude pomocou Tabu

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}