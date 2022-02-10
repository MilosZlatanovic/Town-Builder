using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(FloatingTextComposition))]
public class PlayerMoving : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    private PlayerControls playerInput;

    Animator animator;
    float cutingTree;
    TreesControler trees;
    [SerializeField]
    GameObject cost;

    /*  [SerializeField]
      GameObject floatingTextPrefab;*/
    FloatingTextComposition floatingTextScript;
    int coints = 5;
    private void Awake()
    {
        playerInput = new PlayerControls();
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        floatingTextScript = GetComponent<FloatingTextComposition>();

        trees = GameObject.FindWithTag("Tree").GetComponent<TreesControler>();

        if (trees == null)
        {
            Debug.Log("TreesControler is: NULL");
        }

    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }



    private void Start()
    {
    }

    void Update()
    {
        // cutingTree;

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movementInput = playerInput.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            animator.SetBool("IsMove", true);
        }
        else
        {
            animator.SetBool("IsMove", false);
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
         
            animator.SetBool("IsCuting", true);
   
        }
        if (collision.gameObject.CompareTag("Buildings"))
        {
            collision.gameObject.GetComponentInChildren<Transform>().GetChild(0).gameObject.SetActive(false);
            collision.transform.DOLocalMoveY(2f, 2f);
            collision.transform.DOShakePosition(.1f, .05f, 1, 0, false, true);
        }

        if (collision.gameObject.CompareTag("LandBridge"))
        {
            collision.gameObject.GetComponentInChildren<Transform>().GetChild(0).gameObject.SetActive(false);
            collision.transform.DOLocalMoveY(-1.2f, 2f);
           // collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Construction"))
        {
            collision.transform.DOLocalMoveY(-1.2f, 2f);
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        animator.SetBool("IsCuting", false);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            collision.transform.DOLocalMoveY(-3.5f, 8f);
            collision.transform.DOShakePosition(.1f, .05f, 1, 0, false, false);
            //   floatingTextScript.ShowDamage(coints.ToString(), floatingTextPrefab);
        }
    }
}
