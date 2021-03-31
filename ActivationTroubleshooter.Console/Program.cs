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
            Starter.Run(ms);
        }


    }
}
