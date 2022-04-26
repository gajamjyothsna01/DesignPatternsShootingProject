using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float playerSpeed;
    public float playerJumpForce;
    public float rotationSpeed;
    public GameObject ballParticleEffect;
   // Quaternion playerRotataion, camRotation;
    public Camera cam;
   
    CapsuleCollider capsuleCollider;
    public Animator animator;
    int ammo = 100;
    //int maxAmmo = 100;
   // public Transform bulletLaunchPosition;
    public int health = 100;
    //int maxHealth = 100;
   
    // public SpriteRenderer sprite;
    // public bool isGameWin = false;
    //public GameObject target;
    // public AudioClip audioClip;
   // public AudioSource audioSource;
    public GameObject bulletPrefab;
    public Transform bulletPosition;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();  
       
        //animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {

       // animator.SetBool("isWalking", true);
      
        /* if (Input.GetKeyDown(KeyCode.F))
         {
             animator.SetBool("", !animator.GetBool("IsAiming"));
         }*/
        if (Input.GetMouseButtonDown(0))
        {
             // animator.SetBool("isFiring", !animator.GetBool("isFiring"));
                Debug.Log("Firing State");
                animator.SetTrigger("isFiring");
                //GameObject temp = Instantiate(bulletPrefab, bulletPosition.transform.position, Quaternion.identity);
                GameObject temp = PoolScript.instance.GetObjectsFromPool("Bullet");
                if(temp!= null)
                {

                    temp.transform.position = bulletPosition.transform.position;
                     Instantiate(ballParticleEffect, temp.transform.position, Quaternion.identity);
                    temp.SetActive(true);
                    rb = temp.GetComponent<Rigidbody>();
                    rb.velocity = transform.forward * bulletSpeed;
                    Debug.Log("Player Hit Method");
                 }



            GameObject tempEnemy = PoolScript.instance.GetObjectsFromPool("Enemy");
            tempEnemy.transform.position = new Vector3(UnityEngine.Random.Range(200f, 250f), 1.2f, UnityEngine.Random.Range(120f, 290f));
            tempEnemy.SetActive(true);




            // Debug.Log("Ammo Firing" +ammo);
            ammo--;
                
                //WhenPlayerHitEnemy();
                //audioSource.Play();
               

               // ammo = Mathf.Clamp(ammo - 10, 0, maxAmmo);
                // Debug.Log(ammo);
            


        }





    }

   

   

      
   
}
