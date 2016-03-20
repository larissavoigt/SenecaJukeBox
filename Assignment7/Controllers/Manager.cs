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

        public IEnumerable<ArtistDetails> ArtistDetailsGetAll()
        {
            return Mapper.Map<IEnumerable<ArtistDetails>>
                (ds.Artists.Include("Albums").OrderBy(a => a.Name));
        }

        public ArtistDetails ArtistDetailsGetById(int id)
        {
            // Attempt to fetch the object
            var o = ds.Artists.Include("Albums").SingleOrDefault(e => e.Id == id);

            // Return the result, or null if not found
            return (o == null) ? null : Mapper.Map<ArtistDetails>(o);
        }

        public IEnumerable<AlbumDetails> AlbumDetailsGetAll()
        {
            return Mapper.Map<IEnumerable<AlbumDetails>>
                (ds.Albums.Include("Artists").Include("Tracks").OrderBy(a => a.Name));
        }

        public AlbumDetails AlbumDetailsGetById(int id)
        {
            // Attempt to fetch the object
            var o = ds.Albums.Include("Artists").Include("Tracks").SingleOrDefault(a => a.Id == id);

            // Return the result, or null if not found
            return (o == null) ? null : Mapper.Map<AlbumDetails>(o);
        }

        // Create a new album with artists
        public AlbumDetails AlbumDetailsAdd(AlbumAdd newItem)
        {

            var o = ds.Albums.Add(Mapper.Map<Album>(newItem));

            foreach (var item in newItem.ArtistIds)
            {
                var a = ds.Artists.Find(item);
                o.Artists.Add(a);
            }

            ds.SaveChanges();

            return (o == null) ? null : Mapper.Map<AlbumDetails>(o);
        }

        public IEnumerable<GenreBase> GenreGetAll()
        {
            return Mapper.Map<IEnumerable<GenreBase>>(ds.Genres.OrderBy(a => a.Name));
        }

        // Attention - 13 - Add some programmatically-generated objects to the data store
        // Can write one method, or many methods - your decision
        // The important idea is that you check for existing data first
        // Call this method from a controller action/method


        public IEnumerable<TrackBase> TrackGetAll()
        {
            return Mapper.Map<IEnumerable<TrackBase>>(ds.Tracks.OrderBy(a => a.Name));
        }

        public TrackBase TrackGetById(int? id)
        {
            var o = ds.Tracks.Find(id);
            return (o == null) ? null : Mapper.Map<TrackBase>(o);
        }

        public TrackBase TrackAdd(TrackAdd newItem)
        {
            var addedItem = ds.Tracks.Add(Mapper.Map<Track>(newItem));
            ds.SaveChanges();

            return (addedItem == null) ? null : Mapper.Map<TrackBase>(addedItem);
        }

        public IEnumerable<TrackDetails> TrackDetailsGetAll()
        {
            return Mapper.Map<IEnumerable<TrackDetails>>
                (ds.Tracks.Include("Tracks").OrderBy(a => a.Name));
        }

        public TrackDetails TrackDetailsGetById(int id)
        {
            // Attempt to fetch the object
            var o = ds.Tracks.Include("Albums").SingleOrDefault(e => e.Id == id);

            // Return the result, or null if not found
            return (o == null) ? null : Mapper.Map<TrackDetails>(o);
        }
    }
}