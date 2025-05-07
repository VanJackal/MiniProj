using Godot;
using System;

public partial class Weapon : Node2D
{

	[Export] public PackedScene projectileScene;
	[Export] public Node2D projectileOrigin;

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

		//todo rotate the weapon to face the mouse
	}

	public void PrimaryFire()
	{
		if (CanPrimaryFire())
		{
			Vector2 target = (GetGlobalMousePosition() - GetGlobalPosition()).Normalized(); // get the direction vector from the weapon
			FireProjectile(target);
		}
	}

	private void FireProjectile(Vector2 target)
	{
		Projectile fired = projectileScene.Instantiate<Projectile>();

		fired.SetVelocity(target);
		fired.SetGlobalPosition(projectileOrigin.GlobalPosition);
		AddChild(fired);
	}

	private bool CanPrimaryFire()
	{ // todo this should be made more advanced
		return Input.IsActionJustPressed("primary_fire");
	}
}
