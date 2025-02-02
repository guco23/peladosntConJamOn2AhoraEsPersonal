using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootComponentBigTrinchera : ShootComponent
{
    // Start is called before the first frame update
    void Start()
    {
        RandFireRate();
        elapsedTime = fireRate - firstShootDelay;

        soldierDectect = GetComponent<SoldierDetectSoldierComponent>();
        checker = GetComponent<InFrustrumChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting)
        {
            //control de tiempo
            elapsedTime += Time.deltaTime;

            if (elapsedTime > fireRate)
            {
                elapsedTime = 0;

                //si toca disparar, shoot
                shoot();
            }
        }

        if (target == null || target.GetComponent<LifeComponent>().getLife() <= 0)
        {
            StopShooting();
        }
    }

    //Overridear Start Shooting y Stop Shooting

    protected override void StartShooting()
    {
        shooting = true;

        RandFireRate();

        elapsedTime = fireRate - firstShootDelay;
    }

    public override void StopShooting()
    {
        target = null;
        shooting = false;
        soldierDectect.enemyDefeated();
    }


    protected override void shoot()
    {

        SpawnBullet();
        //si matamos al enemigo
        /*
        if (target.reciveDamage(damage))
        {
            target = null;
            shooting = false;
        }
         */

        //recalcular el fire rate(aleatorio entre min y max)
        RandFireRate();

        //Debug.Log("disparo");

        //llamar al sonido de disparo(LUIS HAZ TU COSA)
        if (checker.IsVisible)
        {
            //EventInstance soundInstance = RuntimeManager.CreateInstance(inputsound.Path);
            emitter.Play();
            //soundInstance.start();
            //soundInstance.release();
        }
    }
}