using UnityEngine;
using System.Collections;

public class InputState : MonoBehaviour {
    public bool actionButton;// Jump Button
    public float absVelX = 0;// Value of X velocity
    public float absVelY = 0;// Value of Y velocity
    public bool standing; // is standing? 
    public float standingThreshold = 1.0f; // standing Thresh Hold 

    private Rigidbody2D body2d;

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }
	
	void Update () {

        actionButton = Input.anyKeyDown;
	
	}

    void FixedUpdate()
    {
        absVelX=System.Math.Abs(body2d.velocity.x);
        absVelY= System.Math.Abs(body2d.velocity.y);
        standing = absVelY <= standingThreshold;
    }
}
