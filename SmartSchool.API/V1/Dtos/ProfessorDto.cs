using System;

namespace SmartSchool.API.V1.Dtos
{
    /// <summary>
    /// DTO de retorno de Professor
    /// </summary>
    public class ProfessorDto
    {
        /// <summary>
        /// Identificador e chave do banco de dados
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome é o primeiro nome e o sobrenome do professor
        /// </summary>
        public string Nome { get; set; }
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
        public DateTime DataInicio { get; set; }
        /// <summary>
        /// Indica se o professor está ativo
        /// </summary>
        public bool Ativo { get; set; } = true;
    }
}
