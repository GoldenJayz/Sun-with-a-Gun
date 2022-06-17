using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3D : MonoBehaviour
{
    public GameObject Player; 
    public float PlayerPosZ;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Cube");
        PlayerPosZ = Player.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerPosZ);
        transform.position = new Vector3(transform.position.x, transform.position.y, PlayerPosZ);
    }
}
