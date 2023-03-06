using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhellController : MonoBehaviour
{   
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentBreakingForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    //public float acceleration = 500f;
    //public float breakingForce = 300f;
    //public float maxTurnAngle = 15;

    //private float currentAcceleration = 0;
    //private float currentBreakingForce = 0;
    //private float currentTurnAngle = 0;
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }
    void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }
    void HandleMotor()
    {
        frontLeft.motorTorque = verticalInput *100000* motorForce;
        frontRight.motorTorque = verticalInput * motorForce;
        currentBreakingForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }
    void ApplyBreaking()
    {
        frontRight.brakeTorque = currentBreakingForce;
        frontLeft.brakeTorque = currentBreakingForce;
        backLeft.brakeTorque = currentBreakingForce;
        backRight.brakeTorque = currentBreakingForce;
    }
    void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeft.steerAngle = currentSteerAngle;
        frontRight.steerAngle = currentSteerAngle;

    }
    void UpdateWheels()
    {
        UpdateSingleWheel(frontRight,frontRightTransform);
        UpdateSingleWheel(frontLeft,frontLeftTransform);
        UpdateSingleWheel(backRight,backRightTransform);
        UpdateSingleWheel(backLeft,backLeftTransform);
    }
    void UpdateSingleWheel(WheelCollider wheelCollider,Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos,out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position= pos;
    }










    //private void FixedUpdate()
    //{
    //    currentAcceleration = acceleration  * Input.GetAxis("Vertical");

    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        print("bast");
    //        currentBreakingForce = breakingForce;
    //    }
    //    else
    //    {
    //        currentBreakingForce = 0;
    //    }

    //    frontRight.motorTorque = currentAcceleration;
    //    frontLeft.motorTorque = currentAcceleration;

    //    frontRight.brakeTorque = currentBreakingForce;
    //    frontLeft .brakeTorque= currentBreakingForce;
    //    backLeft.brakeTorque= currentBreakingForce;
    //    backRight.brakeTorque= currentBreakingForce;

    //    currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
    //    frontLeft.steerAngle = currentTurnAngle;
    //    frontRight.steerAngle = currentTurnAngle;
    //}
}
