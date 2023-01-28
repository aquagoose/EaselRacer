using System;
using Easel;
using Easel.Entities.Components;
using Easel.Math;

namespace EaselRacer.Scripts;

public class EndlessRoad : Component
{
    private EndlessCar _car;
    private Size<int> _textureSize;

    protected override void Initialize()
    {
        base.Initialize();

        _car = GetEntity("Player").GetComponent<EndlessCar>();
        _textureSize = GetComponent<Sprite>().Texture.Size;
    }

    protected override void Update()
    {
        base.Update();

        Transform.Position.X -= _car.Velocity * Time.DeltaTime;

        // TODO: Make this global
        const float numRoads = 3 - 1;

        if (Transform.Position.X + _textureSize.Height <= 0)
            Transform.Position.X = _textureSize.Height * numRoads + (Transform.Position.X + _textureSize.Height);
    }
}