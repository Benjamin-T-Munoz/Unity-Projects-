using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    public float jumpSpeed = 240f;// Jump Speed 
    public float forawdSpeed = 20f;

    private Rigidbody2D body2d; // Refrence to Rigidbody 2d on game object
     
    private InputState inputState; // Refrence to input state.


    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
        inputState = GetComponent<InputState>();
    }

	void Update ()
    {
	
        if(inputState.standing)
        {
            if(inputState.actionButton)
            {
                
                body2d.velocity = new Vector2(transform.position.x < 0? forawdSpeed: 0, jumpSpeed);
            }
        }

	}
}
