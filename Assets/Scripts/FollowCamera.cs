using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x,y,z;
        x = Mathf.Clamp(player.position.x, 0f,105.09f);
        y = Mathf.Clamp(player.position.y, 0f,0.04f);
        z = transform.position.z;
        transform.position = new Vector3(x,y,z);
    }
}
