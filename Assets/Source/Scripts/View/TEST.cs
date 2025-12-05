using UnityEngine;

public class RocketPathFollower : MonoBehaviour
{
    [Header("Путь")]
    public Transform[] waypoints;

    [Header("Настройки")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;

    private int currentWaypointIndex = 0;
    private Vector3 targetPosition;

    void Start()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogError("Waypoints не заданы!");
            enabled = false;
            return;
        }

        targetPosition = waypoints[currentWaypointIndex].position;
    }

    void Update()
    {
        if (currentWaypointIndex >= waypoints.Length) return;

        // Двигаемся к цели
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        // Проверка прибытия
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                Debug.Log("Ракета завершила путь!");
                return;
            }
            targetPosition = waypoints[currentWaypointIndex].position;
        }

        // === КЛЮЧЕВОЕ ИЗМЕНЕНИЕ: НЕ ОБНУЛЯЕМ Y! ===
        Vector3 directionToTarget = targetPosition - transform.position;

        if (directionToTarget.magnitude > 0.01f)
        {
            // Смотрим ТОЧНО в направлении движения (включая вверх/вниз)
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // Плавный поворот в 3D
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}