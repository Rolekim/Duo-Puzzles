using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeController : MonoBehaviour
{

    public static ChangeController changeController;

    [SerializeField]
    Animator wallsAnimator = null;
    public bool canMove = true;
    public bool canDoubleJump = false;
    public bool canJump = false;

    [SerializeField]
    GameObject redGO = null;
    [SerializeField]
    Character redCharacter = null;
    [SerializeField]
    Rigidbody2D redrb = null;
    [SerializeField]
    SpriteRenderer redSprite = null;


    [SerializeField]
    GameObject blueGO = null;
    [SerializeField]
    Character blueCharacter = null;
    [SerializeField]
    Rigidbody2D bluerb = null;
    [SerializeField]
    SpriteRenderer blueSprite = null;

    [SerializeField]
    GameObject blueBackGround = null;
    [SerializeField]
    GameObject redBackGround = null;

    Character characSelected = null;
    GameObject characterSelected = null;
    SpriteRenderer spriteSelected = null;
    Rigidbody2D rbSelected = null;

    [SerializeField]
    Sprite moveButtonBlue = null;
    [SerializeField]
    Sprite moveButtonRed = null;
    [SerializeField]
    Sprite JumpButtonBlue = null;
    [SerializeField]
    Sprite JumpButtonRed = null;
    [SerializeField]
    Button moveButtonLeft = null;
    [SerializeField]
    Button moveButtonRight = null;
    [SerializeField]
    Button JumpButton = null;
    [SerializeField]
    float groundCheckRad = 0.5f;
    [SerializeField]
    LayerMask groundMask = 0;

    [SerializeField]
    Animator flashAnim = null;
    [SerializeField]
    bool canChange = false;
    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;
    Ray ray;
    RaycastHit2D hit;
    bool moving = false;


    //Cambiar GO a listad de GO (una azul y otra roja)
    void Awake()
    {
        changeController = this;
    }

    void Start()
    {
        wallsAnimator.SetTrigger("OpenWallsInGame");
        characterSelected = redGO;
        characSelected = redCharacter;
        spriteSelected = redSprite;
        rbSelected = redrb;
        SetActiveBackground(redBackGround, blueBackGround, blueCharacter, redCharacter);
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Movimiento teclado
            float xAxis = Input.GetAxisRaw("Horizontal");
            characterSelected.transform.Translate(new Vector3(xAxis, 0f, 0f).normalized * (6 * Time.deltaTime));

            if (xAxis != 0)
            {
                characterSelected.GetComponent<Character>().ChangeToRun();
                if (xAxis < 0)
                {
                    if (!spriteSelected.flipX)
                        spriteSelected.flipX = true;
                }
                else
                {
                    if (spriteSelected.flipX)
                        spriteSelected.flipX = false;
                }
            }
            else
            {
                characSelected.ChangeToIddle();
            }
        }

    }

    void Update()
    {
        if (canMove)
        {
            if (DoubleClick() && canChange)
            {
                hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

                if (hit.collider != null)
                {
                    if (hit.collider.tag == "ChangeCollider")
                    {
                        ChangeCharacterSelected();
                        SoundManager.soundManager.PlayFlash();
                        Debug.Log("Cambio");
                    }
                }
            }
        }
    }
   

    public void ChangeCharacterSelected()
    {
        flashAnim.SetTrigger("Flash");
        StartCoroutine(ChangeCharactersCoroutine());
    }

    IEnumerator ChangeCharactersCoroutine()
    {
        yield return new WaitForSeconds(0.05f);

        var objects = FindObjectsOfType<Object>();
        var text = FindObjectsOfType<TutorialText>();

        if (objects != null)
        {
            foreach (Object o in objects)
            {
                if (o != null)
                {
                    o.ChangeActiveSprite();
                }
            }
        }

        if (text != null)
        {
            print("Hey");
            foreach (TutorialText t in text)
            {
                if (t != null)
                {
                    t.ChangeColor();
                }
            }
        }


        if (characterSelected == redGO)
        {
            characterSelected = blueGO;
            characSelected = blueCharacter;
            spriteSelected = blueSprite;
            rbSelected = bluerb;
            SetActiveBackground(blueBackGround, redBackGround, redCharacter, blueCharacter);
            JumpButton.image.sprite = JumpButtonBlue;
            moveButtonRight.image.sprite = moveButtonBlue;
            moveButtonLeft.image.sprite = moveButtonBlue;
        }
        else
        {
            characSelected = redCharacter;
            characterSelected = redGO;
            spriteSelected = redSprite;
            rbSelected = redrb;
            SetActiveBackground(redBackGround, blueBackGround, blueCharacter, redCharacter);
            JumpButton.image.sprite = JumpButtonRed;
            moveButtonRight.image.sprite = moveButtonRed;
            moveButtonLeft.image.sprite = moveButtonRed;
        }
    }


    void SetActiveBackground(GameObject trueBackground, GameObject falseBackground, Character freeze, Character iddle)
    {
        trueBackground.SetActive(true);
        falseBackground.SetActive(false);
        freeze.ChangeToFreeze();
        iddle.ChangeToIddle();
    }

    public Character ReturnCharacter()
    {
        return characSelected;
    }

    public GameObject ReturnCharacterSelected()
    {
        return characterSelected;
    }

    public SpriteRenderer ReturnSpriteSelected()
    {
        return spriteSelected;
    }

    public Rigidbody2D ReturnRBSelected()
    {
        return rbSelected;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        if(characterSelected != null)
        {
            Gizmos.DrawSphere(characterSelected.transform.position, groundCheckRad);
        }
       
    }

    public bool isGrounded(GameObject character)
    {
        return Physics2D.OverlapCircle
            (
                character.transform.position,
                groundCheckRad,
                groundMask
            );
    }

    public void ChangeCanSwitch(bool can)
    {
        canChange = can;
    }

    bool DoubleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked++;
            Debug.Log("Click");
            if (clicked == 1) 
            {
                clicktime = Time.time;
            }
        }
        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            clicked = 0;
            clicktime = 0;
            Debug.Log("Double Click");
            return true;
        }
        else if (clicked > 2 || Time.time - clicktime > 1)
        {
            clicked = 0;
        }

        return false;
    }
}
