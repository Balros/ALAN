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
    public partial class LabelPanel : Panel
    {
        public Label textLabel = new Label();
        public string text;
        public Color farba;

        public LabelPanel(int panelNumber, int tabIndex, string text)
        {
            this.text = text;
            farba = Color.MediumSlateBlue;
            //InitializeComponent(); //ty to tam mas,mne to tu hadze error
            setSettings(panelNumber, tabIndex);

            addLabel(panelNumber, tabIndex);
        }


        private void setSettings(int panelNumber, int tabIndex)
        {
            this.BackColor = farba;
            this.Location = new Point(63, 100 + 33 * panelNumber);
            this.Name = "LabelPanel" + panelNumber;
            this.Size = new Size(150, 32);
            this.TabIndex = tabIndex; //toto nastavuje kolkate to bude pomocou Tabu
        }

        private void addLabel(int panelNumber, int tabIndex)
        {
            setLabel(panelNumber, tabIndex);
            this.Controls.Add(textLabel);
        }

        private void setLabel(int panelNumber, int tabIndex)
        {
            textLabel.AutoSize = true;
            textLabel.Location = new Point(10, 7);
            textLabel.Name = "label" + panelNumber;
            textLabel.Size = new Size(51, 32);
            textLabel.TabIndex = tabIndex + 1;
            textLabel.Text = Text;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }


}
