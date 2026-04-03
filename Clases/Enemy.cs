using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
    protected int Health = 3;
    protected AnimatedSprite2D _animator;

    public override void _Ready()
    {
        
        _animator = GetNode<AnimatedSprite2D>("Animator");

       
        if (_animator != null)
        {
            _animator.Play("default");
        }
    }
    public virtual void ReceiveDamage(int amount)
    {
        Health -= amount;
        GD.Print("El enemigo recibio daño. Vida restante: " +  Health);

        if (Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        GD.Print("El enemigo ha sido derrotado.");
        QueueFree();
    }
}
