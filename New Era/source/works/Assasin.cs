using Godot;
using System;

public class Assasin : Work
{
    public override void DoFirstUpStep(MainInterface gui)
    {
        gui.AddAgility(1);
    }

    public override void DoSecondUpStep(MainInterface gui)
    {
        gui.CreateNewNotification(GetCreatePowerMessage(), baseImage);
    }

    public override void DoThirdUpStep(MainInterface gui)
    {
        gui.CreateNewNotification($"Voce alcansou uma maestria de {workName}! "+
            "Escolha entre: \n"+maestryDescription, baseImage);
    }


    public override int GetBaseDamage(MainInterface gui, int actionIndex=0)
    {
        int weapon = 10;//@getFirstWeaponDamage[com actionindex]
        return weapon+gui.GetAtributeNodeByEnum(relationedAtribute).GetAtributeValue()/2;
    }
}
