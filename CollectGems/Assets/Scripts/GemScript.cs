using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    public float _retractionSpeed;
    public int _initialValue;

    public bool stone;
    public bool gold;
    public bool diamond;

    public Material stoneMat;
    public Material goldMat;
    public Material diamondMat;
    private void Start()
    {
        _retractionSpeed = transform.localScale.x;
        if (stone == true)
        {
            GetComponent<MeshRenderer>().material = stoneMat;
            _initialValue = (int)_retractionSpeed/2;
        }
        if (gold == true)
        {
            GetComponent<MeshRenderer>().material = goldMat;
            _initialValue = (int)_retractionSpeed * 22;
        }
        if (diamond == true)
        {
            GetComponent<MeshRenderer>().material = diamondMat;
            if (transform.localScale.x >=10f)
            {
                _initialValue = 500;
            }
            else
            {
                _initialValue = (int)_retractionSpeed * 150;
            }
        }
    }
}
