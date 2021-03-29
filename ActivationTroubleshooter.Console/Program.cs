using ActivationTroubleshooter.Library;
using ActivationTroubleshooter.Library.Models;

using System;
using System.Collections.Generic;

namespace ActivationTroubleshooter.Console
{
    class Program
    {
        static void WL(string s)
            => System.Console.WriteLine(s);
        static string RL()
            => System.Console.ReadLine();

        static void W(string s)
            => System.Console.Write(s);

        static void Main(string[] args)
        {
            MainModel ms = new MainModel()
            {
                StartId = "start",
            };

            ms.Items.Add(
                new ItemModel()
                {
                    Message = "No1",
                    Id = "start",
                    Choices = new List<ChoiceModel>
                    {
                        new ChoiceModel()
                        {
                            ChoiceMessage  = "MSG",
                            NextId = "No2"
                        }
                    }
                }
            );

            ms.Items.Add(
                new ItemModel()
                {
                    Message = "No2",
                    Id = "No2",
                    Choices = new List<ChoiceModel>
                    {
                        new ChoiceModel()
                        {
                            ChoiceMessage  = "MSG2",
                            NextId = null
                        }
                    }
                }
            );
            Run(ms);
        }

        static void Run(MainModel mm)
        {
            var dic = Helper.ConvertToDic(mm);
            if (!dic.ContainsKey(mm.StartId))
            {
                WL("Cannot find start pointer!");
                return;
            }
            ItemModel im;
            string nextId = mm.StartId;

            while (!string.IsNullOrEmpty(nextId))
            {
                im = dic[nextId];
                WL(im.Message);
                nextId = GetNextId(im.Choices);
            }
        }

        static string GetNextId(List<ChoiceModel> l)
        {
            int ii = 0;
            foreach (var i in l)
            {
                WL($"[{ii}] {i.ChoiceMessage}");
                ++ii;
            }

            while (true)
            {
                W($"Enter your choice [0-{ii - 1}]:");
                if (int.TryParse(RL(), out int choice))
                {
                    if (choice < ii && choice > -1)
                        return l[choice].NextId;
                }
                WL("Invalid Input.");
            }

        }
    }
}
