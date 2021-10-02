using System;

namespace SmartSchool.API.V1.Dtos
{
    /// <summary>
    /// DTO de registro de Professor
    /// </summary>
    public class ProfessorRegistrarDto
    {
        /// <summary>
        /// Identificador e chave do banco de dados
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Primeiro nome do professor
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Sobrenome do professor
        /// </summary>
        public string Sobrenome { get; set; }
        /// <summary>
        /// Código de indetificação do professor na instituição
        /// </summary>
        public int Registro { get; set; }
        /// <summary>
        /// Telefone do professor
        /// </summary>
        public string Telefone { get; set; }
        /// <summary>
        /// Data em que o professor ingressou na instituição
        /// </summary>
        public DateTime DataInicio { get; set; } = DateTime.Now;
        /// <summary>
        /// Data em que o professor saiu da instituição
        /// </summary>
        public DateTime? DataFim { get; set; } = null;
        /// <summary>
        /// Indica se o professor está ativo
        /// </summary>
        public bool Ativo { get; set; } = true;
    }
}
