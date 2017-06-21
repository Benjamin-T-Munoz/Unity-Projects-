using UnityEngine;
using System.Collections;

public class AnimatedTexture : MonoBehaviour {

    public Vector2 speed = Vector2.zero;// speed of scrolling animation
    private Vector2 offset = Vector2.zero;// offset place holder
    private Material material;// mateial place holder


	// Use this for initialization
	void Start () {

        material = GetComponent<Renderer>().material;// gets reffrence to material attached to quad

        offset = material.GetTextureOffset("_MainTex");// initializes the offset
	
	}
	
	// Update is called once per frame
	void Update () {

        offset += (speed * Time.deltaTime); // increments the offset

        material.SetTextureOffset("_MainTex", offset);// sets the offset
	
	}
}
