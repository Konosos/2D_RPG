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
    [SerializeField]protected Transform dameUISpawnPos;
    [SerializeField]protected HealthBar healthBar;
    [SerializeField]protected GameObject bloodVFX;
    [SerializeField]protected GameObject dameUI;

    public bool isHurt=false;
    public bool isHurting=false;
    public bool isDeath=false;

    public float timeHurt=1f;
    protected float cur_TimeHurt=0f;

    public bool isFitter=false;
    public float timeFitter=1.5f;
    protected float cur_TimeFitter=0f;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        cur_Health=maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(cur_Health);
    }
    protected virtual void Update()
    {
        if(isHurting)
        {
            TimeHurt();
        }
        if(isFitter)
        {
            TimeFitter();
        }
    }
    private void TimeFitter()
    {
        if(cur_TimeFitter<timeFitter)
        {
            cur_TimeFitter+=Time.deltaTime;
        }
        else
        {
            isFitter=false;
        }
    }
    private void TimeHurt()
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
    public void TakeFitter()
    {
        isFitter=true;
        cur_TimeFitter=0f;
    }
    public virtual void TakeDamege(int dame)
    {
        if(isDeath)
            return;
        cur_Health -=dame;
        healthBar.SetHealth(cur_Health);
        Instantiate(bloodVFX,deathVFXSpawnPos.position,Quaternion.identity);
        SpawnDame(dame);
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
    protected virtual void SpawnDame(int _dame)
    {
        GameObject dameClone=Instantiate(dameUI,dameUISpawnPos.position,Quaternion.identity);
        DameUI dameScr=dameClone.GetComponent<DameUI>();
        dameScr.SetDameUI(_dame);
    }
    protected virtual void Die()
    {
        Instantiate(deathVFX,deathVFXSpawnPos.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
}
