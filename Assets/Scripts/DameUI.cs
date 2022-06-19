using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DameUI : MonoBehaviour
{
    private RectTransform trans;
    [SerializeField]private TMP_Text dameText;
    // Start is called before the first frame update
    void Start()
    {
        trans=GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        trans.Translate(Vector3.up*Time.deltaTime*3);
    }
    public void SetDameUI(int _dame)
    {
        dameText.text="-" + _dame.ToString();
    }
}
