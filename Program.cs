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

            Catalog myCatalog = new Catalog();
            myCatalog.AddSong(new Album("Scream", "Michael Jackson", 1989, new TimeSpan(2,10,0), "first studio"));
            myCatalog.AddSong(new Album("Load", "Metallica ", 1994, new TimeSpan(3, 24, 5), "S&M"));
            myCatalog.PrintCatalog();
            myCatalog.SaveCatalogXml(myCatalog, "test.xml");
            Catalog myCatalog2 = (Catalog)myCatalog.LoadCatalogXml("test.xml");
            myCatalog2.PrintCatalog();

            // logger.Info("Music Album App Started");

            //private static Logger logger = LogManager.GetCurrentClassLogger();

            /*        myAlbum.EnterAlbumInfo();
                    myAlbum.PrintAlbumInfo();
                    myAlbum.SaveToXmlFile();*/

            /*         album.SaveToXmlFile();

                     Album loadedAlbum = Album.LoadFromXmlFile();
                     loadedAlbum.OutputAlbumInfo();


                     // Серіалізація альбому
                     XmlSerializer serializer = new XmlSerializer(typeof(Album));
                     using (TextWriter writer = new StreamWriter("album.xml"))
                     {
                         serializer.Serialize(writer, album);
                     }
                     logger.Info("Album serialized and saved to file");

                     // Завантаження серіалізованого альбому з файлу
                     Album loadedAlbum;
                     using (TextReader reader = new StreamReader("album.xml"))
                     {
                         loadedAlbum = (Album)serializer.Deserialize(reader);
                     }
                     logger.Info("Album loaded from file");

                     // Збереження даних про альбом у xml файлі
                     using (TextWriter writer = new StreamWriter("album.xml"))
                     {
                         serializer.Serialize(writer, loadedAlbum);
                     }
                     logger.Info("Album data saved to XML file");

                     logger.Info("Music Album App Finished");*/







        }
    }
}
