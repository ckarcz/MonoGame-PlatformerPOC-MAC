using System.Linq;
using Microsoft.Xna.Framework;
using PlatformerPOC.Messages;
using Prism.Events;

namespace PlatformerPOC.Events
{
	public class SpawnPlayersHandler
	{
		private readonly PlatformGame _game;

		public SpawnPlayersHandler (PlatformGame game)
		{
			_game = game;

			_game.EventAggregator.GetEvent<SpawnPlayersMessage> ().Subscribe (Handle);
		}

		public void Handle (SpawnPlayersMessage message)
		{
			for (int playerIndex = 0; playerIndex < _game.gameWorld.Players.Count; playerIndex++)
			{
				var player = _game.gameWorld.Players [playerIndex];
				player.Spawn (GetSpawnPointForPlayerIndex (playerIndex + 1));
			}
		}

		private Vector2 GetSpawnPointForPlayerIndex (int i)
		{
			return _game.gameWorld.spawnPointPositions.ElementAtOrDefault (i - 1);
		}
	}
}