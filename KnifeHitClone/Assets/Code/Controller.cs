using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    AmmoController ammoController;
    public GameObject ammo;

    public bool ready = true;
    public int impulseForce;
    public GameObject log;
    Collider logCollider;
    
    public GameObject knife;
    Collider knifeCollider;
    Rigidbody knifeRb;
    public GameObject knifeOrigin;

    

    // Start is called before the first frame update
    void Start()
    {
        ammoController = ammo.GetComponent<AmmoController>();
        logCollider = log.GetComponent<MeshCollider>();
        knifeCollider = knife.GetComponent<BoxCollider>();
        knifeRb = knife.GetComponent<Rigidbody>();

        ammoController.NewGoal();

    }

    // Update is called once per frame
    void Update()
    {
        if (ready && Input.GetMouseButtonDown(0))
        {
            knifeRb.AddRelativeForce(Vector3.forward * impulseForce, ForceMode.Impulse);
        }
    }

    public void NewKnife()
    {
        knife = Instantiate(knifeOrigin, new Vector3(0, -4.8f, -1), Quaternion.Euler(-56.17f,0 ,0));
        knifeCollider = knife.GetComponent<BoxCollider>();
        knifeRb = knife.GetComponent<Rigidbody>();
        knife.GetComponent<KnifeController>().mainController = this;
        knife.GetComponent<KnifeController>().log = log;
        knife.GetComponent<KnifeController>().ammo = ammo;
        ready = true;

        ammoController.Throw();
    }
    
}
