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

        public IEnumerable<ArtistWithDetail> ArtistGetAllWithDetail()
        {
            return Mapper.Map<IEnumerable<ArtistWithDetail>>
                (ds.Artists.Include("Albums").OrderBy(a => a.Name));
        }

        public ArtistWithDetail ArtistGetByIdWithDetail(int id)
        {
            var o = ds.Artists.Include("Albums").SingleOrDefault(e => e.Id == id);
            return (o == null) ? null : Mapper.Map<ArtistWithDetail>(o);
        }

        public IEnumerable<AlbumWithDetail> AlbumGetAllWithDetail()
        {
            return Mapper.Map<IEnumerable<AlbumWithDetail>>
                (ds.Albums.Include("Artists").Include("Tracks").OrderBy(a => a.Name));
        }

        public AlbumWithDetail AlbumGetByIdWithDetail(int id)
        {
            var o = ds.Albums.Include("Artists").Include("Tracks").SingleOrDefault(a => a.Id == id);
            return (o == null) ? null : Mapper.Map<AlbumWithDetail>(o);
        }

        // Create a new album with artists
        public AlbumWithDetail AlbumAdd(AlbumAdd newItem)
        {

            var o = ds.Albums.Add(Mapper.Map<Album>(newItem));

            foreach (var item in newItem.ArtistIds)
            {
                var a = ds.Artists.Find(item);
                o.Artists.Add(a);
            }

            foreach (var item in newItem.TrackIds)
            {
                var a = ds.Tracks.Find(item);
                o.Tracks.Add(a);
            }

            ds.SaveChanges();

            return (o == null) ? null : Mapper.Map<AlbumWithDetail>(o);
        }

        public IEnumerable<GenreBase> GenreGetAll()
        {
            return Mapper.Map<IEnumerable<GenreBase>>(ds.Genres.OrderBy(a => a.Name));
        }

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

        public IEnumerable<TrackWithDetail> TrackGetAllWithDetail()
        {
            return Mapper.Map<IEnumerable<TrackWithDetail>>
                (ds.Tracks.Include("Albums").OrderBy(a => a.Name));
        }

        public TrackWithDetail TrackGetByIdWithDetail(int id)
        {
            var o = ds.Tracks.Include("Albums").SingleOrDefault(e => e.Id == id);
            return (o == null) ? null : Mapper.Map<TrackWithDetail>(o);
        }

        public TrackWithDetail TrackEdit(TrackEdit newItem)
        {

            var o = ds.Tracks.Find(newItem.Id);

            if (o == null)
            {
                return null;
            }
            else
            {
                ds.Entry(o).CurrentValues.SetValues(newItem);
                ds.SaveChanges();
                return Mapper.Map<TrackWithDetail>(o);
            }
        }

        public bool TrackDelete(int id)
        {
            var itemToDelete = ds.Tracks.Find(id);

            if (itemToDelete == null)
            {
                return false;
            }
            else
            {
                ds.Tracks.Remove(itemToDelete);
                ds.SaveChanges();
                return true;
            }
        }
    }
}