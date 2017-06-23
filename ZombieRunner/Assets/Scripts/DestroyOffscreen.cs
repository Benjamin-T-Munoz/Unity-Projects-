using UnityEngine;
using System.Collections;

public class DestroyOffscreen : MonoBehaviour {

    public float offset = 16f; // How far off screen

    public delegate void OnDestroy();
    public event OnDestroy DestroyCallback;

    private bool offscreen;
    private float offscreenX = 0;// actual location of off screen
    private Rigidbody2D body2d;

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        offscreenX = (((Screen.width / PixelPerfectCamera.pixlesToUnits)/2)+offset); // gives us the actual width of the screen divided in half and adds the offset. 

	
	}
	
	// Update is called once per frame
	void Update () {

        var posx = transform.position.x;//current position of object
        var dirX = body2d.velocity.x;// current rotation of object
        
        if(Mathf.Abs(posx)>offscreenX)
        {
            if (dirX < 0 && posx < -offscreenX)
            {
                offscreen = true;// if object is to the 
            }
            
            else if(dirX > 0 && posx > offscreenX)
            {
                offscreen = true;
            }

            else
            {
                offscreen = false;
            }


        }

        if (offscreen)
        {
            OnOutOfBounds();
        }
	
	}

     void OnOutOfBounds()
    {
        offscreen = false;
        GameObjectUtil.Destroy(gameObject);

        if (DestroyCallback != null)
        {
            DestroyCallback();
        }
    }
}
