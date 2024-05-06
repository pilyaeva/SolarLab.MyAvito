using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace SolarLab.MyAvito.Api.Models
{
    public class AdvertisementDtoIn
    {
        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Title { get; set; }

        public decimal Price { get; set; }

        /// <summary>
        /// Cостояние товара (новое/бу).
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// Описание товара.
        /// </summary>
        public string Description { get; set; }

        public List<IFormFile> Photos { get; set; }
    }
}
