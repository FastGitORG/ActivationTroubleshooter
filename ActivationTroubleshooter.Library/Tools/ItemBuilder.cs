using ActivationTroubleshooter.Library.Models;

namespace ActivationTroubleshooter.Library.Tools
{
    public class ItemBuilder
    {
        private ItemModel _im;

        public ItemBuilder()
        {
            _im = new ItemModel();
        }

        public ItemBuilder(ItemModel im)
            => _im = im;

        public ItemBuilder SetMessage(string s)
        {
            _im.Message = s;
            return this;
        }

        public ItemBuilder SetId(string s)
        {
            _im.Id = s;
            return this;
        }

        public ItemBuilder AddChoice(ChoiceModel cm)
        {
            _im.Choices.Add(cm);
            return this;
        }

        public ItemModel ToItemModel()
            => _im;

        public static implicit operator ItemModel(ItemBuilder ib) => ib._im;

    }
}
