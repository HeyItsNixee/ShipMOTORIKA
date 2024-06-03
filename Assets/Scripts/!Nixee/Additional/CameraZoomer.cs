using Cinemachine;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float zoomSize;
    [SerializeField] private float zoomStep;
    private float originalZoomSize = 0f;

    private void Start()
    {
        originalZoomSize = virtualCamera.m_Lens.OrthographicSize;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
            Zoom();
        else
            Unzoom();

    }

    public void Zoom()
    {
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, zoomSize, zoomStep);
        //virtualCamera.m_Lens.OrthographicSize = zoomSize;
    }

    public void Unzoom()
    {
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, originalZoomSize, zoomStep);
        //virtualCamera.m_Lens.OrthographicSize = originalZoomSize;
    }
}
