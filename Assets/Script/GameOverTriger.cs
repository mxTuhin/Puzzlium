using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTriger : MonoBehaviour
{
    public GameObject gameCompleteCanvas;
    private void OnTriggerEnter(Collider collision)
    {
        
        var hit = collision.gameObject;
        if (hit.CompareTag("Player"))
        {
            gameCompleteCanvas.SetActive(true);
        }
        
        
    }
}
