using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    private Vector3 targetPoint;
    public float speed = 1;
    public int pointsIfHit = 10;

    private void Start()
    {
        targetPoint = pointA.position;
    }

    private void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
    }

    // Move target between targets
    public void Update() {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPoint, 
            Time.deltaTime * speed);

        if (transform.position == targetPoint) {
            if (targetPoint == pointA.position) {
                targetPoint = pointB.position;
            } else {
                targetPoint = pointA.position;
            }
        }
    }
}
