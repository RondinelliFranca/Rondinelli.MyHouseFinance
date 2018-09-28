using System.Collections.Generic;
using System.Linq;

namespace Rondinelli.MyHouseFinance.Util.Enum
{
    public class EnumTipoPagamento
    {
        public static EnumTipoPagamento CREDITO = new EnumTipoPagamento("Crédito", "Crédito");
        public static EnumTipoPagamento DEBITO  = new EnumTipoPagamento("Débito", "Debito Rondinelli");
        public static EnumTipoPagamento DIN_NATHY = new EnumTipoPagamento("Dinheiro_Nathalia", "Dinheiro Nathalia");
   



        public string Value { get; set; }
        public string Description { get; set; }

        private EnumTipoPagamento(string value, string description)
        {
            Value = value;
            Description = description;
        }

        public static List<EnumTipoPagamento> GetList()
        {
            var list = new List<EnumTipoPagamento>
            {
                CREDITO,
                DEBITO,
                DIN_NATHY
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

        public static EnumTipoPagamento GetByValue(string value)
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