using System;
using System.Collections.Generic;
using LinkedQuestion.Library.Models;

namespace LinkedQuestion.Library.Builder
{
    public class Starter
    {
        private MainModel _mm;
        private Dictionary<string, ItemModel> _dic;
        private bool _printTitle = true;

        #region Constructors
        public Starter()
        {

        }

        public Starter(string s)
        {
            ChangeItem(s);
        }

        public Starter(MainModel mm)
        {
            ChangeItem(mm);
        }
        #endregion

        public Starter PrintTitle(bool isPrint = true)
        {
            _printTitle = isPrint;
            return this;
        }

        public Starter ChangeItem(string s)
            => ChangeItem(System.Text.Json.JsonSerializer.Deserialize<MainModel>(s));

        public Starter ChangeItem(MainModel mm)
        {
            _mm = mm;
            _dic = Helper.ConvertToDic(_mm);
            return this;
        }

        public void Run()
        {
            if (_mm is null || _dic is null)
            {
                Console.Error.WriteLine("You haven't iniliase mainmodel");
                return;
            }

            if (_printTitle)
            {
                Console.WriteLine(_mm.Name);
            }

            if (!_dic.ContainsKey(_mm.StartId))
            {
                Console.Error.WriteLine("Cannot find start pointer!");
                return;
            }
            ItemModel im;
            string nextId = _mm.StartId;

            while (!string.IsNullOrEmpty(nextId))
            {
                im = _dic[nextId];
                Console.WriteLine(im.Message);
                nextId = GetNextId(im.Choices);
            }
        }

        public Starter EnsureValid()
        {
            if (!Helper.Verify(_dic))
                throw new Exception("Invalid"); // TODO: Change to correct exp.
            return this;
        }

        private static string GetNextId(List<ChoiceModel> l)
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
