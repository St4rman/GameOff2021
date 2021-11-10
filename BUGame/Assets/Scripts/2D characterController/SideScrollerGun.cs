using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerGun : MonoBehaviour
{
    [Header("Shooting Variables")]
    [SerializeField] public KeyCode shootKey;
    public float recoilForce;
    [Header("References")]
    Rigidbody2D prb;

    void Awake()
    {
        prb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 mouseTo = getMousePosition() - transform.position;
        mouseTo.z =0;

        Vector3 RecoilDirection = -mouseTo.normalized;
        Debug.DrawRay(transform.position, RecoilDirection, Color.green);

        if(Input.GetKey(shootKey))
        {
            Vector2 recoil2D = new Vector2(RecoilDirection.x, RecoilDirection.y);
            shoot(recoil2D);
        }
    }
    Vector3 getMousePosition(){

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z =0;
        return mousePos;

    }

    void shoot(Vector2 recoil)
    {
        //add flair here

        //physics
       prb.AddRelativeForce(recoil * recoilForce, ForceMode2D.Force);
    }
}
