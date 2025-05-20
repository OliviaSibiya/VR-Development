using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtRigScript : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    Vector3 targetLocation = new Vector3 (0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target.transform.position);
        this.transform.Rotate(90, 0, 0);

    }
}
