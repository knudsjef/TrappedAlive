using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    GameObject Player;
    Rigidbody2D PlayerRigid;
    float MoveSpeed = 5;
    float JumpDistance;
    float JumpHeight;
    float PrevMoveSpeed;
    bool CanJump;
    public bool Left = false;
    [SerializeField]
    bool IsSquare;
    bool IsRect;
    bool Fallen;
    SpriteRenderer PlayerSprite;
    BoxCollider2D RectCollider;
    EdgeCollider2D TriCollider;
    CircleCollider2D CirCollider;

    [SerializeField]
    Sprite Square;

    [SerializeField]
    Sprite Rectangle;

    [SerializeField]
    Sprite Triangle;

    [SerializeField]
    Sprite Circle;

    [SerializeField]
    float RectJumpHeight = 7;

    [SerializeField]
    float FallJumpHeight = 3;
        
	// Use this for initialization
	void Start () {

        Player = this.gameObject;
        PlayerRigid = Player.GetComponent<Rigidbody2D>();
        PlayerSprite = Player.GetComponent<SpriteRenderer>();
        RectCollider = Player.GetComponent<BoxCollider2D>();
        TriCollider = Player.GetComponent<EdgeCollider2D>();
        CirCollider = Player.GetComponent<CircleCollider2D>();

        ChangeShape('S');
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && CanJump)
        {
            if (Fallen)
            {
                Move(-Player.transform.up);
            }
            else
            {
                Move(Player.transform.right);
            }
            Left = false;
        }
        else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && CanJump)
        {
            if (Fallen)
            {
                Move(Player.transform.up);
            }
            else
            {
                Move(-Player.transform.right);
            }
            Left = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (IsSquare)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Teleport();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (IsRect)
            {
                RectFall();
            }
        }
	}

    void Move(Vector3 Direction)
    {
        PlayerRigid.velocity = new Vector2(Direction.x * MoveSpeed, PlayerRigid.velocity.y);
    }

    void Jump()
    {
        if (CanJump)
        {
            if (IsSquare)
            {
                if (Left)
                {
                    PlayerRigid.velocity = new Vector2(-JumpDistance, JumpHeight);
                    CanJump = false;
                }
                else
                {
                    PlayerRigid.velocity = new Vector2(JumpDistance, JumpHeight);
                    CanJump = false;
                }
            }
            else
            {
                PlayerRigid.velocity = new Vector2(PlayerRigid.velocity.x, JumpHeight);
                CanJump = false;
            }
        }
    }

    void StopMovement()
    {
        PrevMoveSpeed = MoveSpeed;
        MoveSpeed = 0;
    }

    void ContinueMovement()
    {
        MoveSpeed = PrevMoveSpeed;
    }

    void Teleport()
    {
        StopMovement();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D Hit = Physics2D.Raycast(ray.origin, Vector2.down);
        if (Hit.transform.GetComponent<Teleportable>().TeleportPlatform)
        {
            Player.transform.position = Hit.point;
        }
        ContinueMovement();
    }

    void ChangeShape(char Shape)
    {
        if (Shape == 'S')
        {
            ToSquare();
        }
        else if (Shape == 'R')
        {
            ToRectangle();
        }
        else if (Shape == 'T')
        {
            ToTriangle();
        }
        else if (Shape == 'C')
        {
            ToCircle();
        }
    }

    void ToSquare()
    {
        PlayerSprite.sprite = Square;
        RectCollider.enabled = true;
        TriCollider.enabled = false;
        CirCollider.enabled = false;
        RectCollider.offset = new Vector2(-0.2713981f, 0);
        RectCollider.size = new Vector2(8.18669f, 7.71f);
        JumpDistance = 5;
        JumpHeight = 4;
        MoveSpeed = 5;
        IsSquare = true;
        IsRect = false;
    }

    void ToRectangle()
    {
        PlayerSprite.sprite = Rectangle;
        RectCollider.enabled = true;
        TriCollider.enabled = false;
        CirCollider.enabled = false;
        RectCollider.offset = new Vector2(-3.471959f, 0);
        RectCollider.size = new Vector2(2.166965f, 7.71f);
        JumpDistance = 0;
        MoveSpeed = 3;
        JumpHeight = RectJumpHeight;
        IsSquare = false;
        IsRect = true;
        Fallen = false;
        Player.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void ToTriangle()
    {
        PlayerSprite.sprite = Triangle;
        RectCollider.enabled = false;
        TriCollider.enabled = true;
        CirCollider.enabled = false;
        IsSquare = false;
        IsRect = false;
    }

    void ToCircle()
    {
        PlayerSprite.sprite = Circle;
        RectCollider.enabled = false;
        TriCollider.enabled = false;
        CirCollider.enabled = true;
        IsSquare = false;
        IsRect = false;
    }

    void RectFall()
    {
        Player.transform.rotation = Quaternion.Euler(0, 0, 90);
        JumpHeight = FallJumpHeight;
        Fallen = true;
    }

    void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Ground")
        {
            CanJump = true;
        }
        else if (Col.gameObject.tag == "Rectangle Changer")
        {
            ChangeShape('R');
        }
        else if (Col.gameObject.tag == "Triangle Changer")
        {
            ChangeShape('T');
        }
        else if (Col.gameObject.tag == "Square Changer")
        {
            ChangeShape('S');
        }
        else if (Col.gameObject.tag == "Circle Changer")
        {
            ChangeShape('C');
        }
    }

}
