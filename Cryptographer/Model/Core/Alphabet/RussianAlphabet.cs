using Cryprotgrapher.Model.Core.Utils;
using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Cryprotgrapher.Model.Core.Alphabet
{
    public class RussianAlphabet : IAlphabet
    {
        private readonly char[] _alphabet;
        private readonly BitArray[]  _bitArrays;

        public int CountBitsInSymbol => 5;

        public int CountSymbols => 32;

        public RussianAlphabet() 
        {
            var test = new BitArray(new int[] { 2 });
            _alphabet = Enumerable.Range(0, 32).Select(x => (char)('а' + x)).ToArray();
            _bitArrays = Enumerable.Range(0, 32)
                .Select(x => new BitArray(new int[] { x })
                 .Cast<bool>()
                 .Take(CountBitsInSymbol)
                 .Reverse()
                 .ToBitArray())
                .ToArray();
        }

        public char BitsToChar(BitArray array)
        {
            char result = ' ';
            int arrayIndex = -1;

            for (int i = 0; i < _bitArrays.Length; i++)
            {
                if (_bitArrays[i].Cast<bool>().SequenceEqual(array.Cast<bool>()))
                    arrayIndex = i;
            }

            if (arrayIndex != -1)
                result = _alphabet[arrayIndex];

            return result;
        }

        public BitArray[] CharsToBits(string str)
        {
            BitArray[] bitArrays = new BitArray[str.Length];

            for(int i = 0; i < bitArrays.Length; i++) 
            {
                bitArrays[i] = CharToBits(str[i]);
            }

            return bitArrays;
        }

        public BitArray CharToBits(char ch)
        {
            BitArray result = null;

            int charIndex = Array.IndexOf(_alphabet, ch);

            if (charIndex != -1)
                result = _bitArrays[charIndex];

            return result;
        }

        public char[] GetAlphabetChars()
        {
            return (char[]) _alphabet.Clone();
        }

        public string GetCharsFromBits(BitArray bitArray)
        {
            StringBuilder result = new StringBuilder();
            BitArray[] bitArrays = bitArray.ToBitArrays(CountBitsInSymbol);
            
            foreach(BitArray array in bitArrays)
                result.Append(BitsToChar(array));

            return result.ToString();
        }
    }
}
