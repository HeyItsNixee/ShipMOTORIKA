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
    private bool isRevealed = false;

    public void RevealSegment()
    {
        int realID = segmentForPlate.segmentID - 1;
        isRevealed = true;
        Trigger.enabled = false;
        if (realID < 0)
        {
            Debug.LogWarning("realID is less than zero in " + name);
            return;
        }

        segmentForPlate.segment.OnSegmentRevealed?.Invoke(realID);
        PlayerController.Instance.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.gameObject == PlayerController.Instance.gameObject && !isRevealed)
        {
            Debug.Log(collision.name + " entered PlateTrigger: " + name);
            RevealSegment();
        }
    }
}
