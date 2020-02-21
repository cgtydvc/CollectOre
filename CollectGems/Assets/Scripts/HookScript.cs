using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    public LineRenderer hookLine;
    public Transform spool;
    SpoolScript spoolScript;

    private void Start()
    {
        spoolScript = GameObject.Find("Spool").GetComponent<SpoolScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ore")
        {
            spoolScript.pullbackHook = true;
            float _pull_back_speed = other.gameObject.GetComponent<GemScript>()._retractionSpeed;
            spoolScript.pullback_Speed = spoolScript.ifhookemptySpeed - (_pull_back_speed * 4);
            if (_pull_back_speed <= 0)
            {
                _pull_back_speed = 20f;
            }
            other.gameObject.GetComponent<MeshCollider>().enabled = false;
            other.gameObject.transform.parent = transform;
        }

        else
        {
            spoolScript.pullbackHook = true;
        }
    }
    private void Update()
    {
        lineTracking();
    }
    private void lineTracking()
    {
        hookLine.SetPosition(0, transform.position);
        hookLine.SetPosition(1, spool.position);
    }
}
