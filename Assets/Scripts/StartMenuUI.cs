using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{
    [SerializeField] private AudioClip thunder_quit;
    public bool quittersTalk = false;
    public float quitTimer = 0f;

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
        SoundFXManager.instance.PlaySoundFXClip(thunder_quit, transform, 1f);
        quittersTalk = true;
        quitTimer = 0;
    }

    void Update()
    {
        quitTimer += Time.deltaTime;
        if (quitTimer >= 2 && quittersTalk == true)
        {
            Application.Quit();
            Debug.Log ("quit");
        }
    }
}
