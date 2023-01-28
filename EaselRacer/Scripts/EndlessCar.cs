using System;
using Easel;
using Easel.Entities.Components;
using Easel.Math;
using Pie.Windowing;

namespace EaselRacer.Scripts;

public class EndlessCar : Component
{
    private float _velocity;

    // When the rotation is 0 (facing right), the multiplier is 1. Therefore, the entire car's velocity will be
    // translated here. When the rotation is 180 (facing left), we don't want the car to still move forward!
    public float Velocity => _velocity * MathF.Cos(Transform.SpriteRotation);

    public const float Acceleration = 1000;
    public const float Braking = 800;
    public const float Deceleration = 500;
    public const float MaxSpeed = 100000;
    public const float MaxRotation = 1.2f;

    private float _startingX;

    protected override void Initialize()
    {
        base.Initialize();

        _startingX = Transform.Position.X;
    }

    protected override void Update()
    {
        base.Update();
        
        // The trick with an endless scroller is that the car does not actually move.
        // Instead, only the background moves.

        if (Input.AnyKeyDown(Key.W, Key.Up, Key.S, Key.Down))
        {
            if (Input.AnyKeyDown(Key.W, Key.Up))
                _velocity += Acceleration * Time.DeltaTime;
            if (Input.AnyKeyDown(Key.S, Key.Down))
                _velocity -= Braking * Time.DeltaTime;
        }
        else
            _velocity -= Deceleration * Time.DeltaTime;

        if (Input.AnyKeyDown(Key.A, Key.Left))
            Transform.SpriteRotation -= MaxRotation * Time.DeltaTime;
        if (Input.AnyKeyDown(Key.D, Key.Right))
            Transform.SpriteRotation += MaxRotation * Time.DeltaTime;

        _velocity = EaselMath.Clamp(_velocity, 0, MaxSpeed);

        Transform.Position += Transform.Right * _velocity * Time.DeltaTime;
        Transform.Position.X = _startingX;
    }
}