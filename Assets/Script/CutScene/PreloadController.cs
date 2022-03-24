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

    public float textRevealTimer;

    public string reaperText;

    public string approvalText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(triggerText(reaperText));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void submitPuzzleText()
    {
        print(puzzleText.text);
        if (puzzleText.text.Equals(approvalText))
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
        if (approvalText.Equals("opensezame"))
        {
            SceneManager.LoadScene("PlayScene");
        }
        else if (approvalText.Equals("PUZZLIUM4EVER1107"))
        {
            SceneManager.LoadScene("MidScene");
        }
        else if (approvalText.Equals("THEREALHEROISYOU"))
        {
            SceneManager.LoadScene("EndScene");
        }
        
    }
    
    IEnumerator triggerText(string text)
    {
        yield return new WaitForSeconds(textRevealTimer);
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

    public string puzzleLink;
    public void followPuzzleButton()
    {
        Application.OpenURL(puzzleLink);
        
    }
}
