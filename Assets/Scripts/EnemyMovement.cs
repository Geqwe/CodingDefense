using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 1;

    // public static Transform[] waypoints;

    private void Start() {
        target = WaypointScript.points[1];
    }

    private void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized*speed*Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f) {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint() {

        if(wavepointIndex >= WaypointScript.points.Length - 1) {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = WaypointScript.points[wavepointIndex];
        FaceTarget();
    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(-direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*500f);
    }
}
