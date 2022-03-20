namespace Model
{
    /// <summary>
    /// Класс "Индуктивность".
    /// </summary>
    public class Inductor : Calc
    {
        public override string Name()
        {
            return "Индуктивность";
        }


        /// <summary>
        /// Расчёт комплексного сопротивления.
        /// </summary>
        /// <returns>Расчёт комплексного сопротивления.</returns>
        public override string Get()
        {
            // Расчёт комплексного сопротивления [j * ω * L] и возвращение результата.
            // ω = U, L = I.
            return ((U * I).ToString() + 'j');
        }
    }
}
