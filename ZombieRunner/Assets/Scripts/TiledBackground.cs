using UnityEngine;
using System.Collections;

public class TiledBackground : MonoBehaviour {
    public int texutreSize = 32;// The Native Size of the texture given

    public bool scaleHoriz = true;// Can this be scaled horizontaly?
    public bool scaleVert = true;// Can This be Scaled vertically?
	
	void Start () { //Used to dynamically resize the background material

        var newWidth = !scaleHoriz ? 1 :Mathf.Ceil(Screen.width /(texutreSize * PixelPerfectCamera.scale));// The number of tiles that make up the screen's width
        var newHeight =!scaleVert ? 1 : Mathf.Ceil(Screen.height / (texutreSize * PixelPerfectCamera.scale));// The number of tiles that make up the screen's Height

        transform.localScale = new Vector3(newWidth * texutreSize, newHeight*texutreSize ,1);// Width and Height are Mult. by texture size to set them to right scale

        GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth, newHeight, 1);
    }


}
