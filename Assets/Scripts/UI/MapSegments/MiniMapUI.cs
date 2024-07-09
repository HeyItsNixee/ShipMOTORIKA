using UnityEngine;
using UnityEngine.UI;

public class MiniMapUI : Singleton<MiniMapUI>
{
    [SerializeField] private MapSegmentUI[] UI_Segments;

    private void Start()
    {
        if (UI_Segments.Length <= 0)
        {
            Debug.LogWarning("There's no MapSegmentUI links in " + name);
            enabled = false;
            return;
        }
    }

    public void RevealSegment(int segmentID)
    {
        if (segmentID >= UI_Segments.Length || segmentID < 0)
            return;

        UI_Segments[segmentID].RevealSegment();
    }
}
