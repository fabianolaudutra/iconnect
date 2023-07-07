using Dapper;
using Iconnect.Aplicacao.Dtos;
using Iconnect.Aplicacao.Interfaces.Queries;
using Iconnect.Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Iconnect.Aplicacao.Queries
{
    public class MonitoramentoControleAcessoQuerie : IMonitoramentoControleAcessoQuerie
    {
        private readonly IconnectCoreContext _context;

        public MonitoramentoControleAcessoQuerie(IconnectCoreContext context)
        {
            _context = context;
        }

        public MonitoramentoControleAcessoDto GetAcessoAtualizacaoGrid(int clienteId)
        {
            const string sql = @"SELECT TOP 1
                con.con_n_codigo, con.con_cli_n_codigo, con.con_usu_n_codigo, UPPER(con.con_c_cardNumber) 
                    as con_c_cardNumber,
                UPPER(con.con_c_pontoAcesso) as con_c_pontoAcesso,
                UPPER(con.con_c_status) as con_c_status, con.cin_c_tipoEventoMotivo, 
                CONVERT(varchar, con.con_b_panico) as con_b_panico,
                CONVERT(varchar, con.con_b_panicoTratado) as con_b_panicoTratado, 
                CONVERT(varchar, con.con_b_tipoPanico) as con_b_tipoPanico,
                CONVERT(varchar, con.con_c_obsTratamentoPanico) as con_c_obsTratamentoPanico, 
                UPPER(cli.cli_c_nomeFantasia) as cli_c_nomeFantasia,
                CONCAT(CONVERT(varchar, con.con_d_evento, 103), ' ', CONVERT(varchar, con.con_d_evento, 8)) 
                    as con_d_evento,
                IIF(con.con_fot_n_codigo is null, '0', CONVERT(varchar, con.con_fot_n_codigo)) as con_fot_n_codigo,
                IIF(con.con_c_usuario is null, 'NÃO IDENTIFICADO', UPPER(con.con_c_usuario)) as con_c_usuario,
                IIF(con.con_c_tipoAcesso is null or con.con_c_tipoAcesso like '', 'NI', UPPER(con.con_c_tipoAcesso)) 
                    as con_c_tipoAcesso,
                CASE
                    WHEN con.con_c_tipoPessoa is null or con.con_c_tipoPessoa like '' THEN 'NÃO IDENTIFICADO'
                    WHEN UPPER(con.con_c_tipoPessoa) like 'MORADOR' and cli.cli_tcl_n_codigo = 2 then 'FUNCIONÁRIO'
                    ELSE UPPER(con.con_c_tipoPessoa) END as con_c_tipoPessoa,
                CASE
                    WHEN UPPER(con.con_c_tipoPessoa) like 'MORADOR' THEN REPLACE(mor.mor_c_celular, ' ', '')
                    WHEN UPPER(con.con_c_tipoPessoa) like 'VISITANTE' THEN REPLACE(vis.vis_c_celular, ' ', '')
                    WHEN UPPER(con.con_c_tipoPessoa) like 'PRESTADOR' THEN REPLACE(pse.pse_c_celular, ' ', '')
                    ELSE '' END AS con_c_telefone
                FROM tb_con_monitoramentoControleAcesso con
                INNER JOIN tb_cli_cliente cli on con.con_cli_n_codigo = cli.cli_n_codigo
                LEFT JOIN tb_mor_morador mor on con.con_usu_n_codigo = mor.mor_n_codigo
                LEFT JOIN tb_vis_visitante vis on con.con_usu_n_codigo = vis.vis_n_codigo
                LEFT JOIN tb_pse_prestadorServico pse on con.con_usu_n_codigo = pse.pse_n_codigo
                WHERE con.con_cli_n_codigo = @clienteid
                ORDER BY con.con_n_codigo DESC;";

            var acesso = _context.Database.GetDbConnection()
                .Query<MonitoramentoControleAcessoDto>(sql, new { clienteId });

            return acesso.FirstOrDefault();
        }
    }
}