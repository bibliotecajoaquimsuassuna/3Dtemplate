using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] CharacterController controller;
    [SerializeField] float areaAtk;
    List<Transform> enemyList = new List<Transform>();

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine("Kick");
        }

    }

    //Attacks
    IEnumerator Kick()
    {
        anim.SetBool("isKicking", true);
        yield return new WaitForSeconds(1.2f);
        GetEnemiesInRange();
        anim.SetBool("isKicking", false);
    }

    void GetEnemiesInRange()
    {
        enemyList.Clear();
        foreach(Collider colisor in Phisics.OverlapSphere((transform.position + transform.forward), areaAtk))
        {

        }
    }

    //Movements
    void Run()
    {

    }
}