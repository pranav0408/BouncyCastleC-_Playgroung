using System;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Asn1.TeleTrust;

namespace BouncyCastle_Implement
{
    public class Implement
    {
        readonly ECKeyParameters PrivKey;
        readonly ECKeyParameters PubKey;
        byte[] Msg, signature;

        public Implement()
        {
            X9ECParameters brainpool521 = TeleTrusTNamedCurves.GetByOid(TeleTrusTObjectIdentifiers.BrainpoolP512T1);
            var BrainpoolParam = new ECKeyGenerationParameters(
                    new ECDomainParameters(
                        brainpool521.Curve,
                        brainpool521.G,
                        brainpool521.N,
                        brainpool521.H
                    ),
                    new SecureRandom()
                );

            ECKeyPairGenerator EcKeyPairGen = new ECKeyPairGenerator();
            EcKeyPairGen.Init(BrainpoolParam);
            AsymmetricCipherKeyPair KeyPair = EcKeyPairGen.GenerateKeyPair();

            PrivKey = (ECKeyParameters)KeyPair.Private;
            PubKey = (ECKeyParameters)KeyPair.Public;
        }

        public string Sign(string msg)
        {
            Msg = Encoding.UTF8.GetBytes(msg);

            ISigner sign = SignerUtilities.GetSigner(X9ObjectIdentifiers.ECDsaWithSha1.Id);
            sign.Init(true, PrivKey);
            sign.BlockUpdate(Msg, 0, Msg.Length);
            signature = sign.GenerateSignature();

            return BitConverter.ToString(signature);
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
