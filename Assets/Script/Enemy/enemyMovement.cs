using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public Transform player2;// Referensi ke transform pemain
    public float moveSpeed; // Kecepatan gerakan musuh
    public Vector3 target;

    void Start()
    {
        // Mencari objek PlayerMovement di scene
        player = FindObjectOfType<PlayerMovement>()?.transform;
        player2 = FindObjectOfType<playerMovement2>()?.transform;
        // Memastikan player tidak null
       
    }

    void Update()
    {
        // Pastikan player tidak null sebelum bergerak

        float distanceplayer=0;
        float distanceplayer2=0;
       

        if (player2 != null && player != null)
        {
            distanceplayer = (transform.position - player.position).sqrMagnitude;
            distanceplayer2 = (transform.position - player2.position).sqrMagnitude;
            // Menggerakkan musuh menuju posisi pemain

        }
        else
        {
            if (player != null)
            {
                distanceplayer2 = (transform.position - player.position).sqrMagnitude;
            }
            else
            {
                distanceplayer = (transform.position - player2.position).sqrMagnitude;
            }
        }

        if (distanceplayer < distanceplayer2)
        {
            target = player.position;
        }
        else
        {
            target = player2.position;
        }

        if (player2 != null && player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            // Menggerakkan musuh menuju posisi pemain
            
        }
        else 
        {
            if (player != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, player2.position, moveSpeed * Time.deltaTime);
            }
        }
        /*float distanceToCloseEnemy = Mathf.Infinity;
        player closestEnemy = null;
        player[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentlyEnemy in allEnemies) {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToCloseEnemy)
            {
                distanceToCloseEnemy = distanceToCloseEnemy;
                closestEnemy = currentlyEnemy;
            }*/
    }
}
