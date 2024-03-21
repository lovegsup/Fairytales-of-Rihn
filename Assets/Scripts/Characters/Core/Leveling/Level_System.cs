using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    public class Level_System
    {
        public int level;
        public int experience;
        public int experienceThreshold;

        public Level_System()
        {
            level = 1;
            experience = 0;
            experienceThreshold = 100;
        }

        public void AddExperience(int amount)
        {
            experience += amount;
            if (experience >= experienceThreshold)
            {
                ++level;
                experience -= experienceThreshold;
                experienceThreshold *= 2;
            }
        }
    }
}