using ShipMotorika;
using UnityEngine;

public class DialogInputController : MonoBehaviour
{
    private void Start()
    {
        PlayerController.Instance.DisableControl();
    }
}
