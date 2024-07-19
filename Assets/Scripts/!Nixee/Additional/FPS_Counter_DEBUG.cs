using ShipMotorika;
using UnityEngine;
using UnityEngine.UI;

public class FPS_Counter_DEBUG : SingletonBase<FPS_Counter_DEBUG>
{
    [SerializeField] private Text fpsText;
    private float FPS;

    private void Update()
    {
        CountFPS();
        fpsText.text = FPS.ToString();
    }

    private void CountFPS()
    {
        FPS = (int)(1f / Time.unscaledDeltaTime);
    }
}
