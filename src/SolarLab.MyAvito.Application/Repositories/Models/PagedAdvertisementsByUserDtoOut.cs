using System.Collections.Generic;
using SolarLab.MyAvito.Domain;

namespace SolarLab.MyAvito.Application.Repositories.Models
{
    public class PagedAdvertisementsByUserDtoOut
    {
        public List<Advertisement> Advertisements { get; set; }
        public int MaxPage { get; set; }
    }
}
