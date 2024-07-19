using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : Singleton<CutSceneManager>
{
    [SerializeField] private CutSceneTeller[] cutscenes;
    private int currentCutsceneID = 0;

    private void Start()
    {
        for (int i = 0; i < cutscenes.Length; i++)
            cutscenes[i].gameObject.SetActive(false);
    }

    public void CutSceneWatched()
    {
        cutscenes[currentCutsceneID].gameObject.SetActive(false);
        currentCutsceneID++;
        StoryManager.Instance.OnQuestCompleted();
    }

    public void ShowCutScene()
    {
        for (int i = 0; i < cutscenes.Length; i++)
            cutscenes[i].gameObject.SetActive(false);

        if (currentCutsceneID >= cutscenes.Length)
            return;
        else
            cutscenes[currentCutsceneID].gameObject.SetActive(true);
    }
}
