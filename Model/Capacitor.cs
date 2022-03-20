namespace Model
{
    /// <summary>
    /// Класс "Конденсатор".
    /// </summary>
    public class Capacitor : Calc
    {
        
        public override string Name()
        {
            return "Конденсатор";
        }


        /// <summary>
        /// Расчёт комплексного сопротивления.
        /// </summary>
        /// <returns>Расчёт комплексного сопротивления.</returns>
        public override string Get()
        {
            // Расчёт комплексного сопротивления [-j * 1 / (ω * С)] и возвращение результата.
            // ω = U, I = C.
            return ((-1 / (U * I)).ToString() + 'j');
        }
    }
}
