using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	private float Speed = 60.0f;
	[Export]
	private float SprintMultipler=1.5f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		float moveSpeed = Speed;
		if(Input.IsActionPressed("sprint")){
			moveSpeed *= SprintMultipler;
		}
		if (direction != Vector2.Zero)
		{
			velocity = direction * moveSpeed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, moveSpeed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, moveSpeed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
