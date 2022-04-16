using Godot;
using Godot.Collections;
using System;

public class MaosFermentadas : CriticUse
{
    int mod;

    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        mod = 3 * critic;

        return new MessageNotificationData(
            baseMessage, new object[] { mod }, injectedWork.GetBaseImage()
        );
    }

    public override void DoEndMechanicLogic()
    {
        int orientation = SortOrientation();
        MyEnum.Atribute atribute = SortAtribute();

        string strOrientation = (orientation == 1) ? "Revez" : "Fortuna";
        main.CreateNewNotification(
            $"{strOrientation} em {atribute} por uma hora!", injectedWork.GetBaseImage()
        );
    }

    private int SortOrientation()
    {
        return RollCode.GetRandomCustomRoll(2);
    }

    private MyEnum.Atribute SortAtribute()
    {
        int random = RollCode.GetRandomCustomRoll(5);
        return (MyEnum.Atribute)(random-1);
    }


    public override int RequestCriticTest(MainInterface main)
    {
        return main.RequestWorkRoll(relatedWork) / 10;
    }
}
