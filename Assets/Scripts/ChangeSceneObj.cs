using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneObj : MonoBehaviour
{
    [SerializeField]private bool toNextScene;
    [SerializeField]private int questInt=0;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag!="Player")
            return;
        NPC_Dialogue playerQuest=other.GetComponent<NPC_Dialogue>();
        if(playerQuest.questBoard.cur_Quest<questInt)
            return;
        PlayerChangeScene scr=other.GetComponent<PlayerChangeScene>();
        scr.SaveData();
        scr.cur_PlayerData.save_isNextScene=toNextScene;
        if(toNextScene)
        {
            scr.cur_PlayerData.save_CurSceneIndex++;
            StartCoroutine(LoadSceneManager.instance.LoadAsync(SceneManager.GetActiveScene().buildIndex+1));
        }
        else
        {
            scr.cur_PlayerData.save_CurSceneIndex--;
            StartCoroutine(LoadSceneManager.instance.LoadAsync(SceneManager.GetActiveScene().buildIndex-1));
        }
    }
}
