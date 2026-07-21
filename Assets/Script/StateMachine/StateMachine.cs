
using UnityEngine;

public class StateMachine :IStateMachine
{
	INode _curNode;


	public StateMachine(INode startNode)
	{
		_curNode = startNode;
		startNode.SetStateMachine(this);
	}
	public void ChangeState(INode nextNode)
	{
		if (_curNode != null)
		{
			_curNode.OnEnd();
		}
		_curNode = nextNode;
		_curNode.SetStateMachine(this);
		_curNode.OnStart();
	}

	public void OnUpdate()
	{
		_curNode.OnUpdate();
	}

}
public interface IStateMachine
{
	void ChangeState(INode nextNode);
}
public interface INode
{
	void SetStateMachine(IStateMachine stateMachine);
	void OnStart();
	void OnUpdate();
	void OnEnd();
}
public class Node : MonoBehaviour, INode
{
	IStateMachine _statemachine;
	public virtual void OnEnd()
	{
	}

	public virtual void OnStart()
	{

	}

	public virtual void OnUpdate()
	{
		
	}

	public void SetStateMachine(IStateMachine stateMachine)
	{
		_statemachine = stateMachine;
	}
	protected  void ChangeState(Node node)
	{
		_statemachine.ChangeState(node);
	}
}
