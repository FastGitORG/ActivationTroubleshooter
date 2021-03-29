using System.Collections.Generic;

namespace ActivationTroubleshooter.Library.Models
{
    public class ItemModel
    {
        public string Id { get; set; }

        public string Message { get; set; }

        public List<ChoiceModel> Choices { get; set; }
    }
}
