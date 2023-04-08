using System.IO;

namespace Homework_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Создаём директории 
            DirectoryInfo directoryInfo1 = new DirectoryInfo("c:\\Otus\\TestDir1");
            DirectoryInfo directoryInfo2 = new DirectoryInfo("c:\\Otus\\TestDir2");
            directoryInfo1.Create();
            directoryInfo2.Create();

            //Создаём файлы
            for (int i = 0; i < 10; i++)
            {
                using (File.Create($"c:\\Otus\\TestDir1\\{i}.txt"));
                using (File.Create($"c:\\Otus\\TestDir2\\{i}.txt"));
            }

            for (int i = 1; i <= 2; i++)
            {
                var fileArr = Directory.GetFiles($"c:\\Otus\\TestDir{i}");
                foreach (var patch in fileArr)
                {
                    //Получаем имя файла
                    var seporatorArr = patch.Split(Path.DirectorySeparatorChar);
                    var nameFile = seporatorArr[seporatorArr.Length - 1];

                    //Пишем в фаил имя файла и дату
                    using FileStream fs = new FileStream(patch, FileMode.OpenOrCreate);
                    using StreamWriter sw = new StreamWriter(fs);
                    {
                        sw.WriteLine(nameFile +" "+ DateTime.Now.ToString("dd.MM.yyy"));
                    }
                }
            }

            //Вывод файлов в консоль
            for (int i = 1; i <= 2; i++)
            {
                var fileArr = Directory.GetFiles($"c:\\Otus\\TestDir{i}");
                foreach (var patch in fileArr)
                {
                    //Получаем имя файла
                    var seporatorArr = patch.Split(Path.DirectorySeparatorChar);
                    var nameFile = seporatorArr[seporatorArr.Length - 1];

                    //Читаем фаил имя файла и дату
                    Console.WriteLine($"{nameFile}:{File.ReadAllText(patch)}");
                }
            }

        }
    }
}