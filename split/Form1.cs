using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace split
{
    public partial class Form1 : Form
    {
        private Task[] taskList = new Task[50];
        private Person[] personList = new Person[40];
        private bool fileMissing = false;
        private bool overload = false;
        private bool splitDone = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void split_MouseClick(object sender, MouseEventArgs e)
        {
            
            loadOperators();
            loadTask();
            sortList();
            splitIt();      
            if(!overload)
            this.display.Text = displaySolution();
            splitDone = true;
            
        }

       

        private string displaySolution()
        {
            string display = "";
            for (int i = 0; i < numberOfOperators.Value; i++)
            {
                display += personList[i].Name + " : ";
                for (int j = 0; j < personList[i].task.Length; j++)
                {
                    display += personList[i].task[j].Name + " ";
                    if (personList[i].task[j].firstoff) display += ":F/O ";
                    if (personList[i].task[j].lastoff) display += ":L/O ";
                    if (personList[i].task[j].closeBox) display += ":BOX ";
                }
                    
                display += "\n";
            }

            if (fileMissing)
                display += "data file missing, split done by equal weight";
            return display;
        }

        private void splitIt()
        {
            overload = false;
            for(int i=1; i<41; i++)
            {
                if (taskList[i].TrueWeight() != 0 || taskList[i].firstoff || taskList[i].lastoff )
                {
                    if (personList[lowest()].taskNumber < 14)
                    {
                        personList[lowest()].taskNumber++;
                        personList[lowest()].task[personList[lowest()].taskNumber - 1] = taskList[i];
                    }
                    else
                    {
                        i = 42;
                        this.display.Text = "Person overloaded, alocate more operators!";
                        overload = true;
                    }
                                       
                }


            }                                

        }
        
        private int lowest()
        {
            int lowestWeightPerson = 0;
            for(int i=1;i<this.numberOfOperators.Value;i++)
            {
                if (personList[lowestWeightPerson].totalWeight() > personList[i].totalWeight())
                    lowestWeightPerson = i;
            }
            return lowestWeightPerson;
        } 
    

        private void loadOperators()
        {
            for(int i=0; i<this.numberOfOperators.Value;i++)
            {
                Task[] task = new Task[15];
                for (int j=0; j < 15; j++)
                {
                    task[j] = new Task("", 0);
                }
                    
                string name = "Operator" + Convert.ToString(i + 1);
                personList[i] = new Person(name,task);
            }
        }



        private void loadTask(){
            //taskList[0] = new Task("test", 99);
             taskList[1] = new Task("ax1", taskWeight("ax1")); if (this.ax1.Checked) taskList[1].packing = true;
             taskList[2] = new Task("ax2", taskWeight("ax2")); if (this.ax2.Checked) taskList[2].packing = true;
             taskList[3] = new Task("ax3", taskWeight("ax3")); if (this.ax3.Checked) taskList[3].packing = true;
            taskList[4] = new Task("ax4", taskWeight("ax4")); if (this.ax4.Checked) taskList[4].packing = true;
            taskList[5] = new Task("ax5", taskWeight("ax5")); if (this.ax5.Checked) taskList[5].packing = true;
            taskList[6] = new Task("ax6", taskWeight("ax6")); if (this.ax6.Checked) taskList[6].packing = true;
            taskList[7] = new Task("ax7", taskWeight("ax7")); if (this.ax7.Checked) taskList[7].packing = true;
            taskList[8] = new Task("ax8", taskWeight("ax8")); if (this.ax8.Checked) taskList[8].packing = true;
            taskList[9] = new Task("px1", taskWeight("px1")); if (this.px1.Checked) taskList[9].packing = true;
            taskList[10] = new Task("px2", taskWeight("px2")); if (this.px2.Checked) taskList[10].packing = true;
            taskList[11] = new Task("ee1", taskWeight("ee1")); if (this.ee1.Checked) taskList[11].packing = true;
                                                               if (this.ee1c.Checked) taskList[11].closeBox = true;
            taskList[12] = new Task("ee2", taskWeight("ee2")); if (this.ee2.Checked) taskList[12].packing = true;
                                                               if (this.ee2c.Checked) taskList[12].closeBox = true;
            taskList[13] = new Task("ee3", taskWeight("ee3")); if (this.ee3.Checked) taskList[13].packing = true;
                                                               if (this.ee3c.Checked) taskList[13].closeBox = true;
            taskList[14] = new Task("ee4", taskWeight("ee4")); if (this.ee4.Checked) taskList[14].packing = true;
            taskList[15] = new Task("ee5", taskWeight("ee5")); if (this.ee5.Checked) taskList[15].packing = true;
            taskList[16] = new Task("net2", taskWeight("net2")); if (this.net2.Checked) taskList[16].packing = true;
            taskList[17] = new Task("net3", taskWeight("net3")); if (this.net3.Checked) taskList[17].packing = true;
            taskList[18] = new Task("net4", taskWeight("net4")); if (this.net4.Checked) taskList[18].packing = true;
            taskList[19] = new Task("net5", taskWeight("net5")); if (this.net5.Checked) taskList[19].packing = true;
            taskList[20] = new Task("net6", taskWeight("net6")); if (this.net6.Checked) taskList[20].packing = true;
            taskList[21] = new Task("net7", taskWeight("net7")); if (this.net7.Checked) taskList[21].packing = true;
            taskList[22] = new Task("net8", taskWeight("net8")); if (this.net8.Checked) taskList[22].packing = true;
            taskList[23] = new Task("net9", taskWeight("net9")); if (this.net9.Checked) taskList[23].packing = true;
            taskList[24] = new Task("net10", taskWeight("net10")); if (this.net10.Checked) taskList[24].packing = true;
                                                                   if (this.net10c.Checked) taskList[24].closeBox = true;
            taskList[25] = new Task("net11", taskWeight("net11")); if (this.net11.Checked) taskList[25].packing = true;
            taskList[26] = new Task("km7", taskWeight("km7")); if (this.km7.Checked) taskList[26].packing = true;
            taskList[27] = new Task("km9", taskWeight("km9")); if (this.km9.Checked) taskList[27].packing = true;
            taskList[28] = new Task("km11", taskWeight("km11")); if (this.km11.Checked) taskList[28].packing = true;
            taskList[29] = new Task("km13", taskWeight("km13")); if (this.km13.Checked) taskList[29].packing = true;
            taskList[30] = new Task("km18", taskWeight("km18")); if (this.km18.Checked) taskList[30].packing = true;
            taskList[31] = new Task("km20", taskWeight("km20")); if (this.km20.Checked) taskList[31].packing = true;
            taskList[32] = new Task("km23", taskWeight("km23")); if (this.km23.Checked) taskList[32].packing = true;
            taskList[33] = new Task("km25", taskWeight("km25")); if (this.km25.Checked) taskList[33].packing = true;
            taskList[34] = new Task("km26", taskWeight("km26")); if (this.km26.Checked) taskList[34].packing = true;
            taskList[35] = new Task("km27", taskWeight("km27")); if (this.km27.Checked) taskList[35].packing = true;
            taskList[36] = new Task("km28", taskWeight("km28")); if (this.km28.Checked) taskList[36].packing = true;
            taskList[37] = new Task("km29", taskWeight("km29")); if (this.km29.Checked) taskList[37].packing = true;
            taskList[38] = new Task("km30", taskWeight("km30")); if (this.km30.Checked) taskList[38].packing = true;
            taskList[39] = new Task("km31", taskWeight("km31")); if (this.km31.Checked) taskList[39].packing = true;
            taskList[40] = new Task("km32", taskWeight("km32")); if (this.km32.Checked) taskList[40].packing = true;

            

            for (int i = 0; i<this.FO.Items.Count; i++)
            {
                if (FO.GetItemChecked(i) == true)
                {
                    taskList[i + 1].firstoff = true;                    
                }
                else
                {
                    taskList[i + 1].firstoff = false;
                }
            }

            for (int i = 0; i < this.LO.Items.Count; i++)
            {
                if (LO.GetItemChecked(i) == true)
                {
                    taskList[i + 1].lastoff = true;
                }
                else
                {
                    taskList[i + 1].lastoff = false;
                }
            }

        }
        
        private int taskWeight(string machine)
        {
            if(File.Exists(Path.Combine(Environment.CurrentDirectory, "weight.txt")))
            {
                string text = System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "weight.txt"));
                int pos = 0;
                if (text.Contains(machine))
                {
                    pos = text.IndexOf(machine);
                }
                else
                    MessageBox.Show("could not load values for " + machine);
                return text[pos + 6] - '0';
            }
            else
            {
                fileMissing = true;
                return 1;
            }
                
                                              
        }

        private void sortList()
        {
            bool order = false;
            while (!order)
            {
                order = true;
                for (int i = 1; i < 40; i++)
                {
                    if (taskList[i].TrueWeight() < taskList[i + 1].TrueWeight())
                    {
                        Task t = taskList[i];
                        taskList[i] = taskList[i + 1];
                        taskList[i + 1] = t;
                        order = false;
                    }
                }
            }
        }

        private void ax1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void deselect_MouseClick(object sender, MouseEventArgs e)
        {
            this.ax1.Checked = false;
            this.ax2.Checked = false;
            this.ax3.Checked = false;
            this.ax4.Checked = false;
            this.ax5.Checked = false;
            this.ax6.Checked = false;
            this.ax7.Checked = false;
            this.ax8.Checked = false;
            this.px1.Checked = false;
            this.px2.Checked = false;
            this.ee1.Checked = false;
            this.ee2.Checked = false;
            this.ee3.Checked = false;
            this.ee4.Checked = false;
            this.ee5.Checked = false;
            this.net2.Checked = false;
            this.net3.Checked = false;
            this.net4.Checked = false;
            this.net5.Checked = false;
            this.net6.Checked = false;
            this.net7.Checked = false;
            this.net8.Checked = false;
            this.net9.Checked = false;
            this.net10.Checked = false;
            this.net11.Checked = false;
            this.km7.Checked = false;
            this.km9.Checked = false;
            this.km11.Checked = false;
            this.km13.Checked = false;
            this.km18.Checked = false;
            this.km20.Checked = false;
            this.km23.Checked = false;
            this.km25.Checked = false;
            this.km26.Checked = false;
            this.km27.Checked = false;
            this.km28.Checked = false;
            this.km29.Checked = false;
            this.km30.Checked = false;
            this.km31.Checked = false;
            this.km32.Checked = false;
            for (int i = 0; i < this.LO.Items.Count; i++)
            {
                this.LO.SetItemChecked(i, false);
                this.FO.SetItemChecked(i, false);
            }
            this.ee1c.Checked = false;
            this.ee2c.Checked = false;
            this.ee3c.Checked = false;
            this.net10c.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ax1.Checked = true;
            this.ax2.Checked = true;
            this.ax3.Checked = true;
            this.ax4.Checked = true;
            this.ax5.Checked = true;
            this.ax6.Checked = true;
            this.ax7.Checked = true;
            this.ax8.Checked = true;
            this.px1.Checked = true;
            this.px2.Checked = true;
            this.ee1.Checked = true;
            this.ee2.Checked = true;
            this.ee3.Checked = true;
            this.ee4.Checked = true;
            this.ee5.Checked = true;
            this.net2.Checked = true;
            this.net3.Checked = true;
            this.net4.Checked = true;
            this.net5.Checked = true;
            this.net6.Checked = true;
            this.net7.Checked = true;
            this.net8.Checked = true;
            this.net9.Checked = true;
            this.net10.Checked = true;
            this.net11.Checked = true;
            this.km7.Checked = true;
            this.km9.Checked = true;
            this.km11.Checked = true;
            this.km13.Checked = true;
            this.km18.Checked = true;
            this.km20.Checked = true;
            this.km23.Checked = true;
            this.km25.Checked = true;
            this.km26.Checked = true;
            this.km27.Checked = true;
            this.km28.Checked = true;
            this.km29.Checked = true;
            this.km30.Checked = true;
            this.km31.Checked = true;
            this.km32.Checked = true;
          

        }

        private void label2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("From Sara with love...");
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string fileName = DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".doc";
            string subPath = AppDomain.CurrentDomain.BaseDirectory + @"\Save\"; // your code goes here
            bool exists = System.IO.Directory.Exists(subPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);
            if (splitDone)
            {
                File.WriteAllText(subPath + fileName, displaySolution());
                MessageBox.Show("File saved to current directory.");
            }
               
            else
                MessageBox.Show("There is nothing to save no Split done!");

        }
    }
}
