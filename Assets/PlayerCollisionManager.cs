using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    public Collider[] objectsToIgnore; // Assign the colliders of the objects you want to ignore collisions with in the Inspector
    public CharacterController characterController;
    public Collider Player;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Ignore collisions between the character controller and the specified objects
        foreach (Collider objCollider in objectsToIgnore)
        {
            Physics.IgnoreCollision(characterController, objCollider, true);
            Physics.IgnoreCollision(Player, objCollider, true);
        }
    }
}
