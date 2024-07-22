using UnityEngine;

public class DebugLogNode : ActionNode
{
	[TextArea] public string message;

	public DebugLogNode()
	{
		description = "�޽����� ����մϴ�.";
	}

	protected override void OnStart()
	{
		Debug.Log($"OnStart) {message}");
	}

	protected override void OnStop()
	{
		Debug.Log($"OnStop) {message}");
	}

	protected override State OnUpdate()
	{
		Debug.Log($"OnUpdate) {message}");

		return State.Success;
	}
}
