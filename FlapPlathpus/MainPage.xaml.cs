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

	const int MaxDuna = 200;
	// é a abertura entre os canos onde o passaro passa

	//---------------------------------------------------------------------------------------//

	public MainPage()
	{
		InitializeComponent();
	}

	//---------------------------------------------------------------------------------------//
	async Task Drawn()
	{
		while (!isDead)
		// !=não, enquanto não está morto aplica gravidade
		{
			if (IsFloating)
				FloatBird();
			else

			IntroGravity();
			//Aqui é a gravidade que a gente atribuiu lá em cima
			// que vai ser aplicada no passaro

			ManagerCan();
			//Colocando que enquanto o passaro não morreu 
			//aplica a move dos canos tambem

			GameStarded = true;
			// aqui diz que o jogo começou

			if (IsColliding())
			{
				isDead = true;

				GameStarded = false;

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
		(GameStarded)
		// essa condicional vai fazer com que só funcione 
		// o botão quando a frame game over for clicada

		{
			Imgperry.TranslationY -= PowerFloating;
			//Imgperry é o nome que eu coloquei no x name do passarinho
			// por enquanto é o pulo do passsaro
			TimeFloating++;
			if (TimeFloating >= MaxTimeFloating)
			{
				IsFloating = false;
				TimeFloating = 0;
			}
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
	void OnGameOverClicked(object sender, EventArgs e)
	{
		GameOverFrame.IsVisible = false;
		Initialize();
		Drawn();
		GameStarded = true;
		// aqui quando clicar no frame ele vai definir 
		// o jogo como começando oque possiblta ativar o pulo e clicked do passaro
	}

	//---------------------------------------------------------------------------------------//
    void GameOver()
	{
		if (isDead)
		{
			GameStarded = false;
		}
	}
	//---------------------------------------------------------------------------------------//
	bool IsColliding()
	{
		if (!isDead)
		{
			// Verifica se os elementos são válidos
			if (IsCollidingSky() ||
			IsCollidingHell())
			// aqui diz se colidir com o teto ||= ou com o chao
			// então retorna o atributo declarado em baixo 
			{
				return GameStarded = false;
			}
		}
		return GameStarded = true;
		// aqui é o metodo que é chamado tanto para colidingSky
		// quando colliding hell 
	}
	//---------------------------------------------------------------------------------------//

	bool IsCollidingSky()
	{
		var minY = -windowHeigth / 2;
		if (Imgperry.TranslationY <= -minY)
			return true;
		else
			return false;
	// aui é o metodo quando a altura do passaro chega ou ultrpassa
	// o ceu ou teto do jogo oque faz ele hamar Is coliding
	}
	//---------------------------------------------------------------------------------------//

	bool IsCollidingHell()
	{
		var maxY = windowHeigth / 2 - ImgChao.HeightRequest;
		if (Imgperry.TranslationY >= maxY)
			return true;
		else
			return false;
	
	// aqui a gente está criando o metodo toda vez que o passaro bater 
	// no chao oque significa que quando ele chegar retorna true e então chama
	// o metodo Is coloding
	
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

	void Initialize()
	{
		isDead = false;
		Imgperry.TranslationY = 0;
		GameStarded = true; 
		FloatBird();
		// qaundo o jogo reinicia ele é ativado como verdadeiro
	}

	//---------------------------------------------------------------------------------------//

	void ManagerCan()
	{
		Imgcanobaixo.TranslationX -= Fasty;
		Imgcanocima.TranslationX -= Fasty;
		// aqui a genta está pedindo para que os canos se movam horizontalmente
		// para a esquerda da janela 

		if
		 (Imgcanobaixo.TranslationX <= -windowWidth)
		// aqui é quando a tela acaba entã é redefinido a posiçaõ
		// fazendo o cano voltar no ponto X e refazer o processo
		{
			Imgcanobaixo.TranslationX = windowWidth;
			Imgcanocima.TranslationX = windowWidth;
			// aqui são as imagens com o atributo zerado
			var maxHeigth =-100;
			var minHeigth =-Imgcanobaixo.HeightRequest;
			// aqui são as variaveis que determinar a altura ou espaço
			// que o passaro pode passar alem de colocar o minimo
			Imgcanocima.TranslationY = Random.Shared.Next((int)minHeigth, (int)maxHeigth);
			Imgcanobaixo.TranslationY = Imgcanocima.TranslationY + MaxDuna + Imgcanobaixo.HeightRequest;
			// aqui são as variaveis que determinam a aleotRIEDADE em que os cABNos vão aparecer
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





