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
using System.Runtime.Serialization.Formatters.Binary;

namespace PeterSpanos_Task3_19013035
{
    [Serializable] public partial class Form1 : Form
    {
        GameEngine engine;
        BinaryFormatter bf = new BinaryFormatter();

        public Form1()
        {
            InitializeComponent();
        }

        //Activates the round timer
        private void BtnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        //Pauses the timer
        private void BtnPause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            btnStart.Text = "Resume";
        }

        //Updates the round timer
        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblRound.Text = "Round: " + engine.Round.ToString();
            engine.Update();
            
        }

        //Sends how many units and buildings must be built
        private void Form1_Load(object sender, EventArgs e)
        {
            engine = new GameEngine(20, txtInfo, grpMap, 4);
        }

        private void txtInfo_TextChanged(object sender, EventArgs e)
        {

        }

        //Serializes the data to a file
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                FileStream fs = new FileStream(path: "SaveFileUnits.dat", FileMode.Create, FileAccess.Write, FileShare.None);
                FileStream ss = new FileStream(path: "SaveFileBuildings.dat", FileMode.Create, FileAccess.Write, FileShare.None);

                using (fs)
                {
                    bf.Serialize(fs, engine.map.units); 
                }

                using (ss)
                {
                    bf.Serialize(ss, engine.map.buildings);
                }

                MessageBox.Show(text: "The File Has Been Saved", "File Saved");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        //Deserializes the file and loads the save state
        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {

                FileStream fs = new FileStream(path: "SaveFileUnits.dat", FileMode.Open, FileAccess.Read, FileShare.None);
                FileStream ss = new FileStream(path: "SaveFileBuildings.dat", FileMode.Open, FileAccess.Read, FileShare.None);

                using (fs)
                {
                    engine.map.units = (List<Unit>)bf.Deserialize(fs);   
                }

                using (ss)
                {
                    engine.map.buildings = (List<Building>)bf.Deserialize(ss);  
                }

                MessageBox.Show(text: "The File Has Been Succesfully Loaded", "File Loaded");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            engine.Update();
        } 
    }
}
