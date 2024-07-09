using UnityEngine;

public class MapController : Singleton<MapController>
{
    [SerializeField] private MapSegment[] segments;

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
    }


    public void RevealSegmentInMiniMap(int mapIndex)
    {
        MiniMapUI.Instance.RevealSegment(mapIndex);
    }
}
