using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup screenOverlay;
    [SerializeField] private float fadeSpeed = 2;
    [SerializeField] private GameObject raceOverPanel;
    [SerializeField] private int nextLevelIndex = 1;

    void Start()
    {
        screenOverlay.gameObject.SetActive(true);
        StartCoroutine(FadeOutOverlay());
        raceOverPanel.SetActive(false);
    }
    private void OnEnable()
    {
        FinishGate.FinishRace += OnRaceFinished;
    }
    private void OnDisable()
    {
        FinishGate.FinishRace -= OnRaceFinished;
    }
    private void OnRaceFinished()
    {
        raceOverPanel.SetActive(true);
    }

    private IEnumerator FadeOutOverlay()
    {
        while(screenOverlay.alpha > 0)
        {
            screenOverlay.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
    private IEnumerator FadeInOverlay()
    {
        while (screenOverlay.alpha < 1)
        {
            screenOverlay.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
    public void Restart()
    {
        StartCoroutine(RestartCoroutine());
    }

    private IEnumerator RestartCoroutine()
    {
        yield return StartCoroutine(FadeInOverlay());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
    }

    private IEnumerator NextLevelCoroutine()
    {
        yield return StartCoroutine(FadeInOverlay());
        SceneManager.LoadScene(nextLevelIndex);
    }
    public void Quit()
    {
        StartCoroutine(QuitCoroutine());
    }

    private IEnumerator QuitCoroutine()
    {
        yield return StartCoroutine(QuitCoroutine());
        Application.Quit();
    }
}
