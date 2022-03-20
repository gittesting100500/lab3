namespace Model
{
    /// <summary>
    /// Класс "Резистор".
    /// </summary>
    public class Resistor : Calc
    {
        public override string Name()
        {
            return "Резистор";
        }


        /// <summary>
        /// Расчёт комплексного сопротивления.
        /// </summary>
        /// <returns>Расчёт комплексного сопротивления</returns>
        public override string Get()
        {
            // Расчёт комплексного сопротивления и возвращение результата.
            return (U / I).ToString();
        }
    }
}
