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
        List<Control> ZoznamPrvkovMenu = new List<Control>(); //zoznam panelov ktore su sucastou menu
        public Form1()
        {
            InitializeComponent();
            panel2.AllowDrop = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //  for (int i = 0; i < 3; i++)
            //{
            //    addForPanelTemplate(i);
            //}

            //for (int i = 3; i < 6; i++)
            //{
            //    addSayTextPanelTemplate(i);
            //}

        }

        private void addForPanelTemplate(int i)
        {
            ForPanel forPanel = CreateForPanel(i);

            Controls.Add(forPanel);
        }
        private void addForPanelToList(int i, Point point)
        {
            ForPanel forPanel = CreateForPanel(i);

            forPanel.Location = this.panel2.PointToClient(point);

            panel2.Controls.Add(forPanel);
        }

        private ForPanel CreateForPanel(int i)
        {
            ForPanel forPanel = new ForPanel(i + 1, 10 + i * 3);

            addClickEventForAll(forPanel);
            return forPanel;
        }

        private void addSayTextPanelTemplate(int i, bool menu, string text, System.Drawing.Color farba)
        {
            
            SayTextPanel sayPanel = createSayTextPanel(i, text, farba);
            Controls.Add(sayPanel);
            if (menu == true)
            {
                ZoznamPrvkovMenu.Add(sayPanel);
            }
        }

        private SayTextPanel createSayTextPanel(int i,string text, System.Drawing.Color farba)
        {
            SayTextPanel sayPanel = new SayTextPanel(i + 1, 10 + i * 3, text, farba);

            addClickEventForAll(sayPanel);
            return sayPanel;
        }

        private void addSayTextPanelToList(int pocet, Point point, string text, System.Drawing.Color farba)
        {
            SayTextPanel sayPanel = createSayTextPanel(pocet, text, farba);

            sayPanel.Location = this.panel2.PointToClient(point);

            panel2.Controls.Add(sayPanel);
        }

        private void addMenuPanelTemplate(int i, bool menu, string[] PolozkyMenu, string text, System.Drawing.Color farba)
        {

            MenuPanel menuPnl = createMenuPanel(i, PolozkyMenu, text, farba);
            Controls.Add(menuPnl);
            if (menu == true)
            {
                ZoznamPrvkovMenu.Add(menuPnl);
            }
        }

        private MenuPanel createMenuPanel(int i, string[] PolozkyMenu, string text, System.Drawing.Color farba)
        {
            MenuPanel menuPnl = new MenuPanel(i + 1, 10 + i * 3, PolozkyMenu, text, farba);

            addClickEventForAll(menuPnl);
            return menuPnl;
        }

        private void addMenuPanelToList(int pocet, Point point, string[] PolozkyMenu, string text, System.Drawing.Color farba)
        {
            MenuPanel menuPnl = createMenuPanel(pocet, PolozkyMenu, text, farba);

            menuPnl.Location = this.panel2.PointToClient(point);

            panel2.Controls.Add(menuPnl);
        }

        private void addLabelPanelTemplate(int i, bool menu, string text, System.Drawing.Color farba)
        {

            LabelPanel LabelPnl = createLabelPanel(i, text, farba);
            Controls.Add(LabelPnl);
            if (menu == true)
            {
                ZoznamPrvkovMenu.Add(LabelPnl);
            }
        }

        private LabelPanel createLabelPanel(int i, string text, System.Drawing.Color farba)
        {
            LabelPanel LabelPnl = new LabelPanel(i + 1, 10 + i * 3, text, farba);

            addClickEventForAll(LabelPnl);
            return LabelPnl;
        }

        private void addLabelPanelToList(int pocet, Point point, string text, System.Drawing.Color farba)
        {
            LabelPanel LabelPnl = createLabelPanel(pocet, text, farba);

            LabelPnl.Location = this.panel2.PointToClient(point);

            panel2.Controls.Add(LabelPnl);
        }

        private void addClickEventForAll(Control inputControl)
        {
            inputControl.MouseDown += new MouseEventHandler(this.ControlMouseDown);

            foreach (Control control in inputControl.Controls)
            {
                control.MouseDown += new MouseEventHandler(this.ControlMouseDown);
            }
        }

        private void ControlMouseDown(object sender, MouseEventArgs e)
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
            if (c is ForPanel)
            {
                addForPanelToList(pocet,new Point(e.X,e.Y));

                pocet++;
            }
            if (c is SayTextPanel)
            {
                addSayTextPanelToList(pocet, new Point(e.X, e.Y),"text", System.Drawing.Color.MediumSlateBlue );

                pocet++;
            }

            if (c is MenuPanel)
            {
                addMenuPanelToList(pocet, new Point(e.X, e.Y), new string[] { "polozka", "polozka2" } , "text", System.Drawing.Color.MediumSlateBlue);
                pocet++;
            }
            if (c is LabelPanel)
            {
                addLabelPanelToList(pocet, new Point(e.X, e.Y), "text", System.Drawing.Color.MediumSlateBlue);
                pocet++;
            }
        }


        private void panel2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void VymazPolozkyMenu()
        {
            foreach (Control panel in ZoznamPrvkovMenu)
            {
                panel.Dispose();
            }

        }

        private void button3_Click(object sender, EventArgs e) // Zvuk button
        {
            VymazPolozkyMenu();
            addMenuPanelTemplate(2,true,new string[]
        {
            "cat",
            "dog",
            "panther",
            "tiger"
        }, "Zahraj", System.Drawing.Color.MediumSlateBlue);
            addSayTextPanelTemplate(1, true, "Povedz ", System.Drawing.Color.MediumSlateBlue);
        }

        private void button2_Click(object sender, EventArgs e) // Ovladanie button
        {
            VymazPolozkyMenu();
            addSayTextPanelTemplate(1, true, "Opakuj  ", System.Drawing.Color.Goldenrod);
            addLabelPanelTemplate(2, true, "Koniec opakuj", System.Drawing.Color.Goldenrod);

        }

        private void button4_Click(object sender, EventArgs e) // Premenna button
        {

        }

        private void button1_Click(object sender, EventArgs e) //procedura button
        {

        }
    }
}
