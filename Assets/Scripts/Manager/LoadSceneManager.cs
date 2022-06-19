using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField]private GameObject loadingScene;
    [SerializeField]private Slider slider;
    public Transform startPos;
    public Transform endPos;

    public static LoadSceneManager instance;

    void Awake()
    {
        instance=this;
    }

    public IEnumerator LoadAsync(int _index)
    {
        AsyncOperation operation=SceneManager.LoadSceneAsync(_index);
        loadingScene.SetActive(true);
        while(!operation.isDone)
        {
            float progress=Mathf.Clamp01(operation.progress/0.9f);
            slider.value=progress;
            yield return null;
        }
    }
}
