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

            /* Artists */
            Mapper.CreateMap<Models.Artist, Controllers.ArtistBase>();

            // Disable AutoMapper v4.2.x warnings
#pragma warning disable CS0618

            // Attention - AutoMapper create map statements

#pragma warning restore CS0618
        }
    }
}