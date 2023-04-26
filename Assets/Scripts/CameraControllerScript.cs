using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (transform != null && player!=null)
        {
            float x, y, z;
            x = Mathf.Clamp(player.position.x, 0f, 166.05f);
            y = Mathf.Clamp(player.position.y, 0f, 0.04f);
            z = transform.position.z;
            transform.position = new Vector3(x, y, z);
        }

    }
}
