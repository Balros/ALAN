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
    public partial class CommandControl : Panel
    {
        public Label informationLabel = new Label();
        public CommandControl(int panelNumber, int tabIndex) //hlavny control od ktoreho dedia vsetky "nase custom made" prikazy
        {                                                    //aby sme ich vedeli odlisit od ostatnych Controls, poprosim nemenit iba pridavat
            InitializeComponent();

            setSettings(panelNumber, tabIndex);
            addLabel(panelNumber, tabIndex);
        }
        protected void setLabel(int panelNumber, int tabIndex)
        {
            informationLabel.AutoSize = true;
            informationLabel.Location = new Point(10, 7);
            informationLabel.Name = "label" + panelNumber;
            informationLabel.Size = new Size(51, 32);
            informationLabel.TabIndex = tabIndex + 1;
        }

        protected virtual void setSettings(int panelNumber, int tabIndex)
        {
            this.Location = new Point(63, 100 + 33 * panelNumber);
            this.Size = new Size(150, 32);
            this.TabIndex = tabIndex; //toto nastavuje kolkate to bude pomocou Tabu
        }
        protected void addLabel(int panelNumber, int tabIndex)
        {
            setLabel(panelNumber, tabIndex);
            this.Controls.Add(informationLabel);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
