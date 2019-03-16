using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePlayers : MonoBehaviour {

	public int size; 
	public Text players1;
	public Text players2;
	public Text players3;
	public Text aviso;
	public int minPlayers;
	public Button buttonStart;
	public InputField inputField;

	private ScreenManager screenManager;
	public static Jugadores jugadores;

	// Use this for initialization
	void Start () 
	{
		screenManager= new ScreenManager();
		jugadores= new Jugadores(size);	
		
		//Dejamos todos el contenido de los textos a cero 
		aviso.text=""; players1.text="";players2.text="";players3.text="";
	}

	void Update()
	{
	

	}

	//-------------------------------------------------------------------
    // METHODS
    //-------------------------------------------------------------------
	public void addPlayer()
	{
		//mantenemos la pantalla abierta
		
		TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);

		aviso.text="";

		Player player = new Player();
		player.name=inputField.text;

		//Comprobamos si el nombre esta vacio
		if(player.name=="")
		{
			aviso.text="Nombre vacio";
		}
		//comprobamos si el nombre es repetido
		else if(!jugadores.nameExists(player) && player.name!="")
		{
			jugadores.addListPlayer(player);

			int currentSize= jugadores.getJugaddores().Count;

			//Mostramos los jugadores que se han agregado al juego.
			//5 para cada cuadro
			if(currentSize<=5)
			{
				players1.text+=player.id+". "+player.name+"\r\n";
			}
			else if(currentSize<=10)
			{
				players2.text+=player.id+". "+player.name+"\r\n";
			}
			else if(currentSize<size)
			{
				players3.text+=player.id+". "+player.name+"\r\n";
			} 
			else
			{
				players3.text+=player.id+". "+player.name+"\r\n";
				aviso.text="Lista completa";
			}
			
		}
		else if(jugadores.nameExists(player) && player.name!="")
		{
			aviso.text="Nombre repetido";
		}

		inputField.text="";

	}

	public void startRuleta(Animator anim)
	{
		//Si no ha agregado algun usuario no pasa a la siguiente pantalla
		if(jugadores.minPlayersToPLay(minPlayers))
		{
			screenManager.OpenPanel(anim);
		}
		else
		{
			aviso.text= "El mímino de jugadores es: "+minPlayers;
		}
	}
}
