using System.Collections;
using System.Collections.Generic;
using MalbersAnimations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeSlower : MonoBehaviour
{
    public bool shouldTriggerFlame;
    public GameObject dragonFlame;
    public GameObject sceneChanger;
    public GameObject characterPointLight;
    private void OnTriggerEnter(Collider collision)
    {
        
        var hit = collision.gameObject;
        if (hit.CompareTag("Player"))
        {
            StartCoroutine(bendTime(0.3f));
            if (shouldTriggerFlame)
            {
                dragonFlame.SetActive(true);
                StartCoroutine(sceneChangerTrigger());
                characterPointLight.SetActive(true);
            }
        }

        
        
    }

    IEnumerator bendTime(float timer)
    {
        Time.timeScale = timer;
        yield return new WaitForSeconds(2.0f/2);
        Time.timeScale = 1.0f;
    }

    IEnumerator sceneChangerTrigger()
    {
        yield return new WaitForSeconds(0.8f);
        sceneChanger.SetActive(true);
        StartCoroutine(changeSceneToPreloadTwo());
    }

    IEnumerator changeSceneToPreloadTwo()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("SecondDoor");
    }
}
