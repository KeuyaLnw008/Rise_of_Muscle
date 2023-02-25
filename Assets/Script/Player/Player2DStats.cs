using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2DStats : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private GameObject bulletInstance;

    [Header("Stats")]
    [SerializeField] public Player2DProfile _player;
    public int PlayerHP { get; set; }
    private float nextFire = 0;
    private Transform bulletPoint;
    [SerializeField] private Transform bulletPoint1, bulletPoint2;

    private Animator animator;
    private GameObject playerHPController;
    private int inputPlayer;

    private KeyCode fireButton;
    private KeyCode leftButton;
    private KeyCode rightButton;
    private Vector2 leftRight  = new Vector2(1,0);
    // Start is called before the first frame update
    void Start()
    {
        playerHPController = GameObject.FindGameObjectWithTag("PlayerHP");
        if (this.GetComponent<Player2DMovement>().inputPlayer == 1)
        {
            inputPlayer = 1;
            PlayerHP = playerHPController.GetComponent<HpMain>().HpPlayer1;
        }
        else if (this.GetComponent<Player2DMovement>().inputPlayer == 2)
        {
            inputPlayer = 2;
            PlayerHP = playerHPController.GetComponent<HpMain>().HpPlayer2;
        }
        bulletPoint = bulletPoint1;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputPlayer == 1)
        {
                playerHPController.GetComponent<HpMain>().HpPlayer1 = PlayerHP;
        }
        else if (inputPlayer == 2)
        {
                playerHPController.GetComponent<HpMain>().HpPlayer2 = PlayerHP;
        }
        else { }
        CheckLeftRight();
        Attack();
        StartCoroutine(Die());
    }
    void Attack()
    {
        if (inputPlayer == 1)
        { 
            fireButton = KeyCode.F;
            leftButton = KeyCode.A;
            rightButton = KeyCode.D;
        }
        else if (inputPlayer == 2)
        { 
            fireButton = KeyCode.Slash;
            leftButton = KeyCode.LeftArrow;
            rightButton = KeyCode.RightArrow;
        }
        if (Input.GetKeyDown(fireButton))
        {
            animator.SetBool("Attack", true);
            
            if (Time.time >= nextFire)
            {
                nextFire = _player.fireRate;
                bulletInstance = Instantiate(bullet, bulletPoint.position, transform.rotation);
                bulletInstance.GetComponent<Rigidbody2D>().velocity = leftRight * _player.bulletSpeed;
                bulletInstance.GetComponent<Bullet>().Damage = _player.damage;
            }
        }
        if(Input.GetKeyUp(fireButton))
        { animator.SetBool("Attack", false); }

        //Player 1
        if (Input.GetKeyDown(KeyCode.F))
        {
            SoundManager.instance.Play(SoundManager.SoundName.Player1Attack);
        }
        //Player 2
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            SoundManager.instance.Play(SoundManager.SoundName.Player2Attack);
        }
    }
    void CheckLeftRight()
    {
        if (Input.GetKeyDown(leftButton))
        {
            leftRight = Vector2.left;
            bulletPoint = bulletPoint2;
        }
        if(Input.GetKeyDown(rightButton))
        {
            leftRight = Vector2.right;
            bulletPoint = bulletPoint1;
        }
    } 
    IEnumerator Die()
    {
        if (PlayerHP < 1)
        {
            if (inputPlayer == 1)
            {
                SoundManager.instance.Play(SoundManager.SoundName.Player1Dead);
            }
            if (inputPlayer == 2)
            {
                SoundManager.instance.Play(SoundManager.SoundName.Player2Dead);
            }
            animator.SetBool("Die", true);
            yield return new WaitForSeconds(3);
            Destroy(GameObject.FindGameObjectWithTag("Dont"));
            SceneManager.LoadScene("Deadscene");
            
        }
        else animator.SetBool("Die", false);


    }
}
