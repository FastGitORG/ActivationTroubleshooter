using System.Collections.Generic;

namespace ActivationTroubleshooter.Library.Models
{
    public class MainModel
    {
        public string Name { get; set; }
        public string StartId { get; set; }
        public List<ItemModel> Items { get; set; } = new List<ItemModel>();

        public string ToJson()
            => System.Text.Json.JsonSerializer.Serialize(this);
    }
}
