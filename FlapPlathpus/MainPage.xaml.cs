using Manager;

namespace FlapPlathpus;
public partial class MainPage : ContentPage
{
	const int gravity = 7; 
	// a gravidade que vai ser aplicada no objeto

	const int TimeToFrame = 33; 
	//tempo de espera dos frames ou fps
    
	bool isDead = true; 
	// Óbvio que é quando o passaro cai pelo cano

	double windowHeigth = 0;
	// è a altura da janela 

	double windowWidth = 0;
	// è a espessura da janela que vai aparecer

	int Fasty = 5; //60 fps
	// velocidade de movimento do cano

	bool GameStarded = false; 
	// aqui eu crie essa variavel pra dizer quando o jogo começou 
	// e fazer com que certos metodos funcionem melhor como o pulo 


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
			ManagerCan();
			//Colocando que enquanto o passaro não morreu 
			//aplica a move dos canos tambem

			IntroGravity();
			//Aqui é a gravidade que a gente atribuiu lá em cima
			// que vai ser aplicada no passaro

			await Task.Delay(TimeToFrame);
		    // como esse é o tempo de espra entre os frames 
		}
	}

//---------------------------------------------------------------------------------------//
    
	async void IntroGravity()
	{
		Imgperry.TranslationY += gravity; 
		if (Imgperry.TranslationY >= windowHeigth)
		{
			Imgperry.TranslationX = windowHeigth;
		}
		// translation é a transiçao do eixo Y ou x no caso 
		//como aumenta é oque vai fazer o pasarinho cair                                     
	}

//---------------------------------------------------------------------------------------//
    
	void FloatBird()
	{
	  if 
	  (GameStarded) // essa condicional vai fazer com que só funcione 
	  {             // o botão quando a gframe game over for clicada
	  
	  Imgperry.TranslationY -= 50; //Imgperry é o nome que eu coloquei no x name do passarinho
	                               // por enquanto é o pulo do passsaro
	  }
	}
//---------------------------------------------------------------------------------------
    private void ClickedFloatBird(object sender, EventArgs e)
	{
      FloatBird();
	  // aqui a gente tá chamando o void float bird que faz
	  // a gravidade do passarinho diminuir ou ele pular 
	}

//---------------------------------------------------------------------------------------//
	void OnGameOverClicked (object sender, EventArgs e)
	{
     GameOverFrame.IsVisible = false;
	 Initialize();
	 Drawn();
	 GameStarded = true; // aqui quando clicar no frame ele vai definir 
	                     // o jogo como começando oque possiblta ativar o pulo e clicked do passaro
	}

//---------------------------------------------------------------------------------------//
	void OnToGoHomeClicked(object sender, EventArgs e)
    {
		Application.Current.MainPage = new StartPage();
		
		GameStarded = false; // como ele volta pra tela de inicio
		                    // então o jogo não pode estar rodando
	}
	
//---------------------------------------------------------------------------------------//

    void Initialize()
	{
		isDead = false;
		Imgperry.TranslationY = 0;
		GameStarded = true; // qaundo o jogo reinicia ele é ativado como verdadeiro
	}

//---------------------------------------------------------------------------------------//
    
    void ManagerCan()
	{
		Imgcanobaixo.TranslationX -= Fasty;
		Imgcanocima.TranslationX -= Fasty;
		// aqui a genta está pedindo para que os canos se movam horizontalmente
		// para a esquerda da janela 
		
		if 
		 (Imgcanobaixo.TranslationX <= -Imgcanobaixo.Width)
		 // aqui é quando a tela acaba entã é redefinido a posiçaõ
		 // fazendo o cano voltar no ponto X e refazer o processo
		{
			Imgcanobaixo.TranslationX = windowWidth; 
            Imgcanocima.TranslationX = windowWidth; 
			// aqui são as imagens com o atributo zerado
		}
	}

 //---------------------------------------------------------------------------------------//
    protected override void OnSizeAllocated(double w, double h)
    {
        base.OnSizeAllocated(w, h);
		windowWidth = w;
		//Espessura da janela
		windowHeigth = h;
		// aqui a gente está definindo as janelas para definir o tamanho depois
    }

//---------------------------------------------------------------------------------------//
}





