using System;

namespace SmartSchool.API.V1.Dtos
{
    /// <summary>
    /// DTO de registro de Aluno
    /// </summary>
    public class AlunoRegistrarDto
    {
        /// <summary>
        /// Identificador e chave do banco de dados
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Primeiro nome do aluno
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Sobrenome do aluno
        /// </summary>
        public string Sobrenome { get; set; }
        /// <summary>
        /// Código de indetificação do aluno na instituição
        /// </summary>
        public int Matricula { get; set; }
        /// <summary>
        /// Telefone do aluno
        /// </summary>
        public string Telefone { get; set; }
        /// <summary>
        /// Data de nascimento do aluno
        /// </summary>
        public DateTime DataNascimento { get; set; }
        /// <summary>
        /// Data em que o aluno ingressou na instituição
        /// </summary>
        public DateTime DataInicio { get; set; } = DateTime.Now;
        /// <summary>
        /// Data em que o aluno saiu da instituição
        /// </summary>
        public DateTime? DataFim { get; set; } = null;
        /// <summary>
        /// Indica se o aluno está ativo
        /// </summary>
        public bool Ativo { get; set; } = true;
    }
}
