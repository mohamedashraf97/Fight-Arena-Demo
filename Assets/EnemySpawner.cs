using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nextEnemy;
    public GameObject emitter;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnDestroy(){
     Instantiate(nextEnemy,emitter.transform.position,emitter.transform.rotation); // Assuming you are dropping the object exactly where the enemy died
     PlayerMovement.health+= 2;
     Debug.Log(PlayerMovement.health);
     }
}
