using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    //variables
    private GameController gameController;
    public GameObject character;

    private Rigidbody2D characterBody;

    private float ScreenWidth;


    // Use this for initialization
    void Start()
    {
        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        //loop over every touch found
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                FlyCharacter(1.0f);
            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                FlyCharacter(-1.0f);
            }
            i++;
        }

        checkCharacterPos();
    }
    void FixedUpdate()
    {
#if UNITY_EDITOR
        FlyCharacter(Input.GetAxisRaw("Vertical"));
        checkCharacterPos();
#endif

    }

    private void FlyCharacter(float verticalInput)
    {
        float moveSpeed = gameController.playerSpeed;

        characterBody.velocity = new Vector2(0, verticalInput * moveSpeed);
    }

    private void checkCharacterPos()
    {
        if (transform.position.y > gameController.maxY)
        {
            transform.position = new Vector3(transform.position.x, gameController.maxY, 0);
        }
        else if (transform.position.y < gameController.minY)
        {
            transform.position = new Vector3(transform.position.x, gameController.minY, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        gameController.gameOver(other.gameObject);
    }
}