using UnityEngine;

public class MapController : Singleton<MapController>
{
    [SerializeField] private MapSegment[] segments;
    private int segmentsRevealed;
    private void Start()
    {
        if (segments.Length <= 0)
        {
            Debug.LogWarning("There's no links on segments in " + name);
            enabled = false;
            return;
        }

        for (int i = 0; i < segments.Length; i++)
            segments[i].OnSegmentRevealed += RevealSegmentInMiniMap;

        UpdateRevealedSegmentsCounter();
    }


    public void RevealSegmentInMiniMap(int mapIndex)
    {
        MiniMapUI.Instance.RevealSegment(mapIndex);
        segments[mapIndex].isRevealed = true;

        UpdateRevealedSegmentsCounter();
    }

    private void UpdateRevealedSegmentsCounter()
    {
        int counter = 0;
        for (int i = 0; i < segments.Length; i++)
        {
            if (segments[i].isRevealed)
                counter++;
        }

        segmentsRevealed = counter;

        if (segmentsRevealed >= segments.Length && StoryManager.Instance.CurrentQuest.Type == Quest.QuestType.RevealAllMapSegments)
        {
            CutSceneManager.Instance.ShowCutScene();
            StoryManager.Instance.OnQuestCompleted();
        }
    }
}
