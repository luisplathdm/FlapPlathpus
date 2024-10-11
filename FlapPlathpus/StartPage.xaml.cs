namespace FlapPlathpus;
public partial class StartPage : ContentPage
{
//--------------------------------------------//
    public StartPage()
    {
        InitializeComponent(); 
    }


  void OnToGoToGameClicked(object sender, EventArgs e)
    {
		Application.Current.MainPage = new MainPage();
	}
}


