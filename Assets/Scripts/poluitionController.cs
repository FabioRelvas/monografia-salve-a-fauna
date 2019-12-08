using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poluitionController : MonoBehaviour
{
    private Rigidbody2D rBody;

    private GameController gameController;

    bool scored;

    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;

        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rBody.velocity = new Vector2(gameController.objSpeed, 0);

        if (transform.position.x <= gameController.tPlayer.transform.position.x && !scored)
        {
            gameController.scoreCount();
            scored = true;
        }

        if (transform.position.x <= -13)
        {
            Destroy(this.gameObject);
        }

        gameController.levelUp();
    }
}
