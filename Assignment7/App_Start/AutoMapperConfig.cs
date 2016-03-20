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
            /* Artists */
            Mapper.CreateMap<Models.Artist, Controllers.ArtistBase>();
            Mapper.CreateMap<Controllers.ArtistAdd, Models.Artist>();
            Mapper.CreateMap<Models.Artist, Controllers.ArtistWithAlbums>();
            Mapper.CreateMap<Controllers.ArtistBase, Controllers.ArtistEditAlbumsForm>();

            // Albums
            Mapper.CreateMap<Models.Album, Controllers.AlbumBase>();
            Mapper.CreateMap<Models.Album, Controllers.AlbumWithArtists>();
            Mapper.CreateMap<Controllers.AlbumEditArtists, Models.Album>();
            Mapper.CreateMap<Controllers.AlbumBase, Controllers.AlbumEditArtistsForm>();
#pragma warning restore CS0618
        }
    }
}