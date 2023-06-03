using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Music_Catalog
{
    public class Catalog //: ICatalog, IEnumerable<Album>
    {
        private List<Album> myAlbum = new List<Album>();

        public void Add(object obj)
        {
            if (obj is Album album)
            {
                AddSong(album);
            }
        }

        public void AddSong()
        {
            myAlbum.Add(new Album());
        }

        public void AddSong(Album album)
        {
            myAlbum.Add(album);
        }

        public void RemoveSong(Album album)
        {
            myAlbum.Remove(album);
        }

 /*       public IEnumerator<Album> GetEnumerator()
        {
            return myAlbum.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }*/

        public void PrintAlbum(Album album)
        {
            album.PrintAlbumInfo();
        }

        public void PrintCatalog()
        {
            foreach (Album album in myAlbum)
            {
                album.PrintAlbumInfo();
            }
        }



        public  void SaveCatalogXml(object catalog, string filePath)
        {
            var serializer = new XmlSerializer(typeof(Catalog));
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, catalog);
            }
            Console.WriteLine("Album data saved to XML file");


        }
        public  object LoadCatalogXml(string filePath)
        {
            var serializer = new XmlSerializer(typeof(object));
            using (TextReader reader = new StreamReader(filePath))
            {
                return serializer.Deserialize(reader);
            }
        }



        public void SerializeObjectBin(Object obj, string filePath)
        {
            try
            {
                using (FileStream writer = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(writer, obj);
                }

                Console.WriteLine("Объект успешно записан в файл: " + filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка при сериализации объекта: " + e.Message);
            }
        }




        public object DeserializeObjectBin(string filePath)
        {
            try
            {
                using (FileStream reader = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return formatter.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка при десериализации объекта: " + e.Message);
                return null;
            }
        }

    }
}
