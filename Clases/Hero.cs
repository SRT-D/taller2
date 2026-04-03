using Godot;
using System;

public partial class Hero : CharacterBody2D
{
    
     public float Speed { get; set; } = 150.0f;

    protected AnimatedSprite2D _animator;
    protected Timer _attackTimer;
    protected Timer _killTimer;
    protected Area2D _hitbox;
    protected Enemy _currentTarget; 

    public override void _Ready()
    {
       
        _animator = GetNode<AnimatedSprite2D>("Animator");
        _attackTimer = GetNode<Timer>("AttackTimer");
        _killTimer = GetNode<Timer>("KillTimer");
        _hitbox = GetNode<Area2D>("HitBox");

        _animator.Play("default");
    }

    
    protected void HandleMovement()
    {
        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

        if (direction != Vector2.Zero)
        {
            Velocity = direction * Speed;

            
            _animator.FlipH = direction.X < 0;

           
            if (_animator.Animation != "Attack")
            {
                _animator.Play("ui_right");
            }
        }
        else
        {
            Velocity = Velocity.MoveToward(Vector2.Zero, Speed);

            
            if (_animator.Animation != "Attack")
            {
                _animator.Play("default");
            }
        }

        MoveAndSlide();
    }

    protected void HandleAttackInput()
    {
        if (Input.IsActionJustPressed("ui_attack"))
        {
            ExecuteAttack();
        }
    }

    private void ExecuteAttack()
    {
        _animator.Play("Attack");
        _hitbox.Monitoring = true;
        _attackTimer.Start();
        _killTimer.Start();
    }

    
    protected void _OnHitBoxAttack(Node2D body)
    {
        if (body == this) return;

        if (body is Enemy enemy)
        {
            GD.Print("Objetivo fijado: ");
            _currentTarget = enemy;
        }
    }

    protected void _ResetAttack()
    {
        _animator.Play("default");
        _hitbox.Monitoring = false; 
        _killTimer.Stop();
    }

    protected void _OnKillEnemy()
    {
        _currentTarget.ReceiveDamage(1);
        _killTimer.Stop();
    }
}
