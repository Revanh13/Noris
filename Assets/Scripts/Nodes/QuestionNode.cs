using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;


[Node(false, "Nodes/QuestionNode")]
public class QuestionNode : Node
{
    public const string ID = "QuestionNode";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Question"; } }
    public override Vector2 DefaultSize { get {return new Vector2(200, 200); } }

    [ConnectionKnob("Input", Direction.In, "Flow", NodeSide.Left)]
	public ConnectionKnob flowIn;
    [ConnectionKnob("Child 1", Direction.Out, "Flow")]
	public ConnectionKnob flowChild1;
    

    public override void NodeGUI () 
    {
        name = RTEditorGUI.TextField (name);
        
        foreach (ConnectionKnob knob in connectionKnobs) 
             knob.DisplayLayout ();
    }
}
