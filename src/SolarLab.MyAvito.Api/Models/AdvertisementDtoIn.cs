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

        /// <summary>
        /// Цена товара.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Cостояние товара (новое/бу).
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// Описание товара.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Фотографии товара.
        /// </summary>
        public List<IFormFile> Photos { get; set; }
    }
}
