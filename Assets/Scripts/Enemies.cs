using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int healthPoints = 100;

    //int hitWidth;
    int damagetaken;

    ScoreBoard scoreBoard;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        playerController = FindObjectOfType<PlayerController>();
        HitWidthAnnouncer();
    }

   private void HitWidthAnnouncer()
    {
        damagetaken = playerController.DamageDeal();
       /* if (damagetaken > 0)
        {
            hitWidth = healthPoints / damagetaken;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        HitWidthAnnouncer();
    }
    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);
        healthPoints = healthPoints - damagetaken;
        if (healthPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
