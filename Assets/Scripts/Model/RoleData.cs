using System;
using System.Data;

namespace Model
{
    [Serializable]
    public class RoleData
    {
        public int id;
        public string name;
        public string img;
        public string describe;
        public int slot;
        public int record;
        public int unlock;
        public string unlockConditions;
    }
}