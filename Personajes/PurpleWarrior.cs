using Godot;
using System;

public partial class PurpleWarrior : Hero
{

    public override void _Ready()
    {
       
        base._Ready();
        GD.Print("PurpleWarrior listo y nodos cargados.");
    }
    public override void _Process(double delta)
    {
       
        HandleMovement();
        HandleAttackInput();
    }

}
