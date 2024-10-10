using Manager;

namespace FlapPlathpus;
public partial class MainPage : ContentPage
{
	const int gravity = 10; 
	// a gravidade que vai ser aplicada no objeto

	const int TimeToFrame = 2000; 
	//tempo de espera dos frames ou fps

	bool isDead = false; 
	// Óbvio que é quando o passaro cai pelo cano


//---------------------------------------------------------------------------------------//
	
	public MainPage()
	{
		InitializeComponent(); 
	}


//---------------------------------------------------------------------------------------//
    async Task Drawn()
	{
		while(!isDead) 
		// !=não, enquanto não está morto aplica gravidade
		
		
		{
			IntroGravity();
			await Task.Delay(TimeToFrame);
		    // como esse é o tempo de espra entre os frames 
		}
	}

//---------------------------------------------------------------------------------------//
    
	async void IntroGravity()
	{
		Imgperry.TranslationY += gravity; 
		// translation é a transiçao do eixo Y ou x no caso como aumenta
		//é oque vai fazer o pasarinho cair 
		                                      
	}

//---------------------------------------------------------------------------------------//
	
	protected override void OnAppearing()
	{
		base.OnAppearing();
		Drawn();
		//faz ele rodar de forma sincrona ou junto com a pagina
	}
	
//---------------------------------------------------------------------------------------//
}





