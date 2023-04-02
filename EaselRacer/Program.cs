using Easel;
using Easel.Core;
using EaselRacer.GameModes;

Logger.UseConsoleLogs();

GameSettings settings = new GameSettings();

using EaselGame game = new EaselGame(settings, new EndlessMode());
game.Run();