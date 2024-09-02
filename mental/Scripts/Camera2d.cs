using Godot;
using System;

public partial class Camera2d : Camera2D
{
	// Called when the node enters the scene tree for the first time.
	Vector2 CameraZoom = new Vector2(3,3);
	
	public override void _Ready()
	{
		Zoom = CameraZoom; 
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	
	}
}
