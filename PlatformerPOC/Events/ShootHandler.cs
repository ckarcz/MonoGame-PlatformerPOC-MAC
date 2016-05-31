using PlatformerPOC.Domain;
using PlatformerPOC.Messages;
using Prism.Events;

namespace PlatformerPOC.Events
{
	public class ShootHandler
	{
		private readonly PlatformGame _game;

		public ShootHandler (PlatformGame game)
		{
			_game = game;

			_game.EventAggregator.GetEvent<ShootMessage> ().Subscribe (Handle);
		}

		public void Handle (ShootMessage message)
		{
			var bullet = new Projectile (_game, message.ShooterName, message.ShotPosition, message.HorizontalDirection);
			_game.gameWorld.Bullets.Add (bullet);
			_game.PlaySound (_game.GameDataLoader.ShotSound);
		}
	}
}