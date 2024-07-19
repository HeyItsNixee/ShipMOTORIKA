using ShipMotorika;
using UnityEngine;

public class DialogInputController : MonoBehaviour
{
    private void Update()
    {
        PlayerController.Instance.DisableControl();
    }
}
