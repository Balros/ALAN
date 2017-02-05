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
{<DirectedGraph xmlns="http://schemas.microsoft.com/vs/2009/dgml">
  <Nodes>
    <Node Id="(@1 @2)" Visibility="Hidden" />
    <Node Id="(@3 Namespace=WindowsFormsApplication1 Type=Form1)" Category="CodeSchema_Class" CodeSchemaProperty_IsPublic="True" CommonLabel="Form1" Icon="Microsoft.VisualStudio.Class.Public" IsDragSource="True" Label="Form1" SourceLocation="(Assembly=file:///C:/Users/Matus/Source/Repos/ALAN/WindowsFormsApplication1/WindowsFormsApplication1/Form1.cs StartLineNumber=12 StartCharacterOffset=25 EndLineNumber=12 EndCharacterOffset=30)" />
  </Nodes>
  <Links>
    <Link Source="(@1 @2)" Target="(@3 Namespace=WindowsFormsApplication1 Type=Form1)" Category="Contains" />
  </Links>
  <Categories>
    <Category Id="CodeSchema_Class" Label="Class" BasedOn="CodeSchema_Type" Icon="CodeSchema_Class" />
    <Category Id="CodeSchema_Type" Label="Type" Icon="CodeSchema_Class" />
    <Category Id="Contains" Label="Contains" Description="Whether the source of the link contains the target object" IsContainment="True" />
  </Categories>
  <Properties>
    <Property Id="CodeSchemaProperty_IsPublic" Label="Is Public" Description="Flag to indicate the scope is Public" DataType="System.Boolean" />
    <Property Id="CommonLabel" DataType="System.String" />
    <Property Id="Icon" Label="Icon" DataType="System.String" />
    <Property Id="IsContainment" DataType="System.Boolean" />
    <Property Id="IsDragSource" Label="IsDragSource" Description="IsDragSource" DataType="System.Boolean" />
    <Property Id="Label" Label="Label" Description="Displayable label of an Annotatable object" DataType="System.String" />
    <Property Id="SourceLocation" Label="Start Line Number" DataType="Microsoft.VisualStudio.GraphModel.CodeSchema.SourceLocation" />
    <Property Id="Visibility" Label="Visibility" Description="Defines whether a node in the graph is visible or not" DataType="System.Windows.Visibility" />
  </Properties>
  <QualifiedNames>
    <Name Id="Assembly" Label="Assembly" ValueType="Uri" />
    <Name Id="File" Label="File" ValueType="Uri" />
    <Name Id="Namespace" Label="Namespace" ValueType="System.String" />
    <Name Id="Type" Label="Type" ValueType="System.Object" />
  </QualifiedNames>
  <IdentifierAliases>
    <Alias n="1" Uri="Assembly=$(VsSolutionUri)/WindowsFormsApplication1/WindowsFormsApplication1.csproj" />
    <Alias n="2" Uri="File=$(VsSolutionUri)/WindowsFormsApplication1/Form1.cs" />
    <Alias n="3" Uri="Assembly=$(d649b96f-d49b-4c7c-9fbb-5314fbbf75d6.OutputPathUri)" />
  </IdentifierAliases>
  <Paths>
    <Path Id="d649b96f-d49b-4c7c-9fbb-5314fbbf75d6.OutputPathUri" Value="file:///C:/Users/Matus/Source/Repos/ALAN/WindowsFormsApplication1/WindowsFormsApplication1/bin/Debug/WindowsFormsApplication1.exe" />
    <Path Id="VsSolutionUri" Value="file:///C:/Users/Matus/Source/Repos/ALAN/WindowsFormsApplication1" />
  </Paths>
</DirectedGraph>
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
            for (int i = 0; i < 3; i++)
            {
                addForPanelTemplate(i);
            }

            for (int i = 3; i < 6; i++)
            {
                addSayTextPanelTemplate(i);
            }

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
    }
}
