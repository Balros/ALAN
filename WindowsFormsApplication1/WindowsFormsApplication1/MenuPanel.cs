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
    public partial class MenuPanel : Panel
    {
        public Label menuLabel = new Label();
        public ComboBox menuBox = new ComboBox();
        public string[] polozkyMenu;
        public string text;
        public Color farba;

        public MenuPanel(int panelNumber, int tabIndex)
        {
            this.text = "Zahraj";
            farba = Color.MediumSlateBlue;
            polozkyMenu = new string[]
                {
                    "cat",
                    "dog",
                    "panther",
                    "tiger"
                };
            //InitializeComponent(); //ty to tam mas,mne to tu hadze error
            setSettings(panelNumber, tabIndex);

            addLabel(panelNumber, tabIndex);
            addMenu(panelNumber, tabIndex, polozkyMenu);
        }

        private void addMenu(int panelNumber, int tabIndex, string[] polozkyMenu)
        {
            setMenu(panelNumber, tabIndex, polozkyMenu);
            this.Controls.Add(menuBox);
        }

        private void setMenu(int panelNumber, int tabIndex, string[] polozkyMenu)
        {
            menuBox.Location = new Point(61, 7);
            menuBox.Name = "ComboBox" + panelNumber;
            menuBox.Size = new Size(51, 32);
            menuBox.TabIndex = tabIndex + 2;

            foreach (string polozka in polozkyMenu)
            {
                menuBox.Items.Add(polozka);
            }
        }

        private void setSettings(int panelNumber, int tabIndex)
        {
            this.BackColor = farba;
            this.Location = new Point(63, 100 + 33 * panelNumber);
            this.Name = "MenuPanel" + panelNumber;
            this.Size = new Size(150, 32);
            this.TabIndex = tabIndex; //toto nastavuje kolkate to bude pomocou Tabu
        }

        private void addLabel(int panelNumber, int tabIndex)
        {
            setLabel(panelNumber, tabIndex);
            this.Controls.Add(menuLabel);
        }

        private void setLabel(int panelNumber, int tabIndex)
        {
            menuLabel.AutoSize = true;
            menuLabel.Location = new Point(10, 7);
            menuLabel.Name = "label" + panelNumber;
            menuLabel.Size = new Size(51, 32);
            menuLabel.TabIndex = tabIndex + 1;
            menuLabel.Text = text;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }

    
}
