using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float maxCloseness;
    public int hitPoints;
    public float reloadTime;
    public float shootDistance;
    private float reloadTimer;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = maxCloseness;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        var rayPosition = player.transform.position - transform.position;
        if (Physics.Raycast (transform.position, rayPosition, out hit))
        {
            if (hit.transform == player.transform)
            {
                agent.SetDestination(player.transform.position);
                transform.LookAt(player.transform, Vector3.up);
                //transform.Rotate(0.0f, transform.rotation.y, 0.0f);
                //Quaternion rotation = Quaternion.LookRotation(player.transform.position);
                //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 200);
            }
            //Debug.DrawRay(transform.position, rayPosition, Color.yellow);
        }
        if (hitPoints < 0)
        {
            Destroy(gameObject);
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
