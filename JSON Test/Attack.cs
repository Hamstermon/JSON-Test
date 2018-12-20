using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Test
{
    class Attack
    {
        int attackID = 0;
        public int AttackID
        {
            set { attackID = value; }
            get { return attackID; }
        }

        string name = "";
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        string type = "";
        public string Type
        {
            set { type = value; }
            get { return type; }
        }

        string category = "";
        public string Category
        {
            set { category = value; }
            get { return category; }
        }

        int power = 0;
        public int Power
        {
            set { power = value; }
            get { return power; }
        }

        int accuracy = 0;
        public int Accuracy
        {
            set { accuracy = value; }
            get { return accuracy; }
        }

        int priority = 0;
        public int Priority
        {
            set { priority = value; }
            get { return priority; }
        }

        string effect1Name = "";
        public string Effect1Name
        {
            set { effect1Name = value; }
            get { return effect1Name; }
        }

        int effect1Chance = 0;
        public int Effect1Chance
        {
            set { effect1Chance = value; }
            get { return effect1Chance; }
        }

        string effect2Name = "";
        public string Effect2Name
        {
            set { effect2Name = value; }
            get { return effect2Name; }
        }

        int effect2Chance = 0;
        public int Effect2Chance
        {
            set { effect2Chance = value; }
            get { return effect2Chance; }
        }
    }
}
