using ShipMotorika;
using System;
using System.IO;
using UnityEngine;

[Serializable]
public class PlayerSettings
{
    public bool sideControlButtonsEnabled;
    public float soundVolume;
    public float musicVolume;
    public string playerName;
    public int avatarSpriteIndex = 0;
    public int questID;
}
