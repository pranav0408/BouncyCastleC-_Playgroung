using System;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Asn1.Pkcs;

namespace BouncyCastle_Implement
{
    public class Implement
    {
        readonly RsaKeyParameters PrivKey;
        readonly RsaKeyParameters PubKey;
        byte[] Msg, signature;

        public Implement()
        {
            RsaKeyPairGenerator RsaKeyPairGen = new RsaKeyPairGenerator();
            RsaKeyPairGen.Init(new KeyGenerationParameters(new SecureRandom(), 2048));
            AsymmetricCipherKeyPair KeyPair = RsaKeyPairGen.GenerateKeyPair();

            PrivKey = (RsaKeyParameters)KeyPair.Private;
            PubKey = (RsaKeyParameters)KeyPair.Public;
        }

        public string Sign(string msg)
        {
            Msg = Encoding.UTF8.GetBytes(msg);

            ISigner sign = SignerUtilities.GetSigner(PkcsObjectIdentifiers.Sha256WithRsaEncryption.Id);
            sign.Init(true, PrivKey);
            sign.BlockUpdate(Msg, 0, Msg.Length);
            signature = sign.GenerateSignature();

            return BitConverter.ToString(signature);
        }

        public bool Verify(string msg)
        {
            Msg = Encoding.UTF8.GetBytes(msg);

            ISigner VerifySign = SignerUtilities.GetSigner(PkcsObjectIdentifiers.Sha256WithRsaEncryption.Id);
            VerifySign.Init(false, PubKey);
            VerifySign.BlockUpdate(Msg, 0, Msg.Length);
            bool stat = VerifySign.VerifySignature(signature);

            return stat;
        }
    }
}
