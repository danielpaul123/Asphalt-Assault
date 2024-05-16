using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.CompareTag("Player"))
       {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            player.TakeDamage(0.05f);
       }
    }
    
}
