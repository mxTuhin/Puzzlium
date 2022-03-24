using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
    public GameObject sceneChanger;
    private void OnTriggerEnter(Collider collision)
    {
        
        var hit = collision.gameObject;
        if (hit.CompareTag("Player"))
        {
            StartCoroutine(sceneChangerTrigger());
        }
    }
    
    IEnumerator sceneChangerTrigger()
    {
        yield return new WaitForSeconds(0.3f);
        sceneChanger.SetActive(true);
        StartCoroutine(changeSceneToPreloadTwo());
    }

    IEnumerator changeSceneToPreloadTwo()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("ThirdDoor");
    }
}
