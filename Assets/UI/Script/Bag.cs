using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIFramework
{

    public class Bag : BasePanel
    {
        public static bool _isPause;

        private void Start()
        {

            //Packet_Left.RefreshItemInPacker();
            //Packet_Right.RefreshItemInPacker();

        }

        public override void OnEnter()
        {
            base.OnEnter();
            _isPause = true;

        }


        public override void OnExit()
        {
            base.OnExit();
            _isPause = false;
        }


    }
}
