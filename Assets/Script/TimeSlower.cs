using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlower : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        
        var hit = collision.gameObject;
        if (hit.CompareTag("Player"))
        {
            StartCoroutine(bendTime(0.3f));
        }
        
    }

    IEnumerator bendTime(float timer)
    {
        Time.timeScale = timer;
        yield return new WaitForSeconds(2.0f/2);
        Time.timeScale = 1.0f;
    }
}
