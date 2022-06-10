using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Vector3 playerPosition;

    public GameObject gameChangeCanvas;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerReload()
    {
        gameChangeCanvas.SetActive(true);
        StartCoroutine(reloadGame());
    }

    IEnumerator reloadGame()
    {
        yield return new WaitForSeconds(3.5f);
        reloadGameInstant();
    }

    public void reloadGameInstant()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
