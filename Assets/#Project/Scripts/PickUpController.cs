using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public SaltBehaviour saltBehaviour;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, hand, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;


    private void Start()
    {
        if(!equipped)
        {
            saltBehaviour.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if(equipped)
        {
            saltBehaviour.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }
    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUp();
        }

        if (equipped && Input.GetMouseButtonDown(0))
        {
            Drop();
        }
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //placement de l'objet dans la mains
        transform.SetParent(hand);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
       // transform.localScale = Vector3.one;

        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        coll.isTrigger = true;

        saltBehaviour.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //calcul de la force du lancer
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);

        //pour ajouter une rotation à l'objet
        //float random = Random.Range(-1f, 1f);
        //rb.AddTorque(new Vector3(random, random, random));

        saltBehaviour.enabled = false;
    }
}
