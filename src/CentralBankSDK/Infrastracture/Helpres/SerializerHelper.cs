namespace CetralBankSDK.Infrastracture.Helpres
{
    /// <summary>
    /// Helper для сериализации и десериализации.
    /// </summary>
    public class SerializerHelper
    {
        /// <summary>
        /// Десериализует XML строку в объект.
        /// </summary>
        /// <typeparam name="T">Тип объекта десериализации.</typeparam>
        /// <param name="xmlString">Строковое представление XML.</param>
        public static T DeserializeObj<T>(string xmlString) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(xmlString))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
