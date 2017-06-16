using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    GameObject Player;
    Rigidbody2D PlayerRigid;
    float MoveSpeed = 5;
    float JumpDistance;
    float JumpHeight;
    float PrevMoveSpeed;
    float GravityY;
    bool CanJump;
    public bool Left = false;
    [SerializeField]
    bool IsSquare;
    bool IsRect;
    bool Fallen;
    bool OnRamp;
    SpriteRenderer PlayerSprite;
    BoxCollider2D RectCollider;
    EdgeCollider2D TriCollider;
    CircleCollider2D CirCollider;

    [SerializeField]
    char StartShape;

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
    void Start()
    {

        Player = this.gameObject;
        PlayerRigid = Player.GetComponent<Rigidbody2D>();
        PlayerSprite = Player.GetComponent<SpriteRenderer>();
        RectCollider = Player.GetComponent<BoxCollider2D>();
        TriCollider = Player.GetComponent<EdgeCollider2D>();
        CirCollider = Player.GetComponent<CircleCollider2D>();

        ChangeShape(StartShape);
    }

    // Update is called once per frame
    void Update()
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
            if (TriCollider.enabled == false)
            {
                Jump();
            }
            else
            {
                if (CanJump)
                {
                    TriangleWallJump(Left);
                }
            }
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
            else if (IsRect)
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

    void TriangleWallJump(bool JumpLeft)
    {
        if (TriCollider.enabled == true)
        {
            CanJump = false;
            if (PlayerRigid.velocity.y < 0)
            {
                if (JumpLeft)
                {
                    PlayerRigid.velocity = new Vector2(-3, -7);
                }
                else
                {
                    PlayerRigid.velocity = new Vector2(3, -7);
                }
            }
            else
            {
                if (JumpLeft)
                {
                    PlayerRigid.velocity = new Vector2(-3, 7);
                }
                else
                {
                    PlayerRigid.velocity = new Vector2(3, 7);
                }
            }
        }
    }

    void ToSquare()
    {
        PlayerSprite.sprite = Square;
        RectCollider.enabled = true;
        TriCollider.enabled = false;
        CirCollider.enabled = false;
        RectCollider.offset = new Vector2(0.02245971f, 0.03265064f);
        RectCollider.size = new Vector2(5.117493f, 5.163211f);
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
        else if (Col.gameObject.tag == "Left Wall")
        {
            TriangleWallJump(false);
        }
        else if (Col.gameObject.tag == "Right Wall")
        {
            TriangleWallJump(true);
        }

    }
}
