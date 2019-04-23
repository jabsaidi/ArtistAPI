using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FavoriteArtists.DLA.Repos;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using FavoriteArtists.DLA.Repos.FileRepos;
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
            services.AddScoped(typeof(IArtistRepo), typeof(ArtistRepo));
            services.AddScoped(typeof(IPlaylistRepo), typeof(PlaylistRepo));
            services.AddScoped(typeof(IAlbumSongRepo), typeof(AlbumSongRepo));
            services.AddScoped(typeof(IArtistAlbumRepo), typeof(ArtistAlbumRepo));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
