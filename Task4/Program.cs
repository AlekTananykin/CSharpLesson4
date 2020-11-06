using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Тананыкин
 * 
 * Решить задачу с логинами из урока 2, только логины и 
 * пароли считать из файла в массив. Создайте структуру 
 * Account, содержащую Login и Password.
 */
namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа проверки пароля. ");
            int autorizeTryCount = 3;
            string expectedLogin = "root";
            string expectedPassword = "GeekBrains";

            try
            {
                string accountPath = Directory.GetCurrentDirectory() + 
                "/" + "account.txt";

                SaveAccountToFile(
                    expectedLogin, expectedPassword, accountPath);

                if (PasswordChecker.Autorization(
                    accountPath, autorizeTryCount))
                    Console.WriteLine("\r\nВы авторизованы. ");
                else
                    Console.WriteLine("\r\nВы не авторизованы. ");
            }
            catch (PasswordCheckException ex)
            {
                Console.WriteLine(ex.Message);
                if (null != ex.InnerException)
                    Console.WriteLine(ex.InnerException.Message);
            }

            Console.WriteLine(
                "\r\nНажмите любую клавишу для завершения программы. ");
            Console.ReadKey();
        }

        private static void SaveAccountToFile(
            string login, string password, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(login);
                sw.WriteLine(password);
            }
        }
    }
}
