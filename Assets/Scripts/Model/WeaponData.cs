﻿using System;

namespace Model
{
    [Serializable]
    public class WeaponData
    {
        public int id;
        public string name;
        public string img;
        public int grade;
        public int price;
        public int isLong;
        public int range;
        public float critical_strikes_multiple;
        public float critical_strikes_probability;
        public float cooling;
        public int repel;
        public string describe;
    }
}