using System.Linq;

namespace Cryprotgrapher.Model.Core.Math
{
    public class QuadraticCongruentialGenerator : IMathGenerator
    {
        private readonly int _module;
        private readonly int _multiplierA;
        private readonly int _multiplierB;
        private readonly int _accretion;
        private readonly int _startValueA;
        private readonly int _startValueB;

        public QuadraticCongruentialGenerator(int module, int multiplierA, int multiplierB, int accretion, int startValueA, int startValueB)
        {
            _module = module;
            _multiplierA = multiplierA;
            _multiplierB = multiplierB;
            _accretion = accretion;
            _startValueA = startValueA;
            _startValueB = startValueB;
        }

        public int[] Generate(int count)
        {
            int[] result = new int[count + 2];
            result[0] = _startValueA;
            result[1] = _startValueB;

            for(int i = 2; i < count + 2; i++)
                result[i] = (_multiplierA * (result[i - 1] * result[i - 1]) 
                    + _multiplierB * result[i - 2] 
                    + _accretion) % _module;

            return result.Skip(2).ToArray();

        }
    }
}
