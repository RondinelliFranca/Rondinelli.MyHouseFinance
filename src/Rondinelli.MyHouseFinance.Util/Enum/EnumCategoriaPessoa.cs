using System.Collections.Generic;
using System.Linq;

namespace Rondinelli.MyHouseFinance.Util.Enum
{
    public class EnumCategoriaPessoa
    {
        public static EnumCategoriaPessoa ESPOSA = new EnumCategoriaPessoa("Esposa", "Nathália");
        public static EnumCategoriaPessoa MAE = new EnumCategoriaPessoa("Mãe", "Clarice");
        public static EnumCategoriaPessoa PAi = new EnumCategoriaPessoa("Pai", "Ronildo");
        public static EnumCategoriaPessoa IRMA = new EnumCategoriaPessoa("Irmã", "Rafaela");
        public static EnumCategoriaPessoa AMIGOS = new EnumCategoriaPessoa("Amigos", "Brothers");
        public static EnumCategoriaPessoa TRABALHO = new EnumCategoriaPessoa("Trabalho", "Colegas");
        public static EnumCategoriaPessoa SOGRA = new EnumCategoriaPessoa("Sogra", "Claudia");
        public static EnumCategoriaPessoa SOGRO = new EnumCategoriaPessoa("Sogro", "Zé");
        public static EnumCategoriaPessoa PARENTES = new EnumCategoriaPessoa("Parentes", "Parentes");
        public static EnumCategoriaPessoa VO = new EnumCategoriaPessoa("Antônia", "Vo");
        public static EnumCategoriaPessoa EU = new EnumCategoriaPessoa("Rondinelli", "Eu");



        public string Value { get; set; }
        public string Description { get; set; }

        private EnumCategoriaPessoa(string value, string description)
        {
            Value = value;
            Description = description;
        }

        public static List<EnumCategoriaPessoa> GetList()
        {
            var list = new List<EnumCategoriaPessoa>
            {
                ESPOSA,
                MAE,
                PAi,
                IRMA,
                AMIGOS,
                TRABALHO,
                SOGRA,
                SOGRO,
                PARENTES,
                VO, 
                EU

            };
            return list;
        }

        public static string GetNameByValue(string value)
        {
            var description = GetList().FirstOrDefault(p => p.Value == value);
            if (description != null)
            {
                return description.Description;
            }
            return null;
        }

        public static EnumCategoriaPessoa GetByValue(string value)
        {
            var enumValue = GetList().FirstOrDefault(p => p.Value == value);
            return enumValue;
        }

        public bool Equals(string value)
        {
            if (this.Value == value)
            {
                return true;
            }
            return false;
        }
    }
}