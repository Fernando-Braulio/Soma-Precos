using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SomaPrecos
{
    public partial class App : Application
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "produtosSupermecado.db3");
                    database = new Database(path);
                }
                return database;
            }
        }

        public App ()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

