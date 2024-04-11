using System.Linq;

namespace Cryprotgrapher.Model.Core.Math
{
    internal class LinearCongruentialGenerator : IMathGenerator
    {
        private readonly int _module;
        private readonly int _multiplier;
        private readonly int _accretion;
        private readonly int _startValue;

        public LinearCongruentialGenerator(int module, int multiplier, int accretion, int startValue)
        {
            _module = module;
            _multiplier = multiplier;
            _accretion = accretion;
            _startValue = startValue;
        }

        public int[] Generate(int count)
        {
            int[] result = new int[count + 1];
            result[0] = _startValue;

            for (int i = 1; i < count + 1; i++)
                result[i] = (_multiplier * result[i - 1] + _accretion) % _module;

            return result.Skip(1).ToArray();
        }
    }
}
