using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

   public GameObject playerPrefab;// player prefab

   private GameObject player;
   private GameObject floor;// floor game object
   private Spawner spawner;// spawner script
   private TimeManager timeManager;// used to manipulate time
    private bool gameStarted;
    void Awake()
    {
        floor = GameObject.Find("ForeGround");
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        timeManager = GetComponent<TimeManager>();
    }



	// Use this for initialization
	void Start () {
        var floorHeight = transform.localScale.y;
        var pos = floor.transform.position;
        pos.x = 0;
        pos.y = -((Screen.height / PixelPerfectCamera.pixlesToUnits) / 2) + (floorHeight / 2);
        floor.transform.position = pos;// sets floor to bottom of screen

        spawner.active=false;// turns off spawner at the begining of the game 

        Time.timeScale = 0;
	}
	
	
	void Update () {

        if (!gameStarted && Time.timeScale == 0)
        {
            if(Input.anyKeyDown)                                    // Key Down
            {
                timeManager.ManipulateTime(1,1f);

                ResetGame();
            }
        }
	
	}

    void OnPlayerKilled()
    {
        spawner.active = false;

        var playerDestroyScript = player.GetComponent<DestroyOffscreen>();
        playerDestroyScript.DestroyCallback -= OnPlayerKilled;

        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        timeManager.ManipulateTime(0, 5.5f);
        gameStarted = false;
    }

    void ResetGame()
    {
        spawner.active = true;
        player = GameObjectUtil.Instantiate(playerPrefab, new Vector3(0, (Screen.height / PixelPerfectCamera.pixlesToUnits / 2 +100), 0));

        var playerDestroyScript = player.GetComponent<DestroyOffscreen>();
        playerDestroyScript.DestroyCallback += OnPlayerKilled;

        gameStarted = true;
    }

}
