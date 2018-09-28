using System.Collections.Generic;
using System.Linq;

namespace Rondinelli.MyHouseFinance.Util.Enum
{
    public class EnumMensagem
    {
        public static EnumMensagem SEM_PERMISSAO = new EnumMensagem("Sem Permissão", "O seu usuário não possui permissão para acessar este recurso.");
        public static EnumMensagem SALVO = new EnumMensagem("Salvo", "O registro foi salvo com sucesso.");
        public static EnumMensagem EDITADO = new EnumMensagem("Editado", "O registro foi editado com sucesso.");
        public static EnumMensagem NOT_FOUND = new EnumMensagem("NotFound", "Item não encontrado.");
        public static EnumMensagem DESATIVADO = new EnumMensagem("Desativado", "O registro foi desativado com sucesso.");
        public static EnumMensagem NAO_SALVO = new EnumMensagem("Não Salvo", "O registro não foi salvo.");
        public static EnumMensagem DELETADO = new EnumMensagem("Excluído", "O registro foi excluído com sucesso.");
        public static EnumMensagem ERRO_EXCLUIR_REGISTRO = new EnumMensagem("Erro ao Excluir Registro", "Não é possível excluir registro, pois há dependências com outros registros.");
        public static EnumMensagem PERMISSAO_ALTERADA = new EnumMensagem("Permissão Alterar", "A permissão foi alterada com sucesso.");
        public static EnumMensagem GRUPO_SALVO = new EnumMensagem("Grupo Salvo", "O grupo foi salvo com sucesso.");
        public static EnumMensagem GRUPO_EXCLUIDO = new EnumMensagem("Grupo Excluido", "O grupo foi excluído com sucesso.");
        public static EnumMensagem USUARIO_GRUPO_SALVO = new EnumMensagem("Usuário Salvo", "O usuário foi adicionado ao grupo com sucesso.");
        public static EnumMensagem USUARIO_GRUPO_EXCLUIDO = new EnumMensagem("Usuário Excluido", "O usuário foi excluído do grupo com sucesso.");
        public static EnumMensagem USUARIOS_ATUALIZADOS = new EnumMensagem("Usuários Atualizados", "O(s) usuário(s) foram atualizado(s) com sucesso.");

        public string Value { get; set; }
        public string Description { get; set; }

        private EnumMensagem(string value, string description)
        {
            Value = value;
            Description = description;
        }

        public static List<EnumMensagem> GetList()
        {
            var list = new List<EnumMensagem>
            {
                SEM_PERMISSAO,
                SALVO,
                EDITADO,
                NOT_FOUND,
                DESATIVADO,
                NAO_SALVO,
                DELETADO,
                ERRO_EXCLUIR_REGISTRO,
                PERMISSAO_ALTERADA,
                GRUPO_SALVO,
                GRUPO_EXCLUIDO,
                USUARIO_GRUPO_SALVO,
                USUARIO_GRUPO_EXCLUIDO,
                USUARIOS_ATUALIZADOS

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

        public static EnumMensagem GetByValue(string value)
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