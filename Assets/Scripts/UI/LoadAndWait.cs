using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadAndWait : MonoBehaviour
{
    public CanvasGroup c;
    public GameObject mush;

    void Start()
    {
        mush.SetActive(false);
        StartCoroutine(Fade());
    }
    IEnumerator Fade()
    {
        for (float alpha = 1f; alpha >= -0.05f; alpha -= 0.05f)
        {
            c.alpha = alpha;
            yield return new WaitForSecondsRealtime(0.1f);
        }

        // once done, go to next scene
        SceneManager.LoadSceneAsync("World 1-1", LoadSceneMode.Single);
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        Debug.Log("Return to main menu");
    }

    public void OnPointerEnter()
    {
        mush.SetActive(true);
    }

    public void onPointerExit()
    {
        mush.SetActive(false);
    }
}

