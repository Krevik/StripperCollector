using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace StripperCollector
{

    public partial class Form1 : Form
    {
        List<Position> positions;
        public Form1()
        {
            InitializeComponent();
            positions = new List<Position>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked && this.textBox3.Text.Length > 0)
            {
                addNewPosition();
            }
        }

        private void addNewPosition()
        {
            //create new position
            Position position = new Position(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);
            positions.Add(position);
            regenerateVisualList();
            //empty parameter value for making life easier reasons
            this.textBox3.Text = "";
        }

        private void regenerateVisualList()
        {
            //regenerate list from new positions list
            empty.Items.Clear();
            for (int index = 0; index < positions.Count; index++)
            {
                string textToList = index + ":" + positions[index].mapName + ":" + positions[index].identificationName + ":" + positions[index].parameterValue;
                empty.Items.Add(textToList);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //generate file
            List<string> maps = new List<string>();
            //count maps and add them to a list
            for(int index=0; index < positions.Count; index++)
            {
                Position position = positions.ElementAt(index);
                string currentMapName = position.mapName;
                if (!maps.Contains(currentMapName))
                {
                    maps.Add(currentMapName);
                }
            }


            //for every map index we need a new loop
            for (int mapIndex = 0; mapIndex < maps.Count; mapIndex++)
            {
                //we need new file for each map
                List<string> finalText = new List<string>();
                finalText.Add("filter: \n");

                //for every position in our list
                for (int index = 0; index < positions.Count; index++)
                {
                        Position actualPos = positions.ElementAt(index);
                        //if actual map matches
                        if (actualPos.mapName.Equals(maps.ElementAt(mapIndex)))
                        {
                            //add actual position
                            finalText.Add("{\n");
                            finalText.Add("\t"+"\""+actualPos.identificationName+"\""+"\t"+"\""+actualPos.parameterValue+"\"");
                            finalText.Add("\n}\n");
                        }
                }

                string arrayOfStrings = new string("");
                //let's convert list to one string
                for(int i = 0; i < finalText.Count; i++)
                {
                    arrayOfStrings = arrayOfStrings + finalText.ElementAt(i);
                }
                File.WriteAllTextAsync(maps[mapIndex]+".cfg", arrayOfStrings);
            }

            positions.Clear();
            regenerateVisualList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addNewPosition();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void empty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //remove selected position button
            int indexx = empty.SelectedIndex;
            positions.Remove(positions[indexx]);
            regenerateVisualList();
            //empty parameter value for making life easier reasons
            this.textBox3.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

}
