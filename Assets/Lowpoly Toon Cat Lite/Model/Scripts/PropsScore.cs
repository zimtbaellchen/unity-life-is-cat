using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsScore : MonoBehaviour
{




   
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plattform")) // Überprüfen Sie, ob das GameObject mit einem anderen GameObject kollidiert ist
        {
            // Das GameObject zerstören
            Destroy(gameObject);
            GameManager.instance.score += 1;
           
        }
    }
    




  
}

