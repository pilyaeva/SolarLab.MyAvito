using System;

namespace SolarLab.MyAvito.Domain
{
    public class File
    {
        /// <summary>
        /// Идентификатор файла.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор объявления, в котором находится файл.
        /// </summary>
        public Guid AdvertisementId { get; set; }

        /// <summary>
        /// Имя файла.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Сам файл.
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Разрешение файла (image/jpeg);
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Длина файла.
        /// </summary>
        public long Length { get; set; }

    }
}
