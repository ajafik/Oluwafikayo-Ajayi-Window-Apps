using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.NetworkInformation;

using Windows.UI.Xaml;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class MainViewModel : BindableBase
    {
       private AboutMeViewModel _aboutMeModel;
       private TwitterViewModel _twitterModel;
       private InstagramViewModel _instagramModel;
       private MyBlogViewModel _myBlogModel;
       private MyVideosViewModel _myVideosModel;
       private MyFavoriteMusicViewModel _myFavoriteMusicModel;
        private PrivacyViewModel _privacyModel;

        private ViewModelBase _selectedItem = null;

        public MainViewModel()
        {
            _selectedItem = AboutMeModel;
            _privacyModel = new PrivacyViewModel();

        }
 
        public AboutMeViewModel AboutMeModel
        {
            get { return _aboutMeModel ?? (_aboutMeModel = new AboutMeViewModel()); }
        }
 
        public TwitterViewModel TwitterModel
        {
            get { return _twitterModel ?? (_twitterModel = new TwitterViewModel()); }
        }
 
        public InstagramViewModel InstagramModel
        {
            get { return _instagramModel ?? (_instagramModel = new InstagramViewModel()); }
        }
 
        public MyBlogViewModel MyBlogModel
        {
            get { return _myBlogModel ?? (_myBlogModel = new MyBlogViewModel()); }
        }
 
        public MyVideosViewModel MyVideosModel
        {
            get { return _myVideosModel ?? (_myVideosModel = new MyVideosViewModel()); }
        }
 
        public MyFavoriteMusicViewModel MyFavoriteMusicModel
        {
            get { return _myFavoriteMusicModel ?? (_myFavoriteMusicModel = new MyFavoriteMusicViewModel()); }
        }

        public void SetViewType(ViewTypes viewType)
        {
            AboutMeModel.ViewType = viewType;
            TwitterModel.ViewType = viewType;
            InstagramModel.ViewType = viewType;
            MyBlogModel.ViewType = viewType;
            MyVideosModel.ViewType = viewType;
            MyFavoriteMusicModel.ViewType = viewType;
        }

        public ViewModelBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                UpdateAppBar();
            }
        }

        public Visibility AppBarVisibility
        {
            get
            {
                return SelectedItem == null ? AboutVisibility : SelectedItem.AppBarVisibility;
            }
        }

        public Visibility AboutVisibility
        {

         get { return Visibility.Visible; }
        }

        public void UpdateAppBar()
        {
            OnPropertyChanged("AppBarVisibility");
            OnPropertyChanged("AboutVisibility");
        }

        /// <summary>
        /// Load ViewModel items asynchronous
        /// </summary>
        public async Task LoadDataAsync(bool forceRefresh = false)
        {
            var loadTasks = new Task[]
            { 
                AboutMeModel.LoadItemsAsync(forceRefresh),
                TwitterModel.LoadItemsAsync(forceRefresh),
                InstagramModel.LoadItemsAsync(forceRefresh),
                MyBlogModel.LoadItemsAsync(forceRefresh),
                MyVideosModel.LoadItemsAsync(forceRefresh),
                MyFavoriteMusicModel.LoadItemsAsync(forceRefresh),
            };
            await Task.WhenAll(loadTasks);
        }

        //
        //  ViewModel command implementation
        //
        public ICommand RefreshCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await LoadDataAsync(true);
                });
            }
        }

        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateToPage("AboutThisAppPage");
                });
            }
        }

        public ICommand PrivacyCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateTo(_privacyModel.Url);
                });
            }
        }
    }
}
