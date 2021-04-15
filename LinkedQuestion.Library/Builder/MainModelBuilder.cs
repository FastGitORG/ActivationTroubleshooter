using LinkedQuestion.Library.Models;

namespace LinkedQuestion.Library.Builder
{
    public class MainModelBuilder
    {
        private MainModel _mm;

        public MainModelBuilder()
        {
            _mm = new MainModel();
        }

        public MainModelBuilder SetTitle(string tt)
        {
            _mm.Name = tt;
            return this;
        }

        public MainModelBuilder SetStartId(string sid)
        {
            _mm.StartId = sid;
            return this;
        }

        public MainModelBuilder AddItem(ItemBuilder ib)
        {
            return AddItem((ItemModel)ib);
        }

        public MainModelBuilder AddItem(ItemModel im)
        {
            _mm.Items.Add(im);
            return this;
        }

        public MainModel ToMainModel()
            => _mm;

        public Starter ToStarter()
            => new Starter(_mm);

        public static implicit operator MainModel(MainModelBuilder sb) => sb._mm;
    }
}
