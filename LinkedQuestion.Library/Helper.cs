using LinkedQuestion.Library.Models;

using System.Collections.Generic;

namespace LinkedQuestion.Library
{
    public class Helper
    {
        public static Dictionary<string, ItemModel> ConvertToDic(MainModel mm)
        {
            if (mm.Items.Count < 1)
                return null;

            var dic = new Dictionary<string, ItemModel>();

            foreach (var c in mm.Items)
            {
                dic.Add(c.Id, c);
            }

            return dic;
        }

        public static bool Verify(Dictionary<string, ItemModel> dic)
        {
            foreach (var kv in dic)
            {
                foreach (var c in kv.Value.Choices)
                {
                    if (string.IsNullOrEmpty(c.NextId))
                        continue;
                    if (!dic.ContainsKey(c.NextId))
                        return false;
                }
            }
            return true;
        }
    }
}
