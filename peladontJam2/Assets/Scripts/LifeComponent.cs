using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    [SerializeField]
    protected float maxLife = 10;

    [SerializeField]
    protected float life = 0;

    protected void Start()
    {
        life = maxLife;
    }

    //damage must be positive
    //returns true, if dead
    public virtual bool reciveDamage(float damage)
    {
        life -= damage;
        
        //si tenemos 0 o menos vida, destroy
        if(life <= 0) {
            Destroy(gameObject);
            return true;
        }
        return false;

        //LUIS HAZ TU COSA (SONIDO AQUI)

    }

}

