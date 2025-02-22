using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : PersistentSingleton<LoadingSceneManager>
{
    [SerializeField] protected GameObject goLoadingScene;
    [SerializeField] protected Slider sliderLoadingScene;
    [SerializeField] protected float delayLoadScene = 0.2f;


    private void Start()
    {
        SwichToScene(1);
    }
    public void SwichToScene(int id)
    {
        StartSwichToScene();
        StartCoroutine(SwichToSceneAsyc(SceneManager.LoadSceneAsync(id)));
    }

    public void SwichToScene(string id)
    {
        StartSwichToScene();
        StartCoroutine(SwichToSceneAsyc(SceneManager.LoadSceneAsync(id)));
    }

    public void SwitchToSceneGame(string sceneName) {
        StartSwichToScene();
        StartCoroutine(SwichToSceneAsyc(SceneManager.LoadSceneAsync(sceneName)));
        SceneManager.LoadScene("UIGameScene",LoadSceneMode.Additive);
    }

    private void StartSwichToScene() {
        goLoadingScene.SetActive(true);
        sliderLoadingScene.value = 0;
    }

    IEnumerator SwichToSceneAsyc(AsyncOperation aysncLoad)
    {
        while (!aysncLoad.isDone)
        {
            sliderLoadingScene.value = aysncLoad.progress;
            yield return null;
        }
        yield return new WaitForSeconds(delayLoadScene);
        goLoadingScene.SetActive(false);
    }

}
