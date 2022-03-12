using Godot;
using Godot.Collections;
using System;

using Entities.Interface;
using Capacities;

public class EnxameDaAbelha : CriticUse
{
    public override void DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        main.CreateNewNotification(
            baseMessage, injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
