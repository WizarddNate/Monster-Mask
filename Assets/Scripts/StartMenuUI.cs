using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{
    [SerializeField] private AudioClip thunder_quit;
    [SerializeField] private AudioClip[] startGameClips;
    public bool quittersTalk = false;
    public float quitTimer = 0f;

    public CanvasGroup ggjLogo;
    public float fadeOutTime = 10.0f;

    public float startTimer = 0f;
    public bool letsGo = false;


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
        //gameObject.SetActive(false);
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
        SoundFXManager.instance.PlayRandomSoundFXClip(startGameClips, transform, 1f);
        letsGo = true;
        startTimer = 0;
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
        if (quitTimer >= 1.8 && quittersTalk == true)
        {
            Application.Quit();
            Debug.Log ("quit");
        }

        startTimer += Time.deltaTime; 
        if (startTimer >= 1 && letsGo == true)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
