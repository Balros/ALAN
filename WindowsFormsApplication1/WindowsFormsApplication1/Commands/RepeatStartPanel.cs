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
    public partial class RepeatStartPanel : ParentOfAnotherCommands
    {
        public TextBox forTextBox = new TextBox();

        public RepeatStartPanel(int panelNumber, int tabIndex) : base(panelNumber, tabIndex)
        {
            InitializeComponent();

            informationLabel.Text = "Opakuj  ";
            this.BackColor = Color.Goldenrod;

            setName(panelNumber);
            addTextBox(panelNumber, tabIndex);
        }

        private void addTextBox(int panelNumber, int tabIndex)
        {
            setTextBox(panelNumber, tabIndex);
            this.Controls.Add(forTextBox);
        }

        private void setName(int panelNumber)
        {
            this.Name = "repeatEndPanel" + panelNumber;
        }

        private void setTextBox(int panelNumber, int tabIndex)
        {
            forTextBox.Location = new Point(61, 7);
            forTextBox.Name = "textBox" + panelNumber;
            forTextBox.Size = new Size(51, 32);
            forTextBox.TabIndex = tabIndex + 2;
        }
    }
}
