using Cryprotgrapher.Model.Core.Alphabet;
using Cryprotgrapher.Model.Core.Utils;
using System.Collections;
using System.Linq;

namespace Cryprotgrapher.Model.Core.Cryptographer
{
    public class StreamCipherCryptographer : IEncryptor<BitArray>, IDecryptor<BitArray>
    {
        public string Encrypt(string input, Key<BitArray> key, IAlphabet alphabet)
        {
            BitArray[] inputBitsArray = alphabet.CharsToBits(input);
            bool[] inputBools = inputBitsArray.SelectMany(x => x.Cast<bool>()).ToArray();
            BitArray inputBits = new BitArray(inputBools);
            BitArray cipherText = key.Value.Xor(inputBits);
            string result = alphabet.GetCharsFromBits(cipherText);

            return result;
        }

        public string Decrypt(string input, Key<BitArray> key, IAlphabet alphabet)
        {
            return Encrypt(input, key, alphabet);
        }
    }
}
