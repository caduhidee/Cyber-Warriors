using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleMameInputs()
    {

        ///////////////////////////////////////////
        //  Default Keymap	
        ///////////////////////////////////////////
        /* Main Keys	
        5,6,7,8	   Insert coin	
        1,2,3,4	   Players 1 - 4 start buttons	
        
        Arrow Keys	Controller (Player 1)	
        
        Left Ctrl	Fire 1 (Player 1)	
        Left Alt	Fire 2 (Player 1)	
        Space	    Fire 3 (Player 1)	
        Left Shift	Fire 4 (Player 1)	
        Z	        Fire 5 (Player 1)	
        X           Fire 6(Player 1)	
        
        R,F,G,D	Controller (Player 2)	
        A         Fire 1 (Player 2)	
        S         Fire 2 (Player 2)	
        Q         Fire 3 (Player 2)	
        W         Fire 4 (Player 2)	
        E         Fire 5 (Player 2)	Not set by default
        T         Fire 6 (Player 2)	Not Set By Default	
        
        Playchoice 10 Additional Keys	
        5         Adds Time	
        0         Select Game	
        1         Toggles 1 or 2 Player Mode	
        2         Start Game
        */

        string msg = "";

        /////////////////////////////////////////////
        // Control Keys
        /////////////////////////////////////////////
        // Player 1 - Start
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Vector2 newDirection = Vector2.down;
            msg = "Button - Player 1 Start";
        }
        // Player 2 - Start
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Vector2 newDirection = Vector2.down;
            msg = "Button - Player 2 Start";
        }

        // Coin 1
        if (Input.GetKey(KeyCode.Alpha5))
        {
            Vector2 newDirection = Vector2.left;
            msg = "Button - Coin 1";
        }
        // Coin 2
        if (Input.GetKey(KeyCode.Alpha6))
        {
            Vector2 newDirection = Vector2.left;
            msg = "Button - Coin 2";
        }

        // Coin 2
        if (Input.GetKey(KeyCode.Alpha6))
        {
            Vector2 newDirection = Vector2.left;
            msg = "Button - Coin 2";
        }

        /////////////////////////////////////////////
        // Player 1 Movements
        /////////////////////////////////////////////
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 newDirection = Vector2.left;
            msg = "Player 1 - LeftArrow";
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 newDirection = Vector2.right;
            msg = "Player 1 - RightArrow";
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 newDirection = Vector2.up;
            msg = "Player 1 - UpArrow";
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 newDirection = Vector2.down;
            msg = "Player 1 - DownArrow";
        }


        /////////////////////////////////////
        // Player 1 Actions
        /////////////////////////////////////
        // Left Ctrl   Fire 1(Player 1)
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Vector2 newDirection = Vector2.left;
            msg = "Fire 1(Player 1)";
        }

        // Left Alt    Fire 2(Player 1)
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Vector2 newDirection = Vector2.right;
            msg = "Fire 2(Player 1)";
        }

        // Space Fire 3(Player 1)
        if (Input.GetKey(KeyCode.Space))
        {
            Vector2 newDirection = Vector2.up;
            msg = "Fire 3(Player 1)";
        }

        // Left Shift  Fire 4(Player 1)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector2 newDirection = Vector2.down;
            msg = "Fire 4(Player 1)";
        }

        // Z Fire 5(Player 1)
        if (Input.GetKey(KeyCode.Z))
        {
            Vector2 newDirection = Vector2.left;
            msg = "Fire 5(Player 1)";
        }

        // X Fire 6(Player 1)
        if (Input.GetKey(KeyCode.X))
        {
            Vector2 newDirection = Vector2.right;
            msg = "Fire 6(Player 1)";
        }




        /////////////////////////////////////////////
        // Player 2 Movements
        /////////////////////////////////////////////
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 newDirection = Vector2.left;
            msg = "Player 2 - LeftArrow";
        }
        if (Input.GetKey(KeyCode.G))
        {
            Vector2 newDirection = Vector2.right;
            msg = "Player 2 - RightArrow";
        }
        if (Input.GetKey(KeyCode.R))
        {
            Vector2 newDirection = Vector2.up;
            msg = "Player 2 - UpArrow";
        }
        if (Input.GetKey(KeyCode.F))
        {
            Vector2 newDirection = Vector2.down;
            msg = "Player 2 - DownArrow";
        }


        /////////////////////////////////////
        // Player 2 Actions
        /////////////////////////////////////

        // A   Fire 1(Player 2)
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 newDirection = Vector2.left;
            msg = "Fire 1(Player 2)";
        }

        // S   Fire 2(Player 2)
        if (Input.GetKey(KeyCode.S))
        {
            Vector2 newDirection = Vector2.right;
            msg = "Fire 2(Player 2)";
        }

        // Q   Fire 3(Player 2)
        if (Input.GetKey(KeyCode.Q))
        {
            Vector2 newDirection = Vector2.up;
            newDirection = Vector2.right;
            msg = "Fire 3(Player 2)";
        }

        // W   Fire 4(Player 2)
        if (Input.GetKey(KeyCode.W))
        {
            Vector2 newDirection = Vector2.down;
            newDirection = Vector2.right;
            msg = "Fire 4(Player 2)";
        }

        // NOT DEFAULT - E   Fire 5(Player 2)
        if (Input.GetKey(KeyCode.E))
        {
            Vector2 newDirection = Vector2.left;
            newDirection = Vector2.up;
            msg = "Fire 5(Player 2)";
        }

        // NOT DEFAULT - T   Fire 6(Player 2)
        if (Input.GetKey(KeyCode.T))
        {
            Vector2 newDirection = Vector2.right;
            newDirection = Vector2.up;
            msg = "Fire 6(Player 2)";
        }



        // Show which button was pressed
        if (msg != "")
        {
            Debug.Log(msg);
        }
    }
}
