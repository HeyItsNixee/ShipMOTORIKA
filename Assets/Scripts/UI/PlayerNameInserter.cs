using ShipMotorika;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PlayerNameInserter : MonoBehaviour
{
    private Text textField;

    private void Start()
    {
        textField = GetComponent<Text>();
        if (textField.text.Contains("<player>"))
            textField.text = textField.text.Replace("<player>", PlayerSettingsHolder.Instance.settings.playerName);
    }
}
