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
        static List<Dialog> dialogs = new List<Dialog>();
        static JsonSerializer serializer = new JsonSerializer();

        static void AddElement(string tableName)
        {
            if (tableName == "attack")
            {
                Attack atk = new Attack();
                Console.WriteLine("Name");
                atk.Name = Console.ReadLine();
                Console.WriteLine("Type");
                atk.Type = Console.ReadLine();
                Console.WriteLine("Category");
                atk.Category = Console.ReadLine();
                Console.WriteLine("Zones (O = none, X = hit)");
                atk.Zones = Console.ReadLine();
                Console.WriteLine("Fixed");
                atk.Fixed = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine("Power");
                atk.Power = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Accuracy");
                atk.Accuracy = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Priority");
                atk.Priority = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("MP Cost");
                atk.MP = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Effect1Name");
                atk.Effect1Name = Console.ReadLine();
                Console.WriteLine("Effect1Chance");
                atk.Effect1Chance = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Effect2Name");
                atk.Effect2Name = Console.ReadLine();
                Console.WriteLine("Effect2Chance");
                atk.Effect2Chance = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Description");
                atk.Description = Console.ReadLine();
                atk.AttackID = GetFirstID(tableName);
                attacks.Add(atk);
            }
            else if (tableName == "character")
            {
                CharData character = new CharData();
                Console.WriteLine("Name");
                character.Name = Console.ReadLine();
                Console.WriteLine("Spritesheet");
                character.SpriteSheet = Console.ReadLine();
                Console.WriteLine("SpriteIndex");
                character.SpriteIndex = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("XP");
                character.XP = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Weak1");
                character.Weakness1 = Console.ReadLine();
                Console.WriteLine("Weak2");
                character.Weakness2 = Console.ReadLine();
                Console.WriteLine("Res1");
                character.Resistance1 = Console.ReadLine();
                Console.WriteLine("Res2");
                character.Resistance2 = Console.ReadLine();
                Console.WriteLine("HP");
                character.HP = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("MP");
                character.MP = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("ATK");
                character.ATK = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("DEF");
                character.DEF = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("MAG");
                character.MAG = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("RES");
                character.RES = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("SPD");
                character.SPD = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("OverworldAI");
                character.OverworldAI = Console.ReadLine();
                Console.WriteLine("PassiveSpeed");
                character.PassiveSpeed = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("AgressiveSpeed");
                character.AgressiveSpeed = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("BattleAI");
                character.BattleAI = Console.ReadLine();
                character.CharID = GetFirstID(tableName);
                characters.Add(character);
            }
            else if (tableName == "map")
            {
                MapData map = new MapData();
                Console.WriteLine("Name");
                map.Name = Console.ReadLine();
                Console.WriteLine("Map File Name");
                map.MapFileName = Console.ReadLine();
                Console.WriteLine("Battle File Name");
                map.BattleFileName = Console.ReadLine();
                Console.WriteLine("SpawnCap");
                map.SpawnCap = Convert.ToInt32(Console.ReadLine());
                map.MapID = GetFirstID(tableName);
                maps.Add(map);
            }
            else if (tableName == "mapchar")
            {
                MapChar mc = new MapChar();
                Console.WriteLine("MapID");
                mc.MapID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("CharID");
                mc.CharID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Weight");
                mc.Weight = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("MinLevel");
                mc.MinLevel = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("MaxLevel");
                mc.MaxLevel = Convert.ToInt32(Console.ReadLine());
                mc.ID = GetFirstID(tableName);
                mapChar.Add(mc);
            }
            else if (tableName == "charattack")
            {
                CharAttack ca = new CharAttack();
                Console.WriteLine("CharID");
                ca.CharID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("AttackID");
                ca.AttackID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Level");
                ca.Level = Convert.ToInt32(Console.ReadLine());
                ca.ID = GetFirstID(tableName);
                charAtk.Add(ca);
            }
            else if (tableName == "dialog")
            {
                Dialog di = new Dialog();
                Console.WriteLine("DialogName");
                di.Name = Console.ReadLine();
                Console.WriteLine("CharacterName");
                di.CharName = Console.ReadLine();
                Console.WriteLine("Text");
                di.Text = Console.ReadLine();

                Console.WriteLine("Option1Text");
                di.OptionName1 = Console.ReadLine();
                Console.WriteLine("Option1Next");
                di.OptionNext1 = Console.ReadLine();
                Console.WriteLine("Option1Event");
                di.OptionEvent1 = Console.ReadLine();

                Console.WriteLine("Option2Text");
                di.OptionName2 = Console.ReadLine();
                Console.WriteLine("Option2Next");
                di.OptionNext2 = Console.ReadLine();
                Console.WriteLine("Option2Event");
                di.OptionEvent2 = Console.ReadLine();

                Console.WriteLine("Option3Text");
                di.OptionName3 = Console.ReadLine();
                Console.WriteLine("Option3Next");
                di.OptionNext3 = Console.ReadLine();
                Console.WriteLine("Option3Event");
                di.OptionEvent3 = Console.ReadLine();
                dialogs.Add(di);
            }
        }

        static void EditElement(string tableName, int id)
        {
            //List<KeyValuePair<string,string>> values = new List<KeyValuePair<string, string>>();
            if (tableName == "attack")
            {
                Attack i = attacks[FindElement(tableName,id)];
                
                Console.WriteLine("Name: " + i.Name);
                Console.WriteLine("Type: " + i.Type);
                Console.WriteLine("Category: " + i.Category);
                Console.WriteLine("Zones: " + i.Zones);
                Console.WriteLine("Fixed: " + i.Fixed);
                Console.WriteLine("Power: " + i.Power);
                Console.WriteLine("Accuracy: " + i.Accuracy);
                Console.WriteLine("Priority: " + i.Priority);
                Console.WriteLine("MP Cost: " + i.MP);
                Console.WriteLine("Effect1Name: " + i.Effect1Name);
                Console.WriteLine("Effect1Chance: " + i.Effect1Chance);
                Console.WriteLine("Effect2Name: " + i.Effect2Name);
                Console.WriteLine("Effect2Chance: " + i.Effect2Chance);
                Console.WriteLine("Description: " + i.Description);
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

                Console.WriteLine("Enter Zones (O = none, X = hit)");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Zones = temp;

                Console.WriteLine("Enter Fixed");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Fixed = Convert.ToBoolean(temp);

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

                Console.WriteLine("Enter Description");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Description = temp;
            }
            else if (tableName == "character")
            {
                CharData i = characters[FindElement(tableName, id)];

                Console.WriteLine("Name: " + i.Name);
                Console.WriteLine("Spritesheet: " + i.SpriteSheet);
                Console.WriteLine("SpriteIndex: " + i.SpriteIndex);
                Console.WriteLine("XP: " + i.XP);
                Console.WriteLine("Weak1: " + i.Weakness1);
                Console.WriteLine("Weak2: " + i.Weakness2);
                Console.WriteLine("Res1: " + i.Resistance1);
                Console.WriteLine("Res2: " + i.Resistance2);
                Console.WriteLine("HP: " + i.HP);
                Console.WriteLine("MP: " + i.MP);
                Console.WriteLine("ATK: " + i.ATK);
                Console.WriteLine("DEF: " + i.DEF);
                Console.WriteLine("MAG: " + i.MAG);
                Console.WriteLine("RES: " + i.RES);
                Console.WriteLine("SPD: " + i.SPD);
                Console.WriteLine("OverworldAI: " + i.OverworldAI);
                Console.WriteLine("PassiveSpeed: " + i.PassiveSpeed);
                Console.WriteLine("AgressiveSpeed: " + i.AgressiveSpeed);
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

                Console.WriteLine("Enter Weakness 1");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Weakness1 = temp;

                Console.WriteLine("Enter Weakness 2");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Weakness2 = temp;

                Console.WriteLine("Enter Resistance 1");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Resistance1 = temp;

                Console.WriteLine("Enter Resistance 2");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Resistance2 = temp;

                Console.WriteLine("Enter HP");
                temp = Console.ReadLine();
                if (temp != "")
                    i.HP = Convert.ToInt32(temp);

                Console.WriteLine("Enter MP");
                temp = Console.ReadLine();
                if (temp != "")
                    i.MP = Convert.ToInt32(temp);

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

                Console.WriteLine("Enter Passive Speed");
                temp = Console.ReadLine();
                if (temp != "")
                    i.PassiveSpeed = Convert.ToInt32(temp);

                Console.WriteLine("Enter Agressive Speed");
                temp = Console.ReadLine();
                if (temp != "")
                    i.AgressiveSpeed = Convert.ToInt32(temp);

                Console.WriteLine("Enter Battle AI");
                temp = Console.ReadLine();
                if (temp != "")
                    i.BattleAI = temp;
            }
            else if (tableName == "map")
            {
                MapData i = maps[FindElement(tableName, id)];

                Console.WriteLine("Name: " + i.Name);
                Console.WriteLine("MapFileName: " + i.MapFileName);
                Console.WriteLine("BattleFileName: " + i.BattleFileName);
                Console.WriteLine("SpawnCap: " + i.SpawnCap);
                Console.WriteLine();

                string temp = "";
                Console.WriteLine("Enter Map Name");
                temp = Console.ReadLine();
                if (temp != "")
                    i.Name = temp;
                Console.WriteLine("Enter Map Filename");
                temp = Console.ReadLine();
                if (temp != "")
                    i.MapFileName = temp;
                Console.WriteLine("Enter Battle Filename");
                temp = Console.ReadLine();
                if (temp != "")
                    i.BattleFileName = temp;
                Console.WriteLine("Enter Spawn Cap");
                temp = Console.ReadLine();
                if (temp != "")
                    i.SpawnCap = Convert.ToInt32(temp);
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

        static void EditElement(string tableName, string name)
        {
            if (tableName == "dialog")
            {
                Dialog i = FindDialog(name);
                if (i.Name != "xd")
                {
                    Console.WriteLine("Character: " + i.CharName);
                    Console.WriteLine("Text: " + i.Text);
                    Console.WriteLine("Option1Text: " + i.OptionName1);
                    Console.WriteLine("Option1Next: " + i.OptionNext1);
                    Console.WriteLine("Option1Event: " + i.OptionEvent1);

                    Console.WriteLine("Option2Text: " + i.OptionName2);
                    Console.WriteLine("Option2Next: " + i.OptionNext2);
                    Console.WriteLine("Option2Event: " + i.OptionEvent2);

                    Console.WriteLine("Option3Text: " + i.OptionName3);
                    Console.WriteLine("Option3Next: " + i.OptionNext3);
                    Console.WriteLine("Option3Event: " + i.OptionEvent3);

                    Console.WriteLine("Enter NAME");
                    string temp = Console.ReadLine();
                    if (temp != "")
                        i.Name = temp;
                    Console.WriteLine("Enter CHARACTER");
                    temp = Console.ReadLine();
                    if (temp != "")
                        i.CharName = temp;
                    Console.WriteLine("Enter TEXT");
                    temp = Console.ReadLine();
                    if (temp != "")
                        i.Text = temp;

                    Console.WriteLine("Enter OPTION 1 TEXT");
                    temp = Console.ReadLine();
                    if (temp != "")
                        i.OptionName1 = temp;
                    else if (temp == " ")
                        i.OptionName1 = "";
                    Console.WriteLine("Enter OPTION 1 NEXT");
                    temp = Console.ReadLine();
                    if (temp != "")
                        i.OptionNext1 = temp;
                    else if (temp == " ")
                        i.OptionNext1 = "";
                    Console.WriteLine("Enter OPTION 1 EVENT");
                    temp = Console.ReadLine();
                    if (temp != "")
                        i.OptionEvent1 = temp;
                    else if (temp == " ")
                        i.OptionEvent1 = "";

                    Console.WriteLine("Enter OPTION 2 TEXT");
                    temp = Console.ReadLine();
                    if (temp != "")
                        i.OptionName2 = temp;
                    else if (temp == " ")
                        i.OptionName2 = "";
                    Console.WriteLine("Enter OPTION 2 NEXT");
                    temp = Console.ReadLine();
                    if (temp != "")
                        i.OptionNext2 = temp;
                    else if (temp == " ")
                        i.OptionNext2 = "";
                    Console.WriteLine("Enter OPTION 2 EVENT");
                    temp = Console.ReadLine();
                    if (temp != "")
                        i.OptionEvent2 = temp;
                    else if (temp == " ")
                        i.OptionEvent2 = "";

                    Console.WriteLine("Enter OPTION 3 TEXT");
                    temp = Console.ReadLine();
                    if (temp != "")
                        i.OptionName3 = temp;
                    else if (temp == " ")
                        i.OptionName3 = "";
                    Console.WriteLine("Enter OPTION 3 NEXT");
                    temp = Console.ReadLine();
                    if (temp != "")
                        i.OptionNext3 = temp;
                    else if (temp == " ")
                        i.OptionNext3 = "";
                    Console.WriteLine("Enter OPTION 3 EVENT");
                    temp = Console.ReadLine();
                    if (temp != "")
                        i.OptionEvent3 = temp;
                    else if (temp == " ")
                        i.OptionEvent3 = "";
                }
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

        static void RemoveDialog(string name)
        {
            Dialog temp = FindDialog(name);
            if (temp.Name != "xd")
            {
                dialogs.Remove(temp);
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
                    Console.WriteLine("Zones: " + i.Zones);
                    Console.WriteLine("Fixed: " + i.Fixed);
                    Console.WriteLine("Power: " + i.Power);
                    Console.WriteLine("Accuracy: " + i.Accuracy);
                    Console.WriteLine("Priority: " + i.Priority);
                    Console.WriteLine("MP Cost: " + i.MP);
                    Console.WriteLine("Effect1Name: " + i.Effect1Name);
                    Console.WriteLine("Effect1Chance: " + i.Effect1Chance);
                    Console.WriteLine("Effect2Name: " + i.Effect2Name);
                    Console.WriteLine("Effect2Chance: " + i.Effect2Chance);
                    Console.WriteLine("Description: " + i.Description);
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
                    Console.WriteLine("Weak1: " + i.Weakness1);
                    Console.WriteLine("Weak2: " + i.Weakness2);
                    Console.WriteLine("Res1: " + i.Resistance1);
                    Console.WriteLine("Res2: " + i.Resistance2);
                    Console.WriteLine("HP: " + i.HP);
                    Console.WriteLine("MP: " + i.MP);
                    Console.WriteLine("ATK: " + i.ATK);
                    Console.WriteLine("DEF: " + i.DEF);
                    Console.WriteLine("MAG: " + i.MAG);
                    Console.WriteLine("RES: " + i.RES);
                    Console.WriteLine("SPD: " + i.SPD);
                    Console.WriteLine("OverworldAI: " + i.OverworldAI);
                    Console.WriteLine("PassiveSpeed: " + i.PassiveSpeed);
                    Console.WriteLine("AgressiveSpeed: " + i.AgressiveSpeed);
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
                    Console.WriteLine("MapFileName: " + i.MapFileName);
                    Console.WriteLine("BattleFileName: " + i.BattleFileName);
                    Console.WriteLine("SpawnCap: " + i.SpawnCap);
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
                        if (realMapID >= 0 && realMapID < maps.Count && maps[realMapID] != null)
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
                        if (realCharID < characters.Count && realCharID >= 0 && characters[realCharID] != null)
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
            else if (tableName == "dialog")
            {
                Console.WriteLine("Enter character filter");
                string filter = Console.ReadLine();
                foreach (Dialog i in dialogs)
                {
                    if (filter == "")
                    {
                        Console.WriteLine("NAME: " + i.Name);
                        Console.WriteLine("Character: " + i.CharName);
                        Console.WriteLine("Text: " + i.Text);
                        Console.WriteLine("Option1Text: " + i.OptionName1);
                        Console.WriteLine("Option1Next: " + i.OptionNext1);
                        Console.WriteLine("Option1Event: " + i.OptionEvent1);

                        Console.WriteLine("Option2Text: " + i.OptionName2);
                        Console.WriteLine("Option2Next: " + i.OptionNext2);
                        Console.WriteLine("Option2Event: " + i.OptionEvent2);

                        Console.WriteLine("Option3Text: " + i.OptionName3);
                        Console.WriteLine("Option3Next: " + i.OptionNext3);
                        Console.WriteLine("Option3Event: " + i.OptionEvent3);
                        Console.WriteLine();
                    }
                    else if (i.Name == filter)
                    {
                        Console.WriteLine("NAME: " + i.Name);
                        Console.WriteLine("Character: " + i.CharName);
                        Console.WriteLine("Text: " + i.Text);
                        Console.WriteLine("Option1Text: " + i.OptionName1);
                        Console.WriteLine("Option1Next: " + i.OptionNext1);
                        Console.WriteLine("Option1Event: " + i.OptionEvent1);

                        Console.WriteLine("Option2Text: " + i.OptionName2);
                        Console.WriteLine("Option2Next: " + i.OptionNext2);
                        Console.WriteLine("Option2Event: " + i.OptionEvent2);

                        Console.WriteLine("Option3Text: " + i.OptionName3);
                        Console.WriteLine("Option3Next: " + i.OptionNext3);
                        Console.WriteLine("Option3Event: " + i.OptionEvent3);
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

        static Dialog FindDialog(string name)
        {
            Dialog temp = new Dialog();
            temp.Name = "xd";
            foreach (Dialog i in dialogs)
            {
                if (i.Name == name)
                {
                    temp = i;
                }
            }
            return temp;
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
            using (StreamWriter sw = new StreamWriter("dialogs.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, dialogs);
            }
            Console.WriteLine("tables saved");
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
            using (StreamReader sr = new StreamReader("dialogs.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                dialogs = serializer.Deserialize<List<Dialog>>(reader);
            }
        }

        static void Main(string[] args)
        {
            Load();
            Console.WriteLine("Enter Table to edit");
            string tableName = Console.ReadLine().ToLower();
            while (!(tableName == "attack" || tableName == "character" || tableName == "map" || tableName == "mapchar" || tableName == "charattack" || tableName == "dialog"))
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
                    if (tableName == "dialog")
                        EditElement(tableName, command[1]);
                    else
                        EditElement(tableName, Convert.ToInt32(command[1]));
                    savedChanges = false;
                }
                else if (command[0] == "remove")
                {
                    if (tableName == "dialog")
                        RemoveDialog(command[1]);
                    else
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
                else if (command[0] == "attack")
                {
                    tableName = "attack";
                    Console.WriteLine("Now editing attack table");
                }
                else if (command[0] == "character")
                {
                    tableName = "character";
                    Console.WriteLine("Now editing character table");
                }
                else if (command[0] == "map")
                {
                    tableName = "map";
                    Console.WriteLine("Now editing map table");
                }
                else if (command[0] == "mapchar")
                {
                    tableName = "mapchar";
                    Console.WriteLine("Now editing map-char table");
                }
                else if (command[0] == "charattack")
                {
                    tableName = "charattack";
                    Console.WriteLine("Now editing char-attack table");
                }
                else if (command[0] == "dialog")
                {
                    tableName = "dialog";
                    Console.WriteLine("Now editing dialog table");
                }
                else if (command[0] == "exit")
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
