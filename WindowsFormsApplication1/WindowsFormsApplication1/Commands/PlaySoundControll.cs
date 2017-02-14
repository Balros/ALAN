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
    public partial class PlaySoundPanel : CommandControl { 

        public ComboBox menuBox = new ComboBox();
        public string[] polozkyMenu;

        public PlaySoundPanel(int panelNumber, int tabIndex) : base(panelNumber, tabIndex)
        {
            InitializeComponent();
            informationLabel.Text = "Zahraj  ";
            this.BackColor = Color.MediumSlateBlue;
            polozkyMenu = new string[]
                {
                    "cat",
                    "dog",
                    "panther",
                    "tiger"
                };

            setName(panelNumber);
            addMenu(panelNumber, tabIndex, polozkyMenu);
        }

        private void setName(int panelNumber)
        {
            this.Name = "playSoundPanel" + panelNumber;
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
    }
}
