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
    public partial class RepeatEndPanel : CommandControl
    {

        public RepeatEndPanel(int panelNumber, int tabIndex) : base(panelNumber, tabIndex)
        {
            InitializeComponent();
            informationLabel.Text = "Koniec opakuj  ";
            this.BackColor = Color.Goldenrod;

            setName(panelNumber);
        }

        private void setName(int panelNumber)
        {
            this.Name = "repeatEndPanel" + panelNumber;
        }
    }
}
