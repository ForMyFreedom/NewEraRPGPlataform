using Godot;
using Godot.Collections;
using System;

public class EnterrarOponente : CriticUse
{
    int damageExtra;

    //In this use, the critic value means the amount of meters!
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = critic*10;
        
        if (critic < 0)
            critic = result / 4;

        if (critic > 20)
            critic = 20;

        damageExtra = 2 * critic;
        main.AddExtraDamage(damageExtra);


        return new MessageNotificationData(
            baseMessage, new object[] { result, damageExtra }, criticImage
        );
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-damageExtra);
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestAtributeRoll(MyEnum.Atribute.AGI) / 10;
    }
}
