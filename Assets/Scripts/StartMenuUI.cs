using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{
    public CanvasGroup ggjLogo;
    public float fadeOutTime = 10.0f;

    void Awake()
    {
        //ggjLogo = GetComponent<CanvasGroup>();
        if(ggjLogo == null)
        {
            Debug.Log ("where is she?");
        }
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float startAlpha = ggjLogo.alpha;
        float timer = 0f;

        while (timer < fadeOutTime)
        {
            timer += Time.deltaTime;
            ggjLogo.alpha = Mathf.Lerp(startAlpha, 0f, timer / fadeOutTime);
            yield return null;
        }

        ggjLogo.alpha = 0f;
        gameObject.SetActive(false);
    }

    // public void FadeIn()
    // {
    //     StartCoroutine(FadeInCoroutine());
    // }
    
    // public IEneumerator FadeInCoroutine()
    // {
    //     float startAlpha = canvasGroup.alpha;
    //     float timer = 0f;

    //     while (timer < fadeOutTime)
    //     {
    //         timer += timer.deltaTime;
    //         canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, timer / fadeOutTime);
    //         yield return null;
    //     }

    //     canvasGroup.alpha = 0f;
    //     gameObject.SetActive(false);
    // }

    void Start()
    {
        FadeOut();
    }

    public void OnStartButton()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
