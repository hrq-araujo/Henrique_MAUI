
namespace HenriqueMAUI
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _viewModel;

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = viewModel;
            _viewModel._drawableGraphic = GraphicView;
            _viewModel.StartViewModel();
            
        }
    }
}


