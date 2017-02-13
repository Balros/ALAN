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

    public partial class Form1 : Form
    {
        int pocet = 0;
        List<Control> zoznamPrvkovMenu = new List<Control>(); //zoznam panelov ktore su sucastou menu
        public Form1()
        {
            InitializeComponent();
            panel2.AllowDrop = true;
        }

        private void addControlToList(Control forPanel)
        {
            panel2.Controls.Add(forPanel);
        }

        private void setLocation(Point point, Control forPanel)
        {
            forPanel.Location = this.panel2.PointToClient(point);
        }

        private void addRepeatStartPanelTemplate(int panelNumber, bool menu)
        {

            RepeatStartPanel repeatPanel = new RepeatStartPanel(panelNumber + 1, 10 + panelNumber * 3);
            addClickEventForAll(repeatPanel, new MouseEventHandler(this.controlMouseDownCopy));
            Controls.Add(repeatPanel);
            if (menu == true)
            {
                zoznamPrvkovMenu.Add(repeatPanel);
            }
        }

        private void addRepeatEndPanelTemplate(int panelNumber, bool menu)
        {
            RepeatEndPanel repeatPanel = new RepeatEndPanel(panelNumber + 1, 10 + panelNumber * 3);
            addClickEventForAll(repeatPanel, new MouseEventHandler(this.controlMouseDownCopy));
            Controls.Add(repeatPanel);
            if (menu == true)
            {
                zoznamPrvkovMenu.Add(repeatPanel);
            }
        }

        private void addSayTextPanelTemplate(int panelNumber, bool menu)
        {
            SayTextPanel sayPanel = new SayTextPanel(panelNumber + 1, 10 + panelNumber * 3);
            addClickEventForAll(sayPanel, new MouseEventHandler(this.controlMouseDownCopy));
            Controls.Add(sayPanel);
            if (menu == true)
            {
                zoznamPrvkovMenu.Add(sayPanel);
            }
        }

        private void addMenuPanelTemplate(int panelNumber, bool menu)
        {

            MenuPanel menuPanel = new MenuPanel(panelNumber + 1, 10 + panelNumber * 3);
            addClickEventForAll(menuPanel, new MouseEventHandler(this.controlMouseDownCopy));
            Controls.Add(menuPanel);
            if (menu == true)
            {
                zoznamPrvkovMenu.Add(menuPanel);
            }
        }

        private void addLabelPanelTemplate(int panelNumber, bool menu, string text)
        {

            LabelPanel labelPanel = new LabelPanel(panelNumber + 1, 10 + panelNumber * 3, text);
            addClickEventForAll(labelPanel, new MouseEventHandler(this.controlMouseDownCopy));
            Controls.Add(labelPanel);
            if (menu == true)
            {
                zoznamPrvkovMenu.Add(labelPanel);
            }
        }

        private void addClickEventForAll(Control inputControl, MouseEventHandler eventHandler)
        {
            inputControl.MouseDown += eventHandler;

            foreach (Control control in inputControl.Controls)
            {
                control.MouseDown += eventHandler;
            }
        }

        private void controlMouseDownCopy(object sender, MouseEventArgs e)
        {
            if (sender is Button) // pridal som sem toto, lebo mi to padlo vzdy ked som klikol na nejaky button
            {
                return;
            }
            Panel control = setControl(sender);
            if (control != null)
            {
                control.DoDragDrop(control, DragDropEffects.Copy);

            }
        }

        private void controlMouseDownMove(object sender, MouseEventArgs e)
        {
            if (sender is Button) // pridal som sem toto, lebo mi to padlo vzdy ked som klikol na nejaky button
            {
                return;
            }
            Panel control = setControl(sender);
            if (control != null)
            {
                control.DoDragDrop(control, DragDropEffects.Move);

            }
        }

        private Panel setControl(object sender)
        {
            Panel result = null;
            if (sender is Panel)
            {
                result = (Panel)sender;
            }
            else if (sender is Control)
            {
                result = (Panel)((Control)sender).Parent;
            }

            return result;
        }

        private void panel2_DragDrop(object sender, DragEventArgs e)   //v tejto funkcii treba nejak ziskat pristup k sender.farba, sender.text atd. aby ked sa nieco vyplni v menu sa to zobrazilo aj v tom dropnutom elemente
        {
            Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
            Control newControl = null;
            
            if (c is SayTextPanel)
            {
                newControl = new SayTextPanel(pocet + 1, 10 + pocet * 3);
            }

            else if (c is MenuPanel)
            {
                newControl = new MenuPanel(pocet + 1, 10 + pocet * 3); ;
            }
            else if (c is LabelPanel)
            {
                newControl = new LabelPanel(pocet + 1, 10 + pocet * 3, "text");
            }
            else if (c is RepeatStartPanel)
            {
                newControl = new RepeatStartPanel(pocet + 1, 10 + pocet * 3);
            }
            else if (c is RepeatEndPanel)
            {
                newControl = new RepeatEndPanel(pocet + 1, 10 + pocet * 3);
            }
            if (newControl != null)
            {
                setLocation(new Point(e.X, e.Y), newControl);
                addControlToList(newControl);
                pocet++;
            }

        }

        private void panel2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void VymazPolozkyMenu()
        {
            foreach (Control panel in zoznamPrvkovMenu)
            {
                panel.Dispose();
            }

        }

        private void button3_Click(object sender, EventArgs e) // Zvuk button
        {
            VymazPolozkyMenu();

            addSayTextPanelTemplate(1, true);
            addMenuPanelTemplate(2,true);
        }

        private void button2_Click(object sender, EventArgs e) // Ovladanie button
        {
            VymazPolozkyMenu();
            addRepeatStartPanelTemplate(1, true);
            addRepeatEndPanelTemplate(2, true);

        }

        private void button4_Click(object sender, EventArgs e) // Premenna button
        {

        }

        private void button1_Click(object sender, EventArgs e) //procedura button
        {

        }
    }
}
