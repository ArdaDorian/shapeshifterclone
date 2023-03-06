using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float verticalSpeed;
    [SerializeField] float changeSpeed;
    Vector3 mousePos;
    float vertical;

    [SerializeField] const float shapeArea = 8;

    LevelManager levelManager;

    bool inVoid;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Start()
    {
        transform.localScale = new Vector3(8, 1, 1);
    }

    private void Update()
    {
        if(!levelManager.GetIsMoving()) { return; }

        MoveObject();

        CheckInput();

        ControlScale();

        ClampTransform();
    }

    private void MoveObject()
    {
        transform.Translate(transform.forward * verticalSpeed * Time.deltaTime); // Go forward
        
        if(inVoid) { return; }
        transform.position = new Vector3(transform.position.x, transform.localScale.y / 2, transform.position.z); // Go up and down
    }

    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            vertical = (Input.mousePosition.y - mousePos.y) / Screen.width * 1.5f;
            mousePos = Input.mousePosition;
        }
    }

    #region Scaling
    private void ControlScale()
    {
        switch (vertical)
        {
            case < 0:
                transform.localScale = new Vector3(ChangeScaleValue(transform.localScale.x), KeepConst(transform.localScale.x), transform.localScale.z);
                break;
            case > 0:
                transform.localScale = new Vector3(KeepConst(transform.localScale.y), ChangeScaleValue(transform.localScale.y), transform.localScale.z);
                break;
        }
    }

    float ChangeScaleValue(float value)
    {
        float newValue = value + changeSpeed* Time.deltaTime;
        return newValue;
    }

    float KeepConst(float value)
    {
        float newValue = shapeArea / value;
        return newValue;
    }
    #endregion

    #region Clamping
    private void ClampTransform()
    {
        transform.localScale = GetClampedScale();
        transform.position = GetClampedPosition();
    }

    float ClampValue(float value, float min, float max)
    {
        float clampedValue = Mathf.Clamp(value, min, max);
        return clampedValue;
    }

    Vector3 GetClampedScale()
    {
        Vector3 clampedScale = new Vector3(ClampValue(transform.localScale.x, 1f, 8f), ClampValue(transform.localScale.y, 1f, 8f), transform.localScale.z);
        return clampedScale;
    }
    
    Vector3 GetClampedPosition()
    {
        Vector3 clampedPosition = new Vector3(ClampValue(transform.position.x, 0f, 0f), ClampValue(transform.position.y, -99f, 4f), transform.position.z);
        return clampedPosition;
    }
    #endregion

    public void CheckInVoid(bool statue)
    {
        inVoid = statue;
    }
}
