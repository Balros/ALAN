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
            for (int i = 0; i < 10; i++)
            {
                ForPanel forPanel = new ForPanel(i + 1, 10 + i * 3);

                forPanel.MouseDown += new MouseEventHandler(this.ControlMouseDown);
                forPanel.forLabel.MouseDown += new MouseEventHandler(this.ControlMouseDown);
                forPanel.forTextBox.MouseDown += new MouseEventHandler(this.ControlMouseDown);

                this.Controls.Add(forPanel);
            }

        }

        private void ControlMouseDown(object sender, MouseEventArgs e)
        {
            
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
                ForPanel forPanel = new ForPanel(pocet + 1, 10 + pocet * 3);

                forPanel.MouseDown += new MouseEventHandler(this.ControlMouseDown);

                forPanel.Location = this.panel2.PointToClient(new Point(e.X, e.Y));

                this.panel2.Controls.Add(forPanel);
                pocet++;
            }
        }

        private void panel2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
