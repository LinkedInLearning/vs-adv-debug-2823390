namespace DebugWpf
{
	internal class TicketGenerator
	{
		public static decimal CalculateTicketPrice(int ticketCount, decimal ticketPrice, decimal discountRate)
		{
			return (ticketCount * ticketPrice) * discountRate;
		}

		public static decimal GetDiscountRate(DiscountType discountType)
		{
			switch (discountType)
			{
				case DiscountType.Group:
					return .9M;
					break;

				case DiscountType.Employee:
					return .6M;
					break;

				case DiscountType.TravelAgent:
					return .8M;
					break;

				default:
					return 1M;
					break;
			}
		}

		public static int GetTicketCount()
		{
			return 25000;
		}

		public static int GetTicketCount(bool isLocal)
		{
			if (isLocal)
			{
				return 1500;
			}
			else
			{
				return 25000;
			}
		}

		public static int GetTicketCount(string eventName)
		{
			if (eventName == "Build Conference")
			{
				return 40000;
			}
			else
			{
				return 20000;
			}
		}
	}

	public enum DiscountType
	{
		Group,
		Employee,
		TravelAgent
	}
}