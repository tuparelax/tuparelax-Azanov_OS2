using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace OS_Practice2
{

    class MultiThreading
    {
        
    
        public static string gethash(string first)
        {
            var watch = Stopwatch.StartNew();
            Parallel.For(0, 26, a =>
            {
                byte[] password = new byte[5];
                byte[] hash;
                byte[] one = StringHashToByteArray(first);
                password[0] = (byte)(97 + a);
                var sha = System.Security.Cryptography.SHA256.Create();
                for (password[1] = 97; password[1] < 123; password[1]++)
                    for (password[2] = 97; password[2] < 123; password[2]++)
                        for (password[3] = 97; password[3] < 123; password[3]++)
                            for (password[4] = 97; password[4] < 123; password[4]++)
                            {
                                hash = sha.ComputeHash(password);
                                if (matches(one, hash))
                                    Console.WriteLine(Encoding.ASCII.GetString(password) + " => "
                                        + BitConverter.ToString(hash).ToLower().Replace("-", ""));
                            }
                
            });
            watch.Stop();
            Console.WriteLine($"Провел взлом за {watch.Elapsed.Seconds}c ");
            return null;
        }
        static byte[] StringHashToByteArray(string s)
        {
            return Enumerable.Range(0, s.Length / 2).Select(i => (byte)Convert.ToInt16(s.Substring(i * 2, 2), 16)).ToArray();
        }
        static bool matches(byte[] a, byte[] b)
        {
            for (int i = 0; i < 32; i++)
                if (a[i] != b[i])
                    return false;
            return true;
        }
    }
}