using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment7.Models;

namespace Assignment7.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private ApplicationDbContext ds = new ApplicationDbContext();

        public Manager()
        {
            // If necessary, add constructor code here

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()

        public IEnumerable<ArtistBase> ArtistGetAll()
        {
            return Mapper.Map<IEnumerable<ArtistBase>>(ds.Artists.OrderBy(a => a.Name));
        }

        public ArtistBase ArtistGetById(int? id)
        {
            var o = ds.Artists.Find(id);
            return (o == null) ? null : Mapper.Map<ArtistBase>(o);
        }

        public ArtistBase ArtistAdd(ArtistAdd newItem)
        {
            var addedItem = ds.Artists.Add(Mapper.Map<Artist>(newItem));
            ds.SaveChanges();

            return (addedItem == null) ? null : Mapper.Map<ArtistBase>(addedItem);
        }

        public IEnumerable<ArtistWithAlbums> ArtistGetAllWithAlbums()
        {
            return Mapper.Map<IEnumerable<ArtistWithAlbums>>
                (ds.Artists.Include("Albums").OrderBy(a => a.Name));
        }

        public ArtistWithAlbums ArtistGetByIdWithDetail(int id)
        {
            // Attempt to fetch the object
            var o = ds.Artists.Include("Albums").SingleOrDefault(e => e.Id == id);

            // Return the result, or null if not found
            return (o == null) ? null : Mapper.Map<ArtistWithAlbums>(o);
        }

        public IEnumerable<AlbumWithArtists> AlbumGetAllWithArtists()
        {
            return Mapper.Map<IEnumerable<AlbumWithArtists>>
                (ds.Albums.Include("Artists").OrderBy(a => a.ReleaseDate));
        }

        public AlbumWithArtists AlbumGetByIdWithDetail(int id)
        {
            // Attempt to fetch the object
            var o = ds.Albums.Include("Artists").SingleOrDefault(a => a.Id == id);

            // Return the result, or null if not found
            return (o == null) ? null : Mapper.Map<AlbumWithArtists>(o);
        }

        // Create a new album with artists
        public AlbumWithArtists AlbumEditArtists(AlbumEditArtists newItem)
        {

            var o = ds.Albums.Add(Mapper.Map<Album>(newItem));

            foreach (var item in newItem.ArtistIds)
            {
                var a = ds.Artists.Find(item);
                o.Artists.Add(a);
            }

            ds.SaveChanges();

            return (o == null) ? null : Mapper.Map<AlbumWithArtists>(o);
        }

        public IEnumerable<GenreBase> Genres()
        {
            return Mapper.Map<IEnumerable<GenreBase>>(ds.Genres.OrderBy(a => a.Name));
        }

        // Attention - 13 - Add some programmatically-generated objects to the data store
        // Can write one method, or many methods - your decision
        // The important idea is that you check for existing data first
        // Call this method from a controller action/method

        public bool LoadData()
        {
            // Return if there's existing data

            if (ds.Genres.Count() > 0) { return false; }

            var genres = new List<string> {
                "Alternative",
                 "Blues",
                 "Classical",
                 "Country",
                 "Dance",
                 "Easy Listening",
                 "Electronic",
                "Hip Hop / Rap",
                "Indie Pop",
                "Jazz",
                 "New Age",
                 "Opera",
                 "Pop",
                 "R&B / Soul",
                 "Reggae",
                 "Rock",
                 "World Music / Beats"
            };

            foreach (var g in genres)
            {
                ds.Genres.Add(new Genre { Name = g });
                ds.SaveChanges();
            }

            return true;
        }

    }
}