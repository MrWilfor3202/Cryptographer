using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cryprotgrapher.Model.Core.Utils
{
    public static class BitArrayExtension
    {
        public static BitArray ToBitArray(this IEnumerable<bool> bools) 
        {
            return new BitArray(bools.ToArray());
        }

        public static BitArray[] ToBitArrays(this BitArray array, int sizePart)
        {
            if ((array.Length % sizePart) != 0)
                return null;

            int countParts = array.Length / sizePart;
            bool[] bools = array.Cast<bool>().ToArray();

            BitArray[] result = new BitArray[countParts];

            for (int i = 0; i < countParts; i++)
            {
                result[i] = bools.Skip(i * sizePart).Take(sizePart).ToBitArray();
            }

            return result;
        }

        public static double Log(int n, int b) 
        {
            return System.Math.Log10(n) / System.Math.Log10(b);
        }
    }
}
