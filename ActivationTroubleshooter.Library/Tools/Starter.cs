using ActivationTroubleshooter.Library.Models;

using System;
using System.Collections.Generic;

namespace ActivationTroubleshooter.Library.Tools
{
    public class Starter
    {
        private MainModel _mm;

        public Starter()
        {

        }

        public Starter(string s)
        {
            _mm = System.Text.Json.JsonSerializer.Deserialize<MainModel>(s);
        }

        public Starter(MainModel mm)
        {
            _mm = mm;
        }


        public void Run()
        {
            if (_mm is null)
            {
                Console.Error.WriteLine("You haven't iniliase mainmodel");
                return;
            }
            var dic = Helper.ConvertToDic(_mm);
            if (!dic.ContainsKey(_mm.StartId))
            {
                Console.Error.WriteLine("Cannot find start pointer!");
                return;
            }
            ItemModel im;
            string nextId = _mm.StartId;

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
