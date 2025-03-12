using Godot;
using System;

public partial class MovementScript : CharacterBody2D
{
	private Sprite2D _sprite;

	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	public override void _Ready()
	{
		_sprite = GetNode<Sprite2D>("Icon");
	}

	public override void _PhysicsProcess(double delta)
	{
		// rotate
		if (Input.IsActionPressed("r_right"))
		{
			_sprite.Rotation += 5f * (float)delta;
		}
		else if (Input.IsActionPressed("r_left"))
		{
			_sprite.Rotation -= 5f * (float)delta;
		}

		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("m_left", "m_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
