using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;

namespace Assignment7
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // Add map creation statements here
            // Mapper.CreateMap< FROM , TO >();
#pragma warning disable CS0618

            // Artists 
            Mapper.CreateMap<Models.Artist, Controllers.ArtistBase>();
            Mapper.CreateMap<Controllers.ArtistAdd, Models.Artist>();
            Mapper.CreateMap<Controllers.ArtistAddForm, Models.Artist>();
            Mapper.CreateMap<Models.Artist, Controllers.ArtistWithDetail>();

            // Albums
            Mapper.CreateMap<Models.Album, Controllers.AlbumBase>();
            Mapper.CreateMap<Models.Album, Controllers.AlbumWithDetail>();
            Mapper.CreateMap<Controllers.AlbumAdd, Models.Album>();
            Mapper.CreateMap<Controllers.AlbumBase, Controllers.AlbumAddForm>();

            // Genres
            Mapper.CreateMap<Models.Genre, Controllers.GenreBase>();

            // Tracks
            Mapper.CreateMap<Models.Track, Controllers.TrackBase>();
            Mapper.CreateMap<Controllers.TrackAdd, Models.Track>();
            Mapper.CreateMap<Controllers.TrackAddForm, Models.Track>();
            Mapper.CreateMap<Models.Track, Controllers.TrackWithDetail>();
            Mapper.CreateMap<Controllers.TrackBase, Controllers.TrackEditForm>();
            Mapper.CreateMap<Controllers.TrackWithDetail, Controllers.TrackEditForm>();

#pragma warning restore CS0618
        }
    }
}