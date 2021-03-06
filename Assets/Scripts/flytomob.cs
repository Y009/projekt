﻿using UnityEngine;
using System.Collections;

public class flytomob : MonoBehaviour {

    public Transform target;    //bullet1 annab targeti
    public float dmg;
    public float speed;
    public bool splash;
    public bool ice;
    public float radius = 4;
    public LayerMask enemylayer;
    private Vector3 splashtarget;
    private Vector3 dir;
    private Rigidbody rigid;

    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        if (splash == true)
        {
            splashtarget = target.position;
            dir = splashtarget - transform.position + Vector3.up * 10;
            this.GetComponent<Rigidbody>().velocity = dir.normalized * 20;
        }
    }

	void FixedUpdate () 
    {
        if (target && !splash)
        {
            dir = target.position - transform.position;     //j2llitab vaenlast
            rigid.velocity = dir.normalized * 10;
        }
        else if (splash && transform.position.y > 5)
        {
            dir.y -= 0.005f;
            dir = dir + Vector3.down*2;
            rigid.velocity = dir;
        }
        else if (!target && !splash)
            Destroy(gameObject);

        if (this.transform.position.y < 0 && splash)
        {
            splashattack();
        }
	}

    void splashattack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, enemylayer);
        
        foreach (Collider enemy in hitColliders)
        {
            enemy.GetComponentInChildren<Health>().decrease(dmg);
        }

        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider co)
    {
        if(!splash && co.transform == target)
        {
            Health health = co.GetComponentInChildren<Health>();    //v6tan mobi elud
            if (ice)
            {
                co.GetComponent<Mobmove>().iceslow = true;                                                          
            }
            if (health)
            { 
                health.decrease(dmg);
                Destroy(gameObject);
            }
        }
    }
}
