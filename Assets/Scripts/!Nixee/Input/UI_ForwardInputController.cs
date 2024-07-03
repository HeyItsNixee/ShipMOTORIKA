using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ForwardInputController : Singleton<UI_ForwardInputController>, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image holder;
    [SerializeField] private Image bit;
    public Vector3 Value { get; private set; }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(holder.rectTransform, eventData.position,
                                                                        eventData.pressEventCamera, out position);
        //Debug.Log("position = " + position);
        position.x = (position.x / holder.rectTransform.sizeDelta.x);
        position.y = (position.y / holder.rectTransform.sizeDelta.y);

        position.y = position.y * 2 - 1;

        Value = new Vector3(position.x, position.y, 0);

        if (Value.magnitude > 1)
            Value = Value.normalized;

        //Debug.Log("value.y = " + Value.y);

        float offsetY = holder.rectTransform.sizeDelta.y / 2 - bit.rectTransform.sizeDelta.y / 2;

        bit.rectTransform.anchoredPosition = new Vector2(Value.x, Value.y * offsetY);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData.selectedObject);

        OnDrag(eventData);
    }

    public void ResetStick()
    {
        Value = Vector3.zero;
        bit.rectTransform.anchoredPosition = Vector3.zero;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ResetStick();
    }
    private void OnDisable()
    {
        ResetStick();
    }
}
