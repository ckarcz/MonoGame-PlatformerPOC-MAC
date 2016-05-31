using System.Linq;
using PlatformerPOC.Messages;
using Prism.Events;

namespace PlatformerPOC.Events
{
	public class PowerupPickedUpHandler
	{
		private readonly PlatformGame _game;

		public PowerupPickedUpHandler (PlatformGame game)
		{
			_game = game;

			_game.EventAggregator.GetEvent<PowerupPickedUpMessage> ().Subscribe (Handle);
		}

		public void Handle (PowerupPickedUpMessage message)
		{
			_game.gameWorld.Powerups = _game.gameWorld.Powerups.Where (c => c.Id != message.PowerUpObjectId).ToList ();
		}
	}
}