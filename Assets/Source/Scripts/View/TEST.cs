using UnityEngine;

namespace Source.Scripts.View
{
    public class RocketPathFollower : MonoBehaviour
    {
        public Transform[] waypoints;
    
        public float moveSpeed = 5f;
        public float rotationSpeed = 5f;

        private int currentWaypointIndex = 0;
        private Vector3 targetPosition;

        void Start()
        {
            if (waypoints == null || waypoints.Length == 0)
            {
                enabled = false;
                return;
            }

            targetPosition = waypoints[currentWaypointIndex].position;
        }

        void Update()
        {
            if (currentWaypointIndex >= waypoints.Length) return;
        
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );
        
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex++;
            
                if (currentWaypointIndex >= waypoints.Length)
                {
                    Debug.Log("ENDED!");
                    return;
                }
            
                targetPosition = waypoints[currentWaypointIndex].position;
            }
        
            Vector3 directionToTarget = targetPosition - transform.position;

            if (directionToTarget.magnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
            }
        }
    }
}