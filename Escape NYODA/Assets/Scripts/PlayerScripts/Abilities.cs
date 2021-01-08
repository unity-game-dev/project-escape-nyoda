using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectNyodaToolkit
{
    public class Abilities : Player
    {
        //inherits all properties of player script
        protected Player player;
        protected override void Initialization()
        {
            base.Initialization();
            //Get components of player
            player = GetComponent<Player>();
        }
    }
}
