using UnityEngine;
using UnityEngine.UIElements;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ShipMotorika
{
    /// <summary>
    /// Универсальный скрипт дл¤ визуализации окружности нужного радиуса и цвета.
    /// </summary>
    public sealed class CircleArea : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private Color _color;

        public float Radius => _radius;

        public Vector2 GetRandomInsideZone()
        {
            return (Vector2)transform.position + (Vector2)Random.insideUnitSphere * _radius;
        }

        public void TrySetRadius(float radius)
        {
            if (radius >= 0)
            {
                _radius = radius;
            }            
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Handles.color = _color;
            Handles.DrawSolidDisc(transform.position, transform.forward, _radius);
        }
#endif
    }
}