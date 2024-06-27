using UnityEngine;

public class SeagullFlight : MonoBehaviour
{
    // ������ ������ �� ��� X � Y
    public float radiusX = 5f;
    public float radiusY = 3f;
    // �������� ������
    public float speed = 1f;
    // �������� �������� �������
    public float rotationSpeed = 5f;

    // ��������� ������� �����
    private Vector3 startPosition;
    // ����� ��� ������� �������
    private float time;
    // ���������� ������� ��� ���������� �����������
    private Vector3 previousPosition;

    void Start()
    {
        // ��������� ��������� ������� �����
        startPosition = transform.position;
        // ��������� ��������� ������� ��� ����������
        previousPosition = startPosition;
    }

    void Update()
    {
        // ��������� ����� � ������ ��������
        time += Time.deltaTime * speed;

        // ���������� ������� �� ���������� � ����� ����� ������
        float x = Mathf.Sin(time) * radiusX;
        float y = Mathf.Sin(2 * time) * radiusY;

        // ���������� ������� �����
        Vector3 newPosition = startPosition + new Vector3(x, y, 0);
        transform.position = newPosition;

        // ������� ������� � ����������� ������
        Vector3 direction = newPosition - previousPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // ���������� ���������� �������
        previousPosition = newPosition;
    }

    void OnDrawGizmos()
    {
        // ������������ ������� ������ � ���������
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Mathf.Max(radiusX, radiusY));

        // ������������ ���������� � ����� ���������
        Gizmos.color = Color.blue;
        for (float t = 0; t < Mathf.PI * 2; t += 0.1f)
        {
            float posX = Mathf.Sin(t) * radiusX;
            float posY = Mathf.Sin(2 * t) * radiusY;
            Gizmos.DrawSphere(transform.position + new Vector3(posX, posY, 0), 0.1f);
        }
    }
}
