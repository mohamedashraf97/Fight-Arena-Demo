using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    
    public Slider healthBar ;
    public static GameObject hp;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = 20 ;
        hp = GameObject.FindGameObjectWithTag("HealthBar");
        hp.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = EnemyBoss.bossHealth;
    }
}
