using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

//Створіть програму для роботи з інформацією про музичний альбом, яка зберігатиме таку інформацію:
//1.Назва альбому.
//2.Назва виконавця.
//3.Рік випуску.
//4.Тривалість.
//5.Студія звукозапису.
//Програма має бути з такою функціональністю:
//1.Введення інформації про альбом.
//2. Виведення інформації про альбом.
//3. Серіалізація альбому.
//4. Збереження серіалізованого альбому у файл.
//5. Завантаження серіалізованого альбому з файлу.
//6. Збережіть дані про альбом у xml файлу
//7. Додайте логування, використовуйте NLog

namespace Music_Catalog
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Info("Приложение запущено");
            string filePathBin = "test.txt"; // файл с бинарным содержимым
            string filePathXml = "test.xml";// файл с xml содержимым
            Catalog myCatalog = new Catalog();
            myCatalog.AddSong(new Album("Scream", "Michael Jackson", 1989, new TimeSpan(2, 10, 0), "first studio"));
            myCatalog.AddSong(new Album("Load", "Metallica ", 1994, new TimeSpan(3, 24, 5), "S&M"));
            myCatalog.PrintCatalog();
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("Проверка метода записи Каталога в файл бинарный...");
            FileHandler.SerializeObjectBin(myCatalog, filePathBin);

            Catalog myCatalog2 = (Catalog)FileHandler.DeserializeObjectBin(filePathBin);
            if (myCatalog2 != null)
            {
                logger.Info("Объект успешно прочитан из файла: " + filePathBin);
                Console.WriteLine("Объект успешно прочитан из файла: " + filePathBin);
                myCatalog2.PrintCatalog();
            }


            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("Проверка метода записи Каталога в файл xml...");
            FileHandler.SaveCatalogXml(myCatalog, filePathXml);

            Catalog myCatalogFromXml = FileHandler.LoadCatalogXml<Catalog>(filePathXml);
            if (myCatalogFromXml != null)            // Проверка, был ли объект успешно десериализован
            {
                logger.Info("Объект успешно прочитан из файла: " + filePathXml);
                Console.WriteLine("Объект успешно прочитан из файла: " + filePathXml);
                myCatalogFromXml.PrintCatalog();
            }

            logger.Info("Приложение завершено");
        }
    }
}
