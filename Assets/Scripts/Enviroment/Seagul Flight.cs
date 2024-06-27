using UnityEngine;

public class SeagullFlight : MonoBehaviour
{
    // Радиус полета по оси X и Y
    public float radiusX = 5f;
    public float radiusY = 3f;
    // Скорость полета
    public float speed = 1f;
    // Скорость вращения рендера
    public float rotationSpeed = 5f;

    // Начальная позиция чайки
    private Vector3 startPosition;
    // Время для расчета позиции
    private float time;
    // Предыдущая позиция для вычисления направления
    private Vector3 previousPosition;

    void Start()
    {
        // Сохранить начальную позицию чайки
        startPosition = transform.position;
        // Сохранить начальную позицию как предыдущую
        previousPosition = startPosition;
    }

    void Update()
    {
        // Обновляем время с учетом скорости
        time += Time.deltaTime * speed;

        // Вычисление позиции по траектории в форме цифры восемь
        float x = Mathf.Sin(time) * radiusX;
        float y = Mathf.Sin(2 * time) * radiusY;

        // Обновление позиции чайки
        Vector3 newPosition = startPosition + new Vector3(x, y, 0);
        transform.position = newPosition;

        // Поворот рендера в направлении полета
        Vector3 direction = newPosition - previousPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Обновление предыдущей позиции
        previousPosition = newPosition;
    }

    void OnDrawGizmos()
    {
        // Визуализация радиуса полета в редакторе
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Mathf.Max(radiusX, radiusY));

        // Визуализация траектории в форме восьмерки
        Gizmos.color = Color.blue;
        for (float t = 0; t < Mathf.PI * 2; t += 0.1f)
        {
            float posX = Mathf.Sin(t) * radiusX;
            float posY = Mathf.Sin(2 * t) * radiusY;
            Gizmos.DrawSphere(transform.position + new Vector3(posX, posY, 0), 0.1f);
        }
    }
}
