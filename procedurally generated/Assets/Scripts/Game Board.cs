using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Tiles
{
    Floor,Wall,Crowd,Door,
}

public class GameBoard : MonoBehaviour {

    public int numberOfRooms;

    public int roomHeight = 11;// Height of the room
    public int roomWidth = 11;// Width of the room

    public int boardHeight = 1000; // Height of the board
    public int boardWidth = 1000;// Width of the board
    
    public Room[][] Board;
    public GameObject boardHolder;
    
     

    // Use this for initialization
    void Start () {

        boardHolder = new GameObject("BoardHolder");

        populateBoard();

        
        

    }

    void populateBoard()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
