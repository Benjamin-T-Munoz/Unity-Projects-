using UnityEngine;
using System.Collections;

public class PixelPerfectCamera : MonoBehaviour {

    public static float pixlesToUnits = 1f;// Ratio of Pixles to number of units 
    public static float scale = 1f;
    public Vector2 nativeReselution = new Vector2(240, 160); //Intended Resolution

	void Awake () {

        var camera = GetComponent<Camera>();

        if(camera.orthographic)
        {
            scale = Screen.height / nativeReselution.y;// Scale is equal to the screen's height divided by the Native Resolution's height
            pixlesToUnits += scale;// Used to set a refrence point for resolution changes

            camera.orthographicSize = (Screen.height / 2.0f) / pixlesToUnits;//Changing the size of orthagraphic camera
        }
	
	}
	

}
