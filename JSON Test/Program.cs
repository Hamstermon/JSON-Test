﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace JSON_Test
{
    class Program
    {
        static List<Attack> attacks = new List<Attack>();
        static List<CharData> characters = new List<CharData>();
        static List<MapData> maps = new List<MapData>();
        static List<MapChar> mapChar = new List<MapChar>();
        static List<CharAttack> charAtk = new List<CharAttack>();
        static JsonSerializer serializer = new JsonSerializer();

        static void AddElement(string tableName)
        {
            if (tableName == "attack")
            {
                Attack atk = new Attack();
                Console.WriteLine("Enter Attack Name");
                atk.Name = Console.ReadLine();
                Console.WriteLine("Enter Type");
                atk.Type = Console.ReadLine();
                Console.WriteLine("Enter Category");
                atk.Category = Console.ReadLine();
                Console.WriteLine("Enter Power");
                atk.Power = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Accuracy");
                atk.Accuracy = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Priority");
                atk.Priority = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter MP Cost");
                atk.MP = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Effect1Name");
                atk.Effect1Name = Console.ReadLine();
                Console.WriteLine("Enter Effect1Chance");
                atk.Effect1Chance = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Effect2Name");
                atk.Effect2Name = Console.ReadLine();
                Console.WriteLine("Enter Effect2Chance");
                atk.Effect2Chance = Convert.ToInt32(Console.ReadLine());
                atk.AttackID = GetFirstID(tableName);
                attacks.Add(atk);
            }
        }

        static void EditElement(string tableName, int id)
        {
            List<KeyValuePair<string,string>> values = new List<KeyValuePair<string, string>>();
            if (tableName == "attack")
            {
                Attack i = attacks[FindElement(tableName,id)];
                
                Console.WriteLine("Name: " + i.Name);
                Console.WriteLine("Type: " + i.Type);
                Console.WriteLine("Category: " + i.Category);
                Console.WriteLine("Power: " + i.Power);
                Console.WriteLine("Accuracy: " + i.Accuracy);
                Console.WriteLine("Priority: " + i.Priority);
                Console.WriteLine("MP Cost: " + i.MP);
                Console.WriteLine("Effect1Name: " + i.Effect1Name);
                Console.WriteLine("Effect1Chance: " + i.Effect1Chance);
                Console.WriteLine("Effect2Name: " + i.Effect2Name);
                Console.WriteLine("Effect2Chance: " + i.Effect2Chance);
                Console.WriteLine();

                string temp = "";
                Console.WriteLine("Enter Attack Name");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Name = temp;

                Console.WriteLine("Enter Type");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Type = temp;

                Console.WriteLine("Enter Category");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Category = temp;

                Console.WriteLine("Enter Power");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Power = Convert.ToInt32(temp);

                Console.WriteLine("Enter Accuracy");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Accuracy = Convert.ToInt32(temp);

                Console.WriteLine("Enter Priority");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Priority = Convert.ToInt32(temp);

                Console.WriteLine("Enter MP Cost");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Priority = Convert.ToInt32(temp);

                Console.WriteLine("Enter Effect1Name");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Effect1Name = temp;

                Console.WriteLine("Enter Effect1Chance");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Effect1Chance = Convert.ToInt32(temp);

                Console.WriteLine("Enter Effect2Name");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Effect2Name = temp;

                Console.WriteLine("Enter Effect2Chance");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Effect2Chance = Convert.ToInt32(temp);
            }
            else if (tableName == "character")
            {
                CharData i = characters[FindElement(tableName, id)];

                Console.WriteLine("Name: " + i.Name);
                Console.WriteLine("Spritesheet: " + i.SpriteSheet);
                Console.WriteLine("SpriteIndex: " + i.SpriteIndex);
                Console.WriteLine("XP: " + i.XP);
                Console.WriteLine("Type1: " + i.Type1);
                Console.WriteLine("Type2: " + i.Type2);
                Console.WriteLine("Type3: " + i.Type3);
                Console.WriteLine("HP: " + i.HP);
                Console.WriteLine("ATK: " + i.ATK);
                Console.WriteLine("DEF: " + i.DEF);
                Console.WriteLine("MAG: " + i.MAG);
                Console.WriteLine("RES: " + i.RES);
                Console.WriteLine("SPD: " + i.SPD);
                Console.WriteLine("OverworldAI: " + i.OverworldAI);
                Console.WriteLine("BattleAI: " + i.BattleAI);
                Console.WriteLine();

                string temp = "";
                Console.WriteLine("Enter Character Name");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Name = temp;

                Console.WriteLine("Enter Spritesheet name");
                temp = Console.ReadLine();
                if (temp != "")
                    i.SpriteSheet = temp;

                Console.WriteLine("Enter Sprite index");
                temp = Console.ReadLine();
                if (temp != "")
                    i.SpriteIndex = Convert.ToInt32(temp);

                Console.WriteLine("Enter XP");
                temp = Console.ReadLine();
                if (temp != "")
                    i.XP = Convert.ToInt32(temp);

                Console.WriteLine("Enter Type 1");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Type1 = temp;

                Console.WriteLine("Enter Type 2");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Type2 = temp;

                Console.WriteLine("Enter Type 3");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Type3 = temp;

                Console.WriteLine("Enter HP");
                temp = Console.ReadLine();
                if (temp != "")
                    i.HP = Convert.ToInt32(temp);

                Console.WriteLine("Enter ATK");
                temp = Console.ReadLine();
                if (temp != "")
                    i.ATK = Convert.ToInt32(temp);

                Console.WriteLine("Enter DEF");
                temp = Console.ReadLine();
                if (temp != "")
                    i.DEF = Convert.ToInt32(temp);

                Console.WriteLine("Enter MAG");
                temp = Console.ReadLine();
                if (temp != "")
                    i.MAG = Convert.ToInt32(temp);

                Console.WriteLine("Enter RES");
                temp = Console.ReadLine();
                if (temp != "")
                    i.RES = Convert.ToInt32(temp);

                Console.WriteLine("Enter SPD");
                temp = Console.ReadLine();
                if (temp != "")
                    i.SPD = Convert.ToInt32(temp);

                Console.WriteLine("Enter Overworld AI");
                temp = Console.ReadLine();
                if (temp != "")
                    i.OverworldAI = temp;

                Console.WriteLine("Enter Battle AI");
                temp = Console.ReadLine();
                if (temp != "")
                    i.BattleAI = temp;
            }
            else if (tableName == "map")
            {
                MapData i = maps[FindElement(tableName, id)];

                Console.WriteLine("Name: " + i.Name);
                Console.WriteLine("FileName: " + i.MapFileName);
                Console.WriteLine();

                string temp = "";
                Console.WriteLine("Enter Map Name");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Name = temp;
                Console.WriteLine("Enter Filename");
                temp = Console.ReadLine();
                if (temp != "")
                    i.MapFileName = temp;
            }
            else if (tableName == "mapchar")
            {
                MapChar i = mapChar[FindElement(tableName, id)];

                string mapName = "";
                int realMapID = FindElement("map", i.MapID);
                if (maps[realMapID] != null)
                    mapName = "(" + maps[realMapID].Name + ")";
                string charName = "";
                int realCharID = FindElement("character", i.CharID);
                if (characters[realCharID] != null)
                    charName = "(" + characters[realCharID].Name + ")";
                Console.WriteLine("MapID: " + i.MapID + mapName);
                Console.WriteLine("CharID: " + i.CharID + charName);
                Console.WriteLine("Weight: " + i.Weight);
                Console.WriteLine("MinLevel: " + i.MinLevel);
                Console.WriteLine("MaxLevel: " + i.MaxLevel);
                Console.WriteLine();

                string temp = "";
                Console.WriteLine("Enter MapID");
                temp = Console.ReadLine();
                if (temp != "")
                    i.MapID = Convert.ToInt32(temp);

                Console.WriteLine("Enter CharID");
                temp = Console.ReadLine();
                if (temp != "")
                    i.CharID = Convert.ToInt32(temp);

                Console.WriteLine("Enter Weight");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Weight = Convert.ToInt32(temp);

                Console.WriteLine("Enter MinLevel");
                temp = Console.ReadLine();
                if (temp != "")
                    i.MinLevel = Convert.ToInt32(temp);

                Console.WriteLine("Enter MaxLevel");
                temp = Console.ReadLine();
                if (temp != "")
                    i.MaxLevel = Convert.ToInt32(temp);
            }
            else if (tableName == "charattack")
            {
                CharAttack i = charAtk[FindElement(tableName, id)];

                string charName = "";
                int realCharID = FindElement("character", i.CharID);
                if (characters[realCharID] != null)
                    charName = "(" + characters[realCharID].Name + ")";
                string atkName = "";
                int realAtkID = FindElement("attack", i.AttackID);
                if (attacks[realAtkID] != null)
                    atkName = "(" + attacks[realAtkID].Name + ")";
                Console.WriteLine("CharID: " + i.CharID + charName);
                Console.WriteLine("AttackID: " + i.AttackID + atkName);
                Console.WriteLine("Level: " + i.Level);
                Console.WriteLine();

                string temp = "";
                Console.WriteLine("Enter CharID");
                temp = Console.ReadLine();
                if (temp != "")
                    i.CharID = Convert.ToInt32(temp);

                Console.WriteLine("Enter AttackID");
                temp = Console.ReadLine();
                if (temp != "")
                    i.AttackID = Convert.ToInt32(temp);

                Console.WriteLine("Enter Level");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Level = Convert.ToInt32(temp);
            }
        }

        static void RemoveElement(string tableName, int id)
        {
            if (tableName == "attack")
            {
                attacks.Remove(attacks[FindElement(tableName,id)]);
            }
            else if (tableName == "character")
            {
                characters.Remove(characters[FindElement(tableName, id)]);
            }
            else if (tableName == "map")
            {
                maps.Remove(maps[FindElement(tableName, id)]);
            }
            else if (tableName == "mapchar")
            {
                mapChar.Remove(mapChar[FindElement(tableName, id)]);
            }
            else if (tableName == "charattack")
            {
                charAtk.Remove(charAtk[FindElement(tableName, id)]);
            }
        }

        static void ReadTable(string tableName)
        {
            if (tableName == "attack")
            {
                foreach (Attack i in attacks)
                {
                    Console.WriteLine("ID: " + i.AttackID);
                    Console.WriteLine("Name: " + i.Name);
                    Console.WriteLine("Type: " + i.Type);
                    Console.WriteLine("Category: " + i.Category);
                    Console.WriteLine("Power: " + i.Power);
                    Console.WriteLine("Accuracy: " + i.Accuracy);
                    Console.WriteLine("Priority: " + i.Priority);
                    Console.WriteLine("MP Cost: " + i.MP);
                    Console.WriteLine("Effect1Name: " + i.Effect1Name);
                    Console.WriteLine("Effect1Chance: " + i.Effect1Chance);
                    Console.WriteLine("Effect2Name: " + i.Effect2Name);
                    Console.WriteLine("Effect2Chance: " + i.Effect2Chance);
                    Console.WriteLine();
                }
            }
            else if (tableName == "character")
            {
                foreach (CharData i in characters)
                {
                    Console.WriteLine("ID: " + i.CharID);
                    Console.WriteLine("Name: " + i.Name);
                    Console.WriteLine("Spritesheet: " + i.SpriteSheet);
                    Console.WriteLine("SpriteIndex: " + i.SpriteIndex);
                    Console.WriteLine("XP: " + i.XP);
                    Console.WriteLine("Type1: " + i.Type1);
                    Console.WriteLine("Type2: " + i.Type2);
                    Console.WriteLine("Type3: " + i.Type3);
                    Console.WriteLine("HP: " + i.HP);
                    Console.WriteLine("ATK: " + i.ATK);
                    Console.WriteLine("DEF: " + i.DEF);
                    Console.WriteLine("MAG: " + i.MAG);
                    Console.WriteLine("RES: " + i.RES);
                    Console.WriteLine("SPD: " + i.SPD);
                    Console.WriteLine("OverworldAI: " + i.OverworldAI);
                    Console.WriteLine("BattleAI: " + i.BattleAI);
                    Console.WriteLine();
                }
            }
            else if (tableName == "map")
            {
                foreach (MapData i in maps)
                {
                    Console.WriteLine("ID: " + i.MapID);
                    Console.WriteLine("Name: " + i.Name);
                    Console.WriteLine("FileName: " + i.MapFileName);
                    Console.WriteLine();
                }
            }
            else if (tableName == "mapchar")
            {
                Console.WriteLine("Enter map filter");
                int filter = 0;
                string temp = Console.ReadLine();
                if (temp != "")
                    filter = Convert.ToInt32(temp);
                foreach (MapChar i in mapChar)
                {
                    if (filter == 0)
                    {
                        Console.WriteLine("ID: " + i.ID);
                        string mapName = "";
                        int realMapID = FindElement("map", i.MapID);
                        if (maps[realMapID] != null)
                            mapName = "(" + maps[realMapID].Name + ")";
                        string charName = "";
                        int realCharID = FindElement("character", i.CharID);
                        if (characters[realCharID] != null)
                            charName = "(" + characters[realCharID].Name + ")";
                        Console.WriteLine("MapID: " + i.MapID + mapName);
                        Console.WriteLine("CharID: " + i.CharID + charName);
                        Console.WriteLine("Weight: " + i.Weight);
                        Console.WriteLine("MinLevel: " + i.MinLevel);
                        Console.WriteLine("MaxLevel: " + i.MaxLevel);
                        Console.WriteLine();
                    }
                    else if (filter == i.MapID)
                    {
                        Console.WriteLine("ID: " + i.ID);
                        string charName = "";
                        int realCharID = FindElement("character", i.CharID);
                        if (characters[realCharID] != null)
                            charName = "(" + characters[realCharID].Name + ")";
                        Console.WriteLine("CharID: " + i.CharID + charName);
                        Console.WriteLine("Weight: " + i.Weight);
                        Console.WriteLine("MinLevel: " + i.MinLevel);
                        Console.WriteLine("MaxLevel: " + i.MaxLevel);
                        Console.WriteLine();
                    }
                }
            }
            else if (tableName == "charattack")
            {
                Console.WriteLine("Enter character filter");
                int filter = 0;
                string temp = Console.ReadLine();
                if (temp != "")
                    filter = Convert.ToInt32(temp);
                foreach (CharAttack i in charAtk)
                {
                    if (filter == 0)
                    {
                        Console.WriteLine("ID: " + i.ID);
                        string charName = "";
                        int realCharID = FindElement("character", i.CharID);
                        if (characters[realCharID] != null)
                            charName = "(" + characters[realCharID].Name + ")";
                        string atkName = "";
                        int realAtkID = FindElement("attack", i.AttackID);
                        if (attacks[realAtkID] != null)
                            atkName = "(" + attacks[realAtkID].Name + ")";
                        Console.WriteLine("CharID: " + i.CharID + charName);
                        Console.WriteLine("AttackID: " + i.AttackID + atkName);
                        Console.WriteLine("Level: " + i.Level);
                        Console.WriteLine();
                    }
                    else if (filter == i.CharID)
                    {
                        Console.WriteLine("ID: " + i.ID);
                        string atkName = "";
                        int realAtkID = FindElement("attack", i.AttackID);
                        if (attacks[realAtkID] != null)
                            atkName = "(" + attacks[realAtkID].Name + ")";
                        Console.WriteLine("AttackID: " + i.AttackID + atkName);
                        Console.WriteLine("Level: " + i.Level);
                        Console.WriteLine();
                    }
                }
            }
        }

        static int FindElement(string tableName, int id)
        {
            int realID = -1;
            if (tableName == "attack")
            {
                for (int i = 0; i < attacks.Count; i++)
                {
                    Attack v = attacks[i];
                    if (v.AttackID == id)
                    {
                        realID = i;
                        break;
                    }
                }
            }
            else if (tableName == "character")
            {
                for (int i = 0; i < characters.Count; i++)
                {
                    CharData v = characters[i];
                    if (v.CharID == id)
                    {
                        realID = i;
                        break;
                    }
                }
            }
            else if (tableName == "map")
            {
                for (int i = 0; i < maps.Count; i++)
                {
                    MapData v = maps[i];
                    if (v.MapID == id)
                    {
                        realID = i;
                        break;
                    }
                }
            }
            else if (tableName == "mapchar")
            {
                for (int i = 0; i < mapChar.Count; i++)
                {
                    MapChar v = mapChar[i];
                    if (v.ID == id)
                    {
                        realID = i;
                        break;
                    }
                }
            }
            else if (tableName == "charattack")
            {
                for (int i = 0; i < charAtk.Count; i++)
                {
                    CharAttack v = charAtk[i];
                    if (v.ID == id)
                    {
                        realID = i;
                        break;
                    }
                }
            }
            return realID;
        }

        static int GetFirstID(string tableName)
        {
            int id = 0;
            bool found = false;
            if (tableName == "attack")
            {
                do
                {
                    found = false;
                    foreach(Attack v in attacks)
                    {
                        if (v.AttackID == id)
                        {
                            found = true;
                        }
                    }
                    if (found)
                        id++;
                }
                while (found == true);
            }
            else if (tableName == "character")
            {
                do
                {
                    found = false;
                    foreach (CharData v in characters)
                    {
                        if (v.CharID == id)
                        {
                            found = true;
                        }
                    }
                    if (found)
                        id++;
                }
                while (found == true);
            }
            else if (tableName == "map")
            {
                do
                {
                    found = false;
                    foreach (MapData v in maps)
                    {
                        if (v.MapID == id)
                        {
                            found = true;
                        }
                    }
                    if (found)
                        id++;
                }
                while (found == true);
            }
            else if (tableName == "mapchar")
            {
                do
                {
                    found = false;
                    foreach (MapChar v in mapChar)
                    {
                        if (v.ID == id)
                        {
                            found = true;
                        }
                    }
                    if (found)
                        id++;
                }
                while (found == true);
            }
            else if (tableName == "charattack")
            {
                do
                {
                    found = false;
                    foreach (CharAttack v in charAtk)
                    {
                        if (v.ID == id)
                        {
                            found = true;
                        }
                    }
                    if (found)
                        id++;
                }
                while (found == true);
            }
            return id;
        }

        static void Save()
        {
            using (StreamWriter sw = new StreamWriter("attacks.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, attacks);
            }
            using (StreamWriter sw = new StreamWriter("character.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, characters);
            }
            using (StreamWriter sw = new StreamWriter("maps.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, maps);
            }
            using (StreamWriter sw = new StreamWriter("mapchar.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, mapChar);
            }
            using (StreamWriter sw = new StreamWriter("charattack.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, charAtk);
            }
        }

        static void Load()
        {
            using (StreamReader sr = new StreamReader("attacks.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                attacks = serializer.Deserialize<List<Attack>>(reader);
            }
            using (StreamReader sr = new StreamReader("character.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                characters = serializer.Deserialize<List<CharData>>(reader);
            }
            using (StreamReader sr = new StreamReader("maps.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                maps = serializer.Deserialize<List<MapData>>(reader);
            }
            using (StreamReader sr = new StreamReader("mapchar.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                mapChar = serializer.Deserialize<List<MapChar>>(reader);
            }
            using (StreamReader sr = new StreamReader("charattack.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                charAtk = serializer.Deserialize<List<CharAttack>>(reader);
            }
        }

        static void Main(string[] args)
        {
            Load();
            Console.WriteLine("Enter Table to edit");
            string tableName = Console.ReadLine().ToLower();
            while (!(tableName == "attack" || tableName == "character" || tableName == "map" || tableName == "mapchar" || tableName == "charattack"))
            {
                Console.WriteLine("Invalid table name, enter new table name");
                tableName = Console.ReadLine().ToLower();
            }
            bool running = true;
            bool savedChanges = true;
            do
            {
                Console.WriteLine("Enter command");
                string input = Console.ReadLine().ToLower();
                string[] command = input.Split(' ');
                if (command[0] == "add")
                {
                    AddElement(tableName);
                    savedChanges = false;
                }
                else if (command[0] == "edit")
                {
                    EditElement(tableName, Convert.ToInt32(command[1]));
                    savedChanges = false;
                }
                else if (command[0] == "remove")
                {
                    RemoveElement(tableName, Convert.ToInt32(command[1]));
                    savedChanges = false;
                }
                else if (command[0] == "read")
                {
                    ReadTable(tableName);
                }
                else if (command[0] == "save")
                {
                    Save();
                    savedChanges = true;
                }
                else if(command[0] == "exit")
                {
                    if (savedChanges)
                        running = false;
                    else
                    {
                        Console.WriteLine("changes were not saved, would you like to save?");
                        if (Console.ReadLine().ToLower() == "y")
                        { 
                            Save();
                            running = false;
                        }
                        else if (Console.ReadLine().ToLower() == "n")
                            running = false;
                    }
                    
                }
            }
            while (running);
        }
    }
}
