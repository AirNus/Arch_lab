namespace Arch_lab.Crypto
{
    public class CryptoKey
    {
        //
        // Сводка:
        //     Представляет параметр Exponent для алгоритма System.Security.Cryptography.RSA.
        public byte[] Exponent;

        //
        // Сводка:
        //     Представляет параметр Modulus для алгоритма System.Security.Cryptography.RSA.
        public byte[] Modulus;

        //
        // Сводка:
        //     Представляет параметр P для алгоритма System.Security.Cryptography.RSA.
        public byte[] P;

        //
        // Сводка:
        //     Представляет параметр Q для алгоритма System.Security.Cryptography.RSA.
        public byte[] Q;

        //
        // Сводка:
        //     Представляет параметр DP для алгоритма System.Security.Cryptography.RSA.
        public byte[] DP;

        //
        // Сводка:
        //     Представляет параметр DQ для алгоритма System.Security.Cryptography.RSA.
        public byte[] DQ;

        //
        // Сводка:
        //     Представляет параметр InverseQ для алгоритма System.Security.Cryptography.RSA.
        public byte[] InverseQ;

        //
        // Сводка:
        //     Представляет параметр D для алгоритма System.Security.Cryptography.RSA.
        public byte[] D;
    }
}
