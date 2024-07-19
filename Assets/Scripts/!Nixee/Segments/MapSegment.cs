using System;
using UnityEngine;
using UnityEngine.UI;

public class MapSegment : MonoBehaviour
{
    public Action<int> OnSegmentRevealed;
    public bool isRevealed = false;
}
