using System;

namespace SolarLab.MyAvito.Domain
{
    public class Advertisement
    {
        /// <summary>
        /// Идентификатор объявления.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя, к которому принадлежит объявление.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Цена товара из объявления.
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
    }
}
