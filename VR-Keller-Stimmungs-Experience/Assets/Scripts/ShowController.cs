using System.Collections;
using System.Collections.Generic;
using System.Media;
using System.Runtime.InteropServices;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ShowController : MonoBehaviour
{
    public bool sc = false;

    void Update()
    {
        foreach (var hand in Player.instance.hands)
        {
            if (sc)
            {
                hand.ShowController();
                hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithController);
            }
            else
            {
                hand.HideController();
                hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithController);
            }
        }
    }
}
