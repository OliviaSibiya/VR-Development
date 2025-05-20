using MotionSystems;
using UnityEngine;

//public class CarControllerLMV : MotionPlatiform
//{
//    #region First_Attempt
//    //private ForceSeatMI_Unity m_Api;
//    //private ForceSeatMI_Vehicle m_vehicle;
//    //private ForceSeatMI_Unity.ExtraParameters m_extraParameters;
//    //private LogitechMechanic logiman;
//    //private RCC_CarControllerV3 vehicleMotion;
//    //private ForceSeatMI m_FSMI;

//    //private FSMI_TelemetryACE telemetry= new FSMI_TelemetryACE();
//    //private FSMI_TelemetryACE m_telemtry = FSMI_TelemetryACE.Prepare();

//    //public bool parkingBrake, isPaused = false, wasPaused;
//    //public bool isRigFreezed = false;

//    //public void SetInputs()
//    //{

//    //}

//    //protected override void Start()
//    //{
//    //    m_vehicle = new ForceSeatMI_Vehicle(m_Rigidbody);
//    //    m_FSMI = new ForceSeatMI();
//    //    base.telemetryData = m_FSMI;

//    //    base.Start();
//    //    TryGetComponent(out m_Rigidbody);
//    //    wasPaused = false;
//    //    isPaused = false;

//    //    m_vehicle.Begin();
//    //    m_vehicle.Pause(false);
//    //    m_vehicle.SetGearNumber(5);
//    //    m_vehicle.SetRpm(100);
//    //    m_vehicle.SetMaxRpm(1500);

//    //    m_Api.SetTelemetryObject(m_vehicle);
//    //    m_Api.Begin();
//    //    m_Api.FixedUpdate(1);
//    //    m_Api.SetRoadHarshness(1);
//    //    m_Api.SetSideSlip(0.5f);
//    //    m_Api.Pause(false);
//    //}

//    //protected override void FixedUpdate()
//    //{
//    //    float steeringValue = logiman.xAxis;
//    //    float accelerate = logiman.GasInput;
//    //    float brakes = logiman.BreakInput;
//    //    float handbrakeValue = Input.GetAxis("Jump");

//    //    RotateWheels();
//    //    base.FixedUpdate();
//    //    Move(steeringValue, accelerate, brakes, handbrakeValue);

//    //    m_FSMI.SendTelemetryACE(ref telemetry);
//    //    m_vehicle.FixedUpdate(1, ref telemetry);
//    //}

//    //public void IsPaused(bool _isPaused)
//    //{
//    //    isPaused = _isPaused;
//    //    m_vehicle.Pause(true);
//    //}

//    //private void Move(float steering, float accel, float footbrake, float handbrake)
//    //{
//    //    SteerWheels(steering);
//    //    ApplyDrive(accel, footbrake, handbrake);
//    //    ChangeGear();

//    //    if (m_vehicle != null && m_Api != null)
//    //    {
//    //        m_vehicle.SetGearNumber(m_CurrentGearNumber);
//    //        m_extraParameters.yaw = 1;
//    //        m_extraParameters.pitch = 1;
//    //        m_extraParameters.roll = (float)Math.Sin(Time.fixedTime * 1000) * 0.02f;
//    //        m_extraParameters.right = 1;
//    //        m_extraParameters.up = 1;
//    //        m_extraParameters.forward = 1;
//    //        m_Api.AddExtra(m_extraParameters);
//    //        m_Api.FixedUpdate(Time.fixedDeltaTime);
//    //    }
//    //}

//    //private void ChangeGear()
//    //{
//    //    float f = Mathf.Abs(m_Rigidbody.velocity.magnitude * 3.6f / TopSpeed);
//    //    float upgearlimit = (1 / (float)m_NumberOfGears) * (m_CurrentGearNumber + 1);
//    //    float downgearlimit = (1 / (float)m_NumberOfGears) * m_CurrentGearNumber;

//    //    if (m_CurrentGearNumber > 0 && f < downgearlimit)
//    //    {
//    //        --m_CurrentGearNumber;
//    //    }

//    //    if (f > upgearlimit && (m_CurrentGearNumber < (m_NumberOfGears - 1)))
//    //    {
//    //        ++m_CurrentGearNumber;
//    //    }
//    //}

//    //private void RotateWheels()
//    //{
//    //    Quaternion quat;
//    //    Vector3 position;

//    //    for (int i = 0; i < m_WheelColliders.Length; i++)
//    //    {
//    //        var col = m_WheelColliders[i];
//    //        var whl = m_WheelMeshes[i];

//    //        col.GetWorldPose(out position, out quat);
//    //        whl.transform.position = position;
//    //        whl.transform.rotation = quat;
//    //    }
//    //}

//    //private void SteerWheels(float steering)
//    //{
//    //    m_WheelColliders[0].steerAngle = steering * m_MaximumSteerAngle;
//    //    m_WheelColliders[1].steerAngle = steering * m_MaximumSteerAngle;
//    //}

//    //private void ApplyDrive(float accel, float footbrake, float handbrake)
//    //{
//    //    if (handbrake == 1)
//    //    {
//    //        accel *= 0.1f;
//    //    }

//    //    if (accel < 0.05f && accel > -0.05f)
//    //    {
//    //        accel = 0;
//    //    }

//    //    //var lSpeed = 1 - MathHelpers.Linear(currentSpeed, TopSpeed - 5, TopSpeed);

//    //    //accel *= lSpeed;
//    //    accel = vehicleMotion.speed;
//    //    m_Rigidbody.automaticCenterOfMass = true;
//    //    //m_Rigidbody.centerOfMass = new Vector3(0, 0, 0);

//    //    var footbrakeTorque = footbrake * m_BrakeTorque;
//    //    var handbrakeTorque = handbrake * m_MaxHandbrakeTorque / 5.0f;
//    //    var thrustTorque = accel * m_Torque;

//    //    for (int i = 0; i < m_WheelColliders.Length; i++)
//    //    {
//    //        var curr = m_WheelColliders[i];
//    //        m_WheelColliders[i].motorTorque = thrustTorque;
//    //        if (handbrake == 1)
//    //        {
//    //            m_WheelColliders[i].brakeTorque = handbrakeTorque;
//    //        }
//    //        else
//    //        {
//    //            m_WheelColliders[i].brakeTorque = footbrakeTorque;
//    //        }
//    //    }
//    //}

//    //private void End()
//    //{
//    //    if (m_FSMI.IsLoaded())
//    //    {
//    //        m_FSMI.EndMotionControl();
//    //        m_FSMI.Dispose();
//    //    }

//    //    if (m_Api != null)
//    //    {
//    //        m_Api.End();
//    //    }
//    //}
//    #endregion

//    #region Second_Attempt
//    //private ForceSeatMI fsmi;
//    //private ForceSeatMI_Unity m_Api;
//    //private ForceSeatMI_Vehicle m_vehicle;
//    //private ForceSeatMI_Unity.ExtraParameters extraParameters;

//    //private FSMI_TelemetryACE m_telemetry = FSMI_TelemetryACE.Prepare();

//    //private RCC_CarControllerV3 carControl;
//    //private LogitechMechanic manualDrive;

//    //private bool firstCall = true;

//    //private float prevForwardSpeed = 0;
//    //private float prevRightSpeed = 0;
//    //private float prevUpSpeed = 0;

//    //const float FSMI_VT_ACC_LOW_PASS_FACTOR = 0.5f;
//    //const float FSMI_VT_ANGLES_SPEED_LOW_PASS_FACTOR = 0.5f;
//    //const float FSMI_LINEAR_SPEED_LOW_PASS_FACTOR = 0.5f;
//    //const float FSMI_BODY_PRY_LOW_PASS_FACTOR = 0.5f;

//    //public float m_Downforce;

//    //private Vector3 prevAngles = new Vector3();

//    //public virtual void Begin()
//    //{
//    //    m_vehicle = new ForceSeatMI_Vehicle(m_Rigidbody);
//    //    m_vehicle.SetGearNumber(m_CurrentGearNumber);
//    //    m_vehicle.Pause(false);
//    //    m_vehicle.SetRpm(1000);
//    //    m_vehicle.SetMaxRpm(1500);

//    //    m_Api = new ForceSeatMI_Unity();
//    //    m_Api.SetAppID("");
//    //    m_Api.ActivateProfile("SDK - Vehicle Telemetry ACE");
//    //    m_Api.SetTelemetryObject(m_vehicle);
//    //    m_Api.Pause(false);
//    //    m_Api.Begin();
//    //    m_Api.FixedUpdate(1);
//    //    m_Api.SetRoadHarshness(5);
//    //    m_Api.SetSideSlip(2);

//    //    //api = new ForceSeatMI();

//    //}

//    //private void Start()
//    //{
//    //    fsmi = new ForceSeatMI();

//    //    if (fsmi.IsLoaded())
//    //    {
//    //        fsmi.SetAppID("");
//    //        fsmi.ActivateProfile("SDK - Vehicle Telemetry ACE");
//    //        fsmi.BeginMotionControl();

//    //        m_telemetry.structSize = (byte)Marshal.SizeOf(m_telemetry);
//    //        m_telemetry.structSize = (byte)Marshal.SizeOf(FSMI_BODY_PRY_LOW_PASS_FACTOR);
//    //        m_telemetry.structSize = (byte)Marshal.SizeOf(FSMI_LINEAR_SPEED_LOW_PASS_FACTOR);
//    //        m_telemetry.structSize = (byte)Marshal.SizeOf(FSMI_VT_ACC_LOW_PASS_FACTOR);
//    //        m_telemetry.structSize = (byte)Marshal.SizeOf(FSMI_VT_ANGLES_SPEED_LOW_PASS_FACTOR);
//    //        m_telemetry.state = FSMI_State.NO_PAUSE;
//    //    }
//    //    else
//    //    {
//    //        Debug.LogError("ForceSeatMI library has not been found! Please install ForceSeatPM.");
//    //    }
//    //}

//    //private void Update()
//    //{
//    //    FixedUpdate();
//    //    if (fsmi.IsLoaded())
//    //    {
//    //        fsmi.SetAppID("");
//    //        fsmi.ActivateProfile("SDK - Vehicle Telemetry ACE");
//    //        fsmi.BeginMotionControl();

//    //        m_telemetry.structSize = (byte)Marshal.SizeOf(m_telemetry);
//    //        m_telemetry.state = FSMI_State.NO_PAUSE;
//    //    }
//    //    else
//    //    {
//    //        Debug.LogError("ForceSeatMI library has not been found! Please install ForceSeatPM.");
//    //    }
//    //}

//    //private void End()
//    //{
//    //    if (fsmi.IsLoaded())
//    //    {
//    //        fsmi.EndMotionControl();
//    //        fsmi.Dispose();
//    //    }

//    //    if (m_Api != null)
//    //    {
//    //        m_Api.End();
//    //    }

//    //    //apiV.End();
//    //}

//    //private void FixedUpdate()
//    //{
//    //    float steerValue = manualDrive.xAxis;
//    //    float accelerate = manualDrive.GasInput;
//    //    float brakes = manualDrive.BreakInput;
//    //    float handbrakeValue = carControl.handbrakeInput;

//    //    m_vehicle.FixedUpdate(Time.fixedDeltaTime, ref m_telemetry);
//    //    Tick(ref m_Rigidbody, 1, false, carControl.engineRPM, carControl.maxEngineRPM, carControl.totalGears);
//    //    RotateWheels();
//    //    Move(ref steerValue, accelerate, brakes, handbrakeValue);
//    //    m_Api.AddExtra(extraParameters);
//    //    m_Api.SetUserAux(0, 0.0f);
//    //    m_Api.FixedUpdate(Time.fixedDeltaTime);
//    //    fsmi.SendTelemetryACE(ref m_telemetry);
//    //    SendTelemetryData();
//    //}

//    //public void Tick(ref Rigidbody body, float deltaTime, bool paused, float rpm, float maxRpm, int gearNumber)
//    //{
//    //    //Vector3 velocity = body.transform.InverseTransformDirection(body.velocity);
//    //    Vector3 velocity = m_Rigidbody.transform.InverseTransformDirection(m_Rigidbody.velocity);

//    //    float forwardSpeed = velocity.z;
//    //    float rightSpeed = velocity.x;
//    //    float upSpeed = velocity.y;

//    //    m_telemetry.state = paused ? (byte)FSMI_State.PAUSE : (byte)FSMI_State.NO_PAUSE;

//    //    m_telemetry.rpm = (uint)carControl.engineRPM;
//    //    m_telemetry.maxRpm = (uint)carControl.maxEngineRPM;
//    //    m_telemetry.gearNumber = (sbyte)carControl.totalGears;
//    //    m_telemetry.vehicleForwardSpeed = velocity.magnitude;

//    //    if (firstCall)
//    //    {
//    //        SendTelemetryData();
//    //        if (firstCall == false)
//    //        {
//    //            m_telemetry.bodyLinearAcceleration[0].forward = 0;
//    //            m_telemetry.bodyLinearAcceleration[0].upward = 0;
//    //            m_telemetry.bodyLinearAcceleration[0].right = 0;

//    //            m_telemetry.bodyAngularVelocity[0].roll = 0;
//    //            m_telemetry.bodyAngularVelocity[0].pitch = 0;
//    //            m_telemetry.bodyAngularVelocity[0].yaw = 0;

//    //            m_telemetry.bodyLinearVelocity[0].forward = 0;
//    //            m_telemetry.bodyLinearVelocity[0].upward = 0;
//    //            m_telemetry.bodyLinearVelocity[0].right = 0;

//    //            m_telemetry.bodyPitch = 0;
//    //            m_telemetry.bodyRoll = 0;
//    //        }
//    //        else
//    //        {
//    //            ForceSeatMI_Utils.LowPassFilter(ref m_telemetry.bodyLinearAcceleration[0].forward, (forwardSpeed - prevForwardSpeed), FSMI_VT_ACC_LOW_PASS_FACTOR);
//    //            ForceSeatMI_Utils.LowPassFilter(ref m_telemetry.bodyLinearAcceleration[0].right, (rightSpeed - prevRightSpeed), FSMI_VT_ACC_LOW_PASS_FACTOR);
//    //            ForceSeatMI_Utils.LowPassFilter(ref m_telemetry.bodyLinearAcceleration[0].upward, (upSpeed - prevUpSpeed), FSMI_VT_ACC_LOW_PASS_FACTOR);

//    //            var deltaAngles = new Vector3(
//    //                Mathf.Deg2Rad * Mathf.DeltaAngle(body.transform.eulerAngles.x, prevAngles.x),
//    //                Mathf.Deg2Rad * Mathf.DeltaAngle(body.transform.eulerAngles.y, prevAngles.y),
//    //                Mathf.Deg2Rad * Mathf.DeltaAngle(body.transform.eulerAngles.z, prevAngles.z)
//    //            );

//    //            ForceSeatMI_Utils.LowPassFilter(ref m_telemetry.bodyAngularVelocity[0].roll, deltaAngles.z, FSMI_VT_ANGLES_SPEED_LOW_PASS_FACTOR);
//    //            ForceSeatMI_Utils.LowPassFilter(ref m_telemetry.bodyAngularVelocity[0].pitch, deltaAngles.x, FSMI_VT_ANGLES_SPEED_LOW_PASS_FACTOR);
//    //            ForceSeatMI_Utils.LowPassFilter(ref m_telemetry.bodyAngularVelocity[0].yaw, deltaAngles.y, FSMI_VT_ANGLES_SPEED_LOW_PASS_FACTOR);

//    //            ForceSeatMI_Utils.LowPassFilter(ref m_telemetry.bodyPitch, -ForceSeatMI_Utils.MotionFriendlyPRY_rad(Mathf.Deg2Rad * m_Rigidbody.transform.eulerAngles.x), FSMI_BODY_PRY_LOW_PASS_FACTOR);
//    //            ForceSeatMI_Utils.LowPassFilter(ref m_telemetry.bodyRoll, -ForceSeatMI_Utils.MotionFriendlyPRY_rad(Mathf.Deg2Rad * m_Rigidbody.transform.eulerAngles.z), FSMI_BODY_PRY_LOW_PASS_FACTOR);

//    //        }

//    //        m_telemetry.bodyLinearAcceleration[0].forward = forwardSpeed;
//    //        m_telemetry.bodyLinearAcceleration[0].upward = upSpeed;
//    //        m_telemetry.bodyLinearAcceleration[0].right = rightSpeed;

//    //        m_telemetry.bodyAngularVelocity[0].roll = prevAngles.x;
//    //        m_telemetry.bodyAngularVelocity[0].pitch = prevAngles.y;
//    //        m_telemetry.bodyAngularVelocity[0].yaw = prevAngles.z;

//    //        m_telemetry.bodyLinearVelocity[0].forward = forwardSpeed;
//    //        m_telemetry.bodyLinearVelocity[0].right = rightSpeed;
//    //        m_telemetry.bodyLinearVelocity[0].upward = upSpeed;

//    //        m_telemetry.bodyRoll = prevAngles.x;
//    //        m_telemetry.bodyPitch = prevAngles.y;

//    //        fsmi.SendTelemetryACE(ref m_telemetry);
//    //        SendTelemetryData();
//    //    }

//    //    prevForwardSpeed = forwardSpeed;
//    //    prevRightSpeed = rightSpeed;
//    //    prevUpSpeed = upSpeed;
//    //    prevAngles.x = m_Rigidbody.transform.eulerAngles.x;
//    //    prevAngles.y = m_Rigidbody.transform.eulerAngles.y;
//    //    prevAngles.z = m_Rigidbody.transform.eulerAngles.z;

//    //    m_telemetry.gearNumber = (sbyte)carControl.totalGears;

//    //    fsmi.SendTelemetryACE(ref m_telemetry);
//    //    SendTelemetryData();
//    //}

//    //private void Move(ref float steering, float accel, float footbrake, float handbrake)
//    //{
//    //    SteerWheels(steering);
//    //    ApplyDrive( ref accel, footbrake, handbrake);
//    //    ChangeGear();
//    //    CapSpeed();
//    //    AddDownForce();
//    //}

//    //private void SteerWheels(float steering)
//    //{
//    //    m_WheelColliders[0].steerAngle = steering * m_MaximumSteerAngle;
//    //    m_WheelColliders[1].steerAngle = steering * m_MaximumSteerAngle;
//    //}

//    //private void ApplyDrive(ref float accel, float footbrake, float handbrake)
//    //{
//    //    if (handbrake == 1)
//    //    {
//    //        accel *= 0.1f;
//    //    }

//    //    if (accel < 0.05f && accel > -0.05f)
//    //    {
//    //        accel = 0;
//    //    }

//    //    accel = carControl.speed;

//    //    float footbrakeTorque = footbrake * carControl.brakeTorque;
//    //    float handbrakeTorque = handbrake * carControl.brakeTorque / 5.0f;
//    //    float thrustTorque = accel * carControl.maxEngineTorque;

//    //    if (footbrakeTorque > 0)
//    //    {
//    //        m_WheelColliders[0].brakeTorque = footbrakeTorque;
//    //        m_WheelColliders[1].brakeTorque = footbrakeTorque;
//    //        m_WheelColliders[2].brakeTorque = footbrakeTorque / 3;
//    //        m_WheelColliders[3].brakeTorque = footbrakeTorque / 3;
//    //    }
//    //    else
//    //    {
//    //        m_WheelColliders[0].brakeTorque = 0;
//    //        m_WheelColliders[1].brakeTorque = 0;
//    //        m_WheelColliders[2].brakeTorque = 0;
//    //        m_WheelColliders[3].brakeTorque = 0;
//    //    }

//    //    m_WheelColliders[0].motorTorque = thrustTorque / 3;
//    //    m_WheelColliders[1].motorTorque = thrustTorque / 3;

//    //    if (handbrakeTorque > 0)
//    //    {
//    //        m_WheelColliders[2].brakeTorque = Mathf.Max(m_WheelColliders[2].brakeTorque, handbrakeTorque);
//    //        m_WheelColliders[3].brakeTorque = Mathf.Max(m_WheelColliders[3].brakeTorque, handbrakeTorque);
//    //        m_WheelColliders[2].motorTorque = 0;
//    //        m_WheelColliders[3].motorTorque = 0;
//    //    }
//    //    else
//    //    {
//    //        m_WheelColliders[2].motorTorque = thrustTorque;
//    //        m_WheelColliders[3].motorTorque = thrustTorque;
//    //    }

//    //    for (int i = 0; i < m_WheelColliders.Length; i++)
//    //    {
//    //        var curr = m_WheelColliders[i];
//    //        m_WheelColliders[i].motorTorque = thrustTorque;
//    //        if (handbrake == 1)
//    //        {
//    //            m_WheelColliders[i].brakeTorque = handbrakeTorque;
//    //        }
//    //        else
//    //        {
//    //            m_WheelColliders[i].brakeTorque = footbrakeTorque;
//    //        }
//    //    }

//    //    if (accel <= 0)
//    //    {
//    //        foreach (var collider in m_WheelColliders)
//    //        {
//    //            collider.brakeTorque = Mathf.Max(collider.brakeTorque, m_BrakeTorque);
//    //        }
//    //    }
//    //}

//    //private void ChangeGear()
//    //{
//    //    m_CurrentGearNumber = carControl.currentGear;
//    //    m_NumberOfGears = carControl.totalGears;

//    //    float f = Mathf.Abs(m_Rigidbody.velocity.magnitude * 3.6f / TopSpeed);
//    //    float upgearlimit = (1 / (float)m_NumberOfGears) * (m_CurrentGearNumber + 1);
//    //    float downgearlimit = (1 / (float)m_NumberOfGears) * m_CurrentGearNumber;

//    //    if (m_CurrentGearNumber > 0 && f < downgearlimit)
//    //    {
//    //        --m_CurrentGearNumber;
//    //    }

//    //    if (f > upgearlimit && (m_CurrentGearNumber < (m_NumberOfGears - 1)))
//    //    {
//    //        ++m_CurrentGearNumber;
//    //    }
//    //}

//    //private void RotateWheels()
//    //{
//    //    Quaternion quatern;
//    //    Vector3 objectPosition;

//    //    for (int i = 0; i < m_WheelColliders.Length; i++)
//    //    {
//    //        var col = m_WheelColliders[i];
//    //        var whl = m_WheelMeshes[i];

//    //        col.GetWorldPose(out objectPosition, out quatern);
//    //        whl.transform.position = objectPosition;
//    //        whl.transform.rotation = quatern;
//    //    }
//    //}

//    //private void CapSpeed()
//    //{
//    //    float currentSpeed = m_Rigidbody.velocity.magnitude * 3.6f;

//    //    if (currentSpeed > TopSpeed)
//    //    {
//    //        m_Rigidbody.velocity = (TopSpeed / 3.6f) * m_Rigidbody.velocity.normalized;
//    //    }
//    //}

//    //private void AddDownForce()
//    //{
//    //    var body = m_WheelColliders[0].attachedRigidbody;

//    //    body.AddForce(-transform.up * m_Downforce * body.velocity.magnitude);
//    //}

//    //private void SendTelemetryData()
//    //{

//    //}

//    #endregion

//    #region Third_Attempt
//    //private LogitechMechanic manual;
//    //private RCC_CarControllerV3 carControl;

//    //public WheelCollider[] wheelColliders = new WheelCollider[4];

//    //public GameObject[] wheelMesh = new GameObject[4];

//    //public bool firstCall = true;

//    //public float torque;
//    //public float reverseTorque;
//    //public float maxHandbrakeTorque;
//    //public float maxSteeringAngle;
//    //public float downForce;
//    //public float topSpeed;
//    //public float speed;
//    //public float brakeTorque;

//    //private Vector3 vehicleAngle = new Vector3();

//    //private int numberOfGears = 5;
//    //private int currentGearNumber;

//    //private Rigidbody rb;

//    //private ForceSeatMI fsmi;
//    //private ForceSeatMI_Vehicle vehicle;
//    //private ForceSeatMI_Unity unity;

//    //public FSMI_TelemetryPRY telemetryPry = new FSMI_TelemetryPRY();
//    //public FSMI_TelemetryRUF telemetryRuf = new FSMI_TelemetryRUF();
//    //public FSMI_TelemetryACE telemetry = new FSMI_TelemetryACE();

//    //private void Start()
//    //{
//    //    fsmi = new ForceSeatMI();

//    //    if (fsmi.IsLoaded())
//    //    {
//    //        telemetry = FSMI_TelemetryACE.Prepare();

//    //        telemetry.structSize = (byte)Marshal.SizeOf(telemetry);
//    //        telemetry.state = FSMI_State.NO_PAUSE;

//    //        fsmi.SetAppID("");
//    //        fsmi.ActivateProfile("SDK - Vehicle Telemetry ACE");
//    //        fsmi.BeginMotionControl();

//    //        vehicle = new ForceSeatMI_Vehicle(rb);
//    //        vehicle.Begin();
//    //        vehicle.Pause(false);
//    //        vehicle.SetGearNumber(5);

//    //        unity = new ForceSeatMI_Unity();
//    //        unity.Begin();
//    //        unity.Pause(false);
//    //        unity.SetTelemetryObject(vehicle);

//    //        firstCall = true;
//    //    }
//    //    else
//    //    {
//    //        Debug.LogError("ForceSeatMI Library not found.");
//    //    }
//    //}

//    //private void FixedUpdate()
//    //{
//    //    vehicle.FixedUpdate(Time.fixedDeltaTime, ref telemetry);

//    //    Vector3 velocity = rb.transform.TransformDirection(rb.velocity);
//    //    var forwardSpeed = velocity.z;
//    //    var upSpeed = velocity.y;
//    //    var rightSpeed = velocity.x;

//    //    vehicleAngle.x = rb.transform.eulerAngles.x;
//    //    vehicleAngle.y = rb.transform.eulerAngles.y;
//    //    vehicleAngle.z = rb.transform.eulerAngles.z;

//    //    telemetry.gearNumber = (sbyte)manual.CurrentGear;
//    //    telemetry.accelerationPedalPosition = (byte)manual.GasInput;
//    //    telemetry.brakePedalPosition = (byte)manual.BreakInput;
//    //    telemetry.clutchPedalPosition = (byte)manual.ClutchInput;
//    //    telemetry.rpm = (uint)carControl.engineRPM;
//    //    telemetry.maxRpm = (uint)carControl.maxEngineRPM;
//    //    telemetry.vehicleForwardSpeed = carControl.speed;

//    //    if (firstCall)
//    //    {
//    //        telemetryPry.pitch = -Mathf.Deg2Rad * vehicleAngle.y;
//    //        telemetryPry.roll = Mathf.Deg2Rad * vehicleAngle.x; 
//    //        telemetryPry.yaw = Mathf.Deg2Rad * vehicleAngle.z; 

//    //        telemetryRuf.forward = forwardSpeed;
//    //        telemetryRuf.upward = upSpeed;
//    //        telemetryRuf.right = rightSpeed;
//    //    }

//    //    fsmi.SendTelemetryACE(ref telemetry);
//    //}
//    #endregion
//}

public class CarControllerLMV : MonoBehaviour
{
    public RCC_WheelCollider[] rccWheelColliders = new RCC_WheelCollider[4];
    public GameObject[] wheelObjects = new GameObject[4];

    public float torque;
    public float reverseTorque;
    public float maximumHandbrakeTorque;
    public float maximumSteerAngle;
    public float downForce;
    public float topSpeed;
    public float brakeTorque;

    private int numberOfGears = 6;
    private int currentGearNumber;

    private Rigidbody rb;

    private Vector3 prevVelocityPosition;
    private Vector3 prevVehicleAngle;

    private ForceSeatMI FSMI;
    private ForceSeatMI_Unity api;
    private ForceSeatMI_Vehicle vehicle;
    private FSMI_TelemetryACE telemetry = FSMI_TelemetryACE.Prepare();

    private RCC_CarControllerV3 carController;
    private RCC_Settings settings;

    public void Start()
    {
        rb = carController.rigid;
        torque = carController.maxEngineTorque;
        maximumSteerAngle = carController.steerAngle;
        downForce = carController.downForce;
        topSpeed = carController.maxspeed;
        brakeTorque = carController.brakeTorque;
        currentGearNumber = carController.currentGear;

        FSMI = new ForceSeatMI();
        api = new ForceSeatMI_Unity();
        vehicle = new ForceSeatMI_Vehicle(rb);

        api.Begin();
        api.ActivateProfile("SDK - Vehicle Telemetry ACE");
        api.Pause(false);
        api.FixedUpdate(Time.fixedDeltaTime);
        api.SetTelemetryObject(vehicle);

        
        vehicle.SetRpm((uint)carController.engineRPM);

        FSMI.BeginMotionControl();
        FSMI.ActivateProfile("SDK - Vehicle Telemetry ACE");
        FSMI.Park(FSMI_ParkMode.ForTransport);

        
    }

    private void OnDestroy()
    {
        if (FSMI.IsLoaded())
        {
            FSMI.EndMotionControl();
            FSMI.Dispose();
        }
    }

    public void FixedUpdate()
    {
        float h = carController.steerInput;
        float v = carController.brakeInput;
        float handbrake = Input.GetAxis("Jump");

        VehicleTelemetryData();
        VehicleMove(h, v, v, handbrake);

        if (vehicle != null && api != null)
        {
            vehicle.SetGearNumber(currentGearNumber);
        }
    }

    private void VehicleMove(float steering, float accel, float footbrake, float handbrake)
    {
        RotateWheels();
        SteerWheels(steering);
        ApplyDrive(accel, footbrake, handbrake);
        CapSpeed();
        //ChangeGear();
        AddDownForce();
    }

    private void VehicleTelemetryData()
    {
        var velocity = rb.transform.InverseTransformDirection(rb.velocity);
        var forward = velocity.z;
        var right = velocity.x;
        var up = velocity.y;

        telemetry.state = FSMI_State.NO_PAUSE;
        telemetry.structSize = 1;

        telemetry.accelerationPedalPosition = (byte)carController.throttleInput;
        telemetry.brakePedalPosition = (byte)carController.brakeInput;
        telemetry.clutchPedalPosition = (byte)carController.clutchInput;
        telemetry.gearNumber = (sbyte)currentGearNumber;

        telemetry.rpm = (uint)carController.engineRPM;
        telemetry.maxRpm = (uint)carController.maxEngineRPM;
        telemetry.vehicleForwardSpeed = velocity.magnitude;

        telemetry.bodyLinearAcceleration[1].right = right;
        telemetry.bodyLinearAcceleration[1].forward = forward;
        telemetry.bodyLinearAcceleration[1].upward = up;

        telemetry.bodyAngularVelocity[1].pitch = -Mathf.Deg2Rad * velocity.z;
        telemetry.bodyAngularVelocity[1].roll = Mathf.Deg2Rad * velocity.x;
        telemetry.bodyAngularVelocity[1].yaw = velocity.y;

        telemetry.headPosition[1].forward = forward;
        telemetry.headPosition[1].right = up;
        telemetry.headPosition[1].upward = up;

        telemetry.bodyPitch = velocity.magnitude;
        telemetry.bodyRoll = Mathf.Deg2Rad * velocity.magnitude;

        FSMI.SendTelemetryACE(ref telemetry);
    }

    private void RotateWheels()
    {
        for (int i = 0; i < rccWheelColliders.Length; i++)
        {
            rccWheelColliders[i].ApplyBrakeTorque(brakeTorque);
            rccWheelColliders[i].ApplyMotorTorque(torque);
        }
    }

    private void SteerWheels( float steering)
    {
        var angle = Mathf.Clamp(steering, -1, 1) * maximumSteerAngle;

        rccWheelColliders[0].ApplySteering(steering, angle);
        rccWheelColliders[1].ApplySteering(steering, angle);
    }

    private void ApplyDrive(float accel, float footbrake, float handbrake)
    {
        var footbrakeTorque = -Mathf.Clamp(footbrake, -1, 0) * maximumHandbrakeTorque * 100;
        var handbrakeTorque = Mathf.Clamp(handbrake, 0, 1) * maximumHandbrakeTorque;
        var thrustTorque = Mathf.Clamp(accel, 0, 1) * torque;

        if (footbrakeTorque > 0)
        {
            rccWheelColliders[0].ApplyBrakeTorque(footbrakeTorque);
            rccWheelColliders[1].ApplyBrakeTorque(footbrakeTorque);
            rccWheelColliders[2].ApplyBrakeTorque(footbrakeTorque / 3);
            rccWheelColliders[3].ApplyBrakeTorque(footbrakeTorque / 3);
        }
        else
        {
            rccWheelColliders[0].ApplyBrakeTorque(0);
            rccWheelColliders[1].ApplyBrakeTorque(0);
            rccWheelColliders[2].ApplyBrakeTorque(0);
            rccWheelColliders[3].ApplyBrakeTorque(0);
        }

        rccWheelColliders[0].ApplyMotorTorque(thrustTorque / 3);
        rccWheelColliders[1].ApplyMotorTorque(thrustTorque / 3);

        if (handbrakeTorque > 0)
        {
            rccWheelColliders[2].ApplyBrakeTorque(handbrakeTorque);
            rccWheelColliders[3].ApplyBrakeTorque(handbrakeTorque);
            rccWheelColliders[2].ApplyMotorTorque(0);
            rccWheelColliders[3].ApplyMotorTorque(0);
        }
        else
        {
            rccWheelColliders[3].ApplyMotorTorque(thrustTorque);
            rccWheelColliders[2].ApplyMotorTorque(thrustTorque);
        }

        if (accel <= 0)
        {
            foreach (var collider in rccWheelColliders)
            {
                collider.ApplyBrakeTorque(brakeTorque);
            }
        }
    }

    private void CapSpeed()
    {
        float currentSpeed = rb.velocity.magnitude * 3.6f;

        if (currentSpeed > topSpeed)
        {
            rb.velocity = (topSpeed / 3.6f) * rb.velocity.normalized;
        }
    }

    private void AddDownForce()
    {
        
    }
}
