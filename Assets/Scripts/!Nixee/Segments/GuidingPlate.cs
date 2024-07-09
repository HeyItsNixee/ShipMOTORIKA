using ShipMotorika;
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
    [SerializeField] private Collider2D Trigger;

    public void RevealSegment()
    {
        segmentForPlate.segment.OnSegmentRevealed?.Invoke(segmentForPlate.segmentID);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.gameObject == PlayerController.Instance.gameObject)
        {
            RevealSegment();
            Trigger.enabled = false;
        }
    }
}
