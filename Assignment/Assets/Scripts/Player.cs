using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    //allows to change the player's speed in the inspector
    public float playerSpeed;
    //allows to receive the values from the inputs
    private PlayerActions playerBehaviour;

    //allows to select the character controller in the inspector
    public CharacterController controller;

    //awake event - happens once the scene is loaded
    private void Awake() {
        //define the respective reference for the input actions
        playerBehaviour = new PlayerActions();

    }

    //happens once this object is enabled
    private void OnEnable() {
        //enables the input actions
        playerBehaviour.Player_Map.Enable();
    }

    // Update is called once per frame
    private void Update()
    {
        //adds the values from the inputs to the vector2 variable
        Vector2 inputVector = playerBehaviour.Player_Map.Movement.ReadValue<Vector2>();

        //adds the vector2 values into a new vector3 variable
        Vector3 move = new Vector3(inputVector.x, 0, inputVector.y);
        //makes the player move
         controller.Move(move * playerSpeed * Time.deltaTime);
    }
}
