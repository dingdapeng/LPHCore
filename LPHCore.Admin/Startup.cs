using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using LPHCore.Model;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace LPHCore.Admin
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        //注册服务
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();

            //添加编码
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));

            //连接数据库
            var connection = Configuration.GetConnectionString("LPHdbConnection");
            services.AddDbContext<LPHdbContext>(options => options.UseSqlServer(connection));

            //Session服务
            services.AddSession();

            //授权
            services.AddAuthorization();



        }

        //设置请求管道
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                //开发环境异常处理
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                //生产环境异常处理
                app.UseExceptionHandler("/Home/Error");
            }
            //使用静态文件
            app.UseStaticFiles();
            //Session
            app.UseSession();
            //使用Mvc，设置默认路由为系统登录
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
