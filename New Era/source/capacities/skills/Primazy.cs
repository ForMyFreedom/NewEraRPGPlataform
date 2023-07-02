using Godot;
using Godot.Collections;
using System;

public class Primazy : Skill
{
    public override MessageNotificationData DoMechanicLogic(MainInterface main, int actionIndex = 0, int critic = -1)
    {
        return new MessageNotificationData(notificationText, new object[] { level, (int)(level/2) }, effectImage);
    }

    public override void DoEndMechanicLogic() { }

    public override int RequestCriticTest(MainInterface main)
    {
        return 0;
    }
}