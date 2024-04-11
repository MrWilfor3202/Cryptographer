using Cryprotgrapher.Model.Core.Alphabet;
using System.Collections;

namespace Cryprotgrapher.Model.Core.Gamma
{
    public interface IGammaGenerator
    {
        BitArray GetGamma(string message, IAlphabet alphabet);
    }
}
