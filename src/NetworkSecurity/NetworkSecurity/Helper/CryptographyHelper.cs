using System;
using System.Security.Cryptography;
using System.Text;

namespace NetworkSecurity.Helper
{
    public static class CryptographyHelper
    {
        public static object GetCryptoServiceProvider(this EnumCryptographyAlgorithms algorithm)
        {
            switch (algorithm)
            {
                // Symmetric Algorithms
                case EnumCryptographyAlgorithms.Aes: return new AesCryptoServiceProvider();// :AES  :SymmetricAlgorithm
                case EnumCryptographyAlgorithms.Des: return new DESCryptoServiceProvider();// :DES :SymmetricAlgorithm
                case EnumCryptographyAlgorithms.TripleDes: return new TripleDESCryptoServiceProvider(); // :TripleDES :SymmetricAlgorithm
                case EnumCryptographyAlgorithms.Rc2: return new RC2CryptoServiceProvider();// :RC2 :SymmetricAlgorithm

                // Hash Algorithms
                case EnumCryptographyAlgorithms.Md5: return new MD5CryptoServiceProvider();// MD5  :HashAlgorithm
                case EnumCryptographyAlgorithms.Sha1: return new SHA1CryptoServiceProvider();// SHA1  :HashAlgorithm
                case EnumCryptographyAlgorithms.Sha256: return new SHA256CryptoServiceProvider();// SHA256 :HashAlgorith
                case EnumCryptographyAlgorithms.Sha384: return new SHA384CryptoServiceProvider();// SHA384  :HashAlgorithm
                case EnumCryptographyAlgorithms.Sha512: return new SHA512CryptoServiceProvider();// SHA512  :HashAlgorithm

                default: return new AesCryptoServiceProvider();
            }
        }

        public static byte[] Encrypt(this byte[] toEncryptArray, string key, EnumCryptographyAlgorithms algorithm)
        {
            byte[] resultArray = null;

            var objAlgorithmProvider = algorithm.GetCryptoServiceProvider();

            if (objAlgorithmProvider is SymmetricAlgorithm symmetricAlg)
            {
                //set the secret key for the symmetric algorithm
                symmetricAlg.SetupSymmetric(key);

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

        public static string Encrypt(this string toEncrypt, string key, EnumCryptographyAlgorithms algorithm)
        {
            // string --> (utf8) byte[] --> encrypt ---> byte[] ---> (base64) string
            var toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
            var encryptedBytes = toEncryptArray.Encrypt(key, algorithm);

            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(encryptedBytes, 0, encryptedBytes.Length);
        }

        public static byte[] Decrypt(this byte[] cipherArray, string key, EnumCryptographyAlgorithms algorithm)
        {
            byte[] resultArray = null;

            var objAlgorithmProvider = algorithm.GetCryptoServiceProvider();

            if (objAlgorithmProvider is SymmetricAlgorithm symmetricAlg)
            {
                //set the secret key for the symmetric algorithm
                symmetricAlg.SetupSymmetric(key);

                var cTransform = symmetricAlg.CreateDecryptor();
                resultArray = cTransform.TransformFinalBlock(cipherArray, 0, cipherArray.Length);

                //Release resources held by symmetric Encryptor
                symmetricAlg.Clear();
            }

            return resultArray;
        }

        public static string Decrypt(this string cipherString, string key, EnumCryptographyAlgorithms algorithm)
        {
            //get the byte code of the string
            var toEncryptArray = Convert.FromBase64String(cipherString);
            var decryptedBytes = toEncryptArray.Decrypt(key, algorithm);

            //return the Clear decrypted TEXT
            return Encoding.UTF8.GetString(decryptedBytes);
        }


        public static void SetupSymmetric(this SymmetricAlgorithm alg, string pass, string salt = @"A1b2C3d4E@noise")
        {
            // get salt bytes in ASCII encoding
            var saltBytes = Encoding.ASCII.GetBytes(salt);
            //
            // create a password with pass and salt to derive key
            var key = new Rfc2898DeriveBytes(pass, saltBytes);
            alg.Key = key.GetBytes(alg.KeySize / 8); // set key by algorithm
            alg.IV = key.GetBytes(alg.BlockSize / 8); // set initialization vector by algorithm block size

            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            alg.Mode = CipherMode.ECB;

            //padding mode(if any extra byte added)
            alg.Padding = PaddingMode.PKCS7;

            // alg should now fully set-up.
        }
    }

}