namespace DemoConnector.TwinfieldAPI.Data
{
	public class Session
	{
		public string SessionId { get; set; }
		public string ClusterUrl { get; set; }
		public string Office { get; set; }

		public bool LoggedOn
		{
			get { return SessionId != null; }
		}

		public void Clear()
		{
			SessionId = null;
			ClusterUrl = null;
			Office = null;
		}
	}
}