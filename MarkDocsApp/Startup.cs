using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using DI;
using DIContracts;
using MarkDocsAppContracts.Interfaces.BLL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocketContracts;


namespace MarkDocsApp
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
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dlls");
            var resolver = new Resolver(path, services);
            services.AddSingleton<IResolver>(sp => resolver);
            services.AddControllers();
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
            }));
            //Cloudinary
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseWebSockets();
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/ws/user")
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                        var id = context.Request.Query["id"];
                        var wsService = app.ApplicationServices.GetService<IWSUserService>();
                        wsService.Add(id, webSocket);
                        await wsService.Send(id, "WS::user service is on");
                        while (true)
                        {
                            var buffer = new byte[4082];
                            var recieve = await webSocket.ReceiveAsync(new Memory<byte>(buffer), CancellationToken.None);
                            if (recieve.MessageType == WebSocketMessageType.Close)
                            {
                                await wsService.Remove(id);
                                break;
                            }
                            else
                            {
                                var request = Encoding.UTF8.GetString(buffer);
                            }
                        }

                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                    }
                }
                else if (context.Request.Path == "/ws/draw")
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                        var userID = context.Request.Query["userID"];
                        var docID = context.Request.Query["docID"];
                        var wsService = app.ApplicationServices.GetService<IWSDrawService>();
                        wsService.Add(userID, docID, webSocket);
                        while (true)
                        {
                            var buffer = new byte[4082];
                            var recieve = await webSocket.ReceiveAsync(new Memory<byte>(buffer), CancellationToken.None);
                            if (recieve.MessageType == WebSocketMessageType.Close)
                            {
                                await wsService.Remove(userID, docID);
                                break;
                            }
                            else
                            {
                                await wsService.Receive(userID, buffer);
                            }
                        }

                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                    }
                }
                {
                    await next();
                }
            });
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("ApiCorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
