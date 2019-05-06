using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float maxCloseness;      // Distance at which enemy will stop when too close
    public int hitPoints;           // HP
    public float reloadTime;        // Fire speed
    public GameObject bullet;       // Bullet object
    public float shootDistance;     // Max distnace at which enemy will shoot
    public GameObject sparks;       // Death particles
    public GameObject firePos;      // Where to fire bullets from
    public AudioClip[] soundList;
    private float reloadTimer = 0.0f;
    private bool isDead = false;
    private AudioSource audioSource;
    NavMeshAgent agent;
    Collider enemyHitbox;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyHitbox = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
        agent.stoppingDistance = maxCloseness;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints <= 0)
        {
            hitPoints = 0;
            if (isDead == false)
            {
                agent.isStopped = true;
                isDead = true;
                enemyHitbox.enabled = false;
                audioSource.PlayOneShot(soundList[1]);
                audioSource.volume = 0.3f;
                Instantiate(sparks, transform.position, transform.rotation);
                GameObject model = transform.Find("robot").gameObject;
                model.transform.Rotate(-90f, transform.rotation.y, transform.rotation.y, Space.Self);
            }
        }
        else
        {
            RaycastHit hit;
            var rayPosition = player.transform.position - transform.position;
            if (Physics.Raycast(transform.position, rayPosition, out hit))
            {
                if (hit.transform == player.transform)
                {
                    agent.SetDestination(player.transform.position);
                    transform.LookAt(player.transform, Vector3.up);
                    if (reloadTimer > reloadTime)
                    {
                        Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
                        audioSource.PlayOneShot(soundList[2]);
                        reloadTimer = 0.0f;
                    }
                    reloadTimer += Time.deltaTime;
                    //transform.Rotate(0.0f, transform.rotation.y, 0.0f);
                    //Quaternion rotation = Quaternion.LookRotation(player.transform.position);
                    //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 200);
                }
                //Debug.DrawRay(transform.position, rayPosition, Color.yellow);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hitPoints -= 1;
        }
    }
}
