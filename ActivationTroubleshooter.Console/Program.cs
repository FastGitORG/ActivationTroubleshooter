using ActivationTroubleshooter.Library;
using ActivationTroubleshooter.Library.Models;
using ActivationTroubleshooter.Library.Tools;

using System.Collections.Generic;

namespace ActivationTroubleshooter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            MainModel u = new MainModel()
            {
                StartId = "start",
            };

            u.Items.Add(
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

            u.Items.Add(
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

            System.Console.WriteLine(u.ToJson());

            // System.Console.ReadLine();
            new Starter(u)
                .PrintTitle()
                .Run();
        }


    }
}
