using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    Rigidbody knifeRb;
    bool free = true;
    public float rotationSpeed;
    public float hitForce;
    [Space]
    public Controller mainController;
    public GameObject log;
    LogController logController;

    // Start is called before the first frame update
    void Start()
    {
        free = true;
        mainController.knife = gameObject;
        knifeRb = gameObject.GetComponent<Rigidbody>();   
    }

    private void FixedUpdate()
    {
        if (free)
            gameObject.transform.Rotate(new Vector3(0, 0, 1), rotationSpeed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trigger")
        {
            free = false;

            gameObject.transform.SetParent(log.transform);
            knifeRb.velocity = new Vector3(0, 0, 0);

            mainController.ready = false;
            mainController.NewKnife();
        }
        else if(other.tag=="Player")
        {
            free = false;

            knifeRb.velocity = new Vector3(0, 0, 0);

            knifeRb.AddRelativeForce(Vector3.up * hitForce, ForceMode.Impulse);
            knifeRb.AddRelativeForce(Vector3.back * hitForce/2, ForceMode.Impulse);
            knifeRb.AddRelativeTorque(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));

            mainController.ready = false;
            logController.isPlay = false;
        }
    }
}
