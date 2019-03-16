using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugadores : MonoBehaviour 
{
	private int size;
	private List <Player> players;

    public Jugadores (int size)
	{
		this.size=size;
		players= new List<Player>();
	}


    public void addListPlayer(Player player)
	{	

		if(players.Count<size)
		{
			players.Add(player);
			player.id=players.Count;
		}
	}

	public List<Player> getJugaddores(){return players;}

	public bool nameExists(Player player)
	{
		bool exists=false;

		for (int i = 0; i < players.Count; i++)
		{
			if(players[i].name.Equals(player.name))
			{
				exists=true;
			}
			else{exists=false;}
		}

		return exists;
	}

	public bool isEmpty()
	{
		return players.Count!=0?false:true;
	}

	public bool minPlayersToPLay(int cant)
	{
		return players.Count>=cant?true:false;
	}
}
