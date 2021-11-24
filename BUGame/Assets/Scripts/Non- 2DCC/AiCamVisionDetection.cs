using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AiCamVisionDetection : MonoBehaviour
{
    [Header("Vision Cone")]
    public float viewRadius;
    [Range(0,180)]
    public float viewAngle;

    [Header("Layers")]
    public LayerMask targetMask;
    public LayerMask obsMask;
    Vector2[] originalpos;
    GameObject Dragobj;

    [SerializeField] MouseDrag md;

    void Start()
    {
       Dragobj=GameObject.Find("DraggableObjects");
       originalpos=new Vector2[Dragobj.transform.childCount];
       for(int i=0;i<Dragobj.transform.childCount;i++)
       {
           originalpos[i]= Dragobj.transform.GetChild(i).transform.position;
       }
    }
    void Update()
    {
        checkForPlayer();
    }

    void checkForPlayer()
    {
        Collider2D[] targetInRange = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);  

        for(int i =0; i<targetInRange.Length; i++)
        {
            Vector2 toTarget = targetInRange[i].transform.position -transform.position;
            Vector2 targetDir = toTarget.normalized;


            float angleBw = Vector2.Angle(transform.up, toTarget);

            if( angleBw < (viewAngle/2) )
            {

                RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDir, obsMask);
                Debug.DrawRay(transform.position, targetDir* hit.distance, Color.red);

                
                if(hit.transform == targetInRange[i].transform)
                {
                    
                    StartCoroutine(ResetPos(targetInRange[i]));
                }
            }
        }
    }
    IEnumerator ResetPos(Collider2D targetInRange)
    {
        
        md.enabled=false;
        switch(targetInRange.gameObject.name)
                    {
                        case "Dragobj1":  targetInRange.gameObject.transform.position=originalpos[0];
                                         break;
                        case "Dragobj2": targetInRange.gameObject.transform.position=originalpos[1];
                                         break;
                    }
        yield return new WaitForSeconds(5);
        md.enabled=true;
        yield return null;
    }


    void OnDrawGizmos()
    {
        Handles.DrawWireArc(transform.position, Vector3.forward, transform.up, viewAngle/2, viewRadius);
        Handles.DrawWireArc(transform.position, Vector3.forward, transform.up, -viewAngle/2, viewRadius);

        //Debug.DrawRay(transform.position, transform.up * viewRadius, Color.cyan);

    }
}
