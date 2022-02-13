using Godot;
using Godot.Collections;
using System;

public class NaoSeraoOsUltimosSocorros : CriticUse
{
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        if (critic < 0)
            critic = (main.RequestWorkRoll(relatedWork)/10) *4;
        
        main.CreateNewNotification(
            partsOfMessage[0]+critic+partsOfMessage[1],
            injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
    }
}
