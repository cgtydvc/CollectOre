using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public SpoolScript spool;
    public GameObject child;
    public Rigidbody rb;
    private bool isMove;

    private float destinationSwipe = 100f;

    public Vector2 startFramePos;
    public Vector2 lastFramePos;
    public Vector2 currentPos;

    Vector3 parrentandchildDiff;


    private void Start()
    {
        child.transform.position = transform.position + new Vector3(.5f, 0.1f, 1f);
        parrentandchildDiff = transform.position - child.transform.position;
    }

    private void Update()
    {
        child.transform.position = transform.position + parrentandchildDiff;
    }

    private void FixedUpdate()
    {

        if (isMove)
        {
            Vector3 force = new Vector3(startFramePos.x, 0, 0) * Time.fixedDeltaTime * 20f;
            rb.AddForce(force);
            isMove = false;
        }

        currentPos = Vector2.zero;
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector3.zero;
        }
        if (Input.GetMouseButton(0))
        {
            currentPos = Input.mousePosition;
            if (lastFramePos == Vector2.zero)
            {
                lastFramePos = currentPos;
            }
            startFramePos = currentPos - lastFramePos;
            if (startFramePos.magnitude < destinationSwipe)
            {
                return;
            }
            //startFramePos.Normalize();
            if (Mathf.Abs(startFramePos.y) > Mathf.Abs(startFramePos.x))
            {
                if (startFramePos.y < 0)
                {
                    spool.throwtheHook = true;
                }
                else
                {
                    spool.throwtheHook = false;
                }
            }
            else
            {
                lastFramePos = currentPos;
                isMove = true;
            }
        }
        else
        {
            lastFramePos = Vector2.zero;
        }
    }
}
