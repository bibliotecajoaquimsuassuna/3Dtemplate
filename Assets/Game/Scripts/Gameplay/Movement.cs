using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Components
    [SerializeField] Animator anim;
    [SerializeField] CharacterController controller;

    //Movement
    private float inputX;
    private float inputZ;
    private Vector3 direction;
    [SerializeField] float moveSpeed;

    //Attack
    [SerializeField] float areaAtk;
    List<Transform> enemyList = new List<Transform>();

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Movement
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        direction = new Vector3(inputX, 0, inputZ);

        //Rotation
        if(inputX != 0 || inputZ != 0)
        {
            anim.SetBool("isRunning", true);
            Vector3 lookDirection = new Vector3(direction.x, 0, direction.z);
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        controller.Move(direction * moveSpeed * Time.deltaTime);
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine("Kick");
        }

    }

    //Attacks
    IEnumerator Kick()
    {
        anim.SetBool("isKicking", true);
        yield return new WaitForSeconds(0.6f);
        GetEnemiesInRange();
        foreach(Transform enemies in enemyList)
        {
            //Debug.Log("inimigo na lista");
            Enemy enemy = enemies.GetComponent<Enemy>();

            if(enemy != null)
            {
                enemy.GetHit(20);
            }
        }
        yield return new WaitForSeconds(0.6f);
        anim.SetBool("isKicking", false);
    }

    void GetEnemiesInRange()
    {
        enemyList.Clear();
        foreach(Collider colisor in Physics.OverlapSphere((transform.position + transform.forward), areaAtk))
        {
            if(colisor.gameObject.CompareTag("Enemy"))
            {
                //Debug.Log("Bateu!");
                enemyList.Add(colisor.transform);
            }   
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward, areaAtk);
    }

    //Movements
    void Run()
    {

    }
}