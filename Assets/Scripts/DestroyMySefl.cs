using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMySefl : MonoBehaviour
{
    [SerializeField]private float timeCoolDowm=1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy",timeCoolDowm);
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
