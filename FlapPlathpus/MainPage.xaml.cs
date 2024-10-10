using Manager;

namespace FlapPlathpus;
public partial class MainPage : ContentPage
{
	const int gravity = 30; // a gravidade que vai ser aplicada no objeto

	const int TimeToFrame = 25; //tempo de espera dos frames ou fps

	bool isDead = false; // Óbvio que é quando o passaro cai pelo cano

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	public MainPage()
	{
		InitializeComponent();
		Drawn().RunSynchronously(); 
		//faz ele rodar de forma sincrona ou junto com a pagina
	}

    async Task Drawn()
	{
		while(!isDead) 
		// !=não, enquanto não está morto aplica gravidade
		{
			IntroGravity();
		}
	}

    void IntroGravity()
	{
		Imagemperry.TranslationY += gravity; 
		// translation é a transiçao do eixo Y ou x no caso como aumenta
		//é oque vai fazer o pasarinho cair 
		                                       
	}

}





