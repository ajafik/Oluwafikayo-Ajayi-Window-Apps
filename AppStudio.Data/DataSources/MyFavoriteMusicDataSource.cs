using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class MyFavoriteMusicDataSource : DataSourceBase<MenuSchema>
    {
        private const string _file = "/Assets/Data/MyFavoriteMusicDataSource.json";

        protected override string CacheKey
        {
            get { return "MyFavoriteMusicDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<MenuSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<MenuSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("MyFavoriteMusicDataSource.LoadData", ex.ToString());
                return new MenuSchema[0];
            }
        }

    }
}
