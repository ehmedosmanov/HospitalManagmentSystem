using System.Collections.Generic;

namespace HospitalFinalProject.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RoomAllotment> Rooms { get; set; }

    }
}
