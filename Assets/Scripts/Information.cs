using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    public int maxHealth=100;
    public int cur_Health;
    public int atk=40;
    public GameObject deathVFX;
    [SerializeField]protected Transform deathVFXSpawnPos;
    [SerializeField]protected HealthBar healthBar;

    public bool isHurt=false;
    public bool isHurting=false;
    public bool isDeath=false;

    public float timeHurt=1f;
    protected float cur_TimeHurt=0f;
    private void Awake()
    {
        cur_Health=maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        healthBar.SetHealth(cur_Health);
    }
    protected virtual void Update()
    {
        if(cur_TimeHurt<timeHurt)
        {
            cur_TimeHurt+=Time.deltaTime;
        }
        else
        {
            isHurting=false;
        }
    }
    public virtual void TakeDamege(int dame)
    {
        if(isDeath)
            return;
        cur_Health -=dame;
        healthBar.SetHealth(cur_Health);
        if(cur_Health<=0)
        {
            isDeath=true;
            Die();
        }
        else
        {
            isHurting=true;
            cur_TimeHurt=0f;
            isHurt=true;
        }
    }

    protected virtual void Die()
    {
        Instantiate(deathVFX,deathVFXSpawnPos.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
}
