using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEONaturaARBehaviour : MonoBehaviour
{
    public ProductData data;

    void Start()
    {
		
    }


    void Update()
    {
		
    }

    void OnBecameVisible()
    {
        CanvasManager.instance.SetData(data);
    }

    void OnBecameInvisble()
    {
        CanvasManager.instance.SetData(null);
    }
}
