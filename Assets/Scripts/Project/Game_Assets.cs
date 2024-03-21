using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SublimeFury
{
    public class Game_Assets : MonoBehaviour
    {
        public static Transform DamagePopup => Resources.Load<Transform>("Prefabs/Texts/Damage_Popup_Text");
    }
}