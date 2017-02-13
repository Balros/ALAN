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
    public partial class RepeatEndPanel : Panel
    {
        public Label informationLabel = new Label();
        public TextBox forTextBox = new TextBox();
        public string text;
        public Color farba;

        public RepeatEndPanel(int panelNumber, int tabIndex)
        {
            InitializeComponent();
            text = "Koniec opakuj  ";
            farba = Color.Goldenrod;
            setSettings(panelNumber, tabIndex);

            addLabel(panelNumber, tabIndex, text);
        }        

        private void addLabel(int panelNumber, int tabIndex, string text)
        {
            setLabel(panelNumber, tabIndex, text);
            this.Controls.Add(informationLabel);
        }

        private void setSettings(int panelNumber, int tabIndex)
        {
            this.BackColor = farba;
            this.Location = new Point(63, 100 + 33 * panelNumber);
            this.Name = "RepeatEnd" + panelNumber;
            this.Size = new Size(150, 32);
            this.TabIndex = tabIndex; //toto nastavuje kolkate to bude pomocou Tabu
        }

        private void setLabel(int panelNumber, int tabIndex, string text)
        {
            informationLabel.AutoSize = true;
            informationLabel.Location = new Point(10, 7);
            informationLabel.Name = "label" + panelNumber;
            informationLabel.Size = new Size(50, 32);
            informationLabel.TabIndex = tabIndex + 1;
            informationLabel.Text = text;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
