using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour, IRecycle {

    public Sprite[] sprites;

    public Vector2 colliderOffset=Vector2.zero;


	public void Restart()
    {
        var renderer = GetComponent<SpriteRenderer>();

        renderer.sprite = sprites[Random.Range(0, sprites.Length)]; //changes the sprite 

        var collider = GetComponent<BoxCollider2D>();// gets refrence to collider
        var size = renderer.bounds.size;// changes the collider size

        size.y += colliderOffset.y;

        collider.size =size;
        collider.offset=new Vector2(-colliderOffset.x, collider.size.y/2 - colliderOffset.y); // manually overides offset for each colider

    }

    public void Shutdown()
    {

    }
	
}
