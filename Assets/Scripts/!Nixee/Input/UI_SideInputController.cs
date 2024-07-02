using UnityEngine;
using ShipMotorika;
using UnityEngine.EventSystems;

public class UI_SideInputController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private InputType type;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (type == InputType.Left)
            PlayerController.Instance.TurnLeft();
        if (type == InputType.Right)
            PlayerController.Instance.TurnRight();

        Debug.Log("PointerDown " + name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (type == InputType.Left)
            PlayerController.Instance.StopTurningLeft();
        if (type == InputType.Right)
            PlayerController.Instance.StopTurningRight();

        Debug.Log("PointerUp " + name);
    }
}
