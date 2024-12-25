using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;

    bool isFiring = false;

    private void Start() 
    {
        Cursor.visible = false;
    }

    private void Update() 
    {
        ProcessFiring();
        Movecrosshair();
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
}
