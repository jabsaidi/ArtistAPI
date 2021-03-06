﻿using Microsoft.AspNetCore.Mvc;
using FavoriteArtists.DLA.Repos;
using FavoriteArtists.DLA.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FavoriteArtists
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped(typeof(ISongRepo), typeof(SongRepo));
            services.AddScoped(typeof(IAlbumRepo), typeof(AlbumRepo));
            services.AddScoped(typeof(ICoverRepo), typeof(CoverRepo));
            services.AddScoped(typeof(IArtistRepo), typeof(ArtistRepo));
            services.AddScoped(typeof(IBaseRepo<Song>), typeof(SongRepo));
            services.AddScoped(typeof(IBaseRepo<Cover>), typeof(CoverRepo));
            services.AddScoped(typeof(IPlaylistRepo), typeof(PlaylistRepo));
            services.AddScoped(typeof(IBaseRepo<Album>), typeof(AlbumRepo));
            services.AddScoped(typeof(IAlbumSongRepo), typeof(AlbumSongRepo));
            services.AddScoped(typeof(ISongCoverRepo), typeof(SongCoverRepo));
            services.AddScoped(typeof(IBaseRepo<Artist>), typeof(ArtistRepo));
            services.AddScoped(typeof(IAlbumCoverRepo), typeof(AlbumCoverRepo));
            services.AddScoped(typeof(IArtistAlbumRepo), typeof(ArtistAlbumRepo));
            services.AddScoped(typeof(IBaseRepo<Playlist>), typeof(PlaylistRepo));
            services.AddScoped(typeof(IArtistCoverRepo), typeof(ArtistCoverRepo));
            services.AddScoped(typeof(IPlaylistCoverRepo), typeof(PlaylistCoverRepo));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}
