using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Music_Catalog
{
    [Serializable]
    public class Album
    {
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public int Year { get; set; }
        public TimeSpan Duration { get; set; }
        public string Studio { get; set; }

        public Album() { }

        public Album(string title, string artistName, int year, TimeSpan duration, string studio)
        {
            Title = title;
            ArtistName = artistName;
            Year = year;
            Duration = duration;
            Studio = studio;
        }

        public void EnterAlbumInfo()
        {
            Console.WriteLine("Enter Album Information:");
            Console.Write("Title: ");
            Title = Console.ReadLine();
            Console.Write("Artist Name: ");
            ArtistName = Console.ReadLine();
            Console.Write("Year: ");
            Year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Duration (hh:mm:ss): ");
            string durationString = Console.ReadLine();
            Duration = TimeSpan.Parse(durationString);
            Console.Write("Studio: ");
            Studio = Console.ReadLine();
        }

        public void PrintAlbumInfo()
        {
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("Album Information:");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Artist Name: {ArtistName}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Duration: {Duration}");
            Console.WriteLine($"Studio: {Studio}");
        }

    }
}
