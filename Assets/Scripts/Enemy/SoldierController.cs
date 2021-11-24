using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierController : MonoBehaviour
{
    private Animator anim;
    private GameObject player;
    private BoxCollider attack;
    private PlayerControllerF lifePlayer;
    private bool placePlayer, isPunch, isDamage;
    private float timeDestroy = 3.5f, rotationEnemy = 1.5f, speedEnemy, visionPoint, resetTime;
    private float damageFist = 1, maxLifeEnemy;

    [SerializeField] float lifeEnemy;
    [SerializeField] float timeAttack = 2f, timeDamage = 1.5f;
    [SerializeField] bool isDeath;
    [SerializeField] Image lifeBarEnemy;
    [SerializeField] Text txtPlay;


    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        attack = GameObject.FindGameObjectWithTag("Attack").GetComponent<BoxCollider>();
        lifePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerF>();
        resetTime = timeAttack;
        lifeEnemy = 10f;
        speedEnemy = 2f;
        visionPoint = 14f;
        maxLifeEnemy = lifeEnemy;
        txtPlay.text = "";
    }

    void Update()
    {

        if (isDeath == true)
        {
            timeDestroy -= Time.deltaTime;

            if (timeDestroy <= 0)
            {
                Destroy(gameObject);
                Debug.Break();
            }
        }
        else
        {
            MoveTowards();
            LookAtPlayer();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fist")
        {
            lifeEnemy -= damageFist;
            lifeBarEnemy.fillAmount = lifeEnemy / maxLifeEnemy;

            if (lifeEnemy >= 1)
            {
                anim.SetTrigger("isHit");
            }

            isDamage = true;
        }

        if (lifeEnemy == 0)
        {
            anim.SetTrigger("isDeath");
            isDeath = true;
            txtPlay.text = "Fin del juego. ¡Has ganado!";
        }
    }


    private void MoveTowards()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;

        if ((Vector3.Distance(player.transform.position, transform.position) > visionPoint))
        {
            anim.SetFloat("SpeedY", 0f);
        }
        else
        {

            if (Vector3.Distance(player.transform.position, transform.position) <= 1.01f)
            {
                anim.SetFloat("SpeedY", 0f);
                placePlayer = true;
            }
            else
            {
                transform.position += speedEnemy * direction * Time.deltaTime;
                anim.SetFloat("SpeedY", 1f);
                placePlayer = false;
            }

            if (placePlayer == true && lifePlayer.lifePlayer > 0)
            {
                if (timeAttack == resetTime)
                {
                    Punch();
                    isPunch = true;
                }

                if (isPunch)
                {
                    timeAttack -= Time.deltaTime;

                    if (timeAttack <= 0)
                    {
                        timeAttack = resetTime;
                    }
                }

                if (isDamage)
                {
                    timeDamage -= Time.deltaTime;

                    if (timeDamage <= 0)
                    {
                        isDamage = false;
                    }
                }
            }
        }

    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationEnemy * Time.deltaTime);
    }

    private void Punch()
    {
        anim.SetTrigger("isPunch");
    }

    private void ActivateCollider()
    {
        attack.enabled = true;
    }

    private void DesactivarCollider()
    {
        attack.enabled = false;
    }
}
