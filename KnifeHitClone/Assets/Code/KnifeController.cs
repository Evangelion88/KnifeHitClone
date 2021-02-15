using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    Rigidbody knifeRb;

    public Controller mainController;
    public GameObject log;

    // Start is called before the first frame update
    void Start()
    {
        mainController.knife = gameObject;
        knifeRb = gameObject.GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trigger")
        {
            gameObject.transform.SetParent(log.transform);
            knifeRb.velocity = new Vector3(0, 0, 0);

            mainController.ready = false;
            mainController.NewKnife();
        }
    }
}
