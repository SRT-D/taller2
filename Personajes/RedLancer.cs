using Godot;
using System;

public partial class RedLancer : Enemy
{
    public override void _Ready()
    {
        
        base._Ready();
        Health = 3;
    }
}
