﻿using Dominio.SalesForceApp.Entidade;

namespace Dominio.SalesForceApp.Contratos
{
    public interface IRepositorioPessoa_Teste: IRepositorio<Pessoa_Teste>
    {
        void Incluir();
        void Atualizar();
        

    }
}
