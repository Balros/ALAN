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
        public new string Text;
        public System.Drawing.Color Farba;

        public MenuPanel(int panelNumber, int tabIndex, string[] PolozkyMenu, string text, System.Drawing.Color farba)
        {
            Text = text;
            Farba = farba;
            //InitializeComponent(); //ty to tam mas,mne to tu hadze error
            setSettings(panelNumber, tabIndex);

            addLabel(panelNumber, tabIndex);
            addMenu(panelNumber, tabIndex, PolozkyMenu);
            

        }

        private void addMenu(int panelNumber, int tabIndex, string[] PolozkyMenu)
        {
            setMenu(panelNumber, tabIndex, PolozkyMenu);
            this.Controls.Add(menuBox);
        }

        private void setMenu(int panelNumber, int tabIndex, string[] PolozkyMenu)
        {
            menuBox.Location = new System.Drawing.Point(61, 7);
            menuBox.Name = "ComboBox" + panelNumber;
            menuBox.Size = new System.Drawing.Size(51, 32);
            menuBox.TabIndex = tabIndex + 2;
            foreach (string polozka in PolozkyMenu)
            {
                menuBox.Items.Add(polozka);
            }
                    
        }

        private void setSettings(int panelNumber, int tabIndex)
        {
            this.BackColor = Farba;
            this.Location = new System.Drawing.Point(63, 100 + 33 * panelNumber);
            this.Name = "MenuPanel" + panelNumber;
            this.Size = new System.Drawing.Size(150, 32);
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
            menuLabel.Location = new System.Drawing.Point(10, 7);
            menuLabel.Name = "label" + panelNumber;
            menuLabel.Size = new System.Drawing.Size(51, 32);
            menuLabel.TabIndex = tabIndex + 1;
            menuLabel.Text = Text;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }

    
}
