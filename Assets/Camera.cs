using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform[] transforms;
    private void Update()
    {
        gameObject.transform.localPosition = (transforms[0].localPosition + transforms[1].localPosition)/2;
    }
}
