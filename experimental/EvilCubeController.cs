using BasicShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EvilCubeController : MonoBehaviour, IDamagable {
    private NavMeshAgent nav;
    private Transform player;
    private int health;
    private Transform target;

    public int maxHealth;
    public Transform explosionPrefab;
    public Rigidbody bulletPrefab;
    public Transform bulletPoint;
    public float aggroDistance = 10;

    private float lastShot = 0.0f;
    private float shootDelay = 1.2f;
    private float bulletSpeed = 30f;

    private void Awake()
    {
        // Find via tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        this.health = this.maxHealth;
        StartCoroutine(UpdateTarget());       
    }

    private IEnumerator UpdateTarget()
    {
        while (true)
        {
            float dis = Vector3.Distance(transform.position, player.position);
            if (dis <= aggroDistance)
            {
                target = player;
            } else
            {
                target = null;
            }
            yield return new WaitForSeconds(0.2f);
        } 
    }

    private void Update()
    {
        // Check health
        if (this.health <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        } else
        {
            // AI movement
            if (target != null) {
                NavMeshHit hit;
                if (!nav.Raycast(target.position, out hit))
                {
                    nav.SetDestination(target.position);

                    // Shooting
                    if (lastShot + shootDelay < Time.time)
                    {
                        lastShot = Time.time;
                        Rigidbody bulletInstance = Instantiate(bulletPrefab, 
                            bulletPoint.transform.position, bulletPoint.transform.rotation);

                        // The local up direction of the gun is transformed into world space.
                        Vector3 gunDirection = (target.position - transform.position).normalized;
                        bulletInstance.AddForce(gunDirection * bulletSpeed, ForceMode.Impulse);
                    }
                }
            }
            else {
                nav.ResetPath();
            }
        }
    }

    public void AddDamage(int damage)
    {
        this.health -= damage;
        print("EvilCube health left: " + this.health);
    }
}
