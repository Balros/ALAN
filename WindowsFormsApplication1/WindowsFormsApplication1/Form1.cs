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

        private void addSayTextPanelTemplate(int i)
        {
            SayTextPanel sayPanel = createSayTextPanel(i);

            Controls.Add(sayPanel);
        }

        private SayTextPanel createSayTextPanel(int i)
        {
            SayTextPanel sayPanel = new SayTextPanel(i + 1, 10 + i * 3);

            addClickEventForAll(sayPanel);
            return sayPanel;
        }

        private void addSayTextPanelToList(int pocet, Point point)
        {
            SayTextPanel sayPanel = createSayTextPanel(pocet);

            sayPanel.Location = this.panel2.PointToClient(point);

            panel2.Controls.Add(sayPanel);
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

        private void panel2_DragDrop(object sender, DragEventArgs e)
        {
            Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
            if (c is ForPanel)
            {
                addForPanelToList(pocet,new Point(e.X,e.Y));

                pocet++;
            }
            if (c is SayTextPanel)
            {
                addSayTextPanelToList(pocet, new Point(e.X, e.Y));

                pocet++;
            }
        }


        private void panel2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void button3_Click(object sender, EventArgs e) // Zvuk button
        {
            addSayTextPanelTemplate(1);
        }
    }
}
