﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeterSpanos_Task3_19013035
{
    [Serializable] public class GameEngine
    {
        //Declarations for the GameEngine class
        public Map map;
        private int round;
        Random r = new Random();
        GroupBox grpMap;

        //Fields
        public int Round
        {
            get { return round; }
        }

        //Constructor
        public GameEngine(int numUnits, TextBox txtInfoUnits, GroupBox gMap, int noBuilds, int height, int width)
        {
            grpMap = gMap;
            map = new Map(numUnits, txtInfoUnits, noBuilds, height, width);
            map.Generate();
            map.Display(grpMap);

            round = 1; 
        }

        //Updates the map to display the units' movement, combat and deaths
        public void Update()
        {
            for(int i = 0; i < map.Units.Count; i++)
            {
                if (map.Units[i] is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)map.Units[i];
                    if (mu.Health <= mu.MaxHealth * 0.25) // Running Away
                    {
                        mu.Move(r.Next(0, 4));
                    }
                    else
                    {
                        (Unit closest, int distanceTo) = mu.Closest(map.Units);

                        //Check In Range
                        if (distanceTo <= mu.AttackRange)
                        {
                            mu.IsAttacking = true;
                            mu.Combat(closest);
                        }
                        else //Move Towards
                        {
                            if (closest is MeleeUnit)
                            {
                                MeleeUnit closestMu = (MeleeUnit)closest;
                                if (mu.XPos > closestMu.XPos) //North
                                {
                                    mu.Move(0);
                                }
                                else if (mu.XPos < closestMu.XPos) //South
                                {
                                    mu.Move(2);
                                }
                                else if (mu.YPos > closestMu.YPos) //West
                                {
                                    mu.Move(3);
                                }
                                else if (mu.YPos < closestMu.YPos) //East
                                {
                                    mu.Move(1);
                                }
                            }
                            else if (closest is RangedUnit)
                            {
                                RangedUnit closestRu = (RangedUnit)closest;
                                if (mu.XPos > closestRu.XPos) //North
                                {
                                    mu.Move(0);
                                }
                                else if (mu.XPos < closestRu.XPos) //South
                                {
                                    mu.Move(2);
                                }
                                else if (mu.YPos > closestRu.YPos) //West
                                {
                                    mu.Move(3);
                                }
                                else if (mu.YPos < closestRu.YPos) //East
                                {
                                    mu.Move(1);
                                }
                            }
                        }

                    }
                }
                else if (map.Units[i] is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)map.Units[i];
                   if (ru.Health <= ru.MaxHealth * 0.25) 
                    {
                        ru.Move(r.Next(0, 4));
                    }
                    else
                    {
                        (Unit closest, int distanceTo) = ru.Closest(map.Units);
                      
                        //Check In Range
                        if (distanceTo <= ru.AttackRange)
                        {
                            ru.IsAttacking = true;
                            ru.Combat(closest);
                        }
                        else //Move Towards
                        {
                            if (closest is MeleeUnit)
                            {
                                MeleeUnit closestMu = (MeleeUnit)closest;
                                if (ru.XPos > closestMu.XPos) //North
                                {
                                    ru.Move(0);
                                }
                                else if (ru.XPos < closestMu.XPos) //South
                                {
                                    ru.Move(2);
                                }
                                else if (ru.YPos > closestMu.YPos) //West
                                {
                                    ru.Move(3);
                                }
                                else if (ru.YPos < closestMu.YPos) //East
                                {
                                    ru.Move(1);
                                }
                            }
                            else if (closest is RangedUnit)
                            {
                                RangedUnit closestRu = (RangedUnit)closest;
                                if (ru.XPos > closestRu.XPos) //North
                                {
                                    ru.Move(0);
                                }
                                else if (ru.XPos < closestRu.XPos) //South
                                {
                                    ru.Move(2);
                                }
                                else if (ru.YPos > closestRu.YPos) //West
                                {
                                    ru.Move(3);
                                }
                                else if (ru.YPos < closestRu.YPos) //East
                                {
                                    ru.Move(1);
                                }
                            }
                        }

                    }

                }
                else if (map.Units[i] is WizardUnit)
                {
                    WizardUnit wu = (WizardUnit)map.Units[i];
                    if (wu.Health <= wu.MaxHealth * 0.5) // Running Away
                    {
                        wu.Move(r.Next(0, 4));
                    }
                    else
                    {
                        (Unit closest, int distanceTo) = wu.Closest(map.Units);

                        //Check In Range
                        if (distanceTo <= wu.AttackRange)
                        {
                            wu.IsAttacking = true;
                            wu.Combat(closest);
                        }
                        else //Move Towards
                        {
                            if (closest is MeleeUnit)
                            {
                                MeleeUnit closestMu = (MeleeUnit)closest;
                                if (wu.XPos > closestMu.XPos) //North
                                {
                                    wu.Move(0);
                                }
                                else if (wu.XPos < closestMu.XPos) //South
                                {
                                    wu.Move(2);
                                }
                                else if (wu.YPos > closestMu.YPos) //West
                                {
                                    wu.Move(3);
                                }
                                else if (wu.YPos < closestMu.YPos) //East
                                {
                                    wu.Move(1);
                                }
                            }
                            else if (closest is RangedUnit)
                            {
                                RangedUnit closestRu = (RangedUnit)closest;
                                if (wu.XPos > closestRu.XPos) //North
                                {
                                    wu.Move(0);
                                }
                                else if (wu.XPos < closestRu.XPos) //South
                                {
                                    wu.Move(2);
                                }
                                else if (wu.YPos > closestRu.YPos) //West
                                {
                                    wu.Move(3);
                                }
                                else if (wu.YPos < closestRu.YPos) //East
                                {
                                    wu.Move(1);
                                }
                            }
                        }

                    }
                }
                else if (map.neutralUnits[i] is WizardUnit)
                {
                    WizardUnit wu = (WizardUnit)map.neutralUnits[i];
                    if (wu.Health <= wu.MaxHealth * 0.5) // Running Away
                    {
                        wu.Move(r.Next(0, 4));
                    }
                    else
                    {
                        (Unit closest, int distanceTo) = wu.Closest(map.Units);

                        //Check In Range
                        if (distanceTo <= wu.AttackRange)
                        {
                            wu.IsAttacking = true;
                            wu.Combat(closest);
                        }
                        else //Move Towards
                        {
                            if (closest is MeleeUnit)
                            {
                                MeleeUnit closestMu = (MeleeUnit)closest;
                                if (wu.XPos > closestMu.XPos) //North
                                {
                                    wu.Move(0);
                                }
                                else if (wu.XPos < closestMu.XPos) //South
                                {
                                    wu.Move(2);
                                }
                                else if (wu.YPos > closestMu.YPos) //West
                                {
                                    wu.Move(3);
                                }
                                else if (wu.YPos < closestMu.YPos) //East
                                {
                                    wu.Move(1);
                                }
                            }
                            else if (closest is RangedUnit)
                            {
                                RangedUnit closestRu = (RangedUnit)closest;
                                if (wu.XPos > closestRu.XPos) //North
                                {
                                    wu.Move(0);
                                }
                                else if (wu.XPos < closestRu.XPos) //South
                                {
                                    wu.Move(2);
                                }
                                else if (wu.YPos > closestRu.YPos) //West
                                {
                                    wu.Move(3);
                                }
                                else if (wu.YPos < closestRu.YPos) //East
                                {
                                    wu.Move(1);
                                }
                            }
                        }

                    }
                }
            }
            map.Display(grpMap);
            round++;
        }

        //Determines the distance between two units
        public int DistanceTo(Unit a, Unit b)
        {
            int distance = 0;

            if (a is MeleeUnit && b is MeleeUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is RangedUnit && b is MeleeUnit)
            {
                RangedUnit start = (RangedUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is RangedUnit && b is RangedUnit)
            {
                RangedUnit start = (RangedUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is MeleeUnit && b is RangedUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            //Add wizards
            else if (a is WizardUnit && b is WizardUnit)
            {
                WizardUnit start = (WizardUnit)a;
                WizardUnit end = (WizardUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is WizardUnit && b is MeleeUnit)
            {
                WizardUnit start = (WizardUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is WizardUnit && b is RangedUnit)
            {
                WizardUnit start = (WizardUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }

            return distance;
        }
    }
}
