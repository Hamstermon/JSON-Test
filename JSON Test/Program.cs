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
                Console.WriteLine("Enter Effect1Name");
                atk.Effect1Name = Console.ReadLine();
                Console.WriteLine("Enter Effect1Chance");
                atk.Effect1Chance = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Effect2Name");
                atk.Effect2Name = Console.ReadLine();
                Console.WriteLine("Enter Effect2Chance");
                atk.Effect2Chance = Convert.ToInt32(Console.ReadLine());
                attacks.Add(atk);
            }
        }

        static void EditElement(string tableName, int id)
        {
            List<KeyValuePair<string,string>> values = new List<KeyValuePair<string, string>>();
            if (tableName == "attack")
            {
                Attack i = attacks[id];
                values.Add(new KeyValuePair<string,string>("Name", "Str"));
                values.Add(new KeyValuePair<string, string>("Type", "Str"));
                values.Add(new KeyValuePair<string, string>("Category", "Str"));
                values.Add(new KeyValuePair<string, string>("Power", "Int"));
                values.Add(new KeyValuePair<string, string>("Accuracy", "Int"));
                values.Add(new KeyValuePair<string, string>("Priority", "Int"));
                values.Add(new KeyValuePair<string, string>("Effect1Name", "Str"));
                values.Add(new KeyValuePair<string, string>("Effect1Chance", "Int"));
                values.Add(new KeyValuePair<string, string>("Effect2Name", "Str"));
                values.Add(new KeyValuePair<string, string>("Effect2Chance", "Int"));

                Console.WriteLine("Current Values:");
                foreach (KeyValuePair<string,string> x in values)
                {
                    Console.WriteLine(x.Key+": "+ x.Value);
                }
                
                Console.WriteLine("Name: " + i.Name);
                Console.WriteLine("Type: " + i.Type);
                Console.WriteLine("Category: " + i.Category);
                Console.WriteLine("Power: " + i.Power);
                Console.WriteLine("Accuracy: " + i.Accuracy);
                Console.WriteLine("Priority: " + i.Priority);
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
        }

        static void RemoveElement(string tableName, int id)
        {
            if (tableName == "attack")
            {
                attacks.Remove(attacks[id]);
            }
        }

        static void ReadTable(string tableName)
        {
            if (tableName == "attack")
            {
                foreach (Attack i in attacks)
                {
                    Console.WriteLine("ID: "+i.AttackID);
                    Console.WriteLine("Name: " + i.Name);
                    Console.WriteLine("Type: " + i.Type);
                    Console.WriteLine("Category: " + i.Category);
                    Console.WriteLine("Power: " + i.Power);
                    Console.WriteLine("Accuracy: " + i.Accuracy);
                    Console.WriteLine("Priority: " + i.Priority);
                    Console.WriteLine("Effect1Name: " + i.Effect1Name);
                    Console.WriteLine("Effect1Chance: " + i.Effect1Chance);
                    Console.WriteLine("Effect2Name: " + i.Effect2Name);
                    Console.WriteLine("Effect2Chance: " + i.Effect2Chance);
                    Console.WriteLine();
                }
            }
        }

        static void Save()
        {
            using (StreamWriter sw = new StreamWriter("attacks.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, attacks);
            }
        }

        static void Load()
        {
            using (StreamReader sr = new StreamReader("attacks.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                attacks = serializer.Deserialize<List<Attack>>(reader);
            }
        }

        static void Main(string[] args)
        {
            Load();
            Console.WriteLine("Enter Table to edit");
            string tableName = Console.ReadLine().ToLower();
            while (!(tableName == "attack" || tableName == "character"))
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