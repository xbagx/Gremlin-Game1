using Godot;
using System;

public partial class State : Node
{
	//Declaring the 
	//public PlayerStateMachine PlayerStateMachine;
	
	public virtual void Enter(){}
	public virtual void Exit(){}
	
	public virtual void Ready(){}
	public virtual void Update(float delta){}
	public virtual void PhysicsUpdate(float delta){}
	public virtual void HandleInput(InputEvent @event){}

}
