using System;
using System.Security.Cryptography;
using System.Text;

namespace NetworkSecurity.Helper
{
    public static class CryptographyHelper
    {
        public static object GetCryptoAlgorithm(this CryptographyAlgorithms algorithm)
        {
            switch (algorithm)
            {
                // Symmetric Algorithms
                case CryptographyAlgorithms.Aes: return new AesCryptoServiceProvider();
                case CryptographyAlgorithms.Des: return new DESCryptoServiceProvider();
                case CryptographyAlgorithms.TripleDes: return new TripleDESCryptoServiceProvider();
                case CryptographyAlgorithms.Rc2: return new RC2CryptoServiceProvider();

                // Hash Algorithms
                case CryptographyAlgorithms.Md5: return new MD5CryptoServiceProvider();
                case CryptographyAlgorithms.Sha1: return new SHA1CryptoServiceProvider();
                case CryptographyAlgorithms.Sha256: return new SHA256CryptoServiceProvider();
                case CryptographyAlgorithms.Sha384: return new SHA384CryptoServiceProvider();
                case CryptographyAlgorithms.Sha512: return new SHA512CryptoServiceProvider();

                default: return new AesCryptoServiceProvider();
            }
        }

        public static byte[] Encrypt(this byte[] toEncryptArray, string key, CryptographyAlgorithms algorithm)
        {
            byte[] resultArray = null;

            var objAlgorithmProvider = algorithm.GetCryptoAlgorithm();

            if (objAlgorithmProvider is SymmetricAlgorithm symmetricAlg)
            {
                //set the secret key for the symmetric algorithm
                symmetricAlg.SetupSymmetricKey(key);
                //mode of operation. there are other 4 modes. We choose ECB(Electronic code Book)
                symmetricAlg.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)
                symmetricAlg.Padding = PaddingMode.PKCS7;

                var cTransform = symmetricAlg.CreateEncryptor();
                //transform the specified region of bytes array to resultArray
                resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                //Release resources held by symmetric Encryptor
                symmetricAlg.Clear();
            }
            else if (objAlgorithmProvider is HashAlgorithm hashAlg)
            {
                resultArray = hashAlg.ComputeHash(toEncryptArray);
                //Release resources held by hasher
                hashAlg.Clear();
            }

            return resultArray;
        }

        public static string Encrypt(this string toEncrypt, string key, CryptographyAlgorithms algorithm)
        {
            var toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
            var encryptedBytes = toEncryptArray.Encrypt(key, algorithm);

            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(encryptedBytes, 0, encryptedBytes.Length);
        }

        public static byte[] Decrypt(this byte[] cipherArray, string key, CryptographyAlgorithms algorithm)
        {
            byte[] resultArray = null;

            var objAlgorithmProvider = algorithm.GetCryptoAlgorithm();

            if (objAlgorithmProvider is SymmetricAlgorithm symmetricAlg)
            {
                //set the secret key for the symmetric algorithm
                symmetricAlg.SetupSymmetricKey(key);

                //mode of operation. there are other 4 modes.
                //We choose ECB(Electronic code Book)
                symmetricAlg.Mode = CipherMode.ECB;

                //padding mode(if any extra byte added)
                symmetricAlg.Padding = PaddingMode.PKCS7;

                var cTransform = symmetricAlg.CreateDecryptor();
                resultArray = cTransform.TransformFinalBlock(cipherArray, 0, cipherArray.Length);

                //Release resources held by symmetric Encryptor
                symmetricAlg.Clear();
            }
            else if (objAlgorithmProvider is HashAlgorithm hashAlg)
            {
                resultArray = hashAlg.ComputeHash(cipherArray);
                //Release resources held by hasher
                hashAlg.Clear();
            }

            return resultArray;
        }

        public static string Decrypt(this string cipherString, string key, CryptographyAlgorithms algorithm)
        {
            //get the byte code of the string
            var toEncryptArray = Convert.FromBase64String(cipherString);
            var decryptedBytes = toEncryptArray.Decrypt(key, algorithm);

            //return the Clear decrypted TEXT
            return Encoding.UTF8.GetString(decryptedBytes);
        }


        public static void SetupSymmetricKey(this SymmetricAlgorithm alg, string pass, string saltNoise = @"H\,g,d@13")
        {
            var salt = Encoding.ASCII.GetBytes(saltNoise);
            var key = new Rfc2898DeriveBytes(pass, salt);
            alg.Key = key.GetBytes(alg.KeySize / 8);
            alg.IV = key.GetBytes(alg.BlockSize / 8);
            // alg should now fully set-up.
        }
    }

}