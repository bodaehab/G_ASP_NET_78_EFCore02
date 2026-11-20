using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace G_ASP_NET_78_EFCore02.entities;


public class Organizer
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(150)]
    public string? CompanyName { get; set; }

    public bool IsVerified { get; set; }

   

    public OrganizerProfile? Profile { get; set; }

    public ICollection<Event> Events { get; set; }
        = new List<Event>();


}
