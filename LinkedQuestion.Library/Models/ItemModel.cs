using System.Collections.Generic;

namespace LinkedQuestion.Library.Models
{
    public class ItemModel
    {
        public string Id { get; set; }

        public string Message { get; set; }

        public List<ChoiceModel> Choices { get; set; } = new List<ChoiceModel>();
    }
}
