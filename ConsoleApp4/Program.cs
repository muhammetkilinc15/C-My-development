using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Enter a lenght : ");
            int length = int.Parse(Console.ReadLine());
            Console.Write("Do you want to add special chracters your password : ");
            string a = Console.ReadLine();
            bool specia=false;
            if (a == "yes" || a =="YES")
            {
                specia= true;
            }           
            Console.WriteLine("Your password : " + SuffleThePassword(GenerateRandomPassword(length,specia)));
        }
        static string GenerateRandomPassword(int length,bool specials)
        {
            Random ran = new Random();
            StringBuilder sb = new StringBuilder();
            if (length < 8)
            {
                length = 8;
            }
            else if (length > 12)
            {
                length = 12;
            }
            int a;
            int b;
            int c;
            while (true)
            {
                a = ran.Next(1 , 5);
                b = ran.Next(1 , 4);
                if (specials==true)
                {
                    c = ran.Next(1, 3);
                }
                else
                {
                    c = 0;
                }          
                if (a + b + c < length)
                {
                    break;
                }
            }       
            for (int i = 0; i < a; i++)
            {          
                sb.Append((char)ran.Next('A', 'Z'));
            }
            for (int i = 0; i < b; i++)
            {
                sb.Append(ran.Next(1, 10));
            }
            string special = "?,*.<!;#${}[]";
            for (int i = 0; i < c; i++)
            {
                int k = ran.Next(special.Length);
                sb.Append(special[k]);
            }
            for (int i = 0; i < length - (a + b + c); i++)
            {
                sb.Append((char)ran.Next('a', 'z'));
            }
            return sb.ToString();
        }
        static string SuffleThePassword(string password)
        {
            Random ran = new Random();
            char[] s = password.ToCharArray();

            for (int i = 0; i < s.Length; i++)
            {
                int k = ran.Next(0, password.Length);
                char temp = password[i];
                s[i] = s[k];
                s[k] = temp;
            }
            password = "";
            for (int i = 0; i < s.Length; i++)
            {
                password += s[i];
            }
            return password;
        }

    }
}

