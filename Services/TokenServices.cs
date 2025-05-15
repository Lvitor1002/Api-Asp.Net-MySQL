using System.Text;
using WebApplicationMYSQL.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;


namespace WebApplicationMYSQL.Services
{
    public class TokenServices
    {
        public static object GerarToken(Colaborador colaborador)
        {
            // Cria um array de bytes a partir da chave secreta definida em Key.Chave, usando codificação ASCII
            var key = Encoding.ASCII.GetBytes(Key.Chave);

            // Define as configurações do token JWT, incluindo claims, tempo de expiração e credenciais de assinatura
            var configuracaoToken = new SecurityTokenDescriptor
            {
                // Adiciona uma claim chamada "funcionarioId" com o ID do funcionário (convertido para string)
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] { new Claim("colaborador_Id", colaborador.Id.ToString()) }),

                // Define a data de expiração do token para 2 horas a partir de agora (horário UTC)
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

            };

            // Cria um manipulador para gerar e ler tokens JWT
            var manipuladorToken = new JwtSecurityTokenHandler();

            // Gera o token JWT com base nas configurações definidas
            var token = manipuladorToken.CreateToken(configuracaoToken);

            // Converte o token gerado em uma string no formato JWT
            var tokenString = manipuladorToken.WriteToken(token);

            // Retorna um objeto anônimo com o token em string
            return new {token = tokenString};
        }
    }
}
