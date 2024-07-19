using UnityEngine;
using ShipMotorika;
using UnityEngine.EventSystems;

public class UI_SideInputController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private InputType type;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.activeInHierarchy == false)
            return;

        if (type == InputType.Left)
            PlayerController.Instance.TurnLeft();
        if (type == InputType.Right)
            PlayerController.Instance.TurnRight();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (type == InputType.Left)
            PlayerController.Instance.StopTurningLeft();
        if (type == InputType.Right)
            PlayerController.Instance.StopTurningRight();
    }

    private void OnDisable()
    {
        PlayerController.Instance.StopTurningLeft(); 
        PlayerController.Instance.StopTurningRight();
    }
}
