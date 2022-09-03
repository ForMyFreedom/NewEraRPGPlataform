using Godot;
using Godot.Collections;
using System;

public class NaoSeraoOsUltimosSocorros : CriticUse
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        Medicine medicine = main.GetSkillByWorkAndIndex(relatedWork, 0) as Medicine;
        return medicine.DoMechanicLogic(main, 0, (4 * critic) / 10);
    }

    public override void DoEndMechanicLogic()
    {
    }

    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
