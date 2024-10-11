using Manager;

namespace FlapPlathpus;
public partial class MainPage : ContentPage
{
	const int gravity = 20; 
	// a gravidade que vai ser aplicada no objeto

	const int TimeToFrame = 1000; 
	//tempo de espera dos frames ou fps
    
	bool isDead = true; 
	// Óbvio que é quando o passaro cai pelo cano

	double windowHeigth = 0;
	// è a altura da janela 

	double windowWidth = 0;
	// è a espessura da janela que vai aparecer

	int Fasty = 30; //60 fps
	// velocidade de movimento do cano


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
		if (Imgperry.TranslationY >=- windowHeigth)
		{
			Imgperry.TranslationX =30;
		}
		// translation é a transiçao do eixo Y ou x no caso 
		//como aumenta é oque vai fazer o pasarinho cair                                     
	}

//---------------------------------------------------------------------------------------//
    
				void FloatBird()
				{
					Imgperry.TranslationY -= 30; 
				}

			    private void ClickedFloatBird(object sender, EventArgs e)
				{
                FloatBird();
				}

//---------------------------------------------------------------------------------------//
	void OnGameOverClicked (object sender, EventArgs e)
	{
     GameOverFrame.IsVisible = false;
	 Initialize();
	 Drawn();
	}

//---------------------------------------------------------------------------------------//
	void OnToGoHomeClicked(object sender, EventArgs e)
    {
		Application.Current.MainPage = new StartPage();
	}
	
//---------------------------------------------------------------------------------------//

    void Initialize()
	{
		isDead = false;
		Imgperry.TranslationY = 0;
	}

//---------------------------------------------------------------------------------------//
    
    void ManagerCan()
	{
		Imgcanobaixo.TranslationX -= Fasty;
		Imgcanocima.TranslationX -= Fasty;
		// aqui a genta está pedindo para que os canos se movam horizontalmente
		// para a esquerda da janela 
		
		if 
		 (Imgcanobaixo.TranslationX<=-windowWidth)
		 // aqui é quando a tela acaba entã é redefinido a posiçaõ
		 // fazendo o cano voltar no ponto X e refazer o processo
		{
			Imgcanobaixo.TranslationX = 0;
			Imgcanocima.TranslationX = 0;
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





