using ActivationTroubleshooter.Library.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace ActivationTroubleshooter.Library.Tools
{
    public class ShitBuilder
    {
        private MainModel _mm;

        public ShitBuilder()
        {
            _mm = new MainModel();
        }

        public ShitBuilder SetTitle(string tt)
        {
            _mm.Name = tt;
            return this;
        }

        public ShitBuilder SetStartId(string sid)
        {
            _mm.StartId = sid;
            return this;
        }

        public ShitBuilder AddItem(ItemBuilder ib)
        {
            return AddItem((ItemModel)ib);
        }

        public ShitBuilder AddItem(ItemModel im)
        {
            _mm.Items.Add(im);
            return this;
        }

        public MainModel ToMainModel()
            => _mm;

        public Starter ToStarter()
            => new Starter(_mm);

        public static implicit operator MainModel(ShitBuilder sb) => sb._mm;
    }
}
