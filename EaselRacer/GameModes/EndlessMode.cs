using System.Numerics;
using Easel.Entities;
using Easel.Entities.Components;
using Easel.Graphics;
using Easel.GUI;
using Easel.Math;
using Easel.Scenes;
using EaselRacer.Scripts;

namespace EaselRacer.GameModes;

public class EndlessMode : Scene
{
    protected override void Initialize()
    {
        base.Initialize();
        
        // Tell Easel to use an orthographic 2D camera (aka make the scene a 2D scene).
        Camera.Main.UseOrtho2D();

        Texture2D playerSprite = Content.Load<Texture2D>("racecar");

        float screenCenter = Graphics.Renderer.MainTarget.Size.Height / 2f;
        
        Entity player = new Entity("Player", new Transform()
        {
            Position = new Vector3(100, screenCenter, 0),
            Origin = new Vector3(new Vector2(playerSprite.Size.Width, playerSprite.Size.Height) / 2, 0),
            Scale = new Vector3(0.15f, 0.15f, 1.0f)
        });
        player.AddComponent(new Sprite(playerSprite));
        player.AddComponent(new EndlessCar());
        AddEntity(player);

        Texture2D roadSprite = Content.Load<Texture2D>("highway");
        
        const float numRoads = 3;
        for (int i = 0; i < numRoads; i++)
        {
            Entity road = new Entity($"Road{i}", new Transform()
            {
                Position = new Vector3(i * roadSprite.Size.Height, screenCenter, -5),
                SpriteRotation = EaselMath.ToRadians(90),
                Origin = new Vector3(roadSprite.Size.Width / 2f, roadSprite.Size.Height, 0)
            });
            road.AddComponent(new Sprite(roadSprite));
            road.AddComponent(new EndlessRoad());
            AddEntity(road);
        }

        UI.DefaultStyle.Font = new Font("/home/ollie/Documents/Abel-Regular.ttf");
        //UI.Add("score", new Label(new Position(Anchor.BottomLeft), "YOUR SCORE JFKGNSDLJFGSKJDFNGJKSDJFNGKJLS", 24));
    }
}