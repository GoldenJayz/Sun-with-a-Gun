using UnityEngine;
using UnityEngine.SceneManagement;



public class CameraScript : MonoBehaviour
{
    public float lastY = -2f; // The last Y coordinate of the camera NOTE: Also set to 1.62 so it follows the player immediately
    private int frame = 0;

    private void Update()
    {
        GameObject player = GameObject.Find("character"); // Finds the player so we can check the players Y position later
        Main otherScript = player.GetComponent<Main>(); // Getting the character and getting the script from withinside to access all the fields and properties
        Vector3 pos = transform.position; // This is storing the Vector that contains the Cameras position
        float playersAlt = player.GetComponent<Transform>().position.y; // This gets the players Y pos
        

        if (playersAlt >= lastY) // Checks if the players Y pos is more than the Cameras last Y so the camera can follow the player
        {
            transform.position = new Vector3(pos.x, playersAlt, pos.z);
            if (frame > 60 * 5) lastY = pos.y - 0.2f; // Sets the last Y coordinate so the camera does not fall back down
        }
        else if (playersAlt < lastY)
        {
            Destroy(player);
            Debug.Log("CameraScript ended the game");
            SceneManager.LoadScene("Scenes/GameOver"); // I need to also destroy the class
            for(int i = 0; i < otherScript.objects.Count; i++) // Destroys all of the Objects manually
            {
                Destroy(otherScript.objects[i]);
            }
            // Debug.Log($"LastY: {lastY}, Players Pos: {playersAlt}, Cam Pos: {pos.y}");
        }
        
        frame++;   
    }
}