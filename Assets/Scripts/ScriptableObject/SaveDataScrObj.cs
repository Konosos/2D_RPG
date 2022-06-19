using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="VolumeVal", menuName="SaveData/SoundVal")]
public class SaveDataScrObj : ScriptableObject
{
    [Range(0,1)]
    public float musicVal;
    [Range(0,1)]
    public float sfxVal;

}
