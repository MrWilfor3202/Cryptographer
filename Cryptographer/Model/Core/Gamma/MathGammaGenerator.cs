using Cryprotgrapher.Model.Core.Alphabet;
using Cryprotgrapher.Model.Core.Math;
using System.Collections;
using System.Linq;

namespace Cryprotgrapher.Model.Core.Gamma
{
    public class MathGammaGenerator : IGammaGenerator
    {
        private IMathGenerator _mathGenerator;
        private int _k;

        public MathGammaGenerator(IMathGenerator mathGenerator, int k) 
        {
            _mathGenerator = mathGenerator;
            _k = k;
        }

        public BitArray GetGamma(string message, IAlphabet alphabet)
        {
            int countSymbols = message.Length;
            int[] numbersGamma = _mathGenerator.Generate(countSymbols);
            bool[][] gammaBits = new bool[countSymbols][];


            for (int i = 0; i < gammaBits.GetLength(0); i++)
            {
                bool[] numberBits = new BitArray(new int[] { numbersGamma[i] })
                    .Cast<bool>()
                    .Take(_k)
                    .ToArray();

                gammaBits[i] = numberBits.Reverse().ToArray();
            }

            return new BitArray(gammaBits.SelectMany(x => x).ToArray());
        }
    }
}
