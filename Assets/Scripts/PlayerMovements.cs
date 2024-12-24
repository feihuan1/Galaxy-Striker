using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 5f;

    [SerializeField] float controlRollFactor = 20f;

    Vector2 movement;

    void Update()
    {
        ProcessMovements();
        ProcessRotation();
    }


    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void ProcessMovements()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    private void ProcessRotation()
    {
        transform.localRotation = quaternion.Euler(0f, 0f, -controlRollFactor * movement.x);
    }
}
