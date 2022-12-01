using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Vitor_d7_avaliacao.Data;

namespace Vitor_d7_avaliacao
{
    public partial class App : Application
    {
        private readonly ServiceProvider? serviceProvider;

        public App()
        {
            ServiceCollection services = new();

            services.AddDbContext<Context>(options =>
            {
                options.UseSqlite("Data source = User.db");
            });

            services.AddSingleton<MainWindow>();
            serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object s, StartupEventArgs e)
        {
            var mainWindow = serviceProvider?.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
