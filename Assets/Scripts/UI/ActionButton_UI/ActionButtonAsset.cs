using UnityEngine;

namespace ShipMotorika
{
    [CreateAssetMenu]
    public class ActionButtonAsset : ScriptableObject
    {        
        public Sprite Image;
        public Color Color;
        public string Text;
        public bool RaycastTarget;
    }
}