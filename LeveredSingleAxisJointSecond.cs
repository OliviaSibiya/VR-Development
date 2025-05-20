//using UnityEngine;
//using Framework.Replay;

//using Framework.GameFoundation.Interaction;
//using HurricaneVR.Framework.Components;

//namespace Framework.GameFoundation
//{
//    public class LeveredSingleAxisJointSecond : BaseSingleAxisJoint
//    {
//        #region Serialized Fields
//        [SerializeField]
//        private Lever lever;
//        [SerializeField]
//        private HVRLever leverTwo;

//        [SerializeField]
//        public Transform pivot;

//        [SerializeField]
//        private Vector3 rotationAxis = Vector3.right;

//        [SerializeField]
//        private bool constrain, useLeverYAxis;

//        [SerializeField, Min(0.01f)]
//        public float speed = 1f;

//        [SerializeField, Range(-180, 180)]
//        private float constrainMin = -90, constrainMax = 90;
//        #endregion



//        #region Properties
//        public float ContrainMin => constrainMin;
//        public float ConstrainMax => constrainMax;
//        #endregion

//        private void Update()
//        {
//            if (!lever || !lever.isActiveAndEnabled || Master.IsLoadingOrLoadingScreen || UI.Dialog.IsAnyDialogActive)
//                return;
//            if (ReplayManager && ReplayManager.State != ReplayManagerState.Recording)
//                return;
//            var value = Value;
//            value += useLeverYAxis
//                ? lever.LinearValueY * Time.deltaTime * speed
//                : lever.LinearValueX * Time.deltaTime * speed;
//            if (!constrain)
//            {
//                if (value > 1) value -= 1;
//                if (value < 0) value += 1;
//            } 
//            SetValue(value);
//        }
//        protected override void ApplyValue(float value)
//        { 
//            if(pivot)
//            {
//                if (Mathf.Approximately(rotationAxis.magnitude, 0))
//                    rotationAxis = Vector3.right;
//                if (rotationAxis.magnitude > 1)
//                    rotationAxis.Normalize();
//                var angle = constrain ? Mathf.Lerp(constrainMin, constrainMax, value) : value * 180;
//                var euler = rotationAxis * angle;
//                pivot.localRotation = TransformRelative(Quaternion.Euler(euler));
//            }
//        }

//        protected override void ConstrainValue(ref float value) => value = value.Clamp01();

//        protected override void OnValidate()
//        {
//            base.OnValidate();
//            if (Mathf.Approximately(rotationAxis.magnitude, 0))
//                rotationAxis = Vector3.right;
//            if(rotationAxis.magnitude > 1)
//                rotationAxis.Normalize();
//        }

//        protected virtual void OnDrawGizmos()
//        { 
//            var p = transform.position;
//            var r = transform.rotation * rotationAxis;
//            Gizmos.color = Color.red;
//            Gizmos.DrawRay(p, r);
//            if(constrain) 
//                GizmoHelpers.DrawWireArc(transform.position, transform.rotation, rotationAxis, constrainMin, constrainMax, 1); 
//            if (pivot)
//            {
//                Gizmos      .color = Color.blue;
//                Gizmos      .DrawRay(pivot.position, pivot.forward);
//            }
//        }
//    }
//}
