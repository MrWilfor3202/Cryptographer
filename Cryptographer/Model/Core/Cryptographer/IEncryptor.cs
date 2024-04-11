using Cryprotgrapher.Model.Core.Alphabet;
using Cryprotgrapher.Model.Core.Utils;

namespace Cryprotgrapher.Model.Core.Cryptographer
{
    internal interface IEncryptor<K>
    {
        string Encrypt(string input, Key<K> key, IAlphabet alphabet);
    }
}
