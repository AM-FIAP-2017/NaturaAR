using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchBehaviour : MonoBehaviour
{
   

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                CanvasManager.instance.InstantiateParticle(Input.touches[0].position);
            }
        }
    }
}
