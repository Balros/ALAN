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
        bool move = false;
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

        private void settingsForCommandTemplate(CommandControl commandPanel)
        {
            addClickEventForAll(commandPanel, new MouseEventHandler(this.controlMouseDownCopy));
            Controls.Add(commandPanel);
            zoznamPrvkovMenu.Add(commandPanel); //aby sme vedeli co mazat pri zmene ponukanych commandov
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
            //if (sender is Button) // pridal som sem toto, lebo mi to padlo vzdy ked som klikol na nejaky button
            //{
            //    return;
            //}
            if (sender is Control)
            {
                CommandControl control = selectClosestCommandParent((Control)sender);
                if (control != null)
                {
                    control.DoDragDrop(control, DragDropEffects.Copy);
                }
            }
        }

        private CommandControl selectClosestCommandParent(Control sender)
        {
            CommandControl result = null;
            if (sender is CommandControl)
            {
                result = (CommandControl)sender;
            }
            else if (sender.Parent != null)
            {
                result  = selectClosestCommandParent(sender.Parent);
            }

            return result;
        }

        private void panel2_DragDrop(object sender, DragEventArgs e)   //v tejto funkcii treba nejak ziskat pristup k sender.farba, sender.text atd. aby ked sa nieco vyplni v menu sa to zobrazilo aj v tom dropnutom elemente
        {
            Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
            
            if (move)
            {
                c.Location = this.panel2.PointToClient(new Point(e.X, e.Y));
                move = false;
            }
            else
            {
                createCopyOfDraggedControl(e, c);
            }
        }

        private void createCopyOfDraggedControl(DragEventArgs e, Control c)
        {
            Control newControl = null;
            if (c is SayTextPanel)
            {
                newControl = new SayTextPanel(pocet + 1, 10 + pocet * 3);
            }

            else if (c is PlaySoundPanel)
            {
                newControl = new PlaySoundPanel(pocet + 1, 10 + pocet * 3); ;
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
                addClickEventForAll(newControl, c_MouseDown);
                newControl.Location = this.panel2.PointToClient(new Point(e.X, e.Y));
                addControlToList(newControl);
                pocet++;
            }
        }

        private void c_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            if (sender is Control)
            {
                CommandControl control = selectClosestCommandParent((Control)sender);
                if (control != null)
                {
                    control.DoDragDrop(control, DragDropEffects.Move);
                }
            }
        }

        private void panel2_DragOver(object sender, DragEventArgs e)
        {
            if (move)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void vymazPolozkyMenu()
        {
            foreach (Control panel in zoznamPrvkovMenu)
            {
                panel.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e) // Zvuk button
        {
            List<CommandControl> templates = new List<CommandControl>();

            vymazPolozkyMenu();

            templates.Add(new SayTextPanel(templates.Count + 1, 10 + templates.Count * 3));
            templates.Add(new PlaySoundPanel(templates.Count + 1, 10 + templates.Count * 3));
            //templates.Add(new LabelPanel(templates.Count + 1, 10 + templates.Count * 3, text));

            pridajPolozkyMenu(templates);
        }

        private void pridajPolozkyMenu(List<CommandControl> templates)
        {
            foreach (CommandControl command in templates)
            {
                settingsForCommandTemplate(command);
            }
        }

        private void button2_Click(object sender, EventArgs e) // Ovladanie button
        {
            List<CommandControl> templates = new List<CommandControl>();

            vymazPolozkyMenu();

            templates.Add(new RepeatStartPanel(templates.Count + 1, 10 + templates.Count * 3));
            templates.Add(new RepeatEndPanel(templates.Count + 1, 10 + templates.Count * 3));

            pridajPolozkyMenu(templates);
        }

        private void button4_Click(object sender, EventArgs e) // Premenna button
        {

        }

        private void button1_Click(object sender, EventArgs e) //procedura button
        {

        }
    }
}
