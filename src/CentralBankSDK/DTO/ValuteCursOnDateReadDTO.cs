namespace CetralBankSDK.DTO
{
    /// <summary>
    /// Информация о курсе валюты в заданную дату.
    /// </summary>
    public record ValuteCursOnDateReadDTO
    {
        /// <summary>
        /// Название валюты.
        /// </summary>
        public string Vname { get; init; } = default!;

        /// <summary>
        /// Курс.
        /// </summary>
        public decimal Vcurs { get; init; } = default!;

        /// <summary>
        /// ISO Цифровой код валюты.
        /// </summary>
        public string Vcode { get; init; } = default!;
    }
}
