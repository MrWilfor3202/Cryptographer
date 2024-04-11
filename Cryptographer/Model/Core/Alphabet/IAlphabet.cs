using System.Collections;

namespace Cryprotgrapher.Model.Core.Alphabet
{
    public interface IAlphabet
    {
        int CountBitsInSymbol { get; }

        int CountSymbols{ get; }

        char[] GetAlphabetChars();
        

        char BitsToChar(BitArray array);

        BitArray CharToBits(char ch);

        BitArray[] CharsToBits(string str);

        string GetCharsFromBits(BitArray bitArray);

    }
}
