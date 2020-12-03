using System;
using System.Text;
using Org.BouncyCastle.X509;

namespace BouncyCastle_X509_VerifyCertSignature
{
    class Program
    {
        
        static void Main(string[] args)
        {
            System.IO.FileStream root = new System.IO.FileStream("E:\\Certificates-Keys\\xca-cert-export\\RootP.crt",System.IO.FileMode.Open);
            System.IO.FileStream end = new System.IO.FileStream("E:\\Certificates-Keys\\xca-cert-export\\endP.crt", System.IO.FileMode.Open);

            X509CertificateParser CertParse = new X509CertificateParser();
            X509Certificate RootCert = CertParse.ReadCertificate(root);
            X509Certificate EndCert = CertParse.ReadCertificate(end);

            //Console.WriteLine(RootCert);
            //Console.WriteLine(EndCert);
            /*
            try
            {
                EndCert.Verify(RootCert.GetPublicKey());
                Console.WriteLine("Certificate Verified");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            */
            Console.WriteLine(BitConverter.ToString(EndCert.GetTbsCertificate()));
        }
    }
}
