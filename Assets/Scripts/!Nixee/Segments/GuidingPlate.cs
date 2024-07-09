using System;
using UnityEngine;

public class GuidingPlate : MonoBehaviour
{
    [Serializable]
    public class SegmentForPlate
    {
        [SerializeField] public MapSegment segment;
        [SerializeField] public int segmentID;
    }

    [SerializeField] private SegmentForPlate segmentForPlate;

    public void RevealSegment()
    {
        segmentForPlate.segment.OnSegmentRevealed?.Invoke(segmentForPlate.segmentID);
    }
}
