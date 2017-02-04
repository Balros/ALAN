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
    public partial class SayText : Panel
    {
        public TextBox forTextBox = new TextBox();

        public SayText(int panelNumber, int tabIndex)
        {
            InitializeComponent();

            forTextBox.Location = new System.Drawing.Point(51, 10);
            forTextBox.Name = "textBox" + panelNumber;
            forTextBox.Size = new System.Drawing.Size(51, 32);
            forTextBox.TabIndex = tabIndex + 2;

            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(forTextBox);
            this.Location = new System.Drawing.Point(63, 33 * panelNumber);
            this.Name = "SayText" + panelNumber;
            this.Size = new System.Drawing.Size(150, 32);
            this.TabIndex = tabIndex; //toto nastavuje kolkate to bude pomocou Tabu
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
