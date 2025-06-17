using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    private Transform playerTransform;
    
    public float horizontalSens;
    public float verticalSens;

    private float mouseX;
    private float mouseY;

    public GameObject mainCamera;
    private Transform cameraTransform;
    private Vector3 cameraEulerAngles;

    private float maxVerticalRotation = 80f;
    private float minVerticalRotation = -80f;

    private void Awake()
    {
        playerTransform = GetComponent<Transform>();

        cameraTransform = mainCamera.transform;
    }

    public void OnLookHorizontal(InputAction.CallbackContext context) 
    {
        mouseX = context.ReadValue<float>() * horizontalSens;
        //Debug.Log ("MouseX" +  mouseX);
    }

    public void OnLookVertical(InputAction.CallbackContext context) 
    {
        mouseY = context.ReadValue<float>() * verticalSens;
        //Debug.Log("MouseY" + mouseY);
    }

    private void Update()
    {
        LookHorizontal();
        LookVertical();
    }

    private void LookHorizontal() 
    {
        playerTransform.Rotate(0, mouseX, 0);
    }

    private void LookVertical() 
    {
        cameraEulerAngles = cameraTransform.rotation.eulerAngles;

        float newVerticalRotation = cameraEulerAngles.x - mouseY;

        if (newVerticalRotation > 180) 
        {
            newVerticalRotation -= 360;
        }

        if (newVerticalRotation > minVerticalRotation && newVerticalRotation < maxVerticalRotation)
        {
            cameraTransform.Rotate(-mouseY, 0, 0);
        }
    }
}
