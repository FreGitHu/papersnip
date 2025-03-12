
using Godot;
using System;

// renders a jumpy wiggly line.
public partial class LegDrawer : Line2D
{



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// clear the line
		ClearPoints();

		// draw the line with jumpy effect
		Random random = new Random();
		for (int i = 0; i < 10; i++)
		{
			float y = i * 10;
			float x = random.Next(-10, 10); // random y position to create a jumpy effect
			AddPoint(new Vector2(x, y));
		}
	}
}