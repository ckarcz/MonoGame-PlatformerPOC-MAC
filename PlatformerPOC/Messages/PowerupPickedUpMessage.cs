namespace PlatformerPOC.Messages
{
	public class PowerupPickedUpMessage : Prism.Events.PubSubEvent<PowerupPickedUpMessage>
	{
		public int PowerUpObjectId { get; set; }

		public string PlayerName { get; set; }

		public PowerupPickedUpMessage ()
		{
			
		}


		public PowerupPickedUpMessage (int powerUpObjectId, string playerName)
		{
			PowerUpObjectId = powerUpObjectId;
			PlayerName = playerName;
		}
	}
}