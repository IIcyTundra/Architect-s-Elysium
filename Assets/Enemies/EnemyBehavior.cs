using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform player;
    public LayerMask whatIsGround, Player;
    public float Health = 200;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float TimePerAttack;
    bool JustAttacked;
    public float SightRange, AttackRange;
    public bool playerInSightRange, playerInAttackRange;

    public GameObject projectile;

    // Start is called before the first frame update
    void awake()
    {
        player = GameObject.Find("Player").transform;
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player);
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, SightRange, Player);
        playerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, Player);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            Agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        Agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        Agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!JustAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 20f, ForceMode.Impulse);
            rb.AddForce(transform.up * 0f, ForceMode.Impulse);
            ///End of attack code

            JustAttacked = true;
            Invoke(nameof(ResetAttack), TimePerAttack);
        }
    }
    private void ResetAttack()
    {
        JustAttacked = false;
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, SightRange);
    }

    public void TakeDamage(float DMG, string effect)
    {
        Health -= DMG;
        if(effect.CompareTo("Incendiary") == 0)
        {
            StartCoroutine(DMGOverTime(1));
        }
        
    }

    IEnumerator DMGOverTime(int time)
    {
        while(Health != 0 && time != 5)
        {
            Health -=5;
            yield return new WaitForSeconds(1);
            time++;
            Debug.Log(Health);

        }
        

        
    }

    
}
