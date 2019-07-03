using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static bool lose = false;

    [SerializeField]
    public Rigidbody Character;

    private void Awake()
    {
        lose = false;
        Physics.gravity = new Vector3(0, 0, 9.81f);
        Character.useGravity = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Character.position.z > 9.26)
        {
            lose = true;
            Character.useGravity = false;
            Character.AddForce(new Vector3(0, 0, -9.81f));
        }   
    }
}
