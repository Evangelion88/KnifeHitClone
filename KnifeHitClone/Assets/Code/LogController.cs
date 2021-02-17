using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : MonoBehaviour
{
    public float rotation_Speed;
    public bool isPlay=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlay)
        gameObject.transform.Rotate(0, rotation_Speed * (Time.deltaTime * 10),0, Space.Self);
    }
}
