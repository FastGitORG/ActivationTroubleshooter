using LinkedQuestion.Library.Models;

namespace LinkedQuestion.Library.Builder
{
    public class ChoiceBuilder
    {
        private ChoiceModel _cm;

        public ChoiceBuilder()
        {
            _cm = new ChoiceModel();
        }

        public ChoiceBuilder(ChoiceModel cm)
            => _cm = cm;

        public ChoiceBuilder SetNextId(string id)
        {
            _cm.NextId = id;
            return this;
        }

        public ChoiceBuilder SetMessage(string msg)
        {
            _cm.ChoiceMessage = msg;
            return this;
        }

        public ChoiceModel ToChoiceModel()
            => _cm;

        public static implicit operator ChoiceModel(ChoiceBuilder cb) => cb._cm;
    }
}