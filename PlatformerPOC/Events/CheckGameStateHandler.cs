using System.Linq;
using PlatformerPOC.Messages;
using Prism.Events;

namespace PlatformerPOC.Events
{
	public class CheckGameStateHandler
	{
		private readonly PlatformGame _game;

		public CheckGameStateHandler (PlatformGame game)
		{
			_game = game;

			_game.EventAggregator.GetEvent<CheckGameStateMessage> ().Subscribe (Handle);
		}

		public void Handle (CheckGameStateMessage message)
		{
			switch (_game.gameWorld.AlivePlayers.Count ())
			{
				case 0:
					_game.EventAggregator.GetEvent<SpawnPlayersMessage> ().Publish (new SpawnPlayersMessage ());
					_game.RoundCounter++;
					break;
				case 1:
                    // Only 1 player? Don't do the checks.
					if (_game.gameWorld.Players.Count () == 1) return;

					var winner = _game.gameWorld.AlivePlayers.Single ();
					winner.Score.MarkWin ();
					_game.EventAggregator.GetEvent<SpawnPlayersMessage> ().Publish (new SpawnPlayersMessage ());

					_game.RoundCounter++;

					break;
				default:
                    // continue game
					break;
			}
		}
	}
}