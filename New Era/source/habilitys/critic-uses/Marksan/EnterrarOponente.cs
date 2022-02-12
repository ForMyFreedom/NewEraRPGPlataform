using Godot;
using Godot.Collections;
using System;

public class EnterrarOponente : CriticUse
{
    int damageExtra;

    //In this use, the critic value means the amount of meters!
    public override void DoMechanic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        int result = main.RequestAtributeRoll(MyEnum.Atribute.AGI);

        if (critic < 0)
            critic = result / 4;

        damageExtra = (int)(1.5 * critic);
        main.AddExtraDamage(damageExtra);

        main.CreateNewNotification(
            $"Voce tenta agarrar um alvo com um Teste de Agilidade de {result}, caso venca, voce o agarra e comeca a voar\n"+
             "O alvo ainda tem um turno de direito. Caso continue agarrado, em seu turno a queda acontece!\n"+
            $"Voce causa +{damageExtra} Dano!", injectedWork.GetBaseImage()
        );

        ConnectToLastNotification(main);
    }

    public override void DoEndMechanicLogic()
    {
        main.AddExtraDamage(-damageExtra);
    }
}
