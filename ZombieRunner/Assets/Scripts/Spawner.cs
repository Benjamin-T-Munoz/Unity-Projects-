using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] prefabs;// group of obstecals to spawn
    public float delay = 2.0f;
    public bool active = true;


	// Use this for initialization
	void Start () {

        StartCoroutine(EnemyGenerator());
	}

    IEnumerator EnemyGenerator()
    {
        yield return new WaitForSeconds(delay);// delays the method until after the set delay time.

        if (active)
        {
            var newTransform = transform;


            Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position, Quaternion.identity);// creates an obstacle at the target location
        }

        StartCoroutine(EnemyGenerator());

    }
	
	
}
