using Godot;
using System;

public partial class Projectile : RigidBody2D
{
	[Export]
	private float _projectileSpeed = 10f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetVelocity(Vector2 velocity)
	{
		LinearVelocity = velocity * _projectileSpeed;
		Rotation = Mathf.Atan2(LinearVelocity.Y, LinearVelocity.X) ;
	}


	public void _on_body_entered(Node body)
	{
		GD.Print($"hit body: {body}");
		QueueFree();
	}
	public void _on_hitbox_body_exited(Node body)
	{
		GD.Print("body entered");
	}
}
