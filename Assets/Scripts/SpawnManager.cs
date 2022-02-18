using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : GameManager
{
    private Rigidbody2D rbHoop;
    

    // Start is called before the first frame update
    void Start()
    {
        rbHoop = GameObject.Find("Hoop").GetComponent<Rigidbody2D>();
        base.SpawnHoop(rbHoop);
        StartCoroutine("WaitAndSpawn", timeSpawn);
    }

    private IEnumerator WaitAndSpawn(float time)
    {
        while (!GameManager.endGame)
        {
            yield return new WaitForSeconds(time);
            base.SpawnHoop(rbHoop);
        }
    }
}
