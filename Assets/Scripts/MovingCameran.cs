using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCameran : MonoBehaviour
{
    private static float sqrt2 = 1.41f;
    private float speed = 1f;
    private bool direction = false; //true - forward; false - right
    private static Vector3 PreviousPosition = new Vector3(0, sqrt2, 10);
    private float eps = 0.0001f;
    private bool startgame = true;

    [SerializeField]
    public Transform Camera;
    public Transform TouchSceen;
    public Transform Character;
    public GameObject Block;

    void GenerateNewBlock()
    {
        
        if (System.Math.Abs(PreviousPosition.x - 3 * sqrt2 / 2) < eps)
        {
            //MaxRight Position
            PreviousPosition = new Vector3(PreviousPosition.x - sqrt2 / 2, PreviousPosition.y + sqrt2 / 2, PreviousPosition.z);
            Instantiate(Block, PreviousPosition, Quaternion.Euler(0, 0, 45));
        } else
        {
            if (System.Math.Abs(PreviousPosition.x + 3 * sqrt2 / 2) < eps)
            {
                //MaxLeft Position
                PreviousPosition = new Vector3(PreviousPosition.x + sqrt2 / 2, PreviousPosition.y + sqrt2 / 2, PreviousPosition.z);
                Instantiate(Block, PreviousPosition, Quaternion.Euler(0, 0, 45));
            }
            else
            {

                //Debug.Log(Random.Range(0f, 1f));
                //Random
                if (Random.Range(0f, 1f) >= 0.5f)
                {
                    PreviousPosition = new Vector3(PreviousPosition.x - sqrt2 / 2, PreviousPosition.y + sqrt2 / 2, PreviousPosition.z);
                    Instantiate(Block, PreviousPosition, Quaternion.Euler(0, 0, 45));
                } else
                {
                    PreviousPosition = new Vector3(PreviousPosition.x + sqrt2 / 2, PreviousPosition.y + sqrt2 / 2, PreviousPosition.z);
                    Instantiate(Block, PreviousPosition, Quaternion.Euler(0, 0, 45));
                }
            }
        }
    }

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GenerateNewBlock();
        }
        StartCoroutine(Spawn ());
    }

    IEnumerator Spawn ()
    {
        while (true)
        {
            if (!startgame) GenerateNewBlock();
            yield return new WaitForSeconds(0.7f);
        }
    }

    //Change direction on tap
    void OnMouseDown()
    {
        if (!startgame)
        {
            direction = !direction;
        } else
        {
            startgame = !startgame;
        }
    }
    // Start is called before the first frame update
    /*void Start()
    {

    }*/
    // Update is called once per frame
    void Update()
    {
        if (!startgame && !Player.lose)
        {
            Camera.position = Vector3.MoveTowards(Camera.position, new Vector3(Camera.position.x, Camera.position.y + 0.05f, Camera.position.z), speed * Time.deltaTime);
            TouchSceen.position = Vector3.MoveTowards(TouchSceen.position, new Vector3(TouchSceen.position.x, TouchSceen.position.y + 0.05f, TouchSceen.position.z), speed * Time.deltaTime);
            if (direction)
            {
                Character.position = Vector3.MoveTowards(Character.position,
                    new Vector3(Character.position.x + 0.05f, Character.position.y + 0.05f, Character.position.z),
                    speed * sqrt2 * Time.deltaTime);
            }
            else
            {
                Character.position = Vector3.MoveTowards(Character.position,
                    new Vector3(Character.position.x - 0.05f, Character.position.y + 0.05f, Character.position.z),
                    speed * sqrt2 * Time.deltaTime);
            }
        }
    }
}
