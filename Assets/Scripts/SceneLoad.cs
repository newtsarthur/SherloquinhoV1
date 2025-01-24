using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] private CanvasGroup loadingOverlay;
    [SerializeField]
    [Range(0.01f, 3f)]
    private float fadeTime = 0.5f;

    public static SceneLoad Instance {get; private set;}
    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(PerformLoadSceneAsync(sceneName));
    }

    private IEnumerator PerformLoadSceneAsync(string sceneName)
    {

        yield return StartCoroutine(FadeIn());

        var operation = SceneManager.LoadSceneAsync(sceneName);
        while(operation.isDone == false)
        {
            yield return null;
        }

        yield return StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        float start = 0;
        float end = 1;
        // ds/dt (end - start)/fadeTime
        float speed = (end - start) / fadeTime;

        loadingOverlay.alpha = start;

        while(loadingOverlay.alpha < end)
        {
            loadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }
        loadingOverlay.alpha = end;
    }
    private IEnumerator FadeOut()
    {
        float start = 1;
        float end = 0;
        // ds/dt (end - start)/fadeTime
        float speed = (end - start) / fadeTime;

        loadingOverlay.alpha = start;


        while(loadingOverlay.alpha > end)
        {
            loadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }
        loadingOverlay.alpha = end;
    }
}
