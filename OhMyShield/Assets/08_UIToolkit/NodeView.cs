
using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;

public class NodeView : UnityEditor.Experimental.GraphView.Node
{
	public Action<NodeView> OnNodeSelected;
    public Node node;
    public BehaviourTreeView treeView;
	public Port input;
	public Port output;

    public NodeView(Node node)
    {
        this.node = node;
        title = node.name;
		viewDataKey = node.guid;

		style.left = node.position.x;
		style.top = node.position.y;

		CreateInputPorts();
		CreateOutputPorts();
    }

	private void CreateInputPorts()
	{
		if (node is ActionNode)
		{
			input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
		}
		else if (node is CompositeNode)
		{
			input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
		}
		else if (node is DecoratorNode)
		{
			input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
		}
		else if (node is RootNode)
		{

		}

		if (input != null)
		{
			input.portName = "";
			inputContainer.Add(input);
		}
	}

	private void CreateOutputPorts()
	{
		if (node is ActionNode)
		{
		}
		else if (node is CompositeNode)
		{
			output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));
		}
		else if (node is DecoratorNode)
		{
			output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
		}
		else if (node is RootNode)
		{
			output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
		}

		if (output != null)
		{
			output.portName = "";
			outputContainer.Add(output);
		}
	}

	public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
	{
		{
			evt.menu.AppendAction($"[Delete]", (a) => 
			{
				treeView.DeleteNode(this);
			});
		}
	}

	public override void SetPosition(Rect newPos)
	{
		base.SetPosition(newPos);

		node.position.x = newPos.xMin;
		node.position.y = newPos.yMin;
	}

	public override void OnSelected()
	{
		base.OnSelected();

		OnNodeSelected?.Invoke(this);
	}
}
