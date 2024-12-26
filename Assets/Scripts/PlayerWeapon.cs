using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;

    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

    bool isFiring = false;

    private void Start() 
    {
        Cursor.visible = false;
    }

    private void Update() 
    {
        ProcessFiring();
        Movecrosshair();
        MoveTargetPoint();
        AimLaser();
    }


    void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {
        foreach(GameObject laser in lasers)
        {
            var emmisionModule = laser.GetComponent<ParticleSystem>().emission;
            emmisionModule.enabled = isFiring;
        }
    }

    void Movecrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

        private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLaser()
    {
        foreach(GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position; 
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }

}
