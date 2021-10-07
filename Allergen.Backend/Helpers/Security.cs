using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace Allergen.Backend.Helpers
{
    public static class Security
    {
        //TODO: enter encryption key and encrypt CS
        private static readonly string KeyString = "wprowadzklucz";
        public static string Encrypt(string text)
        {
            if (KeyString.ToLower() == "wprowadzklucz")
            {
                throw new Exception("Wrong encyption key. Check Security.cs");
            }

            byte[] key = Encoding.UTF8.GetBytes(KeyString);

            using (Aes aesAlg = Aes.Create())
            {
                using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        byte[] iv = aesAlg.IV;

                        byte[] decryptedContent = msEncrypt.ToArray();

                        byte[] result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            if (KeyString.ToLower() == "wprowadzklucz")
            {
                throw new Exception("Wrong encryption key. Check Security.cs");
            }

            byte[] fullCipher = Convert.FromBase64String(cipherText);

            byte[] iv = new byte[16];
            byte[] cipher = new byte[fullCipher.Length - iv.Length];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, fullCipher.Length - iv.Length);
            byte[] key = Encoding.UTF8.GetBytes(KeyString);

            using (Aes aesAlg = Aes.Create())
            {
                using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (MemoryStream msDecrypt = new MemoryStream(cipher))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }

        public static string ToSHA512(string input)
        {
            string result;

            byte[] bytes = Encoding.UTF8.GetBytes(input);

            using (SHA512 hash = SHA512.Create())
            {
                byte[] hashedInputBytes = hash.ComputeHash(bytes);
                result = BitConverter.ToString(hashedInputBytes).Replace("-", "");
            }

            return result;
        }
    }
}
