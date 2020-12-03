using System;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Tls;

namespace ClassLibrary1
{
    public class MAC
    {
        private string secret = @"-----BEGIN RSA PRIVATE KEY-----
MIIEogIBAAKCAQEAuU/bwel01N9ujdAeCF5+bPVm6jQxDEQrCnJ+69wjMDK5rqdm
f0k5EXBXOetfP/rS45I4iKM/QtQxck+L3EvjWKyk+2qOaNHMD3G+b3eqFNTxLMp7
UpDy/wgqCOFUQO5h2hyKO0ub34ez62d5Emw989ZN9ybIvzwm6CvCvlmCc05Nha1N
FA5JB4JFa9schU+vJWJTYd7hDgtbgb1dZq313s8uVkU/i9KwQ6TP4dEDqOmwovHG
ngFTB4XDYstgQ1YobvyoLHKVH1Apr0glQG8blb7GQ1aAqEEGhQaA37SIIA2ND7LZ
Y9MMgegyW/Yz9ipwLGZq8vTq0Rl5rjgImy8i9QIDAQABAoIBAByrQSlXz85bHsRr
zSmoTNDYimpzVp86MJp2KjKdJQiA4H8nwNCyaFTNV4FLa7n/OP8iEQL6ln/lSh0Q
N2gGiY6fbwrCanPG+VXuV/LwxWxhoUo3rSqR6DYSckZbbeh5uMPApJYV1XCYkvo5
UN7Lxi3iGr/AzU/go3hJxOAkAu2JjTQa2qJMOh36QO19eg+nXB4HRzRNB4p0YuKZ
5XDcyeCxDKYW2n6eKNC/QVTLyz0eMSEuexta1TfItrr3IkWZZFZ7pkMSONTz8WrL
QnMIrjweRoggV9QEgB5zyaoIYAZPIo/myrGov1+EHZESXkpp6BxBqJpEJjMOC5f5
y7uszmUCgYEA5RNdUzGpU9106qc09ukmaRad4aFA3F2JX8pc2/qWztJYLbT4cn11
FqZSDKvb+bBot2SqjKOCNrxzkvt9PMtPnULwQkp3sZItt/uhQWdjUK/TfNQJow32
2s89yca7SDDX1dR6enzXA+fni/tXuE729c0OhZWEE9vBwoXCfmcxn6sCgYEAzxex
MQZAYveYYM8kdDT7p4jPrJ5ZMYUBaBXjv74xy/0QlXHExQpPLALFqz+F/igJcDuJ
MecoQ73uPyg2GHEXLzFmy8UITG5v+X9reQ/vJ0OhcTeUK4mRCpWk9atQ6beIG0rX
JZnP8q3CnGY520Bhy/kkHR3lLO0a8yyqeBzmJ98CgYBp5Fy0s3U5vlpoimiyZq6J
z5mmDlukQlzZefsY+Sqzaoq2fjyG+DWjBblSADPMpV6SwCcSohb0ZILsg/KtorIn
2SSlEDVqUU9vCBPP3xIK32xc/MuDo1Xkaf5/Aq3aPjHXt8PyUTk3pgDkNYikO2Rv
1Z2L5MTMRT65RAnXUq6exwKBgC1EG3oAyNAZGJiIjopMDnnHQMWVcx+M2ArdRgPi
WdYhwZ841+7N2xJepMBSyUINlEqQ6OMciMON32a0rmZXSd8J6FNABRlXxmf9vwse
PYMSmFY79Mozbp2mqgD86lm7wSdeC3rvjPGZo4E2Iw1WnEnOcmNe5noUdaCTsctB
Xdl3AoGAFNjOITexa4URq8W7+qyxwHPPSRA8vYAhHpx5zsp0H76n8BERjpB1kIoj
6ktrfzTu2avCosd0hN72RyS1KkY855dTKMBxiNp9DXOnIBvrZlfw94bsHNS5RMqk
x3vp6C6M/gMPun9/07X52FIYC0xdPMyER21IoC3bQNCa7lLMT/Y=
-----END RSA PRIVATE KEY-----";

        private string _seed;
        private string _Strlabel;
        private int _size;

        public void doPRF()
        {
            byte[] byteSecret = Encoding.ASCII.GetBytes(secret);
            byte[] bytelabel = Encoding.ASCII.GetBytes(_Strlabel);
            byte[] byteseed = Encoding.ASCII.GetBytes(_seed);

            byte[] seedPrf = new byte[bytelabel.Length + byteseed.Length];

            bytelabel.CopyTo(seedPrf, 0);
            byteseed.CopyTo(seedPrf, bytelabel.Length);

            IDigest digest = TlsUtilities.CreatePrfHash(1);

            byte[] buff = new byte[_size];

            TlsUtilities.HMacHash(digest, byteSecret, seedPrf, buff);

            Buffer = buff;
            
        }

        public string Seed
        {
            set { _seed = value; }
        }
        public string Label
        {
            set { _Strlabel = value; }
        }
        public int Size
        {
            set { _size = value; }
        }
        public byte[] Buffer
        {
            get;
            set;
        }
    }
}
