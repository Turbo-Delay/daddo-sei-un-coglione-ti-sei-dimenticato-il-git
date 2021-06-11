using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // var for inventory
    public InvetoryObject playerInventory;

    // var for movement
    public float moveSpeed;
    public Rigidbody rig;
    public Animator anim;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<item>();
        if (item)
        {
            playerInventory.AddItem(item.Item, 1);
            Destroy(other.gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        playerInventory.Container.Clear();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 dir = transform.right * x + transform.forward * z;
        if(dir.x == 0)
        {
            anim.SetFloat("Speed", 0f);
        }
        else
        {
            anim.SetFloat("Speed", 0.1f);
        }
        dir *= moveSpeed;
        dir.y = rig.velocity.y;
        rig.velocity = dir;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
