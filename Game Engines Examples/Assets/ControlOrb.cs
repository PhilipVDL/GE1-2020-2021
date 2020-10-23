using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlOrb : MonoBehaviour
{
    FPSController fpsController;
    TankController tankController;
    Shooting tankShooting;
    AITank AI;
    RotateOrb rotOrb;

    GameObject cameraTarget;

    private void Start()
    {
        //me
        rotOrb = GetComponent<RotateOrb>();
        //tank
        AI = GetComponentInParent<AITank>();
        tankShooting = GetComponentInParent<Shooting>();
        tankController = GetComponentInParent<TankController>();
        //camera
        fpsController = Camera.main.GetComponent<FPSController>();

        cameraTarget = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            fpsController.enabled = false;
            rotOrb.enabled = false;
            AI.enabled = false;

            tankController.enabled = true;
            tankShooting.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, cameraTarget.transform.position, 0.1f);
            Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, Quaternion.LookRotation(transform.parent.transform.forward), 0.3f);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                fpsController.enabled = true;
                rotOrb.enabled = true;
                AI.enabled = true;

                tankController.enabled = false;
                tankShooting.enabled = false;
            }
        }
    }
}