using System;
using System.Xml.Serialization;


namespace Model
{
    /// <summary>
    /// Абстрактный класс "Расчёт комплексного сопротивления элемента".
    /// </summary>
    [XmlInclude(typeof(Resistor)), XmlInclude(typeof(Capacitor)), XmlInclude(typeof(Inductor))]
    public abstract class Calc
    {
        private double _U;
        private double _I; 


        public double U
        {
            set
            {
                // Если значение меньше либо равно нулю, то создаём исключение.
                if (value <= 0)
                    throw new ArgumentException(String.Format("{0} не может быть меньшей или равной нулю,", 
                        U), "U");

                _U = value;
            }

            get
            {
                return _U;
            }
        }


        public double I
        {
            set
            {
                // Если значение меньше либо равно нулю, то создаём исключение.
                if (value <= 0)
                    throw new ArgumentException(String.Format("{0} не может быть меньшей или равной нулю,",
                        I), "I");

                _I = value;
            }

            get
            {
                return _I;
            }
        }

        /// <summary>
        /// Название класса.
        /// </summary>
        /// <returns>Название класса</returns>
        public abstract string Name();


        /// <summary>
        /// Расчёт комплексного сопротивления.
        /// </summary>
        public abstract string Get();
    }
}
