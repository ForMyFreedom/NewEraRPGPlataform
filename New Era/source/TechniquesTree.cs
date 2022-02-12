using Godot;
using Godot.Collections;
using System;

public class TechniquesTree : Tree
{
    [Export]
    private Resource techniqueNameFont;
    [Export]
    private Resource techniqueDescriptionFont;

    private Array<Technique> techniques;
    private TreeItem[] itens = { };

    public override void _Ready()
    {
        Connect("gui_input", this, "_OnGuiInput");
        GetTree().CurrentScene.Connect("ready", this, "_OnTreeReady");
    }

    private void _OnTreeReady()
    {
        TreeItem root = CreateItem();
        itens = new TreeItem[GetTreeItemLength()];
        int itemIndex = 0;

        foreach (Technique currentTech in techniques)
        {
            AddNewTechniqueItem(root, itemIndex, currentTech);
            itemIndex++;

            AddTechniqueDescription(itemIndex, currentTech);
            itemIndex++;
        }

        MakeBlankUnselected(itens);
        InjectTechniqueInAllCriticUse();
    }


    private void AddNewTechniqueItem(TreeItem root, int itemIndex, Technique technique)
    {
        itens[itemIndex] = CreateItem(root);
        itens[itemIndex].SetText(0, GetTechniqueText(technique));
        itens[itemIndex].SetMetadata(0, technique);
    }

    private void AddTechniqueDescription(int itemIndex, Technique technique)
    {
        itens[itemIndex] = CreateItem(itens[itemIndex - 1]);
        itens[itemIndex].SetText(0, GetTechniqueDescription(technique));
    }


    private void _OnGuiInput(InputEvent @event)
    {
        if (!(@event is InputEventMouseButton)) return;
        var mouseEvent = (InputEventMouseButton) @event;
 
        TreeItem selected = GetSelected();
        if(selected==null) return;
        if (mouseEvent.Doubleclick &&
            this.GetSelected() != null &&
            selected.GetMetadata(0) is Technique)
                ExecuteTechnique((Technique)selected.GetMetadata(0));
    }


    private void ExecuteTechnique(Technique tech)
    {
        tech.DoMechanic((MainInterface) GetTree().CurrentScene);
    }


    private void MakeBlankUnselected(TreeItem[] itens)
    {
        foreach (TreeItem item in itens)
        {
            for (int i = 0; i < Columns; i++)
            {
                if (item.GetText(i) == "")
                {
                    item.SetSelectable(i, false);
                }
            }
        }
    }

    private void InjectTechniqueInAllCriticUse()
    {
        Array<Work> allWorks = GetMain().GetWorks();

        for (int i = 0; i < techniques.Count; i++)
        {
            Technique currentTech = techniques[i];
            MyEnum.Work[] currentEnumWorks = currentTech.GetRelatedWorks();
            Work[] actualWorksArray = new Work[currentEnumWorks.Length];

            for(int j = 0; j < currentEnumWorks.Length; j++)
            {
                actualWorksArray[j] = GetWorkByEnum(allWorks, currentEnumWorks[j]);
            }

            techniques[i].InjectWorks(actualWorksArray);
        }
    }


    private Work GetWorkByEnum(Array<Work> allWorks, MyEnum.Work we)
    {
        foreach(Work work in allWorks)
        {
            if (work.GetEnumWork() == we)
                return work;
        }
        return null;
    }



    public string GetTechniqueText(Technique tech)
    {
        string worksText = "";
        MyEnum.Work[] works = tech.GetRelatedWorks();

        for(int i = 0; i < works.Length; i++)
        {
            worksText += works[i];
            if (i != works.Length - 1)
                worksText += " - ";
        }

        return $"- {tech.GetTechniqueName()}    [{worksText}] [LVL {tech.GetLevel()}]";
    }

    private string GetTechniqueDescription(Technique technique)
    {
        return (
            $"Ofensivo: {technique.GetOfensiveLevel()}      "+
            $"Suporte: {technique.GetSuportLevel()}      " +
            $"Criticos: {GetCriticListWithLevel(technique)}"
        );
    }

    private string GetCriticListWithLevel(Technique technique)
    {
        string text = "";
        CriticUse[] uses = technique.GetCriticUses();
        for(int i = 0; i < uses.Length; i++)
        {
            text += $"{uses[i].GetUseName()} [{technique.GetPowerOfCritics()[i]}]";
            if (i != uses.Length - 1)
                text += " - ";
        }
        return text;
    }




    public Array<Technique> GetTechniques()
    {
        return techniques;
    }

    public void SetTechniques(Array<Technique> tech)
    {
        techniques = tech;
    }


    private MainInterface GetMain()
    {
        return (MainInterface) GetTree().CurrentScene;
    }

    private int GetTreeItemLength()
    {
        return 2*techniques.Count;
    }
}