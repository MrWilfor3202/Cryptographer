using Cryprotgrapher.Model.Core.Alphabet;
using Cryprotgrapher.Model.Core.Utils;

namespace Cryprotgrapher.Model.Core.Cryptographer
{
    internal interface IDecryptor<K>
    {
        string Decrypt(string input, Key<K> key, IAlphabet alphabet);
    }
}
