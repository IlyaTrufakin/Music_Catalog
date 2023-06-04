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
    [Serializable]
    public class Catalog
    {
        public List<Album> myAlbum { get; set; }

        public Catalog()
        {
            myAlbum = new List<Album>();
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

    }
}
