using UnityEngine;

public class CountChildren : MonoBehaviour
{
    // This method is called when the script starts
    void Start()
    {
        // Get the number of child objects
        int numberOfChildren = transform.childCount;

        // Print the result to the Unity Console
        Debug.Log("This GameObject has " + numberOfChildren + " child objects.");
    }
}