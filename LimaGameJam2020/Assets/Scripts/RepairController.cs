using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairController : MonoBehaviour
{

    public ControladorMando controladorMando;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(controladorMando.LeftJoystick().x, controladorMando.LeftJoystick().y, 0) * Time.deltaTime);
    }
}
