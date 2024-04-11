using Cryprotgrapher.Model.Core.Alphabet;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Cryprotgrapher.Model.Core.Gamma
{
    public class MixtureGammaGenerator : IGammaGenerator
    {
        private BitArray x;
        private BitArray y;
        private BitArray z;

        public MixtureGammaGenerator(BitArray x, BitArray y, BitArray z) 
        {
            this.x = x;
            this.y = y;
            this.z = z;
        } 

        public BitArray GetGamma(string message, IAlphabet alphabet)
        { 
            BitArray xyz = ((BitArray) x.Clone()).And((BitArray)y.Clone()).And((BitArray) z.Clone());
            BitArray xz = ((BitArray)x.Clone()).And((BitArray) z.Clone());
            BitArray yx = ((BitArray) y.Clone()).And((BitArray) x.Clone());
            
            
            var result = xyz.Xor(xz).Xor(yx).Xor(z);

            return result;
        }
    }
}
