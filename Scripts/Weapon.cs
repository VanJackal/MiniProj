using Godot;
using System;

public partial class Weapon : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//# input
		if (Input.IsActionPressed("primary_fire"))
		{
			PrimaryFire();
		}
	}

	public void PrimaryFire()
	{
		if (CanPrimaryFire())
		{
			GD.Print("PrimaryFire");
		}
	}

	private bool CanPrimaryFire()
	{ // this should be made more advanced
		return Input.IsActionJustPressed("primary_fire");
	}
}
