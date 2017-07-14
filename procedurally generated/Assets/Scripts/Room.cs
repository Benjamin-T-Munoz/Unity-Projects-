using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    North, East, South, West,
}

public class Room : MonoBehaviour {

  private  Tiles[][] tiles;
    private int exitX = 0;
    private int exitY = 0;
    private int enterX = 0;
    private int enterY = 0;

    public void SetupRoom(int width, int height, int columns, int row, Direction exit)
    {
        tiles = new Tiles[width][];

        // Go through all the tile arrays...
        for (int i = 0; i < tiles.Length; i++)
        {
            // ... and set each tile array is the correct number of rows.
            tiles[i] = new Tiles[height];
        }


        switch (exit)
        {
            case Direction.North:
                exitX= width/2;
                exitY = height-1;                 
                break;
            case Direction.East:
                exitX = width -1;
                exitY = height/2;
                break;

            case Direction.South:
                exitX = width /2;
                exitY = 0;
                break;

            case Direction.West:
                exitX = 0;
                exitY = height / 2;
                break;
        }

        for (int j = 0; j < tiles.Length; j++)
        {
            for (int k = 0; k < tiles.Length; k++)
            {

                if(j==exitX && k==exitY )
                {
                    tiles[j][k] = Tiles.Door;
                }

               else if(j==0||j==width-1)
                {
                    tiles[j][k] = Tiles.Wall;
                }

                else if (k == 0 || k == height - 1)
                {
                    tiles[j][k] = Tiles.Wall;
                }

                else
                {
                    tiles[j][k] = Tiles.Floor;
                }

            }
        }


    }

    public void SetupRoom(int width, int height, int columns, int rows, Direction enterance, Direction exit)
    {

        tiles = new Tiles[width][];

        // Go through all the tile arrays...
        for (int i = 0; i < tiles.Length; i++)
        {
            // ... and set each tile array is the correct number of rows.
            tiles[i] = new Tiles[height];
        }


        switch (exit)
        {
            case Direction.North:
                exitX = width / 2;
                exitY = height - 1;
                break;
            case Direction.East:
                exitX = width - 1;
                exitY = height / 2;
                break;

            case Direction.South:
                exitX = width / 2;
                exitY = 0;
                break;

            case Direction.West:
                exitX = 0;
                exitY = height / 2;
                break;
        }

        switch (enterance)
        {
            case Direction.North:
                enterX = width / 2;
                enterY = height - 1;
                break;
            case Direction.East:
                enterX = width - 1;
                enterY = height / 2;
                break;

            case Direction.South:
                enterX = width / 2;
                enterY = 0;
                break;

            case Direction.West:
                enterX = 0;
                enterY = height / 2;
                break;
        }

        for (int j = 0; j < tiles.Length; j++)
        {
            for (int k = 0; k < tiles.Length; k++)
            {

                if (j == exitX && k == exitY) // checks to see if the tile is on the exit
                {
                    tiles[j][k] = Tiles.Door;
                }

                else if (j == enterX && k == enterY) // checks to see if the tile is on the entrance
                {
                    tiles[j][k] = Tiles.Door;
                }

                else if (j == 0 || j == width - 1) // Top or bottom of the array
                {
                    tiles[j][k] = Tiles.Wall;
                }

                else if (k == 0 || k == height - 1) // Left or right of the the array
                {
                    tiles[j][k] = Tiles.Wall;
                }

                else
                {
                    tiles[j][k] = Tiles.Floor;
                }

            }
        }


    }

}
	// Update is called once per frame
	void Update () {
		
	}
}
