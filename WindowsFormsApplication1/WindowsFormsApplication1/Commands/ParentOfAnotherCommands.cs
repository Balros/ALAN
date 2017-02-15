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
    public partial class ParentOfAnotherCommands : CommandControl
    {
        List<CommandControl> subcommands = new List<CommandControl>();
        Panel commandsPanel = new Panel();
        public ParentOfAnotherCommands(int panelNumber, int tabIndex) : base(panelNumber, tabIndex)
        {
            InitializeComponent();
            this.Height += 10;
            addCommandsPanel(panelNumber, tabIndex);
        }
        public void addCommandsPanel(int panelNumber, int tabIndex)
        {
            setCommandsPanel(panelNumber, tabIndex);
            this.Controls.Add(commandsPanel);
        }
        protected void setCommandsPanel(int panelNumber, int tabIndex)
        {
            commandsPanel.AutoSize = true;
            commandsPanel.Location = new Point(10, 35); //podla elementu ktory je nad nim
            commandsPanel.Name = "panel" + panelNumber;
            commandsPanel.Size = new Size(51, 0);
            commandsPanel.TabIndex = tabIndex + 1;
        }

        public void addSubcommand(CommandControl subcommand)
        {
            subcommand.Location = new Point(10, (commandsPanel.Controls.Count) * 34);
            subcommands.Add(subcommand);
            commandsPanel.Controls.Add(subcommand);
            resizeAdd(subcommand);
        }

        public void removeSubcommand(CommandControl subcommand)
        {
            subcommands.Remove(subcommand);
            Controls.Remove(subcommand);
            resizeRemove(subcommand);
        }

        public void resizeAdd(CommandControl subcommand)
        {
            int width = getWidth();

            commandsPanel.Size = new Size(width, commandsPanel.Height + subcommand.Height + 1);
            this.Size = new Size(20 + commandsPanel.Width, 32 + commandsPanel.Height);

            if (this.Parent is ParentOfAnotherCommands)
            {
                ((ParentOfAnotherCommands)this.Parent).resizeAdd(subcommand);
            }
        }

        private int getWidth()
        {
            int maxWidth = 0;
            foreach (CommandControl item in commandsPanel.Controls)
            {
                if (maxWidth < item.Width)
                {
                    maxWidth = item.Width;
                }
            }
            return maxWidth;
        }

        public void resizeRemove(CommandControl subcommand)
        {
            int width = getWidth();

            commandsPanel.Size = new Size(width, commandsPanel.Height - (subcommand.Height + 1));
            this.Size = new Size(20 + commandsPanel.Width, 32 + commandsPanel.Height);

            if (this.Parent is ParentOfAnotherCommands)
            {
                ((ParentOfAnotherCommands)this.Parent).resizeAdd(subcommand);
            }
        }
    }
}
