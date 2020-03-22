using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy1;

    public GameObject emitter;


    void Start()
    {
       GameObject obj = Instantiate(enemy1, emitter.transform.position, emitter.transform.rotation) as GameObject;
    }

}
