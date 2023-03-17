using System.Security.Cryptography;

namespace Arch_lab.Crypto
{
    public class Signature
    {
        public static Dictionary<string,RSAParameters> AssignNewKey()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                //_publicKey = rsa.ExportParameters(false);
                //_privateKey = rsa.ExportParameters(true);
                return new Dictionary<string, RSAParameters>() {
                    {"publicKey", rsa.ExportParameters(false) }, 
                    {"privateKey", rsa.ExportParameters(true) } 
                };
            }
        }
        public static byte[] SignData(byte[] hashOfDataToSign, CryptoKey privateKey)
        {
            RSAParameters RSAPrivateKey = new RSAParameters()
            {
                Exponent = privateKey.Exponent,
                Modulus = privateKey.Modulus,
                P = privateKey.P,
                Q = privateKey.Q,
                DP = privateKey.DP,
                DQ = privateKey.DQ,
                InverseQ = privateKey.InverseQ,
                D = privateKey.D
            };

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(RSAPrivateKey);

                var rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
                rsaFormatter.SetHashAlgorithm("SHA256");
                return rsaFormatter.CreateSignature(hashOfDataToSign);
            }
        }
        public static bool VerifySignature(byte[] hashOfDataToSign, byte[] signature, CryptoKey publicKey)
        {
            RSAParameters RSAPublicKey = new RSAParameters()
            {
                Exponent = publicKey.Exponent,
                Modulus = publicKey.Modulus
            };
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportParameters(RSAPublicKey);
                var rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
                rsaDeformatter.SetHashAlgorithm("SHA256");
                return rsaDeformatter.VerifySignature(hashOfDataToSign, signature);
            }
        }
    }
}
