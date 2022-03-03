using System.Collections;
using System.Collections.Generic;
using Lightbug.CharacterControllerPro.Implementation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreloadController : MonoBehaviour
{
    public InputField puzzleText;

    public Animator gateAnimator;

    public GameObject cutSceneCanvas;

    public Text notifier;

    public GameObject gameRunCanvas;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(triggerText(
            "Reaper: Hello. Little Filthy Human. How Dare you come here. You can never pass the course of puzzlium. " +
            "Prove your worth. Click the button on bottom left, solve the puzzle and submit what you have found there"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void submitPuzzleText()
    {
        print(puzzleText.text);
        if (puzzleText.text.Equals("opensezame"))
        {
            
            cutSceneCanvas.SetActive(false);
            gateAnimator.SetTrigger("shouldOpen");
            StartCoroutine(gameRunCanvasTrigger());
        }
    }

    IEnumerator gameRunCanvasTrigger()
    {
        yield return new WaitForSeconds(2.0f);
        gameRunCanvas.SetActive(true);
        StartCoroutine(changeScene());
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("PlayScene");
    }
    
    IEnumerator triggerText(string text)
    {
        yield return new WaitForSeconds(5.5f);
        cutSceneCanvas.SetActive(true);
        StartCoroutine(textRevealer(text));
    }

    IEnumerator textRevealer(string text)
    {
        for (int i = 0; i < text.Length; ++i)
        {
            yield return new WaitForSeconds(Random.Range(0.001f,0.005f));
            notifier.text += text[i];
        }
    }

    public void followPuzzleButton()
    {
        Application.OpenURL("https://dinohandwatch.com");
    }
}
