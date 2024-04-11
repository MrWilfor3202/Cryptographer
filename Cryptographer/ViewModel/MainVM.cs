using Cryprotgrapher.Model.Core.Alphabet;
using Cryprotgrapher.Model.Core.Cryptographer;
using Cryprotgrapher.Model.Core.Gamma;
using Cryprotgrapher.Model.Core.Math;
using Cryprotgrapher.Model.Core.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Cryptographer.ViewModel
{
    internal class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _lkgA = 3;
        private int _lkgB = 5;
        private int _lkgP = 29;
        private int _lkgX0 = 7;
        private int _qcgA = 7;
        private int _qcgB = 2;
        private int _qcgP = 41;
        private int _qcgX0 = 2;
        private int _qcgC = 5;
        private int _qcgX1 = 6;
        private int _qcg2A = 3;
        private int _qcg2B = 11;
        private int _qcg2P = 23;
        private int _qcg2X0 = 1;
        private int _qcg2C = 13;
        private int _qcg2X1 = 5;
        private string _encryptText = "";
        private string _decryptText = "";
        private IAlphabet _selectedAlphabet;
        private List<(string, IAlphabet)> alphabets = new List<(string,IAlphabet)>();

        private RelayCommand _encryptCommand;
        private RelayCommand _decryptCommand;
        public int LKGA 
        {
            get => _lkgA;
            set 
            {
                _lkgA = value;
                OnPropertyChanged("LKGA");
            }
        }
        public int LKGB
        {
            get => _lkgB;
            set
            {
                _lkgB = value;
                OnPropertyChanged("LKGB");
            }
        }

        public int LKGP
        {
            get => _lkgP;
            set
            {
                _lkgP = value;
                OnPropertyChanged("LKGP");
            }
        }

        public int LKGX0
        {
            get => _lkgX0;
            set
            {
                _lkgX0 = value;
                OnPropertyChanged("LKGX0");
            }
        }

        public int QCGA
        {
            get => _qcgA;
            set
            {
                _qcgA = value;
                OnPropertyChanged("QCGA");
            }
        }
        public int QCGB
        {
            get => _qcgB;
            set
            {
                _qcgB = value;
                OnPropertyChanged("QCGB");
            }
        }

        public int QCGP
        {
            get => _qcgP;
            set
            {
                _qcgP = value;
                OnPropertyChanged("QCGP");
            }
        }

        public int QCGX0
        {
            get => _qcgX0;
            set
            {
                _qcgX0 = value;
                OnPropertyChanged("QCGX0");
            }
        }

        public int QCGX1
        {
            get => _qcgX1;
            set
            {
                _qcgX1 = value;
                OnPropertyChanged("QCGX1");
            }
        }

        public int QCGC
        {
            get => _qcgC;
            set
            {
                _qcgC = value;
                OnPropertyChanged("QCGC");
            }
        }

        public int QCG2A
        {
            get => _qcg2A;
            set
            {
                _qcg2A = value;
                OnPropertyChanged("QCG2A");
            }
        }
        public int QCG2B
        {
            get => _qcg2B;
            set
            {
                _qcg2B = value;
                OnPropertyChanged("QCG2B");
            }
        }

        public int QCG2P
        {
            get => _qcg2P;
            set
            {
                _qcg2P = value;
                OnPropertyChanged("QCG2P");
            }
        }

        public int QCG2X0
        {
            get => _qcg2X0;
            set
            {
                _qcg2X0 = value;
                OnPropertyChanged("QCG2X0");
            }
        }

        public int QCG2X1
        {
            get => _qcg2X1;
            set
            {
                _qcg2X1 = value;
                OnPropertyChanged("QCG2X1");
            }
        }

        public int QCG2XC
        {
            get => _qcg2C;
            set
            {
                _qcg2C = value;
                OnPropertyChanged("QCG2XC");
            }
        }

        public MainVM()
        {
            alphabets.Add(("ru", new RussianAlphabet()));
            _selectedAlphabet = alphabets[0].Item2;
        }

        public string EncryptedText
        {
            get => _encryptText;
            set
            {
                if (!value.Any(ch => char.IsNumber(ch)) && Regex.IsMatch(value, "^[^A-z]+$"))
                    _encryptText = value;
                else
                    _encryptText = "Используйте только кириллицу";

                OnPropertyChanged("EncryptedText");
            }
        }

        public string DecryptedText
        {
            get => _decryptText;
            set
            {
                if (!value.Any(ch => char.IsNumber(ch)) && Regex.IsMatch(value, "^[^A-z]+$"))
                    _decryptText = value;
                else
                    _decryptText = "Используйте только кириллицу";

                OnPropertyChanged("DecryptedText");
            }
        }

        public IAlphabet SelectedAlphabet 
        {
            get 
            {
                return _selectedAlphabet;
            }

            set 
            {
                _selectedAlphabet = value;
                OnPropertyChanged("SelectedAlphabet");
            }
        }

        public RelayCommand EncryptCommand
        {
            get
            {
                return _encryptCommand ?? (_encryptCommand = new RelayCommand(Encrypt));
            }
        }

        public RelayCommand DecryptCommand
        {
            get
            {
                return _decryptCommand ?? (_decryptCommand = new RelayCommand(Decrypt));
            }
        }

        private void Encrypt(object obj)
        {
            StreamCipherCryptographer cryptographer = new StreamCipherCryptographer();
            string mess = _encryptText.ToLower().Replace(" ", String.Empty);

            IMathGenerator lkg = new LinearCongruentialGenerator(_lkgP, _lkgA, _lkgB, _lkgX0);
            IMathGenerator qcg = new QuadraticCongruentialGenerator(_qcgP, _qcgA, _qcgB, _qcgC, _qcgX0, _qcgX1);
            IMathGenerator qcg2 = new QuadraticCongruentialGenerator(_qcg2P, _qcg2A, _qcg2B, _qcg2C, _qcg2X0, _qcg2X1);

            int lkgK = (int)Math.Floor(BitArrayExtension.Log(_lkgP, 2));
            int qcgK = (int)Math.Floor(BitArrayExtension.Log(_qcgP, 2));
            int qcg2K = (int)Math.Floor(BitArrayExtension.Log(_qcg2P, 2));

            int maxK = 6;

            IGammaGenerator gammaGenerator = new MathGammaGenerator(qcg, maxK);
            IGammaGenerator gammaGenerator2 = new MathGammaGenerator(qcg2, maxK);
            IGammaGenerator gammaGenerator3 = new MathGammaGenerator(lkg, maxK);
            IGammaGenerator gammaGenerator4;

            Key<BitArray> key;
            

            BitArray gamma = gammaGenerator.GetGamma(mess, _selectedAlphabet);
            BitArray gamma2 = gammaGenerator2.GetGamma(mess, _selectedAlphabet);
            BitArray gamma3 = gammaGenerator3.GetGamma(mess, _selectedAlphabet);

            gammaGenerator4 = new MixtureGammaGenerator(gamma, gamma2, gamma3);
            
            bool[] resultGamma = gammaGenerator4.GetGamma(null, null).Cast<bool>().Take(_selectedAlphabet.CountBitsInSymbol * mess.Length).ToArray();


            key = new Key<BitArray>(resultGamma.ToBitArray());


            DecryptedText = cryptographer.Encrypt(mess, key, _selectedAlphabet);
        }

        private void Decrypt(object obj)
        {
            string mess = _decryptText.ToLower().Replace(" ", String.Empty);
            StreamCipherCryptographer cryptographer = new StreamCipherCryptographer();

            IMathGenerator lkg = new LinearCongruentialGenerator(_lkgP, _lkgA, _lkgB, _lkgX0);
            IMathGenerator qcg = new QuadraticCongruentialGenerator(_qcgP, _qcgA, _qcgB, _qcgC, _qcgX0, _qcgX1);
            IMathGenerator qcg2 = new QuadraticCongruentialGenerator(_qcg2P, _qcg2A, _qcg2B, _qcg2C, _qcg2X0, _qcg2X1);

            int lkgK = (int)Math.Floor(BitArrayExtension.Log(_lkgP, 2));
            int qcgK = (int)Math.Floor(BitArrayExtension.Log(_qcgP, 2));
            int qcg2K = (int)Math.Floor(BitArrayExtension.Log(_qcg2P, 2));

            int maxK = 6;

            IGammaGenerator gammaGenerator = new MathGammaGenerator(qcg, maxK);
            IGammaGenerator gammaGenerator2 = new MathGammaGenerator(qcg2, maxK);
            IGammaGenerator gammaGenerator3 = new MathGammaGenerator(lkg, maxK);
            IGammaGenerator gammaGenerator4;

            Key<BitArray> key;


            BitArray gamma = gammaGenerator.GetGamma(mess, _selectedAlphabet);
            BitArray gamma2 = gammaGenerator2.GetGamma(mess, _selectedAlphabet);
            BitArray gamma3 = gammaGenerator3.GetGamma(mess, _selectedAlphabet);

            gammaGenerator4 = new MixtureGammaGenerator(gamma, gamma2, gamma3);

            bool[] resultGamma = gammaGenerator4.GetGamma(null, null).Cast<bool>().Take(_selectedAlphabet.CountBitsInSymbol * mess.Length).ToArray();


            key = new Key<BitArray>(resultGamma.ToBitArray());


            EncryptedText = cryptographer.Encrypt(mess, key, _selectedAlphabet);
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}

