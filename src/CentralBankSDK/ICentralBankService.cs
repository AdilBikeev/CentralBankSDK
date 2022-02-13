namespace CetralBankSDK
{
    /// <summary>
    /// Интерфейс описывающий SDK CentralBankService.
    /// </summary>
    public interface ICentralBankService
    {
        /// <summary>
        /// Возвращает список валют.
        /// </summary>
        /// <param name="seld">
        /// True - перечень ежемесячных валют
        /// False — перечень ежедневных валют
        /// </param>
        Task<IEnumerable<EnumValutes>> GetEnumValutes(bool seld = false);
    }
}