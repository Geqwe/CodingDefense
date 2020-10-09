using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;
    public float startHealth = 100;
    private float health;
    public int value = 10;

    private Transform target;
    private int wavepointIndex = 1;
    public GameObject effectDie;
    public Image healthBar;

    // public static Transform[] waypoints;

    private void Start() {
        target = WaypointScript.points[1];
        health = startHealth;
    }

    private void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized*speed*Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f) {
            GetNextWaypoint();
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        healthBar.fillAmount = health / startHealth;
        if(health <= 0) {
            Die();
        }
    }

    void Die() {
        GameObject eff = (GameObject)Instantiate(effectDie, transform.position, Quaternion.identity);
        Destroy(eff, 2f);
        PlayerStats.Money += value;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    void GetNextWaypoint() {

        if(wavepointIndex >= WaypointScript.points.Length - 1) {
            EndPath();
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

    void EndPath() {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
