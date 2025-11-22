using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 10f;      // How far enemy can detect player
    public string targetTag = "Player";     // Tag to detect
    public NavMeshAgent agent;              // Enemy movement (AI)

    private Transform player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag(targetTag).transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // If player is in detection range → chase
        if (distance <= detectionRange)
        {
            agent.SetDestination(player.position);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw detection range in editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
