using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Music_Catalog
{

    internal class FileHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static void SaveCatalogXml<T>(T obj, string filePath)
        {
            try
            {
                Console.WriteLine("_____________________________________________________");
                Console.WriteLine("Запись объекта в XML файл: ");
                logger.Info("Запись объекта в XML файл: " + filePath);
                var serializer = new XmlSerializer(typeof(T));
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, obj);
                }
                Console.WriteLine("Объект записан в файл: " + filePath);
                logger.Info("Объект записан в файл: " + filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка при сериализации объекта: " + e.Message);
                logger.Info("Произошла ошибка при сериализации объекта, файл: (" + filePath + ") Файл не записан!");
            }
        }

        public static T LoadCatalogXml<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    Console.WriteLine("Чтение из файла: " + filePath);
                    logger.Info("Чтение объекта из XML файла: " + filePath);
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        return (T)serializer.Deserialize(reader);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка чтения объекта из XML файла: (" + filePath + ") Некорректный формат данных! Тип ошибки: " + e.Message);
                    logger.Info("Ошибка чтения объекта из XML файла: (" + filePath + ") Некорректный формат данных! Тип ошибки: " + e.Message);
                    return default;
                }

            }
            else
            {
                logger.Info("Ошибка чтения объекта из XML файла: (" + filePath + ") Файл не найден!");
                return default;
            }
        }



        public static void SerializeObjectBin(object obj, string filePath)
        {
            try
            {
                Console.WriteLine("_____________________________________________________");
                Console.WriteLine("Запись объекта в бинарный файл: ");
                logger.Info("Запись объекта в бинарный файл: " + filePath);
                using (FileStream writer = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(writer, obj);
                }
                Console.WriteLine("_____________________________________________________");
                Console.WriteLine("Объект успешно записан в файл: " + filePath);
                logger.Info("Объект записан в файл: " + filePath);

            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка при сериализации объекта: " + e.Message);
                logger.Info("Произошла ошибка при сериализации объекта, файл: (" + filePath + ") Файл не записан! Тип ошибки: " + e.Message);
            }

        }




        public static object DeserializeObjectBin(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    Console.WriteLine("_____________________________________________________");
                    Console.WriteLine("Чтение из файла: " + filePath);
                     logger.Info("Чтение объекта из файла: " + filePath);
                    using (FileStream reader = new FileStream(filePath, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        return formatter.Deserialize(reader);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Произошла ошибка при десериализации объекта: " + e.Message);
                    logger.Info("Произошла ошибка при десериализации объекта, файл: (" + filePath + ") Файл не прочитан! Тип ошибки: " + e.Message);
                    return null;
                }
            }
            else
            {
                logger.Info("Ошибка чтения объекта из бинарного файла: (" + filePath + ") Файл не найден!");
                return null;
            }
        }

    }
}
