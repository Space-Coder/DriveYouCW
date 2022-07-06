using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authentication.Certificate;

namespace DriveYou
{
    public class CertificateValidationService
    {
        public bool ValidateCertificate(X509Certificate2 clientCertificate)
        {
            string[] allowedThumbs = { "733D590EFCD4576E1D8152FD3677FB7D265CF7D7", "87A6E47A962C0E80A59517691FFA1D0500E3E548", "78A6E47A962C0E80A59517691FFA1D0500E3E548" };
            if (allowedThumbs.Contains(clientCertificate.Thumbprint))
            {
                return true;
            }
            return false;
        }
    }
}
