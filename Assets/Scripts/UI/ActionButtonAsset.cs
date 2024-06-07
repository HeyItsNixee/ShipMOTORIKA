using UnityEngine;

namespace ShipMotorika
{
    /// <summary>
    /// Заготовки под разный визуал ActionButton.
    /// </summary>
    [CreateAssetMenu]
    public class ActionButtonAsset : ScriptableObject
    {        
        public Sprite Image;
        public Color Color;
        public string Text;
        public bool RaycastTarget;
    }
}