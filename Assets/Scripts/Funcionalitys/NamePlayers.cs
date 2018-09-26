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

	private InputField inputField;
	private Jugadores jugadores;
	// Use this for initialization
	void Start () 
	{
		jugadores= new Jugadores(size);	
		inputField= GetComponent<InputField>();
	}
	public void addPlayer()
	{
		aviso.text="";

		Player player = new Player();
		player.name=inputField.text;

		//comprobamos si el nombre es repetido
		if(!jugadores.nameExists(player))
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
				aviso.text="Lista Completa";
			}
			
		}
		else{
			aviso.text="Nombre Repetido";
		}

		inputField.text="";

	}
}
