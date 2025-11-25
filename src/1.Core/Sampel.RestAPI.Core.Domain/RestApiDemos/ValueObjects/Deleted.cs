using Zamin.Core.Domain.ValueObjects;

namespace Sampel.RestAPI.Core.Domain.RestApiDemos.ValueObjects
{
    public class Deleted : BaseValueObject<Deleted>
    {
        #region Constructors

        public Deleted(bool value)
        {
            Value = value;
        }

        #endregion

        #region Properties

        public bool Value { get; private set; }

        #endregion

        #region Methods

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator Deleted(bool v)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    
}
