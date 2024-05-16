using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBUllet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Damage");
            EnemyHealth player = other.GetComponent<EnemyHealth>();
            player.TakeDamage(10);
        }
    }
}
