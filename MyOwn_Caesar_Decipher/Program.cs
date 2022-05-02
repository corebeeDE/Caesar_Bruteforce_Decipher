using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOwn_Caesar_Decipher
{
    class Program
    {
        static void Main()
        {
            string toBeDeciphered = "QRE ANZR QRE PNRFNE-IREFPUYHRFFRYHAT YRVGRG FVPU IBZ EBRZVFPURA SRYQUREEA TNVHF WHYVHF PNRFNE NO, QRE ANPU QRE HROREYVRSREHAT QRF EBRZVFPURA FPUEVSGFGRYYREF FHRGBA QVRFR NEG QRE TRURVZRA XBZZHAVXNGVBA SHRE FRVAR ZVYVGNREVFPUR XBEERFCBAQRAM IREJRAQRG UNG. QNORV ORAHGMGR PNRFNE RVAR IREFPUVROHAT QRF NYCUNORGF HZ QERV OHPUFGNORA.";

            Console.WriteLine("Version 1:");
            for (int ctr = 1; ctr < 27; ctr++)
            {
                Console.WriteLine(CaesarDecrypt(toBeDeciphered, ctr));
            }
            Console.WriteLine("------------------------------------------------------------");

            Console.WriteLine("Version 2:");
            for (int ctr = 1; ctr < 27; ctr++)
            {
                Console.WriteLine(CaesarDecryptShort(toBeDeciphered, ctr));
            }
        }

        // ---------- Long and understandable version ---------- //
        private static char Cipher(char inpChar, int shift)
        {
            if (char.IsLetter(inpChar))
            {
                char position = char.IsUpper(inpChar) ? 'A' : 'a';
                return (char)(((inpChar + shift - position) % 26) + position);
            }
            else
            {
                return inpChar;
            }
        }

        private static string CaesarEncrypt(string input, int shift)
        {
            string output = string.Empty;

            foreach (var item in input)
            {
                output += Cipher(item, shift);
            }

            return output;
        }

        private static string CaesarDecrypt(string input, int shift)
        {
            return CaesarEncrypt(input, 26 - shift);
        }

        // ---------- Short and complex version ---------- //
        private static char CipherShort(char inputCharacter, int shift) => char.IsLetter(inputCharacter) ? (char)(((inputCharacter + shift - (char.IsUpper(inputCharacter) ? 'A' : 'a')) % 26) + (char.IsUpper(inputCharacter) ? 'A' : 'a')) : inputCharacter;

        private static string CaesarEncryptShort(string input, int shift) => string.Concat(input.Select(x => CipherShort(x, shift)));

        private static string CaesarDecryptShort(string input, int shift) => CaesarEncryptShort(input, 26 - shift);
    }
}