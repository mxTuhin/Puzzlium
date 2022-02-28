using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;
    void Start()
    {
        StartCoroutine(changeScene());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(sceneName);
    }
}
