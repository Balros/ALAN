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

                forPanel.MouseDown += new MouseEventHandler(this.panel1_MouseDown);
                forPanel.forLabel.MouseDown += new MouseEventHandler(this.panel1_MouseDown);
                forPanel.forTextBox.MouseDown += new MouseEventHandler(this.panel1_MouseDown);

                this.Controls.Add(forPanel);
            }

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Panel)
            {
                var panel = (Panel)sender;

                panel.DoDragDrop(panel, DragDropEffects.Copy);

            }
        }

        private void panel2_DragDrop(object sender, DragEventArgs e)
        {
            Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
            if (c is ForPanel)
            {
                ForPanel forPanel = new ForPanel(pocet + 1, 10 + pocet * 3);

                forPanel.MouseDown += new MouseEventHandler(this.panel1_MouseDown);

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
