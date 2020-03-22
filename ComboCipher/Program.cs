using System;


namespace ComboCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Encrypt
            Cipher firstCipher = new Polib();//Полиибий
            Cipher SecondCipher = new DoubleRearrangement();// Двойная перестановка
            string getNewMessage = firstCipher.Encrypt("КАНДАКОВА АНАСТАСИЯ НИКОЛАЕВНА");
            Console.WriteLine($"Первый полученный шифр : {getNewMessage}");
            string lastMessage = SecondCipher.Encrypt(getNewMessage, "345216 563142");
            Console.WriteLine($"Результат шифрования {lastMessage}");
            //Decrypt
            Cipher firstCipher1 = new DoubleRearrangement();
            string getOpenCipher = firstCipher1.Decrypt(lastMessage, "345216 563142");
            Console.WriteLine(getOpenCipher);
            Cipher SecondCipher1 = new Polib();
            string getOpentext = SecondCipher1.Decrypt(getOpenCipher);
            Console.WriteLine($"Расшифрованное сообщение: { getOpentext}");
            Console.ReadLine();
        }
    }
}
