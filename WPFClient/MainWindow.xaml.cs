using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop_data_access.Repositories;
using Shop_data_access.Data;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUoW unitOfWork = null;

        public MainWindow()
        {
            InitDbContext();
            InitializeComponent();
            ComboBoxShops.ItemsSource = unitOfWork.ShopRepo.Get(includeProperties: "City").Select(x => new
            {
                x.Id,
                x.Name,
                x.Address,

                //Summary = (x.Review != null ? x.Review.Summary : null),
                //ReviewData = (x.Review != null ? x.Review.Date : DateTime.Now),
            });
        }
        private void InitDbContext()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("MyDbConnection");

            var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionBuilder.UseSqlServer(connectionString).Options;
            unitOfWork = new UnitOfWork(options);
        }
    }
}
