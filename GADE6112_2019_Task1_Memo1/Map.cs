﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Peter_Spanos_19013035_Task2
{
    [Serializable] public class Map
    {
        //Declares list to hold the units and buildings
        public List<Unit> units = new List<Unit>();
        public List<Building> buildings = new List<Building>();

        //Declares random class and other useful variables
        Random r = new Random();
        public int numUnits = 0;
        public int numBuildings = 0;
        TextBox txtInfo;

        //Fields 
        public List<Unit> Units
        {
            get { return units; }
            set { units = value; }
        }

        public List<Building> Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }

        //Constructor
        public Map(int n, TextBox txt, int noBuilds)
        {
            units = new List<Unit>();
            buildings = new List<Building>();
            numUnits = n;
            txtInfo = txt;
            numBuildings = noBuilds;
        }

        //Handles generation of the units
        public void Generate()
        {
            for(int i = 0; i < numUnits; i++)
            {
               if(r.Next(0,2) == 0) //Generate Melee Unit
                {
                    MeleeUnit m = new MeleeUnit(r.Next(0, 10),
                                                r.Next(0, 10),
                                                100,
                                                1,
                                                20,
                                                (i % 2 == 0 ? 1 : 0),
                                                "M/");
                    units.Add(m);
                }
               else // Generate Ranged Unit
                {
                    RangedUnit ru = new RangedUnit(r.Next(0, 10),
                                                r.Next(0, 10),
                                                100,
                                                1,
                                                20,
                                                5,
                                                (i % 2 == 0 ? 1 : 0),
                                                "R}");
                    units.Add(ru);
                }
            }

            for(int k = 0; k < numBuildings; k++)
            {
                if(r.Next(0,2) == 0) //Generate Resource Building
                {
                    ResourceBuilding rb = new ResourceBuilding(r.Next(0, 10),
                                                               r.Next(0, 10),
                                                               150,
                                                               (k % 2 == 0 ? 1 : 0),
                                                               "[G]",
                                                               false);
                     buildings.Add(rb);
                }
                else //Generate Unit Building
                {
                    FactoryBuilding fb = new FactoryBuilding(r.Next(0, 10),
                                                             r.Next(0, 10),
                                                             200,
                                                             (k % 2 == 0 ? 1 : 0),
                                                             "[F]",
                                                             false,
                                                             (r.Next(0, 2) == 1 ? "Melee" : "Ranged"));

                    buildings.Add(fb);
                }
            }
        }

        //Displays the units onto the form
        public void Display(GroupBox groupBox)
        {
            groupBox.Controls.Clear();
            

            //Adding Units
            foreach(Unit u in units)
            {
                Button b = new Button();
                if (u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    b.Size = new Size(30, 30);
                    b.Location = new Point(mu.XPos * 30, mu.YPos * 30);
                    b.Text = mu.Symbol;
                    if (mu.Faction == 0)
                    {
                        b.ForeColor = Color.HotPink;
                    }
                    else
                    {
                        b.ForeColor = Color.Blue ;
                    }
                }
                else
                {
                    RangedUnit ru = (RangedUnit)u;
                    b.Size = new Size(30, 30);
                    b.Location = new Point(ru.XPos * 30, ru.YPos * 30);
                    b.Text = ru.Symbol;
                    if (ru.Faction == 0)
                    {
                        b.ForeColor = Color.HotPink;
                    }
                    else
                    {
                        b.ForeColor = Color.Blue;
                    }
                }
                b.Click += Unit_Click;
                groupBox.Controls.Add(b);
            }

            //Adding Buildings
            foreach (Building bud in buildings)
            {
                Button b = new Button();

                if (bud is ResourceBuilding)
                {
                    ResourceBuilding rb = (ResourceBuilding)bud;

                    b.Size = new Size(30, 30);
                    b.Location = new Point(rb.XPos * 30, rb.YPos * 30);
                    b.Text = rb.Symbol;
                    if (rb.Faction == 0)
                    {
                        b.ForeColor = Color.HotPink;
                    }
                    else
                    {
                        b.ForeColor = Color.Blue;
                    }
                }
                else
                {
                    FactoryBuilding fb = (FactoryBuilding)bud;

                    b.Size = new Size(30, 30);
                    b.Location = new Point(fb.XPos * 30, fb.YPos * 30);
                    b.Text = fb.Symbol;
                    if (fb.Faction == 0)
                    {
                        b.ForeColor = Color.HotPink;
                    }
                    else
                    {
                        b.ForeColor = Color.Blue;
                    }

                }

                b.Click += Building_Click;
                groupBox.Controls.Add(b);
            }
        }

        //Adds a unit's info to the ToString
        public void Unit_Click(object sender, EventArgs e)
        {
            int x, y;
            Button b = (Button)sender;
            x = b.Location.X / 30;
            y = b.Location.Y / 30;

            foreach(Unit u in units)
            {
                if (u is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)u;
                    if (ru.XPos == x && ru.YPos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = ru.ToString();
                    }
                }
                else if (u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    if (mu.XPos == x && mu.YPos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = mu.ToString();
                    }
                }
            }
        }

        //Adds a building's info to the ToString
        public void Building_Click(object sender, EventArgs e)
        {
            int x, y;

            Button b = (Button)sender;

            x = b.Location.X / 30;
            y = b.Location.Y / 30;

            foreach (Building bud in buildings)
            {
                if (bud is ResourceBuilding)
                {
                    ResourceBuilding rb = (ResourceBuilding)bud;
                    if (rb.XPos == x && rb.YPos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = rb.ToString();
                    }
                }
                else if (bud is FactoryBuilding)
                {
                    FactoryBuilding fb = (FactoryBuilding)bud;
                    if (fb.XPos == x && fb.YPos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = fb.ToString();
                    }
                }
            }
        }
    }
}
