using System.Collections.Generic;

namespace SolarLab.MyAvito.Api.Models
{
    public class PagedAdvertisementsWithPhotoIdsByUserDtoOut
    {
        public List<AdvertisementWithPhotoIdsDtoOut> Advertisements { get; set; }

        public int MaxPage { get; set; }
    }
}
