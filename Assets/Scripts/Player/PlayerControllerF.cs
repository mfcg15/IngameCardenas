using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerF : MonoBehaviour
{
    private float moveHorizontal, maxLifePlayer;

    private Animator anim;
    private BoxCollider fist;

    public float lifePlayer = 15;
    [SerializeField] float speed = 8f;
    [SerializeField] Image LifeBarPlayer;
    [SerializeField] Text txtPlay, NamePlayer;

    void Start()
    {
        anim = GetComponent<Animator>();
        fist = GameObject.FindGameObjectWithTag("Fist").GetComponent<BoxCollider>();
        maxLifePlayer = lifePlayer;
        txtPlay.text = "";
        NamePlayer.text = WelcomeManager.instance.GetPlayerName();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
    
        Attack();
    }

    private void Move()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(0, 0, moveHorizontal * Time.deltaTime * speed);
        anim.SetFloat("SpeedX", moveHorizontal);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Attack")
        {

            lifePlayer--;
            LifeBarPlayer.fillAmount = lifePlayer / maxLifePlayer;

            if (lifePlayer >= 1)
            {
                anim.SetTrigger("isHit");
            }

            if (lifePlayer == 0)
            {
                txtPlay.text = "Fin del juego. Has perdio";
                Debug.Break();
            }
        }

    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("isPunch");
        }
    }

    private void ActivateCollider()
    {
        fist.enabled = true;
    }

    private void DesactivarCollider()
    {
        fist.enabled = false;
    }
}
