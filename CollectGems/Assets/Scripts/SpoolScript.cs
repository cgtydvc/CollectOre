using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoolScript : MonoBehaviour
{
    public GameManager manager;
    public Transform hook;
    public bool throwtheHook = false;
    public bool pullbackHook = false;

    public float throw_Speed = 150f;
    public float ifhookemptySpeed = 175f;
    public float pullback_Speed = 0.0f;
    private void Update()
    {
        if (throwtheHook == true)
        {
            hook.gameObject.GetComponent<Rigidbody>().velocity = Vector3.down * Time.deltaTime * throw_Speed;
        }
        if (pullbackHook == true)
        {
            hook.gameObject.GetComponent<Rigidbody>().velocity = -Vector3.down * Time.deltaTime * throw_Speed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hook")
        {
            throwtheHook = false;
            pullbackHook = false;
            hook.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            hook.parent = transform;
            if (hook.childCount > 0)
            {
                manager.increasetoMoney(hook.GetComponentInChildren<GemScript>()._initialValue);
                Destroy(hook.GetChild(0).gameObject);
            }
            pullback_Speed = ifhookemptySpeed;
        }
    }

}
