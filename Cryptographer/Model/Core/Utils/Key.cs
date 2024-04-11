namespace Cryprotgrapher.Model.Core.Utils
{
    public struct Key<T>
    {
        private T _value;

        public Key(T value)
        {
            _value = value;
        }

        public T Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
            }
        }

    }
}
