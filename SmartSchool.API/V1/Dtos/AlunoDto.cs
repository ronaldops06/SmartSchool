using System;

namespace SmartSchool.API.V1.Dtos
{
    /// <summary>
    /// DTO de retorno de Aluno
    /// </summary>
    public class AlunoDto
    {
        /// <summary>
        /// Identificador e chave do banco de dados
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome é o primeiro nome e o sobrenome do aluno
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Código de indetificação do aluno na instituição
        /// </summary>
        public int Matricula { get; set; }
        /// <summary>
        /// Telefone do aluno
        /// </summary>
        public string Telefone { get; set; }
        /// <summary>
        /// Idade do aluno
        /// </summary>
        public int Idade { get; set; }
        /// <summary>
        /// Data em que o aluno ingressou na instituição
        /// </summary>
        public DateTime DataInicio { get; set; }
        /// <summary>
        /// Indica se o aluno está ativo
        /// </summary>
        public bool Ativo { get; set; } = true;
    }
}
