using Godot;
using System;

public abstract class Skill : Resource
{
    [Export]
    protected string skillName;
    [Export]
    protected Texture effectImage; 
    [Export]
    protected CSharpScript wayOfLevelCalculeScript;
    [Export]
    protected String skillDescription;
    [Export(PropertyHint.MultilineText)]
    protected String mechanicDescription;
    [Export]
    protected int level;

    public abstract void DoMechanic(MainInterface main);
    private WayOfCalculeSkill wayOfLevelCalcule;

    public String GetSkillName()
    {
        return skillName;
    }

    public void PlayWayOfLevelCalcule(WorkTree workTree, int workIndex, int skillIndex, int level)
    {
        wayOfLevelCalcule = (WayOfCalculeSkill)wayOfLevelCalculeScript.New();
        wayOfLevelCalcule.CalculeLevelSkill(workTree, workIndex, skillIndex, level);
    }


    public int GetLevel()
    {
        return level;
    }

    public void SetLevel(int l)
    {
        level = l;
    }

    public void AddLevel(int add)
    {
        level += add;
    }


    public String GetSkillDescription()
    {
        return skillDescription;
    }

    public void SetSkillDescription(String description)
    {
        skillDescription = description;
    }

    public String GetMechanicDescription()
    {
        return mechanicDescription;
    }

    public void SetMechanicDescription(String description)
    {
        mechanicDescription = description;
    }
}