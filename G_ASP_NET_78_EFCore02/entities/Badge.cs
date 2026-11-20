namespace G_ASP_NET_78_EFCore02.entities;

public class Badge
{
    public int Id { get; set; }

    public string BadgeNumber { get; set; }

    public DateTime IssuedDate { get; set; }

    public BadgeTier Tier { get; set; }

    public int AttendeeId { get; set; }

   

    public Attendee Attendee { get; set; }
}
