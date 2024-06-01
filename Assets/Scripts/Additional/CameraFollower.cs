using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform followTarget;

    private void FixedUpdate()
    {
        transform.position = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
        transform.rotation = followTarget.rotation;
    }
}
