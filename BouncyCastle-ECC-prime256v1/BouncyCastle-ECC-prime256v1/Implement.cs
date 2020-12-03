using System;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Asn1.X9;

namespace BouncyCastle_Implement
{
    public class Implement
    {
        readonly ECKeyParameters PrivKey;
        readonly ECKeyParameters PubKey;
        byte[] Msg, signature;

        public Implement()
        {
            ECKeyPairGenerator EcKeyPairGen = new ECKeyPairGenerator();
            EcKeyPairGen.Init(new KeyGenerationParameters(new SecureRandom(), 256));
            AsymmetricCipherKeyPair KeyPair = EcKeyPairGen.GenerateKeyPair();

            PrivKey = (ECKeyParameters)KeyPair.Private;
            PubKey = (ECKeyParameters)KeyPair.Public;
        }

        public byte[] Sign(string msg)
        {
            Msg = Encoding.UTF8.GetBytes(msg);

            ISigner sign = SignerUtilities.GetSigner(X9ObjectIdentifiers.ECDsaWithSha1.Id);
            sign.Init(true, PrivKey);
            sign.BlockUpdate(Msg, 0, Msg.Length);
            signature = sign.GenerateSignature();

            return signature;
        }

        public bool Verify(string msg)
        {
            Msg = Encoding.UTF8.GetBytes(msg);

            ISigner VerifySign = SignerUtilities.GetSigner(X9ObjectIdentifiers.ECDsaWithSha1.Id);
            VerifySign.Init(false, PubKey);
            VerifySign.BlockUpdate(Msg, 0, Msg.Length);
            bool stat = VerifySign.VerifySignature(signature);

            return stat;
        }
    }
}
