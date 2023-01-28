using Easel;
using EaselRacer.GameModes;

GameSettings settings = new GameSettings();

using EaselGame game = new EaselGame(settings, new EndlessMode());
game.Run();