using System;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace Task4
{
    class PasswordChecker
    {
        private static string ReadText(string textToPrint)
        {
            Console.Write(textToPrint);
            return Console.ReadLine();
        }

        static string ReadPassword(string textToPrint)
        {
            Console.Write(textToPrint);
            StringBuilder passwd = new StringBuilder();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (ConsoleKey.Enter == key.Key)
                    break;

                char ch = key.KeyChar;
                if (Char.IsControl(ch))
                    throw new FormatException("Недопустимый символ в пароле.");

                Console.Write('*');
                passwd.Append(ch);
            }
            Console.WriteLine();
            return passwd.ToString();
        }

        public static bool Autorization(string expectedLogin,
            string expectedPassword, int autorizeTryCount)
        {
            try
            {
                while (0 < autorizeTryCount--)
                {
                    Console.WriteLine();
                    try
                    {
                        string login = ReadText("Логин: ");
                        string password = ReadPassword("Пароль: ");

                        if (expectedLogin == login && expectedPassword == password)
                            return true;
                    }
                    catch (FormatException fex)
                    {
                        Console.WriteLine(
                            "{0}, Попробуйте ввести пароль ещё. ", fex.Message);
                        continue;
                    }
                    if (0 < autorizeTryCount)
                        Console.WriteLine(
                            CreateWrongPassMessage(autorizeTryCount));
                }
            }
            catch (Exception ex)
            {
                throw new PasswordCheckException(
                    "Ошибка при проверке пароля. ", ex);
            }
            return false;
        }

        public static bool Autorization(string accountFilePath,
            int autorizeTryCount)
        {
            Account account;
            GetAccountFromFile(accountFilePath, out account);

            return Autorization(account._login, account._password, 
                autorizeTryCount);
        }

        private static string CreateWrongPassMessage(int autorizeTryCount)
        {
            StringBuilder message = new StringBuilder();
            message.Append("\r\nНе верный логин или пароль. ");

            if (1 == autorizeTryCount)
                message.Append("Осталась ещё 1 попытка.");
            else
                message.Append(String.Format("Осталось ещё {0} попытки.",
                    autorizeTryCount));

            return message.ToString();
        }

        private static void GetAccountFromFile(
            string filePath, out Account account)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                if (2 != lines.Length)
                {
                    account = default;
                    throw new PasswordCheckException(
                        "Неверный формат файла с аккаунтом пользователя. ");
                }

                account._login = lines[0];
                account._password = lines[1];
            }
            catch (Exception ex)
            {
                throw new PasswordCheckException(
                    "Ошибка считывания логина и пароля из файла. ", ex);
            }
        }

        private struct Account
        {
            public string _login;
            public string _password;
        }
    }
}
