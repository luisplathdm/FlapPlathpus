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

	int Fasty = 5;
	//60 fps
	// velocidade de movimento do cano

	bool GameStarded = false;
	// aqui eu crie essa variavel pra dizer quando o jogo começou 
	// e fazer com que certos metodos funcionem melhor como o pulo 

	const int MaxTimeFloating = 3;
	//é o tempo que ele vai pular ate cair 

	int TimeFloating = 0;
	// ainda não entenmdi esse treco o meu tava mais facil

	bool IsFloating = false;
	// é pra dizer se esse negocio tá pulando ou não

	const int PowerFloating = 30;
	//é o tanto que vai pular porque o meu tava melhor mais 
	// o tiagão falou que estava errado e eu como um bom aluno só estou
	// fazendo para provar que o meu dava no mesmo

	const int MaxDuna = 50;
	// é a abertura entre os canos onde o passaro passa

	int Score = 0;
	// é a pomtuação que a pessoa ganha 
	//por passar pelo cano

	//---------------------------------------------------------------------------------------//

	public MainPage()
	{
		InitializeComponent();
	}

	//---------------------------------------------------------------------------------------//
	void Initialize()
	{
		isDead = false;
		LabelFinalScore.IsVisible = false;
		Imgperry.TranslationY = 0; 
		Imgperry.TranslationX = 0;
		Imgcanobaixo.TranslationX = -windowWidth;
		Imgcanocima.TranslationX = -windowWidth;
		Score = 0;
		ManagerCan();
		Drawn();
	}

	//---------------------------------------------------------------------------------------//
	async Task Drawn()
	{
		while (!isDead)
		// !=não, enquanto não está morto aplica gravidade
		{
			    if (IsFloating)
				{	
					FloatBird();
				}
				else
                {
					IntroGravity();
					//Aqui é a gravidade que a gente atribuiu lá em cima
					// que vai ser aplicada no passaro

					ManagerCan();
					//Colocando que enquanto o passaro não morreu 
					//aplica a move dos canos tambem
				}
                IntroGravity();
				ManagerCan();
				if (IsColliding())
				{
					isDead = true;
                    GameOverFrame.IsVisible = true;
				    LabelFinalScore.IsVisible = true;

					break;
					// Aqui a gente diz que se ele colidir então o jogo 
					// não começou oque significa que a frame aparece

				}

			await Task.Delay(TimeToFrame);
			// como esse é o tempo de espra entre os frames 
		}
	}

	//---------------------------------------------------------------------------------------//

	async void IntroGravity()
	{
		Imgperry.TranslationY += gravity;
		// translation é a transiçao do eixo Y ou x no caso 
		//como aumenta é oque vai fazer o pasarinho cair                                     
	}

	//---------------------------------------------------------------------------------------//

	void FloatBird()
	{
		{
			Imgperry.TranslationY -= PowerFloating;
			//Imgperry é o nome que eu coloquei no x name do passarinho
			// por enquanto é o pulo do passsaro
			TimeFloating++;
			if (TimeFloating > MaxTimeFloating)
			{
				IsFloating = false;
				TimeFloating = 0;
			}
		}
	}
	//---------------------------------------------------------------------------------------
	void ClickedFloatBird(object s, TappedEventArgs a)
	{
		IsFloating = true;
		// aqui a gente tá dizendo que o passarinho tá pulando 
		//  oque faz a gravidade do passarinho diminuir ou ele pular 
	}

	//---------------------------------------------------------------------------------------//
	void OnGameOverClicked(object s, TappedEventArgs a)
	{
		GameOverFrame.IsVisible = false;
		Score = 0;
		Initialize();
		// aqui quando clicar no frame ele vai definir 
		// o jogo como começando oque possiblta ativar o pulo e clicked do passaro
	}

	//---------------------------------------------------------------------------------------//
		bool IsColliding()
	{
		if (!isDead)
		{
			// Verifica se os elementos são válidos //
			if (IsCollidingSky() ||
				IsCollidingHell() ||
				IsCollidingCanSky() ||
				IsCollidingCanHell())
			{
				// Se colidir com o teto ou o chão, ou com um dos canos, retorna verdadeiro
				return true;
			}
		}

		// Se não houver colisãocom nenhum cano  retorna false
		return false;
	}
	
	//---------------------------------------------------------------------------------------//

	bool IsCollidingSky()
	{
		var minY = -windowHeigth / 2;
		if (Imgperry.TranslationY <= minY)
			return true;
		else
			return false;
	// aui é o metodo quando a altura do passaro chega ou ultrpassa
	// o ceu ou teto do jogo oque faz ele hamar Is coliding
	}
	//---------------------------------------------------------------------------------------//

	bool IsCollidingHell()
	{
		var maxY = windowHeigth / 2;
		if (Imgperry.TranslationY >= maxY)
			return true;
		else
			return false;
	
	// aqui a gente está criando o metodo toda vez que o passaro bater 
	// no chao oque significa que quando ele chegar retorna true e então chama
	// o metodo Is coloding
	
	}
    //---------------------------------------------------------------------------------------//
    bool IsCollidingCanSky()
	{
		var  posHPerry = (windowWidth/2) - (Imgperry.WidthRequest/2);
		var posVPerry = (windowHeigth/2) - (Imgperry.HeightRequest/2) + Imgperry.TranslationY;
		
		if (posHPerry >= Math.Abs(Imgcanocima.TranslationX) -Imgcanocima.WidthRequest && 
		    posHPerry <= Math.Abs(Imgcanocima.TranslationX) + Imgcanocima.WidthRequest &&
		    posVPerry <= Imgcanocima.HeightRequest + Imgcanocima.TranslationY)
		{
			return true;
		}
		else 
		{
			return false;
		}
	}
	
		bool IsCollidingCanHell()
	{ 
		var posHPerry = (windowWidth / 2) - (Imgperry.WidthRequest / 2);
		var posVPerry = (windowHeigth / 2) - (Imgperry.HeightRequest / 2) + Imgperry.TranslationY;

		// Verificar se o personagem está na mesma posição horizontal que o cano e se a altura do cano cobre o personagem
		if (posHPerry >= Imgcanobaixo.TranslationX && 
			posHPerry <= Imgcanobaixo.TranslationX + Imgcanobaixo.WidthRequest &&
			posVPerry >= Imgcanobaixo.TranslationY && 
			posVPerry <= Imgcanobaixo.TranslationY + Imgcanobaixo.HeightRequest)
		{
			return true;
		}
		else
		{
			return false;
		}
	}


	//---------------------------------------------------------------------------------------//
	void OnToGoHomeClicked(object sender, EventArgs e)
	{
		Application.Current.MainPage = new StartPage();

		GameStarded = false; 
		// como ele volta pra tela de inicio
		// então o jogo não pode estar rodando
	}

	//---------------------------------------------------------------------------------------//

	void ManagerCan()
	{
		Imgcanobaixo.TranslationX -= Fasty;
		Imgcanocima.TranslationX -= Fasty;
		// aqui a genta está pedindo para que os canos se movam horizontalmente
		// para a esquerda da janela 

		if (Imgcanobaixo.TranslationX < -windowWidth)
		// aqui é quando a tela acaba entã é redefinido a posiçaõ
		// fazendo o cano voltar no ponto X e refazer o processo
		
		{
			Imgcanobaixo.TranslationX = windowWidth;
            Imgcanocima.TranslationX = windowWidth;
			// aqui antes eram as imagens com o atributo zerado
			// agora eu coloquei um negocinho só para eles votarem da direita
			
			var maxHeigth =-100;
			var minHeigth = -Imgcanobaixo.HeightRequest;
			// aqui são as variaveis que determinar a altura ou espaço
			// que o passaro pode passar alem de colocar o minimo
			
			Imgcanocima.TranslationY = Random.Shared.Next((int)minHeigth, (int)maxHeigth);
			Imgcanobaixo.TranslationY = Imgcanocima.TranslationY + MaxDuna + Imgcanobaixo.HeightRequest;
			// aqui são as variaveis que determinam a aleotRIEDADE em que os cABNos vão aparecer

			Score++;
			LabelScore.Text = "Canos: " + Score.ToString("D3");


			LabelFinalScore.Text = "Final Score:" + Score.ToString("D3");
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





