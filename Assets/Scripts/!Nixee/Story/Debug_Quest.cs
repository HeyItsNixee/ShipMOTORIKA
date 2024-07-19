using ShipMotorika;
using UnityEngine;

public class Debug_Quest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.H))
            Player.Instance.Money.TryChangeMoneyAmount(10);
    }
}
