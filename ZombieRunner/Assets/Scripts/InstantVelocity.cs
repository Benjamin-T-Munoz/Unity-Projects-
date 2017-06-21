using UnityEngine;
using System.Collections;

public class InstantVelocity : MonoBehaviour {

    public Vector2 velocity = Vector2.zero;// Velocity of Object

    private Rigidbody2D body2d;// refrence to the 2d rigidbody

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();// gets refrence to rigid body
    }

    void FixedUpdate()
    {
        body2d.velocity = velocity;// sets rigidbody's velocity to that of the provided velocity
    }
}
