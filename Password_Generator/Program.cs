using System;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using TextCopy;

namespace Password_Generator
{
    internal class Program
    {

        private const int Default_lenght = 14;
        static void Main(string[] args)
        {
            Console.Write(" Please enter number of password you need to Generate :  ");
            int NumberOfPass = int.Parse(Console.ReadLine());
            int count = 1;
            string CopyPass;

            while (NumberOfPass > 0)
            {


                int length;
                int choice;
                string charPool = "";

                Console.Write("\n Please enter the password length :  ");

                bool flag1 = int.TryParse(Console.ReadLine(), out length);

                Console.Write("\nChoose password type:\n ");

                Console.WriteLine("\n1 - Letters only");
                Console.WriteLine("\n2 - Numbers only");
                Console.WriteLine("\n3 - Letters + Numbers");
                Console.WriteLine("\n4 - Letters + Numbers + Symbols");
                Console.Write("\nYour choice: ");
                bool flag2 = int.TryParse(Console.ReadLine(), out choice);


                if (flag1 && flag2)
                {
                    switch (choice)
                    {
                        case 1 :
                            charPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                            break;
                                              
                        case 2 :
                            charPool = "0123456789";
                            break;

                        case 3 :
                            charPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                            break;

                        case 4 :
                            charPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@'#$%^&*()-_=+[]{};:,./?`~";
                            break;

                            default:
                            Console.WriteLine("Invalid choice. Using letters + numbers by default.");
                            charPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                            break;

                    }

                    Console.WriteLine($" \n Password {count} is : \" {CopyPass = Generate_Password(length , charPool)} \"");

                    Console.WriteLine("\n-------------------------------------------------");

                    NumberOfPass--;
                    count++;

                    ClipboardService.SetText(CopyPass);

                }


            }





        }


        public static string Generate_Password(int lenght , string charPool)
        {
            if (lenght < 2)
            {
                lenght = Default_lenght;
               
            }

            RNGCryptoServiceProvider reg = new RNGCryptoServiceProvider();
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < lenght; i++)
            {
                byte[] RandomNum = new byte[1]; 
                reg.GetBytes(RandomNum);
                int index = RandomNum[0] % charPool.Length;

                password.Append(charPool[index]);

            }
            return password.ToString();
        }
    }
}
