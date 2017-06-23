using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] prefabs;// group of obstecals to spawn
    public float delay = 2.0f;
    public bool active = true;
    public Vector2 delayrange=new Vector2(1,2);



	void Start () {
        ResetDelay();
        StartCoroutine(EnemyGenerator());
	}

    IEnumerator EnemyGenerator()
    {
        yield return new WaitForSeconds(delay);// delays the method until after the set delay time.

        if (active)
        {
            var newTransform = transform;


           GameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position);// creates an obstacle at the target location
            ResetDelay();
        }

        StartCoroutine(EnemyGenerator());

    }
	
    void ResetDelay()// adds variety to obstecal spawnning 
    {
        delay = Random.Range(delayrange.x, delayrange.y);// Resets The Delay Range
    }
	
}
