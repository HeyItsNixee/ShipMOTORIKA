using ShipMotorika;
using UnityEngine;

public class IconLookAtPlayer : MonoBehaviour
{
    [SerializeField] private int offset = 106;
    private void Update()
    {
        Vector3 Look = transform.InverseTransformPoint(Player.Instance.Ship.transform.position);
        float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg + offset;

        transform.Rotate(0f, 0f, Angle);
    }
}
