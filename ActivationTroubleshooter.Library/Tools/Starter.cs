using ActivationTroubleshooter.Library.Models;

using System;
using System.Collections.Generic;

namespace ActivationTroubleshooter.Library.Tools
{
    public class Starter
    {
        public static void Run(string s)
            => Run(System.Text.Json.JsonSerializer.Deserialize<MainModel>(s));

        public static void Run(MainModel mm)
        {
            var dic = Helper.ConvertToDic(mm);
            if (!dic.ContainsKey(mm.StartId))
            {
                Console.Error.WriteLine("Cannot find start pointer!");
                return;
            }
            ItemModel im;
            string nextId = mm.StartId;

            while (!string.IsNullOrEmpty(nextId))
            {
                im = dic[nextId];
                Console.WriteLine(im.Message);
                nextId = GetNextId(im.Choices);
            }
        }

        public static string GetNextId(List<ChoiceModel> l)
        {
            int ii = 0;
            foreach (var i in l)
            {
                Console.WriteLine($"[{ii}] {i.ChoiceMessage}");
                ++ii;
            }

            while (true)
            {
                Console.Write($"Enter your choice [0-{ii - 1}]:");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice < ii && choice > -1)
                        return l[choice].NextId;
                }
                Console.Error.WriteLine("Invalid Input.");
            }

        }
    }
}
