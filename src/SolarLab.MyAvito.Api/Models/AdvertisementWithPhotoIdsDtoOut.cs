using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace SolarLab.MyAvito.Api.Models
{
    public class AdvertisementWithPhotoIdsDtoOut
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid UserId { get; set; }

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
        /// Время создания.
        /// </summary>
        public DateTime CreateAt { get; set; }

        /// <summary>
        /// Идентификаторы фотографий.
        /// </summary>
        public List<Guid> PhotosId { get; set; }
    }
}
