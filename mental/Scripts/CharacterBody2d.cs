using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	public float Speed = 100.0f;
	
	private AnimatedSprite2D _animatedSprite;
	private CollisionShape2D _colShape;
	private Node2D _spriteFlipper;
	public enum State{idle, moving,dashing};
	State _currentState = State.idle;  
	//[Signal]
	//public delegate void DirectionChangeEventHandler(bool facingLeft);

	public override void _Ready()
	{
		_spriteFlipper = GetNode<Node2D>("Node2D");
		_animatedSprite = GetNode<AnimatedSprite2D>("Node2D/AnimatedSprite2D");
		_colShape = GetNode<CollisionShape2D>("CollisionShape2D");
	}
	
	public override void _PhysicsProcess(double delta) {
		Vector2 velocity = Velocity;
		Vector2 direction = Input.GetVector(
			"left", "right", "up", "down");
		GD.Print(_currentState);
		
		if(Input.IsActionJustPressed("dash") ){
			_currentState = State.dashing; 
		}
		//could change implementation of what happens within states as functions
		switch(_currentState)
		{
			case State.idle:
				_animatedSprite.Play("idle");
				velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
				velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
				
				//Transition to moving state
				if (direction != Vector2.Zero  ) {
					_currentState = State.moving;
				}

				
				break;
			
			case State.moving:
				Speed = 100.0f;
				velocity = direction * Speed;
				_animatedSprite.Play("move");
				
				if(direction == Vector2.Right){
					_spriteFlipper.Scale = new Vector2(1,1);
				}else if (direction == Vector2.Left){
					_spriteFlipper.Scale = new Vector2(-1,1);
				//Transition to idle state
				}else if(direction == Vector2.Zero){
					_currentState = State.idle; 
				}
				break; 
				
			case State.dashing:
				Speed = 2000.0f;
				//_colShape.Disabled = false; //DISABLE MASK 3 SINCE THAT IS THE LAYER OF THE FLOOR
				CollisionMask = 3;
				//If facing left
				if(_spriteFlipper.Scale == new Vector2(-1,1)) {
					velocity = Vector2.Left * Speed;
				}else{
					velocity = Vector2.Right * Speed;
				}
				
				//Need to figure out how to activate
				CollisionMask =3;
				
				// set_collision_layer_bit(0, false)  
				_currentState = State.idle; 
				break; 
		}	
		Velocity = velocity;
		MoveAndSlide();
	}
	
	

	
}
