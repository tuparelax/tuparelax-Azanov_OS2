using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;


namespace OS_Practice2
{

    class SingleTread
    {
        
        public static void Brut(object hashCode)
        {
            var watch = Stopwatch.StartNew();
            string hashCode1 = (string)hashCode;
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            char[] arralphabet;
            char[] password1 = new char[5];
            for (int i = 0; i < 5; i++) { password1[i] = ' '; }

            arralphabet = alphabet.ToCharArray(0, 26);
            for (int i = 0; i < alphabet.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    for (int k = 0; k < alphabet.Length; k++)
                    {
                        for (int l = 0; l < alphabet.Length; l++)
                        {
                            for (int m = 0; m < alphabet.Length; m++)
                            {
                                password1[0] = arralphabet[i];
                                password1[1] = arralphabet[j];
                                password1[2] = arralphabet[k];
                                password1[3] = arralphabet[l];
                                password1[4] = arralphabet[m];
                                string PasswordStr = new string(password1);
                                using (SHA256 sha256hash = SHA256.Create())
                                {
                                    string hash = GetHash(sha256hash, PasswordStr);
                                    if (hash == hashCode1)
                                    {
                                        Console.WriteLine(PasswordStr + " пароль найден"); Console.WriteLine("хэш данного пароля " + hash);
                                        watch.Stop();
                                        Console.WriteLine($"Провел взлом за {watch.Elapsed.Seconds}c ");
                                    }

                                }
                            }
                        }
                    }
                }
            }
           
        }
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {


            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));


            var sBuilder = new StringBuilder();


            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}